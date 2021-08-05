using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Cidade
{
    public class CidadeVM : Pai.PaiVM
    {
        
        [Display(Name = "Cidade")]
        [Required]
        public string nmCidade { get; set; }
        
        [Display(Name = "DDD")]
        public string nrDDD { get; set; }

        [Display(Name = "Cód. IBGE")]
        public string nrIBGE { get; set; }
        
        [Display(Name = "Código Estado")]
        public int idEstado { get; set; }




        public Models.Estado.ConsultaVM Estado { get; set; }

        public Entity.Cidade VM2E(Entity.Cidade bean)
        {
            bean.nmCidade = this.nmCidade;
            bean.nrDDD = this.nrDDD;
            bean.nrIBGE = this.nrIBGE;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
            bean.idEstado = this.Estado.id ?? 0;

            return bean;
        }

    }
}