using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.Cidade
{
    public class ConsultaVM
    {
        public int? idCidade { get; set; }
        public string nmCidade { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}

