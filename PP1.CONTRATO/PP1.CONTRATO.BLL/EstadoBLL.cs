using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class EstadoBLL
    {

        private EstadoDAO objEstadoDAO;

        public EstadoBLL()
        {
            objEstadoDAO = new EstadoDAO();

        }

        public void create(Estado objEstado)
        {
            bool verificacao = true;

            string nome = objEstado.nmEstado;
            if (nome == null)
            {

                return;
            }
            else
            {
                nome = objEstado.nmEstado.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {

                    return;
                }

            }

            objEstadoDAO.Insert(objEstado);
            return;
        }


        public void update(Estado objEstado)
        {
            bool verificacao = true;

            string codigo = objEstado.idEstado.ToString();
            long id = 0;
            if (codigo == null)
            {

                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objEstado.idEstado);
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
            objEstadoDAO.Update(objEstado);
            return;
        }

        //public void delete(int id)
        //{
        //    bool verificacao = true;

        //    Estado objEstadoAux = new Estado();
        //    objEstadoAux.idEstado = objEstado.idEstado;
        //    verificacao = objEstadoDAO.FindID(objEstadoAux);
        //    if (!verificacao)
        //    {

        //        return;
        //    }


        //    //objEstado.Estado = 99;
        //    objEstadoDAO.Delete(objEstado);
        //    return;
        //}

        //public void find(int id)
        //{
        //    return objEstadoDAO.FindID(obj);
        //}

        public List<Estado> findAll()
        {
            return objEstadoDAO.FindAll();
        }
        //public List<Estado> findAllEstados(Estado objEstado)
        //{
        //    return objEstadoDAO.findAllEstado(objEstado);
        //}
    }
}
