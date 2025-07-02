using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class AtividadeV : IComparable<AtividadeV>
    {
        public string Localidade { get; set; }
        public string Livro { get; set; }
        public string Voluntario { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public string Funcao { get; set; }
        public string Data { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public string Horas { get; set; }
        public string HorasDesc { get; set; }
        public string Valor { get; set; }

        public int CompareTo(AtividadeV other)
        {
            return Localidade.ToUpper().CompareTo(other.Localidade.ToUpper());
        }

        public override string ToString()
        {
            return $"{Localidade} | {Livro} | {Voluntario} | {CPF} | {DataNascimento} | {Funcao} | {Data} | {Inicio} | {Fim} | {HorasDesc} | {Valor}";
        }
    }
}
