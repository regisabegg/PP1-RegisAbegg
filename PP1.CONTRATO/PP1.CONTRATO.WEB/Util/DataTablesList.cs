using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Util
{

    public class DataTablesList<T>
    {
        public DataTablesList() { }
        public DataTablesList(List<T> itens)
        {
            Set = itens;
        }
        public string js { get; set; }

        public List<T> Get
        {
            get
            {
                if (string.IsNullOrEmpty(js))
                    return new List<T>();
                try
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(js, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                }
                catch (Exception)
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(js, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm" });
                }
            }
        }

        public List<T> Set
        {
            set
            {
                js = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }
    }
}