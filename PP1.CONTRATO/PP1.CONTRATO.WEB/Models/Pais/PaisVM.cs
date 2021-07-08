using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Models.Pais
{
    public class PaisVM : Pai.PaiVM
    {       
        [Display(Name = "Nome")]
        [Required]
        public string nmPais { get; set; }
        [Display(Name = "Sigla")]
        public string dsSigla { get; set; }
        [Display(Name = "DDI")]
        public string nrDDI { get; set; }


        public Entity.Pais VM2E(Entity.Pais bean)
        {
            //bean.idPais = this.idPai;
            bean.nmPais = this.nmPais;
            bean.dsSigla = this.dsSigla;
            bean.nrDDI = this.nrDDI;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
            return bean;
        }

    }
}