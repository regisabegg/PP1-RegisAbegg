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

        public string nrDDD { get; set; }
 
        public DateTime dtCadastro { get; set; }
       
        public DateTime dtAtualizacao { get; set; }

        public int idPais { get; set; }

    }
}
