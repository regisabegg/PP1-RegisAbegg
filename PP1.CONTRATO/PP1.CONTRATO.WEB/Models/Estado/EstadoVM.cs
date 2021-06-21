﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Estado
{
    public class EstadoVM : Pai.PaiVM
    {
      
        [Display(Name = "Estado")]
        [Required]
        public string nmEstado { get; set; }
        [Display(Name = "UF")]
        public string dsUF { get; set; }
     
        [Display(Name = "Cód. IBGE")]
        public string nrIBGE { get; set; }

        [Display(Name = "Região")]
        public string flRegiao { get; set; }




        public Pais.ConsultaVM Pais { get; set; }

        [Display(Name = "Código País")]
        public int idPais { get; set; }

        public Entity.Estado VM2E(Entity.Estado bean)
        {
            bean.nmEstado = this.nmEstado;
            bean.dsUF = this.dsUF;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
            bean.nrIBGE = this.nrIBGE;
            bean.flRegiao = this.flRegiao;
            bean.idPais = this.Pais.id ?? 0;

            return bean;
        }

        public static SelectListItem[] RegiaoTipo
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Text = "", Value = "" },
                    new SelectListItem { Text = "Centro Oeste", Value = Entity.Estado.REGIAO_COESTE },
                    new SelectListItem { Text = "Nordeste", Value = Entity.Estado.REGIAO_NORDESTE },
                    new SelectListItem { Text = "Norte", Value = Entity.Estado.REGIAO_NORTE },
                    new SelectListItem { Text = "Sul", Value = Entity.Estado.REGIAO_SUL },
                    new SelectListItem { Text = "Suldeste", Value = Entity.Estado.REGIAO_SULDESTE },
                };
            }
        }

    }
}