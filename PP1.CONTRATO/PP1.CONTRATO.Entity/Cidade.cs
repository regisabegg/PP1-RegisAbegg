using System;

namespace PP1.CONTRATO.Entity
{
    public class Cidade
    {
        public int idCidade { get; set; }

        public string nmCidade { get; set; }

        public string nrDDD { get; set; }

        public string nrIBGE { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtAtualizacao { get; set; }

        public int idEstado { get; set; }

    }
}
