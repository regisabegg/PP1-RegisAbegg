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
                OpenConection();
                Cmd = new SqlCommand("insert into cliente (nmcliente, nmapelido, nrdocumento, nrregistro," +
                    " nrtelefone, nrcelular, dsemail, dssite, nmcontato, flcontato, dsobservacao, fltipo, " +
                    "flsituacao, nrcep, nmlogradouro, nrnumero, nmbairro, dscomplemento, vllimite, dtcadastro," +
                    " dtatualizacao, idcidade ) values (@v1, @v2, @v3, @v4, @v5, @v6, @v7, @v8, @v9, @v10, @v11, " +
                    "@v12, @v13, @v14, @v15, @v16, @v17, @v18, @v19, @v20, @v21, @v22)", Con);

                Cmd.Parameters.AddWithValue("@v1", obj.nmCliente);
                Cmd.Parameters.AddWithValue("@v2", obj.nmApelido);
                Cmd.Parameters.AddWithValue("@v3", obj.nrDocumento);
                Cmd.Parameters.AddWithValue("@v4", obj.nrRegistro);
                Cmd.Parameters.AddWithValue("@v5", obj.nrTelefone);
                Cmd.Parameters.AddWithValue("@v6", obj.nrCelular);
                Cmd.Parameters.AddWithValue("@v7", obj.dsEmail);
                Cmd.Parameters.AddWithValue("@v8", obj.dsSite);
                Cmd.Parameters.AddWithValue("@v9", obj.nmContato);
                Cmd.Parameters.AddWithValue("@v10", obj.flContato);
                Cmd.Parameters.AddWithValue("@v11", obj.dsObservacao);
                Cmd.Parameters.AddWithValue("@v12", obj.flTipo);
                Cmd.Parameters.AddWithValue("@v13", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@v14", obj.nrCEP);
                Cmd.Parameters.AddWithValue("@v15", obj.nmLogradouro);
                Cmd.Parameters.AddWithValue("@v16", obj.nrNumero);
                Cmd.Parameters.AddWithValue("@v17", obj.nmBairro);
                Cmd.Parameters.AddWithValue("@v18", obj.dsComplemento);
                Cmd.Parameters.AddWithValue("@v19", obj.vlLimite);
                Cmd.Parameters.AddWithValue("@v20", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@v21", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@v22", obj.idCidade);

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
                OpenConection();
                Cmd = new SqlCommand("update cliente set nmcliente=@v1, dsuf=@v2, dtcadastro=@v3, dtatualizacao=@v4,  nribge=@v5,  flregiao=@v6, idcidade=@v7 where idcliente = @v23", Con);

                Cmd.Parameters.AddWithValue("@v1", obj.nmCliente);
                Cmd.Parameters.AddWithValue("@v2", obj.nmApelido);
                Cmd.Parameters.AddWithValue("@v3", obj.nrDocumento);
                Cmd.Parameters.AddWithValue("@v4", obj.nrRegistro);
                Cmd.Parameters.AddWithValue("@v5", obj.nrTelefone);
                Cmd.Parameters.AddWithValue("@v6", obj.nrCelular);
                Cmd.Parameters.AddWithValue("@v7", obj.dsEmail);
                Cmd.Parameters.AddWithValue("@v8", obj.dsSite);
                Cmd.Parameters.AddWithValue("@v9", obj.nmContato);
                Cmd.Parameters.AddWithValue("@v10", obj.flContato);
                Cmd.Parameters.AddWithValue("@v11", obj.dsObservacao);
                Cmd.Parameters.AddWithValue("@v12", obj.flTipo);
                Cmd.Parameters.AddWithValue("@v13", obj.flSituacao);
                Cmd.Parameters.AddWithValue("@v14", obj.nrCEP);
                Cmd.Parameters.AddWithValue("@v15", obj.nmLogradouro);
                Cmd.Parameters.AddWithValue("@v16", obj.nrNumero);
                Cmd.Parameters.AddWithValue("@v17", obj.nmBairro);
                Cmd.Parameters.AddWithValue("@v18", obj.dsComplemento);
                Cmd.Parameters.AddWithValue("@v19", obj.vlLimite);
                Cmd.Parameters.AddWithValue("@v20", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@v21", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@v22", obj.idCidade);
                Cmd.Parameters.AddWithValue("@v23", obj.idCliente);

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
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"]);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"]);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"]);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"]);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"]);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"]);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"]);
                    obj.dsSite = Convert.ToString(Dr["dssite"]);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"]);
                    obj.flContato = Convert.ToString(Dr["flcontato"]);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"]);
                    obj.flTipo = Convert.ToString(Dr["fltipo"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"]);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"]);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"]);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"]);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"]);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
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
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"]);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"]);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"]);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"]);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"]);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"]);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"]);
                    obj.dsSite = Convert.ToString(Dr["dssite"]);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"]);
                    obj.flContato = Convert.ToString(Dr["flcontato"]);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"]);
                    obj.flTipo = Convert.ToString(Dr["fltipo"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"]);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"]);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"]);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"]);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"]);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
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
                    obj.nmCliente = Convert.ToString(Dr["nmcliente"]);
                    obj.nmApelido = Convert.ToString(Dr["nmapelido"]);
                    obj.nrDocumento = Convert.ToString(Dr["nrdocumento"]);
                    obj.nrRegistro = Convert.ToString(Dr["nrregistro"]);
                    obj.nrTelefone = Convert.ToString(Dr["nrtelefone"]);
                    obj.nrCelular = Convert.ToString(Dr["nrcelular"]);
                    obj.dsEmail = Convert.ToString(Dr["dsemail"]);
                    obj.dsSite = Convert.ToString(Dr["dssite"]);
                    obj.nmContato = Convert.ToString(Dr["nmcontato"]);
                    obj.flContato = Convert.ToString(Dr["flcontato"]);
                    obj.dsObservacao = Convert.ToString(Dr["dsobservacao"]);
                    obj.flTipo = Convert.ToString(Dr["fltipo"]);
                    obj.flSituacao = Convert.ToString(Dr["flsituacao"]);
                    obj.nrCEP = Convert.ToString(Dr["nrcep"]);
                    obj.nmLogradouro = Convert.ToString(Dr["nmlogradouro"]);
                    obj.nrNumero = Convert.ToString(Dr["nrnumero"]);
                    obj.nmBairro = Convert.ToString(Dr["nmbairro"]);
                    obj.dsComplemento = Convert.ToString(Dr["dscomplemento"]);
                    obj.vlLimite = Convert.ToDecimal(Dr["vllimite"]);
                    obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                    obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
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

    }
}
