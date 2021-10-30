using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.ContaReceber
{
    public class ContaReceberVM : Pai.PaiVM
    {
        [Display(Name = "Descrição")]
        public string dsDescricao { get; set; }

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "Nº Parcela")]
        public int nrParcela { get; set; }

        [Display(Name = "Valor da conta")]
        public decimal vlConta { get; set; }

        [Display(Name = "Data de vencimento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtVencimento { get; set; }

        [Display(Name = "Data de pagamento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtRecebimento { get; set; }

        public FormaPagto.ConsultaVM FormaPagto { get; set; }

        public Cliente.ConsultaVM Cliente { get; set; }

        public ContaContabeis.ConsultaVM ContaContabeis { get; set; }



        //public Entity.ContaReceber VM2E(Entity.ContaReceber bean)
        //{
        //    bean.nmContaReceber = this.nmContaReceber;
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
                    new SelectListItem { Value = "P", Text = "PENDENTE" },
                    new SelectListItem { Value = "Q", Text = "QUITADA" },
                    new SelectListItem { Value = "C", Text = "CANCELADA" },
                };
            }
        }
    }
}