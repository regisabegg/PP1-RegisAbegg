using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class CondicaoPagtoDAO : ConexaoDB
    {
        //Atributos
        //idCondicaoPagto, nmCondicaoPagto, dsSigla, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(CondicaoPagto obj)
        {
            string resp = "";
            OpenConection();
            SqlTransaction sqlTrans = Con.BeginTransaction();
            SqlCommand command;
            try
            {

                command = Con.CreateCommand();
                command.Transaction = sqlTrans;
                command.CommandText = "insert into condicaopagto (nmcondicaopagto, flsituacao, txjuros, txmulta, dtcadastro, dtatualizacao ) values " +
                  "(@nmcondicaopagto, @flsituacao, @txjuros, @txmulta, @dtcadastro, @dtatualizacao );SELECT CAST(SCOPE_IDENTITY() AS int)";

                command.Parameters.AddWithValue("@nmcondicaopagto", obj.nmCondicaoPagto);
                command.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                command.Parameters.AddWithValue("@txjuros", ((object)obj.txJuros) != DBNull.Value ? ((object)obj.txJuros) : 0);
                command.Parameters.AddWithValue("@txmulta", ((object)obj.txMulta) != DBNull.Value ? ((object)obj.txMulta) : 0);
                command.Parameters.AddWithValue("@dtcadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                command.Parameters.AddWithValue("@dtatualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                command.Parameters.AddWithValue("@idcondicaopagto", obj.idCondicaoPagto);
                
                //CondicaoForma objForma = new CondicaoForma();
                //command.ExecuteNonQuery();

                Int32 idRetorno = Convert.ToInt32(command.ExecuteScalar());
                foreach (var item in obj.CondicaoForma)
                {

                    command = Con.CreateCommand();
                    command.Transaction = sqlTrans;
                    command.CommandText = "insert into condicaoforma (condicaopagto_id, formapagto_id, nrparcela, qtdias, txpercentual, nmformapagto ) " +
                     "values (@condicaopagto_id, @formapagto_id, @nrparcela, @qtdias, @txpercentual, @nmformapagto )";

                    command.Parameters.AddWithValue("@condicaopagto_id", idRetorno);
                    command.Parameters.AddWithValue("@formapagto_id", item.idFormaPagto);
                    command.Parameters.AddWithValue("@nrparcela", ((object)item.nrParcela) != DBNull.Value ? ((object)item.nrParcela) : 0);
                    command.Parameters.AddWithValue("@qtdias", ((object)item.qtDias) != DBNull.Value ? ((object)item.qtDias) : 0);
                    command.Parameters.AddWithValue("@txpercentual", ((object)item.txPercentual) != DBNull.Value ? ((object)item.txPercentual) : 0);
                    command.Parameters.AddWithValue("@nmformapagto", item.nmFormaPagto);
                    //resp = command.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";
                    command.ExecuteNonQuery();
                }

                sqlTrans.Commit();
            }
            catch (Exception ex)
            {
                sqlTrans.Rollback();
                throw new Exception("Erro ao inserir o Condicao de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(CondicaoPagto obj)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("update condicaopagto set nmCondicaoPagto=@nmcondicaopagto, flsituacao=@flsituacao, txjuros=@txjuros, txmulta=@txmulta, dtcadastro=@dtcadastro, dtatualizacao=@dtatualizacao where idcondicaopagto = @idcondicaopagto", Con);

                Cmd.Parameters.AddWithValue("@nmcondicaopagto", obj.nmCondicaoPagto);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@txjuros", obj.txJuros);
                Cmd.Parameters.AddWithValue("@txmulta", obj.txMulta);
                Cmd.Parameters.AddWithValue("@dtcadastro", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@dtatualizacao", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@idcondicaopagto", obj.idCondicaoPagto);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o Condicao de pagamento: " + ex.Message);
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
                Cmd = new SqlCommand("delete from condicaopagto where idcondicaopagto = @idcondicaopagto", Con);

                Cmd.Parameters.AddWithValue("@idcondicaopagto", id);



                return Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o Condicao de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public CondicaoPagto FindID(int? id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from condicaopagto where idcondicaopagto=@idcondicaopagto", Con);
                Cmd.Parameters.AddWithValue("@idcondicaopagto", id);
                Dr = Cmd.ExecuteReader();


                CondicaoPagto obj = null;
                if (Dr.Read())
                {
                    obj = new CondicaoPagto();

                    obj.idCondicaoPagto = Convert.ToInt32(Dr["idcondicaopagto"]);
                    obj.nmCondicaoPagto = Convert.ToString(Dr["nmcondicaopagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.txJuros = Convert.ToInt32(Dr["txjuros"]);
                    obj.txMulta = Convert.ToInt32(Dr["txmulta"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);



                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Condicao de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<CondicaoPagto> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from condicaopagto where nmcondicaopagto like @nmcondicaopagto", Con);
                Cmd.Parameters.AddWithValue("@nmcondicaopagto", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<CondicaoPagto> list = new List<CondicaoPagto>();


                while (Dr.Read())
                {
                    CondicaoPagto obj = new CondicaoPagto();

                    obj.idCondicaoPagto = Convert.ToInt32(Dr["idcondicaopagto"]);
                    obj.nmCondicaoPagto = Convert.ToString(Dr["nmcondicaopagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.txJuros = Convert.ToInt32(Dr["txjuros"]);
                    obj.txMulta = Convert.ToInt32(Dr["txmulta"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }

                return list;


            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Condicao de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }


        //Método para localizar todos os dados
        public List<CondicaoPagto> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from condicaopagto", Con);
                Dr = Cmd.ExecuteReader();

                List<CondicaoPagto> list = new List<CondicaoPagto>();


                while (Dr.Read())
                {
                    CondicaoPagto obj = new CondicaoPagto();

                    obj.idCondicaoPagto = Convert.ToInt32(Dr["idcondicaopagto"]);
                    obj.nmCondicaoPagto = Convert.ToString(Dr["nmcondicaopagto"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.txJuros = Convert.ToInt32(Dr["txjuros"]);
                    obj.txMulta = Convert.ToInt32(Dr["txmulta"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Condicao de pagamento: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }
    }
}
