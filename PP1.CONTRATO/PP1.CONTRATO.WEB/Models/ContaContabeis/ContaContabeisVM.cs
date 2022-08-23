using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.ContaContabeis
{
    public class ContaContabeisVM : Pai.PaiVM
    {
        [Display(Name = "Conta:")]
        public string nmConta { get; set; }

        [Display(Name = "Situação:")]
        public string flSituacao { get; set; }

        [Display(Name = "Classificação:")]
        public string nrClassificacao { get; set; }

        [Display(Name = "Saldo:")]
        public decimal vlSaldo { get; set; }

        [Display(Name = "Data de vencimento:")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtVencimento { get; set; }

        [Display(Name = "Data de pagamento:")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtRecebimento { get; set; }


        //public Entity.ContaContabeis VM2E(Entity.ContaContabeis bean)
        //{
        //    bean.nmContaContabeis = this.nmContaContabeis;
        //    bean.flSituacao = this.flSituacao;
        //    bean.dtAtualizacao = this.dtAtualizacao;
        //    bean.dtCadastro = this.dtCadastro;
        //    return bean;
        //}

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