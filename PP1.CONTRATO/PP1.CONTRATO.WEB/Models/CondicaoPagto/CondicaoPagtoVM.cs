using Newtonsoft.Json;
using PP1.CONTRATO.WEB.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.CondicaoPagto
{
    public class CondicaoPagtoVM : Pai.PaiVM
    {
        
        [Display(Name = "Condição de Pagamento:")]
        [Required]
        public string nmCondicaoPagto { get; set; }

        [Display(Name = "Situação:")]
        public string flSituacao { get; set; }

        [Display(Name = "Juros (%):")]
        public decimal? txJuros { get; set; }

        [Display(Name = "Multa (%):")]
        public decimal? txMulta { get; set; }

        [Display(Name = "Dias:")]
        public short? qtDias { get; set; }

        [Display(Name = "Porcentagem (%):")]
        public short? txPercent { get; set; }

        public int idFormaPagto { get; set; }

        public Entity.CondicaoPagto VM2E(Entity.CondicaoPagto bean)
        {
         
            bean.nmCondicaoPagto = this.nmCondicaoPagto;
            bean.flSituacao = this.flSituacao;
            bean.txJuros = this.txJuros ?? 0;
            bean.txMulta = this.txMulta ?? 0;


            foreach (var item in Itens.Get)
            {
                bean.CondicaoForma.Add(new Entity.CondicaoForma
                {
                    idCondicaoPagto = item.idCondicaoPagto ?? 0,
                    nrParcela = item.nrParcela ?? 0,
                    qtDias = item.qtDias ?? 0,
                    txPercentual = item.txPercentual ?? 0,
                    idFormaPagto = item.idFormaPagto ?? 0
                }) ;
            }

            return bean;
        }

        public static SelectListItem[] Situacao
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "A", Text = "ATIVA" },
                    new SelectListItem { Value = "I", Text = "INATIVA" }
                };
            }
        }


        //public DataTablesList<FormaPagto.ConsultaVM> Itens { get; set; }


        public FormaPagto.ConsultaVM FormaPagto { get; set; }

        //public CondicaoPagto.ConsultaVM FormasPagto { get; set; }



        public DataTablesList<CodicaoFormaVM> Itens { get; set; }



        public class CodicaoFormaVM
        {
            public int? idCondicaoPagto { get; set; }
            public short? nrParcela { get; set; }
            public short? qtDias { get; set; }
            public decimal? txPercentual { get; set; }
            public int? idFormaPagto { get; set; }
            public string nmFormaPagto { get; set; }
        }

        //public string jsItens { get; set; }

        //public List<CodicaoFormaVM> ListCondicao
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(jsItens))
        //            return new List<CodicaoFormaVM>();
        //        return JsonConvert.DeserializeObject<List<CodicaoFormaVM>>(jsItens);
        //    }
        //    set
        //    {
        //        jsItens = JsonConvert.SerializeObject(value);
        //    }
        //}


    }
}