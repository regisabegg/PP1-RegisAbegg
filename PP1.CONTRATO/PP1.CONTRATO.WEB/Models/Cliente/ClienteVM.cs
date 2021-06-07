using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Cliente
{
    public class ClienteVM
    {
        [Display(Name = "Código")]
        public int idCliente { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        public string nmCliente { get; set; }
       
        public string nmApelido { get; set; }

        public string nrDocumento { get; set; }

        public string nrRegistro { get; set; }

        [Display(Name = "Telefone")]
        public string nrTelefone { get; set; }

        [Display(Name = "Celular")]
        public string nrCelular{ get; set; }

        [Display(Name = "E-mail")]
        public string dsEmail { get; set; }

        [Display(Name = "Site")]
        public string dsSite { get; set; }

        [Display(Name = "Limite crédito")]
        public decimal vlLimite { get; set; }

        [Display(Name = "Contato")]
        public string nmContato { get; set; }

        [Display(Name = "Tipo Contato")]
        public string flContato { get; set; }

        [Display(Name = "Observações")]
        public string dsObservacao { get; set; }

        [Display(Name = "Tipo Cliente")]
        public string flTipo { get; set; }


        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "CEP")]
        public string nrCEP { get; set; }

        [Display(Name = "Logradouro")]
        public string nmLogradouro { get; set; }

        [Display(Name = "Número")]
        public string nrNumero { get; set; }

        [Display(Name = "Bairro")]
        public string nmBairro { get; set; }

        [Display(Name = "Complemento")]
        public string dsComplemento { get; set; }

        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }

        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }

        [Display(Name = "Código Estado")]
        public int idEstado { get; set; }

        public Models.Estado.ConsultaVM Estado { get; set; }

        //public Entity.Cliente VM2E(Entity.Cliente bean)
        //{
        //    bean.nmCliente = this.nmCliente;
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

        public static SelectListItem[] Tipo
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "F", Text = "FÍSICA" },
                    new SelectListItem { Value = "J", Text = "JURÍDICA" }
                };
            }
        }

        public static SelectListItem[] Sexo
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "M", Text = "MASCULINO" },
                    new SelectListItem { Value = "F", Text = "FEMININO" }
                };
            }
        }


        public static SelectListItem[] Contato
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "D", Text = "DIRETOR" },
                    new SelectListItem { Value = "G", Text = "GERENTE" },
                    new SelectListItem { Value = "V", Text = "VENDEDOR" },
                    new SelectListItem { Value = "O", Text = "OUTROS" },
                };
            }
        }



    }
}