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
        
        [Display(Name = "Condição de Pagamento")]
        [Required]
        public string nmCondicaoPagto { get; set; }

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "Juros (%)")]
        public decimal? txJuros { get; set; }

        [Display(Name = "Multa (%)")]
        public decimal? txMulta { get; set; }

        [Display(Name = "Qtd. Parcelas")]
        public short? qtParcela { get; set; }

        [Display(Name = "Dias")]
        public short? qtDias { get; set; }

        [Display(Name = "Porcentagem (%)")]
        public short? txPercent { get; set; }

        public int idFormaPagto { get; set; }

        public DataTablesList<FormaPagto.ConsultaVM> Itens { get; set; }


        public FormaPagto.ConsultaVM FormaPagto { get; set; }

        public CondicaoPagto.ConsultaVM FormasPagto { get; set; }



        //public class CodicaoFormaVM
        //{
        //    public int idFormaPagto { get; set; }
        //    public string nmFomaPagto { get; set; }
        //}

        //public DataTablesList<FormaCondicaoVM> Itens { get; set; }


        public Entity.CondicaoPagto VM2E(Entity.CondicaoPagto bean)
        {
            bean.idFormaPagto = this.idPai;
            bean.nmCondicaoPagto = this.nmCondicaoPagto;
            bean.txJuros = this.txJuros ?? 0;
            bean.txMulta = this.txMulta ?? 0;
            bean.qtParcela = this.qtParcela;


            //foreach (var item in Itens.Get)
            //{
            //    bean.Materias.Add(new Entity.CondicaoPagto
            //    {
            //        idFormaPagto = item.idFormaPagto
            //    });
            //}

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

    }
}