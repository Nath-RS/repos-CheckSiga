using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Tools;

namespace ChecklistLancamento
{
    public partial class FrmMain : Form
    {

        string Source;
        List<string> localidades = new List<string>();
        List<AtividadeV> list = new List<AtividadeV>();
        RegraNegocio regra = new Tools.RegraNegocio();
        List<Relatorio> relatList = new List<Relatorio>();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void AplicarTemaDoWindows()
        {
            bool temaClaro = DetectarTemaClaro();

            if (temaClaro)
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.FromArgb(30, 30, 30);
                this.ForeColor = Color.White;
            }

            foreach (Control ctrl in this.Controls)
            {
                ctrl.ForeColor = this.ForeColor;
                ctrl.BackColor = this.BackColor;
            }
            btnImport.BackColor = Color.Blue;
            btnGerarelatorio.BackColor = Color.Red;
            btngrafico.BackColor = Color.Orange;

            if (this.Controls.ContainsKey("dgvAtividades"))
            {
                var dgv = this.Controls["dgvAtividades"] as DataGridView;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.SelectionBackColor = temaClaro ? Color.LightBlue : Color.DarkSlateBlue;
            }
        }

        private bool DetectarTemaClaro()
        {
            try
            {
                using (RegistryKey chave = Registry.CurrentUser.OpenSubKey(
                    @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
                {
                    if (chave != null)
                    {
                        object valor = chave.GetValue("AppsUseLightTheme");
                        if (valor != null && valor is int)
                        {
                            return ((int)valor) != 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Em caso de erro, assume tema claro
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AplicarTemaDoWindows();
        }

        private void NodeUserGrid()
        {
            dgvAtividades.Columns[0].Visible = true;
            dgvAtividades.Columns[1].Visible = true;
            dgvAtividades.Columns[2].Visible = true;
            dgvAtividades.Columns[3].Visible = true;
            dgvAtividades.Columns[4].Visible = true;
            dgvAtividades.Columns[5].Visible = true;
            dgvAtividades.Columns[6].Visible = true;
            dgvAtividades.Columns[7].Visible = true;
            dgvAtividades.Columns[8].Visible = true;
            dgvAtividades.Columns[9].Visible = true;
            dgvAtividades.Columns[10].Visible = true;
            dgvAtividades.Columns[11].Visible = true;

            dgvAtividades.Columns[0].ReadOnly = true;


            dgvAtividades.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.75F, FontStyle.Bold);
            dgvAtividades.ScrollBars = ScrollBars.Vertical;
            dgvAtividades.RowHeadersVisible = false;
            dgvAtividades.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAtividades.RowHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dgvAtividades.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }


        private void setRegDGV(List<AtividadeV> Ordenado)
        {
            //if (Ordenado[0].Status != "OK")
            //{
            //    MessageBox.Show(Ordenado[0].msg, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            AtividadeV auxArquivo = new AtividadeV();
            dgvAtividades.DataSource = null;
            dgvAtividades.Rows.Clear();
            dgvAtividades.Refresh();
            dgvAtividades.DataSource = Ordenado;
            //}
        }
        private void Pegarlocalidadesdistintos()
        {
            if (rbtn91.Checked)
            {
                localidades = Carregarxml("Setor91");
            }
            else if (rbtn92.Checked)
            {
                localidades = Carregarxml("Setor92");
            }
            else if (rbtn93.Checked)
            {
                localidades = Carregarxml("Setor93");
            }
            else
            {
                localidades = list.Select(a => a.Localidade).Distinct().ToList();
            }
        }

        private List<string> Carregarxml(string setorFiltro)
        {
            List<string> localidades = new List<string>();
            XElement xml;
            // Carrega o XML
            if (File.Exists(Directory.GetCurrentDirectory() + @"\configsetor.xml"))
            {
                xml = XElement.Load(Directory.GetCurrentDirectory() + @"\configsetor.xml");
            }
            else
            {
                xml = XElement.Load(@"C:\Users\Nathjan\source\repos\ChecklistLancamento\Tools\configsetor.xml");
            }


            // Busca o setor correspondente
            var setor = xml.Elements("Setor")
                           .FirstOrDefault(s => (string)s.Attribute("nome") == setorFiltro);

            Console.WriteLine($"Localidades do {setorFiltro}:");

            foreach (var localidade in setor.Elements("Localidade"))
            {
                localidades.Add(localidade.Value);
            }
            return localidades;
        }

        private void contapontamentos()
        {
            List<AtividadeV> AuxList = new List<AtividadeV>();

            foreach (string lc in localidades)
            {
                Relatorio auxrel = new Relatorio();


                auxrel.Localidade = lc;
                AuxList.AddRange(list.FindAll(x => x.Localidade == auxrel.Localidade));

                List<string> livros = AuxList.Select(a => a.Livro).Distinct().ToList();

                foreach (string lv in livros)
                {
                    Livro auxlv = new Livro();
                    auxlv.Nome = lv;
                    auxlv.apontamentos = AuxList.FindAll(y => y.Livro == lv).Count;
                    auxrel.LivrosLocalidade.Add(auxlv);
                }

                relatList.Add(auxrel);
                AuxList.Clear();
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDimport = new OpenFileDialog();

            OFDimport.Title = "Import File (.csv)";
            OFDimport.Filter = ".csv .xls |*.csv;*.xls";

            if (OFDimport.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OFDimport.FileName;
                Source = txtFile.Text;
                list = regra.ReadFile(Source);

                setRegDGV(list);
                lblTotal.Text = list.Count.ToString();
                btnGerarelatorio.Enabled = true;
                btngrafico.Enabled = true;
            }
        }



        private void btnGerarelatorio_Click(object sender, EventArgs e)
        {
            localidades.Clear();
            relatList.Clear();

            this.Pegarlocalidadesdistintos();
            this.contapontamentos();

            PrintDocument doc = new CPrintDocument("Relatório " + File.GetLastWriteTime(Source).ToString());

            doc.PrintPage += this.Doc_PrintPage;

            PrintDialog dialogo = new PrintDialog();
            dialogo.Document = doc;

            //  Se o usuário clicar em OK , imprime o documento
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                //verifica se o usuário deseja visualizar a impressao

                PrintPreviewDialog ppdlg = new PrintPreviewDialog();
                ppdlg.Document = doc;
                ppdlg.ShowDialog();

            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            CPrintDocument doc = (CPrintDocument)sender;

            float margemTopo = e.MarginBounds.Top;
            float margemEsquerda = e.MarginBounds.Left;

            using (Pen pen = new Pen(Color.Black, 1))
            using (Font fonteTitulo = new Font("Tahoma", 12, FontStyle.Bold))
            using (Font fonteCabecalho = new Font("Tahoma", 10, FontStyle.Bold))
            using (Font fonteNormal = new Font("Tahoma", 10))
            {
                Brush brushNormal = Brushes.Black;
                Brush brushZero = Brushes.Red;

                // Pega o relatório atual baseado no offset
                Relatorio relat = relatList[doc.Offset];

                // --- CABEÇALHO DO RELATÓRIO ---
                string header = doc.Header;
                SizeF tamanhoHeader = e.Graphics.MeasureString(header, fonteTitulo);
                float xHeader = margemEsquerda + (e.MarginBounds.Width - tamanhoHeader.Width) / 2;
                e.Graphics.DrawString(header, fonteTitulo, brushNormal, new PointF(xHeader, 30));

                // --- TABELA ---
                float alturaLinha = 25f;
                float xTabela = margemEsquerda;
                float yTabela = margemTopo + 40;
                float larguraCol1 = (e.MarginBounds.Width / 3) * 2;
                float larguraCol2 = (e.MarginBounds.Width / 3) * 1;

                e.Graphics.DrawRectangle(pen, xTabela, yTabela, larguraCol1 + larguraCol2, alturaLinha);
                e.Graphics.DrawString(relat.Localidade, fonteCabecalho, brushNormal, xTabela + 5, yTabela + 5);
                yTabela += alturaLinha;

                e.Graphics.DrawRectangle(pen, xTabela, yTabela, larguraCol1, alturaLinha);
                e.Graphics.DrawRectangle(pen, xTabela + larguraCol1, yTabela, larguraCol2, alturaLinha);
                e.Graphics.DrawString("Livro", fonteCabecalho, brushNormal, xTabela + 5, yTabela + 5);
                e.Graphics.DrawString("Total Lançados", fonteCabecalho, brushNormal, xTabela + larguraCol1 + 5, yTabela + 5);

                float yLinha = yTabela + alturaLinha;

                foreach (Livro lv in relat.LivrosLocalidade)
                {
                    Brush corTexto = lv.apontamentos == 0 ? brushZero : brushNormal;
                    e.Graphics.DrawRectangle(pen, xTabela, yLinha, larguraCol1, alturaLinha);
                    e.Graphics.DrawRectangle(pen, xTabela + larguraCol1, yLinha, larguraCol2, alturaLinha);

                    e.Graphics.DrawString(lv.Nome, fonteNormal, corTexto, xTabela + 5, yLinha + 5);
                    e.Graphics.DrawString(lv.apontamentos.ToString(), fonteNormal, corTexto, xTabela + larguraCol1 + 5, yLinha + 5);

                    yLinha += alturaLinha;
                }

                // --- OBSERVAÇÕES ---
                int linhasObs = 23;
                float alturaLinhaObs = 25f;
                float larguraQuadro = e.MarginBounds.Width;
                float alturaQuadro = (linhasObs + 1) * alturaLinhaObs;
                float yQuadro = e.MarginBounds.Bottom - alturaQuadro - 20;

                RectangleF rect = new RectangleF(margemEsquerda, yQuadro, larguraQuadro, alturaQuadro);
                e.Graphics.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

                using (Font tituloFont = new Font("Tahoma", 10, FontStyle.Bold))
                {
                    string titulo = "OBSERVAÇÕES";
                    SizeF tamanhoTexto = e.Graphics.MeasureString(titulo, tituloFont);
                    float xTextoObs = margemEsquerda + (larguraQuadro - tamanhoTexto.Width) / 2;
                    e.Graphics.DrawString(titulo, tituloFont, brushNormal, xTextoObs, yQuadro + 3);
                }

                for (int i = 1; i <= linhasObs; i++)
                {
                    float yLinhaObs = yQuadro + i * alturaLinhaObs;
                    e.Graphics.DrawLine(pen, margemEsquerda, yLinhaObs, margemEsquerda + larguraQuadro, yLinhaObs);
                }

                doc.NumeroPagina++;

                // Verifica se há mais relatórios
                doc.Offset++;
                if (doc.Offset < relatList.Count)
                {
                    e.HasMorePages = true;
                }
                else
                {
                    doc.Offset = 0; // Reinicia para futura impressão
                    e.HasMorePages = false;
                }
            }
        }

        private void btngrafico_Click(object sender, EventArgs e)
        {
            localidades.Clear();
            relatList.Clear();

            this.Pegarlocalidadesdistintos();
            this.contapontamentos();

            string ifile = txtFile.Text.Replace(txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\')), "\\grafico9.3.png");

            GerarGraficoPorLocalidade(list, localidades, ifile);
        }

        public static void GerarGraficoPorLocalidade(
        IList<AtividadeV> atividades,
        IList<string> todasLocalidades,
        string caminhoSaidaPng)
        {
            if (atividades == null)
                throw new ArgumentNullException(nameof(atividades));

            if (todasLocalidades == null || todasLocalidades.Count == 0)
                throw new ArgumentException("A lista de localidades está vazia.", nameof(todasLocalidades));

            // Passo 1 ─ contabiliza as ocorrências reais
            Dictionary<string, int> contagem = atividades
                .Where(a => !string.IsNullOrWhiteSpace(a.Localidade))
                .GroupBy(a => a.Localidade.Trim())
                .ToDictionary(g => g.Key,
                              g => g.Count(),
                              StringComparer.CurrentCultureIgnoreCase);

            // Passo 2 ─ garante que TODAS as localidades apareçam (valor 0 se não existir)
            List<ItemGrafico> dados = new List<ItemGrafico>();
            foreach (string loc in todasLocalidades)
            {
                int qtd;
                contagem.TryGetValue(loc.Trim(), out qtd);  // qtd = 0 se não existir
                dados.Add(new ItemGrafico { Localidade = loc.Trim(), Quantidade = qtd });
            }

            // Ordena pelo próprio vetor de entrada (ou alfabético, se preferir)
            // dados = dados.OrderBy(d => d.Localidade, StringComparer.CurrentCultureIgnoreCase).ToList();

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Salvar gráfico";
                sfd.Filter = "Imagem PNG (*.png)|*.png";
                sfd.FileName = "grafico-localidades.png";
                sfd.AddExtension = true;
                sfd.OverwritePrompt = true;

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;     // usuário cancelou

                /* ─────────────────────────── GRÁFICO ────────────────────────────── */
                using (Chart chart = new Chart())
                {
                    chart.Size = new Size(1280, 720);
                    chart.Palette = ChartColorPalette.BrightPastel;

                    ChartArea area = new ChartArea("Area");
                    area.AxisX.Title = "Localidade";
                    area.AxisX.Interval = 1;
                    area.AxisY.Title = "Nº de Atividades";
                    chart.ChartAreas.Add(area);

                    Series serie = new Series("Atividades");
                    serie.ChartType = SeriesChartType.Column;
                    serie.IsValueShownAsLabel = true;
                    chart.Series.Add(serie);

                    foreach (ItemGrafico item in dados)
                        serie.Points.AddXY(item.Localidade, item.Quantidade);

                    chart.SaveImage(sfd.FileName, ChartImageFormat.Png);
                }

                MessageBox.Show("Gráfico salvo com sucesso!", "OK",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
    class ItemGrafico
    {
        public string Localidade;
        public int Quantidade;
    }
}
