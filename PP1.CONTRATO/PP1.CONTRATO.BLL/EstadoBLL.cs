using PP1.CONTRATO.DAO;
using PP1.CONTRATO.Entity;
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
                //objEstado.Estado = 20;
                return;
            }
            else
            {
                nome = objEstado.nmEstado.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    //objEstado.Estado = 2;
                    return;
                }



            }
            //end validar nome

            //    //inicio da validação do cpf
            //    string cpf = objEstado.NrCPF;
            //    if (cpf == null)
            //    {
            //        //objEstado.Estado = 50;
            //        return;
            //    }
            //    else
            //    {
            //        cpf = objEstado.NrCPF.Trim();
            //        verificacao = cpf.Length <= 12 && cpf.Length > 10;
            //        if (!verificacao)
            //        {
            //            //objEstado.Estado = 250;
            //            return;
            //        }

            //    }

            //    //fim da validãção do cpf

            //    //begin validar endereco retorna estado=6
            //    string endereco = objEstado.Endereco;
            //    if (endereco == null)
            //    {
            //        objEstado.Estado = 60;
            //        return;
            //    }
            //    else
            //    {
            //        endereco = objEstado.Endereco.Trim();
            //        verificacao = endereco.Length <= 50 && endereco.Length > 0;
            //        if (!verificacao)
            //        {
            //            objEstado.Estado = 6;
            //            return;
            //        }

            //    }
            //    //end validar endereco

            //    //begin validar telefone retorna estado=7
            //    string telefone = objEstado.Telefone;
            //    if (telefone == null)
            //    {
            //        objEstado.Estado = 70;
            //        return;
            //    }
            //    else
            //    {
            //        telefone = objEstado.Telefone.Trim();
            //        verificacao = telefone.Length <= 15 && telefone.Length > 7;
            //        if (!verificacao)
            //        {
            //            objEstado.Estado = 7;
            //            return;
            //        }

            //    }
            //    //end validar telefone

            //    //begin verificar duplicidade retorna estado=8
            //    Estado objEstadoAux = new Estado();
            //    objEstadoAux.IdEstado = objEstado.IdEstado;
            //    verificacao = !objEstadoDAO.find(objEstadoAux);
            //    if (!verificacao)
            //    {
            //        objEstado.Estado = 8;
            //        return;
            //    }
            //    //end validar duplicidade

            //    //begin verificar duplicidade cpf retorna estado=8
            //    Estado objEstado1 = new Estado();
            //    objEstado1.Cpf = objEstado.Cpf;
            //    verificacao = !objEstadoDAO.findEstadoPorcpf(objEstado1);
            //    if (!verificacao)
            //    {
            //        objEstado.Estado = 9;
            //        return;
            //    }


            //    //se nao tem erro
            //    objEstado.Estado = 99;
               objEstadoDAO.create(objEstado);
               return;
            }

            ////end validar duplicidade cpf

            //public void update(Estado objEstado)
            //{
            //    bool verificacao = true;
            //    //begin validar codigo retorna estado=1
            //    string codigo = objEstado.IdEstado.ToString();
            //    long id = 0;
            //    if (codigo == null)
            //    {
            //        objEstado.Estado = 10;
            //        return;
            //    }
            //    else
            //    {
            //        try
            //        {
            //            id = Convert.ToInt64(objEstado.IdEstado);
            //            verificacao = codigo.Length > 0 && codigo.Length < 999999;


            //            if (!verificacao)
            //            {
            //                objEstado.Estado = 1;
            //                return;
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            objEstado.Estado = 100;
            //            return;
            //        }

            //    }
            //    //end validar codigo


            //    //begin validar nome retorna estado=2
            //    string nome = objEstado.Nome;
            //    if (nome == null)
            //    {
            //        objEstado.Estado = 20;
            //        return;
            //    }
            //    else
            //    {
            //        nome = objEstado.Nome.Trim();
            //        verificacao = nome.Length <= 30 && nome.Length > 0;
            //        if (!verificacao)
            //        {
            //            objEstado.Estado = 2;
            //            return;
            //        }

            //    }
            //    //end validar nome




            //    //inicio da validação do cpf
            //    string cpf = objEstado.Cpf;
            //    if (cpf == null)
            //    {
            //        objEstado.Estado = 50;
            //        return;
            //    }
            //    else
            //    {
            //        cpf = objEstado.Cpf.Trim();
            //        verificacao = cpf.Length <= 12 && cpf.Length > 10;
            //        if (!verificacao)
            //        {
            //            objEstado.Estado = 250;
            //            return;
            //        }

            //    }

            //    //fim da validãção do cpf



            //    //begin validar endereço retorna estado=6
            //    string endereco = objEstado.Endereco;
            //    if (endereco == null)
            //    {
            //        objEstado.Estado = 60;
            //        return;
            //    }
            //    else
            //    {
            //        endereco = objEstado.Endereco.Trim();
            //        verificacao = endereco.Length <= 50 && endereco.Length > 0;
            //        if (!verificacao)
            //        {
            //            objEstado.Estado = 6;
            //            return;
            //        }

            //    }
            //    //end validar endereco

            //    //begin validar telefone retorna estado=7
            //    string telefone = objEstado.Telefone;
            //    if (telefone == null)
            //    {
            //        objEstado.Estado = 70;
            //        return;
            //    }
            //    else
            //    {
            //        telefone = objEstado.Telefone.Trim();
            //        verificacao = telefone.Length <= 30 && telefone.Length > 0;
            //        if (!verificacao)
            //        {
            //            //objEstado.Estado = 7;
            //            return;
            //        }

            //    }
            //    //end validar telefone



            //se nao tem erro
            //objEstado.Estado = 99;
            //objEstadoDAO.update(objEstado);
            //return;
        //}

        //public void delete(Estado objEstado)
        //{
        //    bool verificacao = true;
        //    //verificando se existe
        //    Estado objEstadoAux = new Estado();
        //    objEstadoAux.IdEstado = objEstado.IdEstado;
        //    verificacao = objEstadoDAO.find(objEstadoAux);
        //    if (!verificacao)
        //    {
        //        objEstado.Estado = 33;
        //        return;
        //    }


        //    //objEstado.Estado = 99;
        //    objEstadoDAO.delete(objEstado);
        //    return;
        //}

        public bool find(Estado objEstado)
        {
            return objEstadoDAO.find(objEstado);
        }

        public List<Estado> findAll()
        {
            return objEstadoDAO.findAll();
        }
        public List<Estado> findAllEstados(Estado objEstado)
        {
            return objEstadoDAO.findAllEstado(objEstado);
        }
    }
}
