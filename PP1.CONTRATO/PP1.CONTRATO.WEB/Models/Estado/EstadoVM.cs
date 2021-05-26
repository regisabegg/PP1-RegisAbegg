using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Models.Estado
{
    public class EstadoVM
    {
        [Display(Name = "Código")]
        public int idEstado { get; set; }
        [Display(Name = "Estado")]
        [Required]
        public string nmEstado { get; set; }
        [Display(Name = "UF")]
        public string dsUF { get; set; }
        [Display(Name = "DDD")]
        public string nrDDD { get; set; }
        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }
        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }


        public Models.Pais.ConsultaVM Pais { get; set; }

        [Display(Name = "Código País")]
        public int idPais { get; set; }

        //public Entity.Estado VM2E(Entity.Estado bean)
        //{
        //    bean.nmEstado = this.nmEstado;
        //    bean.dsSigla = this.dsSigla;
        //    bean.nrDDI = this.nrDDI;
        //    bean.dtAtualizacao = this.dtAtualizacao;
        //    bean.dtCadastro = this.dtCadastro;

        //    return bean;
        //}

    }
}