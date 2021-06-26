using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;

namespace PP1.CONTRATO.BLL
{
    public class FuncionarioBLL
    {

        private FuncionarioDAO objFuncionarioDAO;

        public FuncionarioBLL()
        {
            objFuncionarioDAO = new FuncionarioDAO();

        }

        public void create(Funcionario objFuncionario)
        {
            bool verificacao = true;

            string nome = objFuncionario.nmFuncionario;
            if (nome == null)
            {

                return;
            }
            else
            {
                nome = objFuncionario.nmFuncionario.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {

                    return;
                }

            }

            objFuncionarioDAO.Insert(objFuncionario);
            return;
        }


        public void update(Funcionario objFuncionario)
        {
            bool verificacao = true;

            string codigo = objFuncionario.idFuncionario.ToString();
            long id = 0;
            if (codigo == null)
            {

                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objFuncionario.idFuncionario);
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
            objFuncionarioDAO.Update(objFuncionario);
            return;
        }


        public Funcionario find(int id)
        {
            return objFuncionarioDAO.FindID(id);
        }

        public List<Funcionario> findFilter(string filter)
        {
            return objFuncionarioDAO.FindFilter(filter);
        }

        public List<Funcionario> findAll()
        {
            return objFuncionarioDAO.FindAll();
        }

        public static string Tipo(string flTipo)
        {
            if (flTipo == Funcionario.TIPO_FISICA)
                return "FÍSICO";
            if (flTipo == Funcionario.TIPO_JURIDICA)
                return "JURÍRIDICO";

            return flTipo;
        }
    }
}
