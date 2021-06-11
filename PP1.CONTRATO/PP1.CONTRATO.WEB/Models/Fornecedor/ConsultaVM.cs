using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.Fornecedor
{
    public class ConsultaVM
    {
        public int? idFornecedor { get; set; }
        public string nmFornecedor { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}

