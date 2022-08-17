using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class CidadeDAO : ConexaoDB
    {

        //Atributos
        //idCidade, nmCidade, dsUF, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(Cidade obj)
        {
            try
            {
                findInsert(obj.nmCidade, obj.idCidade);

                OpenConection();
                Cmd = new SqlCommand("insert into cidade (nmcidade, nrddd, nribge, dtcadastro, dtatualizacao, idestado ) " +
                                     "values (@nmCidade, @nrDDD, @nrIBGE, @dtCadastro, @dtAtualizacao, @idEstado)", Con);

                Cmd.Parameters.AddWithValue("@nmCidade", obj.nmCidade);
                Cmd.Parameters.AddWithValue("@nrDDD", obj.nrDDD ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrIBGE", obj.nrIBGE ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtCadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtAtualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idEstado", ((object)obj.idEstado) ?? DBNull.Value);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o Cidade: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(Cidade obj)
        {
            try
            {
                findInsert(obj.nmCidade, obj.idCidade);

                OpenConection();
                Cmd = new SqlCommand("update cidade set nmcidade=@nmCidade, nrddd=@nrDDD,  nribge=@nrIBGE, dtcadastro=@dtCadastro," +
                                     " dtatualizacao=@dtAtualizacao, idestado=@idEstado where idcidade = @idCidade", Con);

                Cmd.Parameters.AddWithValue("@nmCidade", obj.nmCidade);
                Cmd.Parameters.AddWithValue("@nrDDD", obj.nrDDD ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrIBGE", obj.nrIBGE ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtCadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtAtualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idEstado", ((object)obj.idEstado) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idCidade", ((object)obj.idCidade) ?? DBNull.Value);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar a Cidade: " + ex.Message);
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
                Cmd = new SqlCommand("delete from cidade where idcidade = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", id);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir a Cidade: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public Cidade FindID(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cidade where idcidade=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();

                Cidade obj = null;
                if (Dr.Read())
                {
                    obj = new Cidade();

                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    obj.nmCidade = Convert.ToString(Dr["nmcidade"]);
                    obj.nrDDD = Convert.ToString(Dr["nrddd"]);
                    obj.nrIBGE = Convert.ToString(Dr["nribge"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
                    obj.idEstado = Convert.ToInt32(Dr["idestado"]);
                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar a Cidade: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        public List<Cidade> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cidade where nmcidade like @v1 or nrddd like @v2 ", Con);
                Cmd.Parameters.AddWithValue("@v1", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v2", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<Cidade> list = new List<Cidade>();


                while (Dr.Read())
                {
                    Cidade obj = new Cidade();

                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    obj.nmCidade = Convert.ToString(Dr["nmcidade"]);
                    obj.nrDDD = Convert.ToString(Dr["nrddd"]);
                    obj.nrIBGE = Convert.ToString(Dr["nribge"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
                    obj.idEstado = Convert.ToInt32(Dr["idestado"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar a Cidade: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        //Método para localizar todos os dados
        public List<Cidade> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cidade", Con);
                Dr = Cmd.ExecuteReader();

                List<Cidade> list = new List<Cidade>();

                while (Dr.Read())
                {
                    Cidade obj = new Cidade();

                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                    obj.nmCidade = Convert.ToString(Dr["nmcidade"]);
                    obj.nrDDD = Convert.ToString(Dr["nrddd"]);
                    obj.nrIBGE = Convert.ToString(Dr["nribge"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
                    obj.idEstado = Convert.ToInt32(Dr["idestado"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar a Cidade: " + ex.Message);
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
                Cmd = new SqlCommand("select * from cidade where nmcidade=@v1 and idcidade <> @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", text);
                Cmd.Parameters.AddWithValue("@v2", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();


                    obj.nmPais = Convert.ToString(Dr["nmcidade"]);
                    throw new Exception("Já existe uma cidade cadastrada com esse nome, verifique!");

                }
            }
            finally
            {
                CloseConection();
            }
        }

    }
}
