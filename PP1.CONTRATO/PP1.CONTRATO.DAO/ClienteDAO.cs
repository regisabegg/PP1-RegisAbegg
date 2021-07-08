using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class ClienteDAO : ConexaoDB
    {

        //Atributos
        //idCliente, nmCliente, dsUF, nrDDI, dtCadastro, dtAtualizacao, 

        //Método para gravar dados
        public void Insert(Cliente obj)
        {
            try
            {
                findInsert(obj.nmCliente, obj.idCliente);

                OpenConection();
                Cmd = new SqlCommand("insert into cliente (nmcliente, nmapelido, nrdocumento, nrregistro, " +
                    "nrtelefone, nrcelular, dsemail, dssite, nmcontato, flcontato, dsobservacao, fltipo, " +
                    "flsituacao, nrcep, nmlogradouro, nrnumero, nmbairro, dscomplemento, vllimite, dtcadastro, " +
                    "dtatualizacao, idcidade, dtnascimento, flsexo ) values (@nmcliente, @nmapelido, @nrdocumento, @nrregistro, @nrtelefone," +
                    "@nrcelular, @dsemail, @dssite, @nmcontato, @flcontato, @dsobservacao, @fltipo, @flsituacao, @nrcep, " +
                    "@nmlogradouro, @nrnumero, @nmbairro, @dscomplemento, @vllimite, @dtcadastro, @dtatualizacao, @idcidade, @dtnascimento, @flsexo )", Con);

                Cmd.Parameters.AddWithValue("@nmcliente", obj.nmCliente);
                Cmd.Parameters.AddWithValue("@nmapelido", obj.nmApelido ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrdocumento", obj.nrDocumento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrregistro", obj.nrRegistro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrtelefone", obj.nrTelefone ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelular", obj.nrCelular ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsemail", obj.dsEmail ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dssite", obj.dsSite ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmcontato", obj.nmContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcontato", obj.flContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsobservacao", obj.dsObservacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@fltipo", obj.flTipo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcep", obj.nrCEP ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmlogradouro", obj.nmLogradouro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrnumero", obj.nrNumero ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmbairro", obj.nmBairro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dscomplemento", obj.dsComplemento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@vllimite", ((object)obj.vlLimite) ?? DBNull.Value );
                Cmd.Parameters.AddWithValue("@dtcadastro", ((object)obj.dtCadastro) ?? DBNull.Value );
                Cmd.Parameters.AddWithValue("@dtatualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtnascimento", ((object)obj.dtNascimento) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsexo", obj.flSexo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@idcidade", ((object)obj.idCidade) ?? DBNull.Value);

                //cmd.Parameters.Add("@units", SqlDbType.Int).Value = units ?? (object)DBNull.Value; 
                //cmd.Parameters.Add("@range", SqlDbType.Int).Value = range ?? (object)DBNull.Value;
                //cmd.Parameters.Add("@scale", SqlDbType.Int).Value = scale ?? (object)DBNull.Value; 
                //cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = description ?? (object)DBNull.Value;



                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao inserir o Cliente: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para atualizar dados
        public void Update(Cliente obj)
        {
            try
            {

                findInsert(obj.nmCliente, obj.idCliente);

                OpenConection();
                Cmd = new SqlCommand("update cliente set nmcliente=@nmcliente, nmapelido=@nmapelido, nrdocumento=@nrdocumento, " +
                    "nrregistro=@nrregistro, nrtelefone=@nrtelefone, nrcelular=@nrcelular, dsemail=@dsemail, dssite=@dssite," +
                    "nmcontato=@nmcontato, flcontato=@flcontato,  dsobservacao=@dsobservacao,  fltipo=@fltipo,  flsituacao=@flsituacao," +
                    "nrcep=@nrcep,  nmlogradouro=@nmlogradouro,  nrnumero=@nrnumero,  dscomplemento=@dscomplemento,  vllimite=@vllimite, " +
                    "dtcadastro=@dtcadastro, dtatualizacao=@dtatualizacao,  idcidade=@idcidade, dtnascimento=@dtnascimento, flsexo=@flsexo " +
                    "where idcliente = @idcliente", Con);

                Cmd.Parameters.AddWithValue("@nmcliente", obj.nmCliente);
                Cmd.Parameters.AddWithValue("@nmapelido", obj.nmApelido ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrdocumento", obj.nrDocumento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrregistro", obj.nrRegistro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrtelefone", obj.nrTelefone ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcelular", obj.nrCelular ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsemail", obj.dsEmail ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dssite", obj.dsSite ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmcontato", obj.nmContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flcontato", obj.flContato ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dsobservacao", obj.dsObservacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@fltipo", obj.flTipo ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsituacao", obj.flSituacao ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrcep", obj.nrCEP ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmlogradouro", obj.nmLogradouro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nrnumero", obj.nrNumero ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@nmbairro", obj.nmBairro ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@dscomplemento", obj.dsComplemento ?? (object)DBNull.Value);
                Cmd.Parameters.AddWithValue("@vllimite", ((object)obj.vlLimite) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtcadastro", ((object)obj.dtCadastro) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtatualizacao", ((object)obj.dtAtualizacao) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@dtnascimento", ((object)obj.dtNascimento) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@flsexo", ((object)obj.flSexo) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idcidade", ((object)obj.idCidade) ?? DBNull.Value);
                Cmd.Parameters.AddWithValue("@idcliente", ((object)obj.idCliente) ?? DBNull.Value);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao atualizar o Cliente: " + ex.Message);
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
                Cmd = new SqlCommand("delete from cliente where idcliente = @v1", Con);

                Cmd.Parameters.AddWithValue("@v1", id);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir o Cliente: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar pelo Código
        public Cliente FindID(int id)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cliente where idcliente=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", id);
                Dr = Cmd.ExecuteReader();

                Cliente obj = null;
                if (Dr.Read())
                {
                    obj = new Cliente();

                    obj.idCliente = Convert.ToInt32(Dr["idcliente"]);
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"] != DBNull.Value ? Dr["nmcliente"] : null);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);
                    obj.flTipo = Convert.ToString(Dr["fltipo"] != DBNull.Value ? Dr["fltipo"] : null);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"] != DBNull.Value ? Dr["vllimite"] : null);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);
                    obj.dtNascimento = (Dr["dtnascimento"] == DBNull.Value) ? (DateTime?)null : ((DateTime?)Dr["dtnascimento"]);
                    obj.flSexo = Convert.ToString(Dr["flsexo"]);
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);
                }
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Cliente: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        public List<Cliente> FindFilter(string filter)
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cliente where nmcliente like @v1 or  nmapelido like @v2 or nrdocumento like @v3", Con);
                Cmd.Parameters.AddWithValue("@v1", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v2", "%" + filter + "%");
                Cmd.Parameters.AddWithValue("@v3", "%" + filter + "%");
                Dr = Cmd.ExecuteReader();

                List<Cliente> list = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente obj = new Cliente();


                    obj.idCliente = Convert.ToInt32(Dr["idcliente"]);
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"] != DBNull.Value ? Dr["nmcliente"] : null);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);
                    obj.flTipo = Convert.ToString(Dr["fltipo"] != DBNull.Value ? Dr["fltipo"] : null);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"] != DBNull.Value ? Dr["vllimite"] : null);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);
                    obj.dtNascimento = (Dr["dtnascimento"] == DBNull.Value) ? (DateTime?)null : ((DateTime?)Dr["dtnascimento"]);
                    obj.flSexo = Convert.ToString(Dr["flsexo"]);
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Cliente: " + ex.Message);
            }
            finally
            {
                CloseConection();
            }
        }

        //Método para localizar todos os dados
        public List<Cliente> FindAll()
        {
            try
            {
                OpenConection();
                Cmd = new SqlCommand("select * from cliente", Con);
                Dr = Cmd.ExecuteReader();

                List<Cliente> list = new List<Cliente>();


                while (Dr.Read())
                {
                    Cliente obj = new Cliente();

                    obj.idCliente = Convert.ToInt32(Dr["idcliente"]);
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"] != DBNull.Value ? Dr["nmcliente"] : null );
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"] != DBNull.Value ? Dr["nmapelido"] : null);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"] != DBNull.Value ? Dr["nrdocumento"] : null);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"] != DBNull.Value ? Dr["nrregistro"] : null);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"] != DBNull.Value ? Dr["nrtelefone"] : null);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"] != DBNull.Value ? Dr["nrcelular"] : null);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"] != DBNull.Value ? Dr["dsemail"] : null);
                    obj.dsSite = Convert.ToString(Dr["dssite"] != DBNull.Value ? Dr["dssite"] : null);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"] != DBNull.Value ? Dr["nmcontato"] : null);
                    obj.flContato = Convert.ToString(Dr["flcontato"] != DBNull.Value ? Dr["flcontato"] : null);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"] != DBNull.Value ? Dr["dsobservacao"] : null);
                    obj.flTipo = Convert.ToString(Dr["fltipo"] != DBNull.Value ? Dr["fltipo"] : null);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"] != DBNull.Value ? Dr["flsituacao"] : null);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"] != DBNull.Value ? Dr["nrcep"] : null);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"] != DBNull.Value ? Dr["nmlogradouro"] : null);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"] != DBNull.Value ? Dr["nrnumero"] : null);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"] != DBNull.Value ? Dr["nmbairro"] : null);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"] != DBNull.Value ? Dr["dscomplemento"] : null);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"] != DBNull.Value ? Dr["vllimite"] : null);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"] != DBNull.Value ? Dr["dtcadastro"] : null);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"] != DBNull.Value ? Dr["dtatualizacao"] : null);
                    obj.dtNascimento = (Dr["dtnascimento"] == DBNull.Value) ? (DateTime?)null : ((DateTime?)Dr["dtnascimento"]);
                    obj.flSexo = Convert.ToString(Dr["flsexo"] );
                    obj.idCidade = Convert.ToInt32(Dr["idcidade"]);

                    list.Add(obj);
                }
                return list;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar o Cliente: " + ex.Message);
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
                Cmd = new SqlCommand("select * from cliente where nmcliente=@v1 and idcliente <> @v2", Con);
                Cmd.Parameters.AddWithValue("@v1", text);
                Cmd.Parameters.AddWithValue("@v2", id);
                Dr = Cmd.ExecuteReader();

                Pais obj = null;
                if (Dr.Read())
                {
                    obj = new Pais();


                    obj.nmPais = Convert.ToString(Dr["nmcliente"]);
                    throw new Exception("Já existe um cliente cadastrado com esse nome, verifique!");

                }
            }
            finally
            {
                CloseConection();
            }
        }

    }
}
