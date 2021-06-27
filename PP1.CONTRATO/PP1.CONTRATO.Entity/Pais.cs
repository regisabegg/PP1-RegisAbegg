using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.Entity
{
    public class Pais
    {
       

        public int idPais { get; set; }
       
        public string nmPais { get; set; }

        public string dsSigla { get; set; }

        public string nrDDI { get; set; }
 
        public DateTime dtCadastro { get; set; }
       
        public DateTime dtAtualizacao { get; set; }

        public List<Estado> Estados { get; set; }

        public Pais()
        {
            Estados = new List<Estado>();
        }


        public Pais(int idPais)
        {
            this.idPais = idPais;
        }

    }
}
