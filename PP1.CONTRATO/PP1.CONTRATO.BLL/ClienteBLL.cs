using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class ClienteBLL
    {

        private ClienteDAO objClienteDAO;

        public ClienteBLL()
        {
            objClienteDAO = new ClienteDAO();

        }

        public void create(Cliente objCliente)
        {
            bool verificacao = true;

            string nome = objCliente.nmCliente;
            if (nome == null)
            {

                return;
            }
            else
            {
                nome = objCliente.nmCliente.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {

                    return;
                }

            }

            objClienteDAO.Insert(objCliente);
            return;
        }


        public void update(Cliente objCliente)
        {
            bool verificacao = true;

            string codigo = objCliente.idCliente.ToString();
            long id = 0;
            if (codigo == null)
            {

                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objCliente.idCliente);
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
            objClienteDAO.Update(objCliente);
            return;
        }


        public Cliente find(int id)
        {
            return objClienteDAO.FindID(id);
        }

        public List<Cliente> findFilter(string filter)
        {
            return objClienteDAO.FindFilter(filter);
        }

        public List<Cliente> findAll()
        {
            return objClienteDAO.FindAll();
        }

        public static string Tipo(string flTipo)
        {
            if (flTipo == Cliente.TIPO_FISICA)
                return "FÍSICA";
            if (flTipo == Cliente.TIPO_JURIDICA)
                return "JURÍDICA";

            return flTipo;
        }
    }
}
