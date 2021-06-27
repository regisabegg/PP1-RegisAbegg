using System;

namespace PP1.CONTRATO.Entity
{
    public class CondicaoPagto
    {
        public int idCondicaoPagto { get; set; }

        public string nmCondicaoPagto { get; set; }

        public string flSituacao { get; set; }

        public decimal? txJuros { get; set; }

        public decimal? txMulta { get; set; }

        public short? qtParcela { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtAtualizacao { get; set; }

        public int idFormaPagto { get; set; }

        public const string SITUACAO_ATIVA = "A";
        public const string SITUACAO_INATIVA = "I";

    }
}
