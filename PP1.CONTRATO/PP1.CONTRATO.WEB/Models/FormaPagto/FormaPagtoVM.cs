using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.FormaPagto
{
    public class FormaPagtoVM : Pai.PaiVM
    {
        [Display(Name = "Nome:")]
        [Required]
        public string nmFormaPagto { get; set; }
        [Display(Name = "Situação:")]
        public string flSituacao { get; set; }


        public Entity.FormaPagto VM2E(Entity.FormaPagto bean)
        {
            bean.nmFormaPagto = this.nmFormaPagto;
            bean.flSituacao = this.flSituacao;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
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