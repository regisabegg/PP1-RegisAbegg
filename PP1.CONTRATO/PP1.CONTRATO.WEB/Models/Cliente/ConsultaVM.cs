using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PP1.CONTRATO.WEB.Models.Cliente
{
    public class ConsultaVM
    {
        public int? idCliente { get; set; }
        public string nmCliente { get; set; }

        public int? id { get; set; }
        public string text { get; set; }

    }
}

