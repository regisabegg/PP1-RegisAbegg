using System;

namespace PP1.CONTRATO.Entity
{
    public class Funcionario
    {
        public int idFuncionario { get; set; }

        public string nmFuncionario { get; set; }

        public string nmApelido { get; set; }

        public string flInstrucao { get; set; }

        public string flCivil { get; set; }

        public string flSexo { get; set; }

        public DateTime? dtNascimento { get; set; }

        public string dsImagem { get; set; }

        public byte[] imagem { get; set; }

        //Documentos

        public string nrDocumento { get; set; }

        public string nrRegistro { get; set; }

        public string nmOrgaoRG { get; set; }

        public string nrCTPS { get; set; }

        public string nrPIS { get; set; }

        public string nmOrgaoCTPS { get; set; }

        public string nrTitulo { get; set; }

        public string nrZona { get; set; }

        public string nrSecao { get; set; }

        //Filiação

        public string nmMae { get; set; }

        public string nmPai { get; set; }

        //Endereço

        public string nrCEP { get; set; }

        public string nmLogradouro { get; set; }

        public string nrNumero { get; set; }

        public string nmBairro { get; set; }

        public string dsComplemento { get; set; }

        public int idCidade { get; set; }

        //Contato

        public string nrTelefone { get; set; }

        public string nrCelular { get; set; }

        public string dsEmail { get; set; }

        public string dsSite { get; set; }

        public string dsLinkedin { get; set; }

        public string dsFacebook { get; set; }

        public string dsInstagram { get; set; }

        //Emergência

        public string nmContato { get; set; }

        public string flContato { get; set; }

        public string nrFoneEmergecia { get; set; }

        public string nrCelularEmergecia { get; set; }

        //Admissão

        public DateTime dtAdmissao { get; set; }

        public DateTime? dtDemissao { get; set; }

        public string nmFuncao { get; set; }

        public string nmDepartamento { get; set; }

        public string flExperiencia { get; set; }

        //Bancários

        public string nmBanco { get; set; }

        public string flTipoConta { get; set; }

        public string nrAgencia { get; set; }

        public string nrConta { get; set; }

        public string nrDigito { get; set; }

        public string nrPix { get; set; }

        //Geral 

        public string dsObservacao { get; set; }

        public string flSituacao { get; set; }
       
        public DateTime dtCadastro { get; set; }
     
        public DateTime dtAtualizacao { get; set; }


        public const string TIPO_FISICA = "F";
        public const string TIPO_JURIDICA = "J";
        
        public const string SITUACAO_ATIVA = "A";
        public const string SITUACAO_INATIVA = "I";

        public const string SEXO_FEMININO = "F";
        public const string SEXO_MASCULINO = "M";

    }
}
