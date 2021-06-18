using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.FormaPagto
{
    public class FormaPagtoVM
    {
        [Display(Name = "Código")]
        public int idFormaPagto { get; set; }

        [Display(Name = "FormaPagto")]
        [Required]
        public string nmFormaPagto { get; set; }
       

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }
             
        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }

        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }
        
        //public Entity.FormaPagto VM2E(Entity.FormaPagto bean)
        //{
        //    bean.nmFormaPagto = this.nmFormaPagto;
        //    bean.nrDDD = this.nrDDD;
        //    bean.nrIBGE = this.nrIBGE;
        //    bean.dtAtualizacao = this.dtAtualizacao;
        //    bean.dtCadastro = this.dtCadastro;
        //    bean.idEstado = this.idEstado;

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