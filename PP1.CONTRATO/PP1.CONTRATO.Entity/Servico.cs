using System;

namespace PP1.CONTRATO.Entity
{
    public class Servico
    {      
        public int idServico{ get; set; }
       
        public string nmServico{ get; set; }
       
        public string flSituacao { get; set; }
     
        public decimal? vlServico { get; set; }
             
        public DateTime dtCadastro { get; set; }
    
        public DateTime dtAtualizacao { get; set; }

        public const string SITUACAO_ATIVA = "A";
        public const string SITUACAO_INATIVA = "I";

    }
}
