using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class ServicoDAO : ConexaoDB
    {
        //Atributos
        //idServico, nmServico, dsSigla, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(Servico obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("insert into servico (nmservico, flsituacao, vlservico, dtcadastro, dtatualizacao ) values (@nmservico, @flsituacao,  @vlservico, @dtcadastro, @dtatualizacao )", Con);


                Cmd.Parameters.AddWithValue("@nmservico", obj.nmServico);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@vlservico", ((object)obj.vlServico) != DBNull.Value ? ((object)obj.vlServico) : 0);
                Cmd.Parameters.AddWithValue("@dtcadastro", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@dtatualizacao", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@idservico", obj.idServico);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o Servico: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(Servico obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("update servico set nmServico=@nmservico, flsituacao=@flsituacao, vlservico=@vlservico, dtcadastro=@dtcadastro, dtatualizacao=@dtatualizacao where idservico = @idservico", Con);

                Cmd.Parameters.AddWithValue("@nmservico", obj.nmServico);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@vlservico", obj.vlServico);
                Cmd.Parameters.AddWithValue("@dtcadastro", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@dtatualizacao", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@idservico", obj.idServico);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o Servico: " + ex.Message);
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
                Cmd = new SqlCommand("delete from servico where idservico = @idservico", Con);

                Cmd.Parameters.AddWithValue("@idservico", id);



                return Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o Servico: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public Servico FindID(int? id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from servico where idservico=@idservico", Con);
                Cmd.Parameters.AddWithValue("@idservico", id);
                Dr = Cmd.ExecuteReader();


                Servico obj = null;
                if (Dr.Read())
                {
                    obj = new Servico();

                    obj.idServico = Convert.ToInt32(Dr["idservico"]);
                    obj.nmServico = Convert.ToString(Dr["nmservico"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.vlServico = Convert.ToInt32(Dr["vlservico"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);



                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Servico: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<Servico> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from servico where nmservico like @nmservico", Con);
                Cmd.Parameters.AddWithValue("@nmservico", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<Servico> list = new List<Servico>();


                while (Dr.Read())
                {
                    Servico obj = new Servico();

                    obj.idServico = Convert.ToInt32(Dr["idservico"]);
                    obj.nmServico = Convert.ToString(Dr["nmservico"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.vlServico = Convert.ToInt32(Dr["vlservico"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }

                return list;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Servico: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        //Método para localizar todos os dados
        public List<Servico> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from servico", Con);
                Dr = Cmd.ExecuteReader();

                List<Servico> list = new List<Servico>();


                while (Dr.Read())
                {
                    Servico obj = new Servico();

                    obj.idServico = Convert.ToInt32(Dr["idservico"]);
                    obj.nmServico = Convert.ToString(Dr["nmservico"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.vlServico = Convert.ToInt32(Dr["vlservico"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Servico: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }
    }
}
