using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Cliente
{
    public class ClienteVM : Pessoa.PessoaVM
    {
        [Display(Name = "Limite crédito")]
        //[Column(TypeName = "decimal(8,2)")]
        //[DisplayFormat(DataFormatString = "{N:2}")]

        public decimal? vlLimite { get; set; }
                
        public Entity.Cliente VM2E(Entity.Cliente bean)
        {
            bean.nmCliente = this.nmPessoa;
            bean.nrTelefone = !string.IsNullOrEmpty(this.nrTelefone) ? this.nrTelefone.Replace("(", "").Replace(")", "").Replace("-", "") : this.nrTelefone;
            bean.nrCelular = !string.IsNullOrEmpty(this.nrCelular) ? this.nrCelular.Replace("(","").Replace(")","").Replace("-","") : this.nrCelular;
            bean.dsEmail = this.dsEmail;
            bean.dsObservacao = this.dsObservacao;
            bean.flTipo = this.flTipo;
            bean.flSituacao = this.flSituacao;
            bean.nrCEP = !string.IsNullOrEmpty(this.nrCEP) ? this.nrCEP.Replace("-", "") : this.nrCEP;
            bean.nmLogradouro = this.nmLogradouro;
            bean.nrNumero = this.nrNumero;
            bean.nmBairro = this.nmBairro;
            bean.dsComplemento = this.dsComplemento;
            bean.vlLimite = this.vlLimite ?? 0;
            bean.dtAtualizacao = this.dtAtualizacao;
            bean.dtCadastro = this.dtCadastro;
            bean.idCidade = this.Cidade.id ?? 0;
            if (bean.flTipo == Entity.Cliente.TIPO_JURIDICA)
                bean = this.Juridica.VM2E(bean);
            if (bean.flTipo == Entity.Cliente.TIPO_FISICA)
                bean = this.Fisica.VM2E(bean);

            return bean;
        }

        public PessoaFisicaVM Fisica { get; set; }
        public PessoaJuridicaVM Juridica { get; set; }

        public class PessoaFisicaVM
        {
            [Display(Name = "Apelido")]
            public string nmApelido { get; set; }

            [Display(Name = "CPF")]
            [Required(ErrorMessage = "Por favor, informe o CPF!")]
            public string nrCPF { get; set; }

            [Display(Name = "RG")]
            public string nrRG { get; set; }

            [Display(Name = "Dt. nascimento")]
            public DateTime? dtNascimento { get; set; }

            [Display(Name = "Sexo")]
            public string flSexo { get; set; }

            public Entity.Cliente VM2E(Entity.Cliente bean)
            {
                bean.nmApelido = this.nmApelido;
                bean.nrDocumento = !string.IsNullOrEmpty(this.nrCPF) ? this.nrCPF.Replace(".", "").Replace("-", "") : this.nrCPF ;
                bean.nrRegistro = this.nrRG;
                bean.flSexo = this.flSexo;
                bean.dtNascimento = this.dtNascimento;

                return bean;
            }
        }

        public class PessoaJuridicaVM
        {

            [Display(Name = "Nome fantasia")]
            public string nmFantasia { get; set; }

            [Display(Name = "CNPJ")]
            [Required(ErrorMessage = "Por favor, informe o CNPJ!")]
            public string nrCNPJ { get; set; }

            [Display(Name = "Nº IE")]
            public string nrIE { get; set; }

            [Display(Name = "Site")]
            public string dsSite { get; set; }

            [Display(Name = "Contato")]
            public string nmContato { get; set; }

            [Display(Name = "Tipo Contato")]
            public string flContato { get; set; }


            public Entity.Cliente VM2E(Entity.Cliente bean)
            {               
                bean.nrDocumento = !string.IsNullOrEmpty(this.nrCNPJ) ? this.nrCNPJ.Replace(".", "").Replace(",", "").Replace("/", "").Replace("-", "") : this.nrCNPJ;
                bean.nmApelido = this.nmFantasia;
                bean.nrRegistro = this.nrIE;
                bean.dsSite = this.dsSite;
                bean.nmContato = this.nmContato;
                bean.flContato = this.flContato;
               

                return bean;
            }
        }


       

    }
}