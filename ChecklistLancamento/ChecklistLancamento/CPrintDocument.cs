using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecklistLancamento
{
    class CPrintDocument : PrintDocument
    {
        public string Header { get; set; }
        public string[] Texto { get; set; }
        public int NumeroPagina { get; set; }
        public int Offset { get; set; }

        public CPrintDocument(string Cabecalho)
        {
            Header = Cabecalho;
        }
    }
}
