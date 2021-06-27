using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class CondicaoPagtoBLL
    {

        private CondicaoPagtoDAO objCondicaoPagtoDAO;

        public CondicaoPagtoBLL()
        {
            objCondicaoPagtoDAO = new CondicaoPagtoDAO();

        }

        public void create(CondicaoPagto objCondicaoPagto)
        {
            bool verificacao = true;

            string nome = objCondicaoPagto.nmCondicaoPagto;
            if (nome == null)
            {
                
                return;
            }
            else
            {
                nome = objCondicaoPagto.nmCondicaoPagto.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                   
                    return;
                }

            }
           
            objCondicaoPagtoDAO.Insert(objCondicaoPagto);
            return;
        }

       
        public void update(CondicaoPagto objCondicaoPagto)
        {
            bool verificacao = true;
         
            string codigo = objCondicaoPagto.idCondicaoPagto.ToString();
            long id = 0;
            if (codigo == null)
            {
               
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCondicaoPagto.idCondicaoPagto);
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
            objCondicaoPagtoDAO.Update(objCondicaoPagto);
            return;
        }

        //public CondicaoPagto delete(int id)
        //{
        //    objCondicaoPagtoDAO.Delete(id);

        //    return (d);

        //}

        public CondicaoPagto find(int id)
        {
            return objCondicaoPagtoDAO.FindID(id);
        }

        public List<CondicaoPagto> findFilter(string filter)
        {
            return objCondicaoPagtoDAO.FindFilter(filter);
        }

        public List<CondicaoPagto> findAll()
        {
            return objCondicaoPagtoDAO.FindAll();
        }
       
    }
}
