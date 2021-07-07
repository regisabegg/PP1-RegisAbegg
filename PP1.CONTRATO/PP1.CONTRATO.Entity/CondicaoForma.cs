using System;

namespace PP1.CONTRATO.Entity
{
    public class CondicaoForma
    {
        public int? idCondicaoPagto { get; set; }
        public short? nrParcela { get; set; }
        public short? qtDias { get; set; }
        public decimal? txPercentual { get; set; }
        public int? idFormaPagto { get; set; }

        public FormaPagto FormaPagto { get; set; }
        public CondicaoPagto CondicaoPagto { get; set; }
    }
}
