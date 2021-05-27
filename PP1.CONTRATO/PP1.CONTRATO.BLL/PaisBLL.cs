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
                //objPais.Estado = 20;
                return;
            }
            else
            {
                nome = objPais.nmPais.Trim();
                verificacao = nome.Length <= 50 && nome.Length > 0;
                if (!verificacao)
                {
                    //objPais.Estado = 2;
                    return;
                }



            }
            //end validar nome

            //    //inicio da validação do cpf
            //    string cpf = objPais.NrCPF;
            //    if (cpf == null)
            //    {
            //        //objPais.Estado = 50;
            //        return;
            //    }
            //    else
            //    {
            //        cpf = objPais.NrCPF.Trim();
            //        verificacao = cpf.Length <= 12 && cpf.Length > 10;
            //        if (!verificacao)
            //        {
            //            //objPais.Estado = 250;
            //            return;
            //        }

            //    }

            //    //fim da validãção do cpf

            //    //begin validar endereco retorna estado=6
            //    string endereco = objPais.Endereco;
            //    if (endereco == null)
            //    {
            //        objPais.Estado = 60;
            //        return;
            //    }
            //    else
            //    {
            //        endereco = objPais.Endereco.Trim();
            //        verificacao = endereco.Length <= 50 && endereco.Length > 0;
            //        if (!verificacao)
            //        {
            //            objPais.Estado = 6;
            //            return;
            //        }

            //    }
            //    //end validar endereco

            //    //begin validar telefone retorna estado=7
            //    string telefone = objPais.Telefone;
            //    if (telefone == null)
            //    {
            //        objPais.Estado = 70;
            //        return;
            //    }
            //    else
            //    {
            //        telefone = objPais.Telefone.Trim();
            //        verificacao = telefone.Length <= 15 && telefone.Length > 7;
            //        if (!verificacao)
            //        {
            //            objPais.Estado = 7;
            //            return;
            //        }

            //    }
            //    //end validar telefone

            //    //begin verificar duplicidade retorna estado=8
            //    Pais objPaisAux = new Pais();
            //    objPaisAux.IdPais = objPais.IdPais;
            //    verificacao = !objPaisDAO.find(objPaisAux);
            //    if (!verificacao)
            //    {
            //        objPais.Estado = 8;
            //        return;
            //    }
            //    //end validar duplicidade

            //    //begin verificar duplicidade cpf retorna estado=8
            //    Pais objPais1 = new Pais();
            //    objPais1.Cpf = objPais.Cpf;
            //    verificacao = !objPaisDAO.findPaisPorcpf(objPais1);
            //    if (!verificacao)
            //    {
            //        objPais.Estado = 9;
            //        return;
            //    }


            //    //se nao tem erro
            //    objPais.Estado = 99;
               objPaisDAO.create(objPais);
               return;
            }

        ////end validar duplicidade cpf

        public void update(Pais objPais)
        {
            bool verificacao = true;
            //begin validar codigo retorna estado=1
            string codigo = objPais.idPais.ToString();
            long id = 0;
            if (codigo == null)
            {
                //objPais.Estado = 10;
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
                        //objPais.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    //objPais.Estado = 100;
                    return;
                }

            }
            //end validar codigo


            ////begin validar nome retorna estado=2
            //string nome = objPais.Nome;
            //if (nome == null)
            //{
            //    objPais.Estado = 20;
            //    return;
            //}
            //else
            //{
            //    nome = objPais.Nome.Trim();
            //    verificacao = nome.Length <= 30 && nome.Length > 0;
            //    if (!verificacao)
            //    {
            //        objPais.Estado = 2;
            //        return;
            //    }

            //}
            ////end validar nome




            ////inicio da validação do cpf
            //string cpf = objPais.Cpf;
            //if (cpf == null)
            //{
            //    objPais.Estado = 50;
            //    return;
            //}
            //else
            //{
            //    cpf = objPais.Cpf.Trim();
            //    verificacao = cpf.Length <= 12 && cpf.Length > 10;
            //    if (!verificacao)
            //    {
            //        objPais.Estado = 250;
            //        return;
            //    }

            //}

            ////fim da validãção do cpf



            ////begin validar endereço retorna estado=6
            //string endereco = objPais.Endereco;
            //if (endereco == null)
            //{
            //    objPais.Estado = 60;
            //    return;
            //}
            //else
            //{
            //    endereco = objPais.Endereco.Trim();
            //    verificacao = endereco.Length <= 50 && endereco.Length > 0;
            //    if (!verificacao)
            //    {
            //        objPais.Estado = 6;
            //        return;
            //    }

            //}
            ////end validar endereco

            ////begin validar telefone retorna estado=7
            //string telefone = objPais.Telefone;
            //if (telefone == null)
            //{
            //    objPais.Estado = 70;
            //    return;
            //}
            //else
            //{
            //    telefone = objPais.Telefone.Trim();
            //    verificacao = telefone.Length <= 30 && telefone.Length > 0;
            //    if (!verificacao)
            //    {
            //        //objPais.Estado = 7;
            //        return;
            //    }

            //}
            ////end validar telefone



            //se nao tem erro
            //objPais.Estado = 99;
            objPaisDAO.update(objPais);
            return;
        }

        //public void delete(Pais objPais)
        //{
        //    bool verificacao = true;
        //    //verificando se existe
        //    Pais objPaisAux = new Pais();
        //    objPaisAux.IdPais = objPais.IdPais;
        //    verificacao = objPaisDAO.find(objPaisAux);
        //    if (!verificacao)
        //    {
        //        objPais.Estado = 33;
        //        return;
        //    }


        //    //objPais.Estado = 99;
        //    objPaisDAO.delete(objPais);
        //    return;
        //}

        public bool find(Pais objPais)
        {
            return objPaisDAO.find(objPais);
        }

        public List<Pais> findAll()
        {
            return objPaisDAO.findAll();
        }
        public List<Pais> findAllPaiss(Pais objPais)
        {
            return objPaisDAO.findAllPais(objPais);
        }
    }
}
