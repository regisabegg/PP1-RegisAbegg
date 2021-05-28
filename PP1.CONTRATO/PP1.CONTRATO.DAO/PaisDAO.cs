using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class PaisDAO : ConexaoDB
    {
        //Atributos
        //idPais, nmPais, dsSigla, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(Pais obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("insert into pais (nmPais, dsSigla, nrDDI, dtCadastro, dtAtualizacao ) values (@v1, @v2, @v3, @v4, @v5)", Con);

                Cmd.Parameters.AddWithValue("@v1", obj.nmPais);
                Cmd.Parameters.AddWithValue("@v2", obj.dsSigla);
                Cmd.Parameters.AddWithValue("@v3", obj.nrDDI);
                Cmd.Parameters.AddWithValue("@v4", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@v5", obj.dtAtualizacao);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o País: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(Pais obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("update pais set nmPais=@v1, dsSigla=@v2, nrDDI=@v3, dtCadastro=@v4, dtAtualizacao=@v5 where idpais = @v6", Con);

                Cmd.Parameters.AddWithValue("@v1", obj.nmPais);
                Cmd.Parameters.AddWithValue("@v2", obj.dsSigla);
                Cmd.Parameters.AddWithValue("@v3", obj.nrDDI);
                Cmd.Parameters.AddWithValue("@v4", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@v5", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@v6", obj.idPais);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o País: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para ecluir dados
        public void Delete(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("delete from pais where idpais = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", id);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o País: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public Pais FindID(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from pais where idpais=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();

                    obj.idPais = Convert.ToInt32(Dr["idpais"]);
                    obj.nmPais = Convert.ToString(Dr["nmPais"]);
                    obj.dsSigla = Convert.ToString(Dr["dsSigla"]);
                    obj.nrDDI = Convert.ToString(Dr["nrDDI"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtCadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtAtualizacao"]);
                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o País: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<Pais> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from pais", Con);
                Dr = Cmd.ExecuteReader();

                List<Pais> list = new List<Pais>();


                while (Dr.Read())
                {
                    Pais obj = new Pais();

                    obj.idPais = Convert.ToInt32(Dr["idpais"]);
                    obj.nmPais = Convert.ToString(Dr["nmPais"]);
                    obj.dsSigla = Convert.ToString(Dr["dsSigla"]);
                    obj.nrDDI = Convert.ToString(Dr["nrDDI"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtCadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtAtualizacao"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o País: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        #region connectionOld
        //private ConexaoDB objConexaoDB;
        //private SqlCommand comando;

        //public PaisDAO()
        //{
        //    objConexaoDB = ConexaoDB.saberEstado();
        //}

        //public void create(Pais objPais)
        //{
        //    string create = "insert into pais(nmpais, dssigla, nrddi, dtcadastro, dtatualizacao) VALUES ('" + objPais.nmPais + "', '" + objPais.dsSigla + "' , '" + objPais.nrDDI + "' , '" + objPais.dtCadastro + "', '" + objPais.dtAtualizacao + "' )";
        //    try
        //    {
        //        comando = new SqlCommand(create, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public void delete(Pais objPais)
        //{
        //    string delete = "delete from pais where idpais = '" + objPais.idPais + "' ";
        //    try
        //    {
        //        comando = new SqlCommand(delete, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        //objPais.Estado = 1;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public void update(Pais objPais)
        //{
        //    string update = "update pais set nmpais='" + objPais.nmPais + "', '" + objPais.dsSigla + "' , '" + objPais.nrDDI + "' , '" + objPais.dtCadastro + "', '" + objPais.dtAtualizacao + "' where idpais='" + objPais.idPais + "'";
        //    try
        //    {
        //        comando = new SqlCommand(update, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        //objPais.Estado = 1;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public bool find(Pais objPais)
        //{
        //    bool temRegistros;
        //    string find = "select * from pais where idpais  = '" + objPais.idPais + "' ";
        //    try
        //    {
        //        comando = new SqlCommand(find, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        temRegistros = reader.Read();
        //        if (temRegistros)
        //        {
        //            objPais.nmPais = reader[1].ToString();
        //            objPais.dsSigla = reader[2].ToString();
        //            objPais.nrDDI = reader[3].ToString();
        //            objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());

        //        }
        //        else
        //        {
        //            //objPais.Estado = 1;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return temRegistros;
        //}

        //public List<Pais> findAll()
        //{
        //    List<Pais> listaPaiss = new List<Pais>();
        //    string findAll = "select * from pais order by idpais";

        //    try
        //    {
        //        comando = new SqlCommand(findAll, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Pais objPais = new Pais();
        //            objPais.idPais = Convert.ToInt32(reader[0].ToString());
        //            objPais.nmPais = reader[1].ToString();
        //            objPais.dsSigla = reader[2].ToString();
        //            objPais.nrDDI = reader[3].ToString();
        //            objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
        //            listaPaiss.Add(objPais);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return listaPaiss;
        //}

        //public List<Pais> findAllPais(Pais objPais)
        //{
        //    List<Pais> listaPaiss = new List<Pais>();
        //    string findAll = "select* from pais where nmpais like '%" + objPais.nmPais + "%' or dssigla like '%" + objPais.dsSigla + "%' or idpais like '%" + objPais.idPais + "%' ";
        //    try
        //    {

        //        comando = new SqlCommand(findAll, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Pais objPaiss = new Pais();
        //            objPais.idPais = Convert.ToInt32(reader[0].ToString());
        //            objPais.nmPais = reader[1].ToString();
        //            objPais.dsSigla = reader[2].ToString();
        //            objPais.nrDDI = reader[3].ToString();
        //            objPais.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objPais.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
        //            listaPaiss.Add(objPais);

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return listaPaiss;

        //}
        #endregion
    }
}
