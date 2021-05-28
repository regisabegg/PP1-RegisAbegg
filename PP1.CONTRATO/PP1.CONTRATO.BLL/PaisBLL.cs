using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class PaisBLL
    {

        private PaisDAO objPaisDAO;

        public PaisBLL()
        {
            objPaisDAO = new PaisDAO();

        }

        public void create(Pais objPais)
        {
            bool verificacao = true;

            string nome = objPais.nmPais;
            if (nome == null)
            {
                
                return;
            }
            else
            {
                nome = objPais.nmPais.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                   
                    return;
                }

            }
           
            objPaisDAO.Insert(objPais);
            return;
        }

       
        public void update(Pais objPais)
        {
            bool verificacao = true;
         
            string codigo = objPais.idPais.ToString();
            long id = 0;
            if (codigo == null)
            {
               
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objPais.idPais);
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
            objPaisDAO.Update(objPais);
            return;
        }

        //public void delete(int id)
        //{
        //    bool verificacao = true;

        //    Pais objPaisAux = new Pais();
        //    objPaisAux.idPais = objPais.idPais;
        //    verificacao = objPaisDAO.FindID(objPaisAux);
        //    if (!verificacao)
        //    {

        //        return;
        //    }


        //    //objPais.Estado = 99;
        //    objPaisDAO.Delete(objPais);
        //    return;
        //}

        public Pais find(int id)
        {
            return objPaisDAO.FindID(id);
        }

        public List<Pais> findAll()
        {
            return objPaisDAO.FindAll();
        }
        //public List<Pais> findAllPaiss(Pais objPais)
        //{
        //    return objPaisDAO.findAllPais(objPais);
        //}
    }
}
