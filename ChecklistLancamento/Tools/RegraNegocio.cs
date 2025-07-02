using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class RegraNegocio
    {
        Dao atividade;

        public List<AtividadeV> ReadFile(string Source)
        {
            atividade = new Dao();
            return atividade.LoadReg(Source);
        }
    }
}
