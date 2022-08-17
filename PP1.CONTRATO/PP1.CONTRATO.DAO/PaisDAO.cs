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
                findInsert(obj.nmPais, obj.idPais);

                OpenConection();
                Cmd = new SqlCommand("insert into pais (nmPais, dsSigla, nrDDI, dtCadastro, dtAtualizacao ) values (@nmPais, @dsSigla, @nrDDI, @dtCadastro, @dtAtualizacao)", Con);

                Cmd.Parameters.AddWithValue("@nmPais", obj.nmPais);
                Cmd.Parameters.AddWithValue("@dsSigla", obj.dsSigla ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrDDI", obj.nrDDI ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtCadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtAtualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);

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
                findInsert(obj.nmPais, obj.idPais);

                OpenConection();
                Cmd = new SqlCommand("update pais set nmPais=@nmPais, dsSigla=@dsSigla, nrDDI=@nrDDI, dtAtualizacao=@dtAtualizacao where idpais = @idPais", Con);

                Cmd.Parameters.AddWithValue("@nmPais", obj.nmPais);
                Cmd.Parameters.AddWithValue("@dsSigla", obj.dsSigla ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrDDI", obj.nrDDI ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtCadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtAtualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);

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
        public int Delete(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("delete from pais where idpais = @idPais", Con);

                Cmd.Parameters.AddWithValue("@idPais", id);



                return Cmd.ExecuteNonQuery();

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
        public Pais FindID(int? id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from pais where idpais=@idPais", Con);
                Cmd.Parameters.AddWithValue("@idPais", id);
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
        public List<Pais> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from pais where nmpais like @v1 or dssigla like @v2 or  nrddi like @v3", Con);
                Cmd.Parameters.AddWithValue("@v1", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v2", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v3", "%" + filter + "%");
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


        public void findInsert(string text, int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from pais where nmpais=@v1 and idpais<>@v2", Con);
                Cmd.Parameters.AddWithValue("@v1", text);
                Cmd.Parameters.AddWithValue("@v2", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();


                    obj.nmPais = Convert.ToString(Dr["nmpais"]);
                    throw new Exception("Já existe um país cadastrado com esse nome, verifique!");

                }
            }           
            finally
            {
                CloseConection();
            }
        }
    }
}
