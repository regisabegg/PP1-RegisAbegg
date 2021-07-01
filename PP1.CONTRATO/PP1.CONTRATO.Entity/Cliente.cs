using System;

namespace PP1.CONTRATO.Entity
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string nmCliente { get; set; }

        public string nmApelido { get; set; }

        public string nrDocumento { get; set; }

        public string nrRegistro { get; set; }

        public string nrTelefone { get; set; }

        public string nrCelular { get; set; }

        public string dsEmail { get; set; }

        public string dsSite { get; set; }

        public string nmContato { get; set; }

        public string flContato { get; set; }

        public string dsObservacao { get; set; }

        public string flTipo { get; set; }

        public string flSituacao { get; set; }

        public string nrCEP { get; set; }

        public string nmLogradouro { get; set; }

        public string nrNumero { get; set; }

        public string nmBairro { get; set; }

        public string dsComplemento { get; set; }

        public double? vlLimite { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtAtualizacao { get; set; }

        public DateTime? dtNascimento { get; set; }

        public string flSexo { get; set; }

        public int idCidade { get; set; }



        public const string TIPO_FISICA = "F";
        public const string TIPO_JURIDICA = "J";

        public const string SITUACAO_ATIVA = "A";
        public const string SITUACAO_INATIVA = "I";

        public const string SEXO_FEMININO = "F";
        public const string SEXO_MASCULINO = "M";

    }
}
