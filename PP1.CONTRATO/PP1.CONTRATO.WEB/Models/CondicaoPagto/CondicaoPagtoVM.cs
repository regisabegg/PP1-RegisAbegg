using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.CondicaoPagto
{
    public class CondicaoPagtoVM
    {
        [Display(Name = "Código")]
        public int idCondicaoPagto { get; set; }

        [Display(Name = "CondicaoPagto")]
        [Required]
        public string nmCondicaoPagto { get; set; }

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "Juros (%)")]
        public decimal? txJuros { get; set; }

        [Display(Name = "Multa (%)")]
        public decimal? txMulta { get; set; }

        [Display(Name = "Parcela(s)")]
        public short? qtParcela { get; set; }

        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }

        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }

        //public Entity.CondicaoPagto VM2E(Entity.CondicaoPagto bean)
        //{
        //    bean.nmCondicaoPagto = this.nmCondicaoPagto;
        //    bean.nrDDD = this.nrDDD;
        //    bean.nrIBGE = this.nrIBGE;
        //    bean.dtAtualizacao = this.dtAtualizacao;
        //    bean.dtCadastro = this.dtCadastro;
        //    bean.idEstado = this.idEstado;

        //    return bean;
        //}


        //public class CursoMateriaVM
        //{
        //    public int idFormaPagto { get; set; }
        //    public string nmFomaPagto { get; set; }
        //}

        //public DataTablesList<FormaCondicaoVM> Itens { get; set; }


        //public Entity.CondicaoPagto VM2E(Entity.CondicaoPagto bean)
        //{
        //    bean.id = this.id;
        //    bean.Nome = this.Nome;


        //    foreach (var item in Itens.Get)
        //    {
        //        bean.Materias.Add(new Entity.CondicaoPagto
        //        {
        //            idFormaPagto = item.idFormaPagto
        //        });
        //    }

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