﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Models.Pais
{
    public class PaisVM
    {
        [Display(Name = "Código")]
        public int idPais { get; set; }
        [Display(Name = "Nome")]
        [Required]
        public string nmPais { get; set; }
        [Display(Name = "Sigla")]
        public string dsSigla { get; set; }
        [Display(Name = "DDI")]
        public string nrDDI { get; set; }
        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }
        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }

        public Entity.Pais VM2E(Entity.Pais bean)
        {
            bean.nmPais = this.nmPais;
            bean.dsSigla = this.dsSigla;
            bean.nrDDI = this.nrDDI;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;

            return bean;
        }

    }
}