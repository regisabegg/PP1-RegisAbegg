using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class ServicoBLL
    {

        private ServicoDAO objServicoDAO;

        public ServicoBLL()
        {
            objServicoDAO = new ServicoDAO();

        }

        public void create(Servico objServico)
        {
            bool verificacao = true;

            string nome = objServico.nmServico;
            if (nome == null)
            {
                
                return;
            }
            else
            {
                nome = objServico.nmServico.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                   
                    return;
                }

            }
           
            objServicoDAO.Insert(objServico);
            return;
        }

       
        public void update(Servico objServico)
        {
            bool verificacao = true;
         
            string codigo = objServico.idServico.ToString();
            long id = 0;
            if (codigo == null)
            {
               
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objServico.idServico);
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
            objServicoDAO.Update(objServico);
            return;
        }

        //public Servico delete(int id)
        //{
        //    objServicoDAO.Delete(id);

        //    return (d);

        //}

        public Servico find(int id)
        {
            return objServicoDAO.FindID(id);
        }

        public List<Servico> findFilter(string filter)
        {
            return objServicoDAO.FindFilter(filter);
        }

        public List<Servico> findAll()
        {
            return objServicoDAO.FindAll();
        }
       
    }
}
