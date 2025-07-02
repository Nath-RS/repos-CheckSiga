using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Relatorio
    {
        public string Localidade { get; set; }

        public List<Livro> LivrosLocalidade { get; set; } = new List<Livro>();

    }
}
