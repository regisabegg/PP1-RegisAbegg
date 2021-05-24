using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PP1.CONTRATO.WEB.Util.DataTables
{
    public static class DataTablesHelper
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, ColumnCollection columns, int start, int length)
        {
            string orderExpression = string.Empty;

            foreach (var column in columns.GetSortedColumns().OrderBy(p => p.OrderNumber))
            {
                if (column.SortDirection == Column.OrderDirection.Ascendant)
                    orderExpression += string.Format("{0} {1}, ", column.Data, "ascending");
                else
                    orderExpression += string.Format("{0} {1}, ", column.Data, "descending");
            }
            if (!string.IsNullOrEmpty(orderExpression))
            {
                query = query.OrderBy(orderExpression.TrimEnd(new char[] { ',', ' ' }));
            }
            else
            {
                var column = columns.Where(u => u.Orderable == true).FirstOrDefault();
                if (column == null)
                {
                    column = columns.FirstOrDefault();
                }
                var expresionFixed = string.Format("{0} {1}, ", column.Data, "ascending");
                query = query.OrderBy(expresionFixed.TrimEnd(new char[] { ',', ' ' }));
            }

            //paginacao
            if(length <= 0)
            {
                length = query.Count();
            }
            return query.Skip(start).Take(length);
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> query, ColumnCollection columns, int start, int length)
        {
            string orderExpression = string.Empty;

            foreach (var column in columns.GetSortedColumns().OrderBy(p => p.OrderNumber))
            {
                if (column.SortDirection == Column.OrderDirection.Ascendant)
                    orderExpression += string.Format("{0} {1}, ", column.Data, "ascending");
                else
                    orderExpression += string.Format("{0} {1}, ", column.Data, "descending");
            }
            if (!string.IsNullOrEmpty(orderExpression))
            {
                query = query.OrderBy(orderExpression.TrimEnd(new char[] { ',', ' ' }));
            }
            else
            {
                var column = columns.Where(u => u.Orderable == true).FirstOrDefault();
                if (column == null)
                {
                    column = columns.FirstOrDefault();
                }
                var expresionFixed = string.Format("{0} {1}, ", column.Data, "ascending");
                query = query.OrderBy(expresionFixed.TrimEnd(new char[] { ',', ' ' }));
            }

            //paginacao
            return query.Skip(start).Take(length);
        }
        public static IList<T> OrderBy<T>(this IList<T> query, ColumnCollection columns, int start, int length)
        {
            string orderExpression = string.Empty;

            foreach (var column in columns.GetSortedColumns().OrderBy(p => p.OrderNumber))
            {
                if (column.SortDirection == Column.OrderDirection.Ascendant)
                    orderExpression += string.Format("{0} {1}, ", column.Data, "ascending");
                else
                    orderExpression += string.Format("{0} {1}, ", column.Data, "descending");
            }

            //paginacao
            return query;
        }
    }
}