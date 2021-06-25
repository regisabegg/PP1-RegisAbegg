using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class FornecedorBLL
    {

        private FornecedorDAO objFornecedorDAO;

        public FornecedorBLL()
        {
            objFornecedorDAO = new FornecedorDAO();

        }

        public void create(Fornecedor objFornecedor)
        {
            bool verificacao = true;

            string nome = objFornecedor.nmFornecedor;
            if (nome == null)
            {

                return;
            }
            else
            {
                nome = objFornecedor.nmFornecedor.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {

                    return;
                }

            }

            objFornecedorDAO.Insert(objFornecedor);
            return;
        }


        public void update(Fornecedor objFornecedor)
        {
            bool verificacao = true;

            string codigo = objFornecedor.idFornecedor.ToString();
            long id = 0;
            if (codigo == null)
            {

                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objFornecedor.idFornecedor);
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
            objFornecedorDAO.Update(objFornecedor);
            return;
        }


        public Fornecedor find(int id)
        {
            return objFornecedorDAO.FindID(id);
        }

        public List<Fornecedor> findFilter(string filter)
        {
            return objFornecedorDAO.FindFilter(filter);
        }

        public List<Fornecedor> findAll()
        {
            return objFornecedorDAO.FindAll();
        }

        public static string Tipo(string flTipo)
        {
            if (flTipo == Fornecedor.TIPO_FISICA)
                return "FÍSICO";
            if (flTipo == Fornecedor.TIPO_JURIDICA)
                return "JURÍRIDICO";

            return flTipo;
        }
    }
}
