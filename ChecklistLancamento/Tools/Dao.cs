using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using NPOI.HSSF.UserModel; // Para .xls
using NPOI.SS.UserModel;

namespace Tools
{
    public class Dao
    {
        public List<AtividadeV> LoadReg(string Source)
        {
            string caminhoArquivo = Source; // Altere para o caminho do seu arquivo

            if (Path.GetExtension(caminhoArquivo).ToLower() == ".csv")
            {
                return LerCSV(caminhoArquivo);
            }
            else
            {
                return LerExcel(caminhoArquivo);
            }

        }

        static List<AtividadeV> LerExcel(string caminhoArquivo)
        {
            List<AtividadeV> lista = new List<AtividadeV>();

            using (FileStream file = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
            {
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheetAt(0);

                int rowCount = sheet.LastRowNum;

                for (int row = 11; row <= rowCount; row++) // Começa da linha 12 (índice 11)
                {
                    IRow currentRow = sheet.GetRow(row);
                    if (currentRow == null) continue;

                    string GetCellValue(int index) => currentRow.GetCell(index)?.ToString() ?? "";

                    var atividade = new AtividadeV
                    {
                        Localidade = GetCellValue(0),
                        Livro = GetCellValue(2),
                        Voluntario = GetCellValue(7),
                        CPF = GetCellValue(8),
                        DataNascimento = GetCellValue(9),
                        Funcao = GetCellValue(11),
                        Data = GetCellValue(12),
                        Inicio = GetCellValue(14),
                        Fim = GetCellValue(17),
                        Horas = GetCellValue(18),
                        HorasDesc = GetCellValue(19),
                        Valor = GetCellValue(20)
                    };

                    if (!string.IsNullOrWhiteSpace(atividade.Localidade) ||
                        !string.IsNullOrWhiteSpace(atividade.Livro) ||
                        !string.IsNullOrWhiteSpace(atividade.Voluntario))
                    {
                        lista.Add(atividade);
                    }
                }
            }

            lista.Sort();
            return lista;
        }

        static List<AtividadeV> LerCSV(string caminhoArquivo)
        {
            List<AtividadeV> lista = new List<AtividadeV>();

            using (var reader = new StreamReader(caminhoArquivo))
            {
                string linha;
                int cabecalho = 0;

                

                while ((linha = reader.ReadLine()) != null & !reader.EndOfStream)
                {
                    if (cabecalho < 12)
                    {
                        ++cabecalho;
                        continue;
                    }

                    string[] camposbrutos = linha.Split(new char[] { ',', ';' }, StringSplitOptions.None);
                    string[] campos = camposbrutos.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                    if(campos.Length > 0)
                    {
                        var atividade = new AtividadeV
                        {
                            Localidade = campos[0].Trim(),
                            Livro = campos[1].Trim(),
                            Voluntario = campos[2].Trim(),
                            CPF = campos[3].Trim(),
                            DataNascimento = campos[4].Trim(),
                            Funcao = campos[5].Trim(),
                            Data = campos[6].Trim(),
                            Inicio = campos[7].Trim(),
                            Fim = campos[8].Trim(),
                            Horas = campos[9].Trim(),
                            HorasDesc = campos[10].Trim(),
                            Valor = campos[11].Trim()
                        };

                        // Adiciona apenas se houver pelo menos um campo preenchido
                        if (!string.IsNullOrWhiteSpace(atividade.Localidade) ||
                            !string.IsNullOrWhiteSpace(atividade.Livro) ||
                            !string.IsNullOrWhiteSpace(atividade.Voluntario))
                        {
                            lista.Add(atividade);
                        }
                    }
                    
                }
            }
            lista.Sort();
            return lista;
        }
    }
}
