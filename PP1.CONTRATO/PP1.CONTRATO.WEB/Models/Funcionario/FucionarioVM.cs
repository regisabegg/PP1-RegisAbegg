using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Funcionario
{
    public class FuncionarioVM
    {
        [Display(Name = "Código")]
        public int idFuncionario { get; set; }

        [Display(Name = "Nome")]
        [Required]
        public string nmFuncionario { get; set; }

        [Display(Name = "Sobre Nome")]
        [Required]
        public string nmSobreNome { get; set; }

        [Display(Name = "Grau de instrução")]
        public string flInstrucao { get; set; }

        [Display(Name = "Estado civil")]
        public string flCivil { get; set; }

        [Display(Name = "Nascimento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtNascimento { get; set; }

        public string dsImagem { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }

        //Documentos

        [Display(Name = "CPF")]
        public string nrCPF { get; set; }

        [Display(Name = "RG")]
        public string nrRG { get; set; }

        [Display(Name = "Orgão exp. RG")]
        public string nmOrgaoRG { get; set; }

        [Display(Name = "CTPS/Série")]
        public string nrCTPS { get; set; }

        [Display(Name = "PIS")]
        public string nrPIS { get; set; }

        [Display(Name = "Orgão exp. CTPS")]
        public string nmOrgaoCTPS { get; set; }

        [Display(Name = "Titulo de eleitor")]
        public string nrTitulo { get; set; }

        [Display(Name = "Zona")]
        public string nrZona { get; set; }

        [Display(Name = "Seção")]
        public string nrSecao { get; set; }       


        //Filiação

        [Display(Name = "Nome da mãe")]
        public string nmMae { get; set; }

        [Display(Name = "Nome do pai")]
        public string nmPai { get; set; }

        //Endereço

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

        [Display(Name = "Código Estado")]
        public int idEstado { get; set; }

        //Contato

        [Display(Name = "Telefone")]
        public string nrTelefone { get; set; }

        [Display(Name = "Celular")]
        public string nrCelular{ get; set; }

        [Display(Name = "E-mail")]
        public string dsEmail { get; set; }

        [Display(Name = "Site")]
        public string dsSite { get; set; }

        [Display(Name = "Linkedin")]
        public string dsLinkedin { get; set; }

        [Display(Name = "Facebook")]
        public string dsFacebook { get; set; }

        [Display(Name = "Instagram")]
        public string dsInstagram { get; set; }

        
        //Emergência

        [Display(Name = "Contato")]
        public string nmContato { get; set; }

        [Display(Name = "Tipo Contato")]
        public string flContato { get; set; }

        [Display(Name = "Telefone")]
        public string nrFoneEmergecia { get; set; }

        [Display(Name = "Celular")]
        public string nrCelularEmergecia { get; set; }

        //Admissão

        [Display(Name = "Admissão")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAdmissao { get; set; }

        [Display(Name = "Demissão")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtDemissao { get; set; }

        [Display(Name = "Função")]
        public string nmFuncao { get; set; }

        [Display(Name = "Departamento")]
        public string nmDepartamento { get; set; }

        [Display(Name = "Regime de experiência")]
        public string flExperiencia { get; set; }

        //Bancários

        [Display(Name = "Banco")]
        public string nmBanco { get; set; }

        [Display(Name = "Tipo Conta")]
        public string flTipoConta { get; set; }

        [Display(Name = "Agência")]
        public string nrAgencia { get; set; }

        [Display(Name = "Conta")]
        public string nrConta{ get; set; }

        [Display(Name = "Dígito")]
        public string nrDigito { get; set; }

        //Geral 

        [Display(Name = "Observações")]
        public string dsObservacao { get; set; }

        [Display(Name = "Situação")]
        public string flSituacao { get; set; }

        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }

        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }

        public Models.Estado.ConsultaVM Estado { get; set; }

        //public Entity.Funcionario VM2E(Entity.Funcionario bean)
        //{
        //    bean.nmFuncionario = this.nmFuncionario;
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

        public static SelectListItem[] Experiencia
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "S", Text = "SIM" },
                    new SelectListItem { Value = "N", Text = "NÃO" }
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

        public static SelectListItem[] Instrucao
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "M1", Text = "MÉDIO COMPLETO" },
                    new SelectListItem { Value = "S1", Text = "SUPERIOR CURSANDO" },
                    new SelectListItem { Value = "S2", Text = "SUPERIOR INCOMPLETO" },
                    new SelectListItem { Value = "S3", Text = "SUPERIOR COMPLETO" },
                    new SelectListItem { Value = "P1", Text = "PÓS CURSANDO" },
                    new SelectListItem { Value = "P2", Text = "PÓS INCOMPLETO" },
                    new SelectListItem { Value = "P3", Text = "PÓS COMPLETO" },
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
                    new SelectListItem { Value = "P", Text = "PAI" },
                    new SelectListItem { Value = "M", Text = "MÃE" },
                    new SelectListItem { Value = "C", Text = "CÔNJUGE" },
                    new SelectListItem { Value = "F", Text = "FILHO(A)" },
                    new SelectListItem { Value = "O", Text = "OUTROS" },
                };
            }
        }



    }
}