using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP1.CONTRATO.Entity
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string nmCliente { get; set; }

        public string nmApelido { get; set; }

        public string nrDocumento { get; set; }

        public string nrRegistro { get; set; }
       
        public string nrTelefone { get; set; }
       
        public string nrCelular { get; set; }
       
        public string dsEmail { get; set; }

        public string dsSite { get; set; }
        
        public string nmContato { get; set; }
      
        public string flContato { get; set; }

        public string dsObservacao { get; set; }
       
        public string flTipo { get; set; }
       
        public string flSituacao { get; set; }
       
        public string nrCEP { get; set; }
       
        public string nmLogradouro { get; set; }
       
        public string nrNumero { get; set; }
      
        public string nmBairro { get; set; }
        
        public string dsComplemento { get; set; }

        public decimal vlLimite { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtAtualizacao { get; set; }

        public int idCidade { get; set; }



        public const string TIPO_FISICO = "F";
        public const string TIPO_JURIDICO = "J";

    }
}
