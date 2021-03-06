using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.Entity
{
    public class FormaPagto
    {
       

        public int idFormaPagto { get; set; }

        public string nmFormaPagto { get; set; }

        public string flSituacao { get; set; }

        public DateTime dtCadastro { get; set; }
       
        public DateTime dtAtualizacao { get; set; }

        public const string SITUACAO_ATIVA = "A";
        public const string SITUACAO_INATIVA = "I";


        public FormaPagto()
        {
            this.CondicaoForma = new List<CondicaoForma>();
        }

        public ICollection<CondicaoForma> CondicaoForma { get; set; }
    }
}
