using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.CondicaoPagto
{
    public class ConsultaVM
    {
        public int? idCondicaoPagto { get; set; }
        public string nmCondicaoPagto { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}

