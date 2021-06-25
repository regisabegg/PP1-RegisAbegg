using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class FormaPagtoBLL
    {

        private FormaPagtoDAO objFormaPagtoDAO;

        public FormaPagtoBLL()
        {
            objFormaPagtoDAO = new FormaPagtoDAO();

        }

        public void create(FormaPagto objFormaPagto)
        {
            bool verificacao = true;

            string nome = objFormaPagto.nmFormaPagto;
            if (nome == null)
            {
                
                return;
            }
            else
            {
                nome = objFormaPagto.nmFormaPagto.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                   
                    return;
                }

            }
           
            objFormaPagtoDAO.Insert(objFormaPagto);
            return;
        }

       
        public void update(FormaPagto objFormaPagto)
        {
            bool verificacao = true;
         
            string codigo = objFormaPagto.idFormaPagto.ToString();
            long id = 0;
            if (codigo == null)
            {
               
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objFormaPagto.idFormaPagto);
                    verificacao = codigo.Length > 0 && codigo.Length < 999999;


                    if (!verificacao)
                    {
                       
                        return;
                    }
                }
                catch (Exception)
                {
                    
                    return;
                }

            }
           ;
            objFormaPagtoDAO.Update(objFormaPagto);
            return;
        }

        //public FormaPagto delete(int id)
        //{
        //    objFormaPagtoDAO.Delete(id);

        //    return (d);

        //}

        public FormaPagto find(int id)
        {
            return objFormaPagtoDAO.FindID(id);
        }

        public List<FormaPagto> findFilter(string filter)
        {
            return objFormaPagtoDAO.FindFilter(filter);
        }

        public List<FormaPagto> findAll()
        {
            return objFormaPagtoDAO.FindAll();
        }
       
    }
}
