using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.OrdemServico
{
    public class OrdemServicoVM : Pai.PaiVM
    {

        [Display(Name = "Descrição O.S:")]
        [Required]
        public string dsObservacao { get; set; }

        [Display(Name = "Situação:")]
        public string flSituacao { get; set; }

        [Display(Name = "Tipo do serviço:")]
        public string flTipo { get; set; }

        [Display(Name = "Valor ($):")]
        public decimal? vlOrdemServico { get; set; }

        [Display(Name = "Valor ($):")]
        public decimal? vlServico { get; set; }

        [Display(Name = "Quantidade:")]
        public int? vlQuantidade { get; set; }

        [Display(Name = "Total ($):")]
        public decimal? vlTotal { get; set; }

        public int idFormaPagto { get; set; }

        [Display(Name = "Data da O.S:")]
        public DateTime dtOrdem { get; set; }

        [Display(Name = "Data do Término:")]
        public DateTime dtTermino { get; set; }

        [Display(Name = "Data da início:")]
        public DateTime dtInicio { get; set; }

        [Display(Name = "Data da Entrega:")]
        public DateTime dtEntrega{ get; set; }

        public Cliente.ConsultaVM Cliente { get; set; }

        public Servico.ConsultaVM Servico { get; set; }

        public Funcionario.ConsultaVM Funcionario { get; set; }

        //public Entity.OrdemServico VM2E(Entity.OrdemServico bean)
        //{
        //    bean.idOrdemServico = this.idPai;
        //    bean.nmOrdemServico = this.nmOrdemServico;
        //    bean.vlOrdemServico = this.vlOrdemServico ?? 0;

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

        public static SelectListItem[] TipoServico
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "N", Text = "NORMAL" },
                    new SelectListItem { Value = "A", Text = "ADICIONAL" }
                };
            }
        }

    }
}