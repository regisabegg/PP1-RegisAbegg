using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class CidadeBLL
    {

        private CidadeDAO objCidadeDAO;

        public CidadeBLL()
        {
            objCidadeDAO = new CidadeDAO();

        }

        public void create(Cidade objCidade)
        {
            bool verificacao = true;

            string nome = objCidade.nmCidade;
            if (nome == null)
            {

                return;
            }
            else
            {
                nome = objCidade.nmCidade.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {

                    return;
                }

            }

            objCidadeDAO.Insert(objCidade);
            return;
        }


        public void update(Cidade objCidade)
        {
            bool verificacao = true;

            string codigo = objCidade.idCidade.ToString();
            long id = 0;
            if (codigo == null)
            {

                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCidade.idCidade);
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
            objCidadeDAO.Update(objCidade);
            return;
        }

        //public void delete(int id)
        //{
        //    bool verificacao = true;

        //    Cidade objCidadeAux = new Cidade();
        //    objCidadeAux.idCidade = objCidade.idCidade;
        //    verificacao = objCidadeDAO.FindID(objCidadeAux);
        //    if (!verificacao)
        //    {

        //        return;
        //    }


        //    //objCidade.Cidade = 99;
        //    objCidadeDAO.Delete(objCidade);
        //    return;
        //}

        //public void find(int id)
        //{
        //    return objCidadeDAO.FindID(obj);
        //}

        public List<Cidade> findAll()
        {
            return objCidadeDAO.FindAll();
        }
        //public List<Cidade> findAllCidades(Cidade objCidade)
        //{
        //    return objCidadeDAO.findAllCidade(objCidade);
        //}


        
    }
}
