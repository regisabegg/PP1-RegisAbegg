using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP1.CONTRATO.WEB.Models.Funcionario
{
    public class FuncionarioVM : Pessoa.PessoaVM
    {
        [Display(Name = "Apelido/Crachá")]
        public string nmApelido{ get; set; }

        [Display(Name = "Grau de instrução")]
        public string flInstrucao { get; set; }

        [Display(Name = "Estado civil")]
        public string flCivil { get; set; }

        [Display(Name = "Sexo")]
        public string flSexo { get; set; }

        [Display(Name = "Nascimento")]
   
        public DateTime? dtNascimento { get; set; }

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


        //Contato

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
     
        public DateTime dtAdmissao { get; set; }

        [Display(Name = "Demissão")]
        [DataType(DataType.Date)]
        public DateTime? dtDemissao { get; set; }

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

        [Display(Name = "Chave PIX")]
        public string nrPIX { get; set; }

        public Entity.Funcionario VM2E(Entity.Funcionario bean)
        {
            bean.nmFuncionario = this.nmPessoa;
            bean.nmApelido = this.nmApelido;
            bean.flInstrucao = this.flInstrucao;
            bean.flCivil = this.flCivil;
            bean.flSexo = this.flSexo;
            bean.dtNascimento = this.dtNascimento;
            bean.dsImagem = this.dsImagem;
            //nmapelido = this.imagem;
            //Documentos
            bean.nrDocumento = this.nrCPF;
            bean.nrRegistro = this.nrRG;
            bean.nmOrgaoRG = this.nmOrgaoRG;
            bean.nrCTPS = this.nrCTPS;
            bean.nrPIS = this.nrPIS;
            bean.nmOrgaoCTPS = this.nmOrgaoCTPS;
            bean.nrTitulo = this.nrTitulo;
            bean.nrZona = this.nrZona;
            bean.nrSecao = this.nrSecao;
            //Filiação
            bean.nmMae = this.nmMae;
            bean.nmPai = this.nmPai;
            //Endereço
            bean.nrCEP = !string.IsNullOrEmpty(this.nrCEP) ? this.nrCEP.Replace("-", "") : this.nrCEP;
            bean.nmLogradouro = this.nmLogradouro;
            bean.nrNumero = this.nrNumero;
            bean.nmBairro = this.nmBairro;
            bean.dsComplemento = this.dsComplemento;
            bean.idCidade = this.Cidade.id ?? 0;
            //Contato
            bean.nrTelefone = !string.IsNullOrEmpty(this.nrTelefone) ? this.nrTelefone.Replace("(", "").Replace(")", "").Replace("-", "") : this.nrTelefone;
            bean.nrCelular = !string.IsNullOrEmpty(this.nrCelular) ? this.nrCelular.Replace("(", "").Replace(")", "").Replace("-", "") : this.nrCelular;
            bean.dsEmail = this.dsEmail;
            bean.dsSite = this.dsSite;
            bean.dsLinkedin = this.dsLinkedin;
            bean.dsFacebook = this.dsFacebook;
            bean.dsInstagram = this.dsInstagram;
            //Emergência
            bean.nmContato = this.nmContato;
            bean.flContato = this.flContato;          
            bean.nrFoneEmergecia = !string.IsNullOrEmpty(this.nrFoneEmergecia) ? this.nrFoneEmergecia.Replace("(", "").Replace(")", "").Replace("-", "") : this.nrFoneEmergecia;
            bean.nrCelularEmergecia = !string.IsNullOrEmpty(this.nrCelularEmergecia) ? this.nrCelularEmergecia.Replace("(", "").Replace(")", "").Replace("-", "") : this.nrCelularEmergecia;
            //Admissão
            bean.dtAdmissao = this.dtAdmissao;
            bean.dtDemissao = this.dtDemissao;
            bean.nmFuncao = this.nmFuncao;
            bean.nmDepartamento = this.nmDepartamento;
            bean.flExperiencia = this.flExperiencia;
            //Bancários
            bean.nmBanco = this.nmBanco;
            bean.flTipoConta = this.flTipoConta;
            bean.nrAgencia = this.nrAgencia;
            bean.nrConta = this.nrConta;
            bean.nrDigito = this.nrDigito;
            bean.nrPix = this.nrPIX;
            //Geral
            bean.dsObservacao = this.dsObservacao;
            bean.flSituacao = this.flSituacao;
            bean.dtCadastro = this.dtCadastro;
            bean.dtAtualizacao = this.dtAtualizacao;



            return bean;
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



        public static SelectListItem[] TipoConta
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "C", Text = "CONTA CORRENTE" },
                    new SelectListItem { Value = "P", Text = "CONTA POUPANÇA" },
                    new SelectListItem { Value = "S", Text = "CONTA SALÁRIO" },
                };
            }
        }


        public static SelectListItem[] EstadoCivil
        {
            get
            {
                return new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "C", Text = "CASADO(A)" },
                    new SelectListItem { Value = "D", Text = "DIVORCIADO(A)" },
                    new SelectListItem { Value = "S", Text = "SOLTEIRO(A)" },
                    new SelectListItem { Value = "U", Text = "UNIÃO ESTÁVEL" },
                    new SelectListItem { Value = "V", Text = "VIÚVO(A)" },
                };
            }
        }

        public static SelectListItem[] ContatoFuncionario
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