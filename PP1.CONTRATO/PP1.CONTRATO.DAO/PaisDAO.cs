using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class PaisDAO : Inter<Pais>
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public PaisDAO()
        {
            objConexaoDB = ConexaoDB.saberEstado();
        }

        public void create(Pais objPais)
        {
            string create = "insert into pais(nmpais, dssigla, nrddi, dtcadastro, dtatualizacao) VALUES ('" + objPais.nmPais + "', '" + objPais.dsSigla + "' , '" + objPais.nrDDI + "' , '" + objPais.dtCadastro + "', '" + objPais.dtAtualizacao + "' )";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void delete(Pais objPais)
        {
            string delete = "delete from pais where idpais = '" + objPais.idPais + "' ";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //objPais.Estado = 1;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public void update(Pais objPais)
        {
            string update = "update pais set nmpais='" + objPais.nmPais + "', '" + objPais.dsSigla + "' , '" + objPais.nrDDI + "' , '" + objPais.dtCadastro + "', '" + objPais.dtAtualizacao + "' where idpais='" + objPais.idPais + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //objPais.Estado = 1;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }
        }

        public bool find(Pais objPais)
        {
            bool temRegistros;
            string find = "select * from pais where idpais  = '" + objPais.idPais + "' ";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objPais.nmPais = reader[1].ToString();
                    objPais.dsSigla = reader[2].ToString();
                    objPais.nrDDI = reader[3].ToString();
                    objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
                    objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());

                }
                else
                {
                    //objPais.Estado = 1;
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return temRegistros;
        }

        public List<Pais> findAll()
        {
            List<Pais> listaPaiss = new List<Pais>();
            string findAll = "select * from pais order by idpais";

            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pais objPais = new Pais();
                    objPais.idPais = Convert.ToInt32(reader[0].ToString());
                    objPais.nmPais = reader[1].ToString();
                    objPais.dsSigla = reader[2].ToString();
                    objPais.nrDDI = reader[3].ToString();
                    objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
                    objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
                    listaPaiss.Add(objPais);
                }

            }
            catch (Exception)
            {
                throw;

            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPaiss;
        }

        public List<Pais> findAllPais(Pais objPais)
        {
            List<Pais> listaPaiss = new List<Pais>();
            string findAll = "select* from pais where nmpais like '%" + objPais.nmPais + "%' or dssigla like '%" + objPais.dsSigla + "%' or idpais like '%" + objPais.idPais + "%' ";
            try
            {

                comando = new SqlCommand(findAll, objConexaoDB.getCon());
                objConexaoDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pais objPaiss = new Pais();
                    objPais.idPais = Convert.ToInt32(reader[0].ToString());
                    objPais.nmPais = reader[1].ToString();
                    objPais.dsSigla = reader[2].ToString();
                    objPais.nrDDI = reader[3].ToString();
                    objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
                    objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
                    listaPaiss.Add(objPais);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.getCon().Close();
                objConexaoDB.CloseDB();
            }

            return listaPaiss;

        }
    }
}
