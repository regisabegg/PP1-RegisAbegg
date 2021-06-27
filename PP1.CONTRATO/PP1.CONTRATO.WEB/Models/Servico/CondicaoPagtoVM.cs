using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Servico
{
    public class ServicoVM : Pai.PaiVM
    {

        [Display(Name = "Condição de Pagamento")]
        [Required]
        public string nmServico { get; set; }

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "Valor ($)")]
        public decimal? vlServico { get; set; }

        public int idFormaPagto { get; set; }

        public Entity.Servico VM2E(Entity.Servico bean)
        {
            bean.idServico = this.idPai;
            bean.nmServico = this.nmServico;
            bean.vlServico = this.vlServico ?? 0;

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