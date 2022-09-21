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
            findInsert(obj.nmCondicaoPagto, obj.idCondicaoPagto);
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
                    command.CommandText = "insert into condicaoforma (condicaopagto_id, formapagto_id, nrparcela, qtdias, txpercentual ) " +
                     "values (@condicaopagto_id, @formapagto_id, @nrparcela, @qtdias, @txpercentual )";

                    command.Parameters.AddWithValue("@condicaopagto_id", idRetorno);
                    command.Parameters.AddWithValue("@formapagto_id", item.idFormaPagto);
                    command.Parameters.AddWithValue("@nrparcela", ((object)item.nrParcela) != DBNull.Value ? ((object)item.nrParcela) : 0);
                    command.Parameters.AddWithValue("@qtdias", ((object)item.qtDias) != DBNull.Value ? ((object)item.qtDias) : 0);
                    command.Parameters.AddWithValue("@txpercentual", ((object)item.txPercentual) != DBNull.Value ? ((object)item.txPercentual) : 0);
                    resp = command.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";

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

                findInsert(obj.nmCondicaoPagto, obj.idCondicaoPagto);

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
                    obj.CondicaoForma = this.FindByForma(obj.idCondicaoPagto);
                    return obj;

                }
                else return null;

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

        public List<CondicaoForma> FindByForma(int? id)
        {
            OpenConection();
            List<CondicaoForma> obj = new List<CondicaoForma>();
            Cmd = new SqlCommand("select * from condicaoforma where condicaopagto_id=@idcondicaopagto", Con);
            Cmd.Parameters.AddWithValue("@idcondicaopagto", id);
            Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                CondicaoForma obj2 = new CondicaoForma();
                obj2.idCondicaoPagto = Convert.ToInt32(Dr["condicaopagto_id"]);
                obj2.idFormaPagto = Convert.ToInt32(Dr["formapagto_id"]);
                obj2.nrParcela = Convert.ToInt16(Dr["nrParcela"]);
                obj2.qtDias = Convert.ToInt16(Dr["qtDias"]);
                obj2.txPercentual = Convert.ToInt32(Dr["txPercentual"]);
                obj.Add(obj2);
            }
            return obj;

        }


        //public Funcionario FindById(int id)
        //{
        //    string sql = @"SELECT * FROM Funcionarios WHERE Id = ?";

        //    using (OdbcConnection conexao = ConnectionFactory.CreateConnection())
        //    {
        //        OdbcCommand comando = new OdbcCommand(sql, conexao);
        //        comando.Parameters.AddWithValue("@Id", id);
        //        conexao.Open();
        //       OdbcDataReader resultado = comando.ExecuteReader();
        //        while (resultado.Read())
        //        {
        //            Funcionario funcionario = new Funcionario();
        //            funcionario.ID = Convert.ToInt32(resultado["Id"] as string);
        //            funcionario.Nome = resultado["Nome"] as string;
        //            funcionario.Salario = resultado.GetDouble
        //              (resultado.GetOrdinal("Salario"));
        //            funcionario.Dependentes =
        //              this.FindByFuncionario(funcionario.ID, conexao);
        //            return funcionario;
        //        }
        //        else return null;
        //    }
        //}

        //private List<Dependente> FindByFuncionario  (int id, OdbcConnection conexao)
        //{
        //    List<Dependente> dependentes = new List<Dependente>();
        //    string sql = @"SELECT * FROM Dependentes WHERE FuncionarioId = ?";

        //    OdbcCommand comando = new OdbcCommand(sql, conexao);
        //        comando.Parameters.AddWithValue("@FuncionarioId", id);
        //        OdbcDataReader resultado = comando.ExecuteReader();
        //        while (resultado.Read())
        //        {
        //            Dependente d = new Dependente();
        //            d.ID = resultado.GetInt32(resultado.GetOrdinal("Id"));
        //            d.Nome = resultado.GetString(resultado.GetOrdinal("Nome"));
        //            d.Parentesco =
        //                  resultado.GetString(resultado.GetOrdinal("Parentesco"));
        //            dependentes.Add(d);
        //        }
        //        return dependentes;
        //   }




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


        public void findInsert(string text, int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from condicaopagto where nmcondicaopagto=@v1 and idcondicaopagto <> @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", text);
                Cmd.Parameters.AddWithValue("@v2", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();


                    obj.nmPais = Convert.ToString(Dr["nmcondicaopagto"]);
                    throw new Exception("Já existe uma condição de pagamento cadastrada com esse nome, verifique!");

                }
            }
            finally
            {
                CloseConection();
            }
        }

    }
}
