using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class FormaPagtoDAO : ConexaoDB
    {
        //Atributos
        //idFormaPagto, nmFormaPagto, dsSigla, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(FormaPagto obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("insert into formapagto (nmformapagto, flsituacao, dtcadastro, dtatualizacao ) values (@nmformapagto, @flsituacao, @dtcadastro, @dtatualizacao )", Con);

                Cmd.Parameters.AddWithValue("@nmformapagto", obj.nmFormaPagto);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@dtcadastro", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@dtatualizacao", obj.dtAtualizacao);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o Forma de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(FormaPagto obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("update formapagto set nmFormaPagto=@nmformapagto, flsituacao=@flsituacao, dtcadastro=@dtcadastro, dtatualizacao=@dtatualizacao where idformapagto = @idformapagto", Con);

                Cmd.Parameters.AddWithValue("@nmformapagto", obj.nmFormaPagto);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@dtcadastro", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@dtatualizacao", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@idformapagto", obj.idFormaPagto);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o Forma de pagamento: " + ex.Message);
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
                Cmd = new SqlCommand("delete from formapagto where idformapagto = @idformapagto", Con);

                Cmd.Parameters.AddWithValue("@idformapagto", id);

                
              
                return Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o Forma de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public FormaPagto FindID(int? id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from formapagto where idformapagto=@idformapagto", Con);
                Cmd.Parameters.AddWithValue("@idformapagto", id);
                Dr = Cmd.ExecuteReader();


                FormaPagto obj = null;
                if (Dr.Read())
                {
                    obj = new FormaPagto();

                    obj.idFormaPagto = Convert.ToInt32(Dr["idformapagto"]);
                    obj.nmFormaPagto = Convert.ToString(Dr["nmformapagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Forma de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<FormaPagto> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from formapagto where nmformapagto like @nmformapagto", Con);
                Cmd.Parameters.AddWithValue("@nmformapagto", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<FormaPagto> list = new List<FormaPagto>();


                while (Dr.Read())
                {
                    FormaPagto obj = new FormaPagto();

                    obj.idFormaPagto = Convert.ToInt32(Dr["idformapagto"]);
                    obj.nmFormaPagto = Convert.ToString(Dr["nmformapagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }

                return list;
                

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Forma de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        //Método para localizar todos os dados
        public List<FormaPagto> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from formapagto", Con);
                Dr = Cmd.ExecuteReader();

                List<FormaPagto> list = new List<FormaPagto>();


                while (Dr.Read())
                {
                    FormaPagto obj = new FormaPagto();

                    obj.idFormaPagto = Convert.ToInt32(Dr["idformapagto"]);
                    obj.nmFormaPagto = Convert.ToString(Dr["nmformapagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Forma de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }
    }
}
