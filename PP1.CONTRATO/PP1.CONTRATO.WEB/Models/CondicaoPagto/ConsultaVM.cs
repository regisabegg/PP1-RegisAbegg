using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.FormaPagto
{
    public class ConsultaVM
    {
        public int? idFormaPagto { get; set; }
        public string nmFormaPagto { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}

