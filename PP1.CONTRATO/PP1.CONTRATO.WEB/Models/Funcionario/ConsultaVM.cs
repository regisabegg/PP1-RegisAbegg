using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.Funcionario
{
    public class ConsultaVM
    {
        public int? idFuncionario { get; set; }
        public string nmFuncionario { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}


