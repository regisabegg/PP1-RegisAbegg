using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP1.CONTRATO.WEB.Util
{ 

    public class JsonSelect<T>
    {
        public JsonSelect() { }

        public JsonSelect(IQueryable<T> query, int? page, int? pageSize)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;

            totalCount = query.Count();
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            more = (page * pageSize) < totalCount;

            results = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
        }

        public List<T> results { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
        public bool more { get; set; }
    }

}