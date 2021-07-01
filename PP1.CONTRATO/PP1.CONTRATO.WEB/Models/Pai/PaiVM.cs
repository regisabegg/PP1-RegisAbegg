using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Models.Pai
{
    public class PaiVM
    {
        [Display(Name = "Código")]
        public int idPai { get; set; }

        [Display(Name = "Cadastro")]
        [DisplayFormat(DataFormatString  = "mm/dd/yyyy")]
        public DateTime dtCadastro { get; set; }
        [Display(Name = "Atualização")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime dtAtualizacao { get; set; }

      

    }
}