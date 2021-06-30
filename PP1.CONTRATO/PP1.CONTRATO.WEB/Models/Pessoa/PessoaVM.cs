using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Pessoa
{
    public class PessoaVM : Pai.PaiVM
    {    
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Por favor, informe o cliente!")]
        public string nmPessoa { get; set; }

        [Display(Name = "Telefone")]
        public string nrTelefone { get; set; }

        [Display(Name = "Celular")]
        public string nrCelular { get; set; }

        [Display(Name = "E-mail")]
        public string dsEmail { get; set; }

        
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

        [Display(Name = "Código Cidade")]
        public int idCidade { get; set; }

        public Cidade.ConsultaVM Cidade { get; set; }

       

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
                    new SelectListItem { Value = "F", Text = "FEMININO" },
                    new SelectListItem { Value = "M", Text = "MASCULINO" }
                };
            }
        }


        public static SelectListItem[] Contato
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "C", Text = "CÔNJUGE" },
                    new SelectListItem { Value = "M", Text = "MÃE" },
                    new SelectListItem { Value = "P", Text = "PAI" },
                    new SelectListItem { Value = "O", Text = "OUTROS" },
                };
            }
        }



    }
}