using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.CONTRATO.Entity
{
    public class Estado
    {


        public int idEstado { get; set; }
       
        public string nmEstado { get; set; }

        public string dsUF { get; set; }

        public string nrIBGE { get; set; }

        public string flRegiao { get; set; }
 
        public DateTime dtCadastro { get; set; }
       
        public DateTime dtAtualizacao { get; set; }

        public int idPais { get; set; }


        public const string REGIAO_SUL = "S";
        public const string REGIAO_NORTE = "N";
        public const string REGIAO_NORDESTE = "R";
        public const string REGIAO_COESTE = "O";
        public const string REGIAO_SULDESTE = "L";

    }
}
