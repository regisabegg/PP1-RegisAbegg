using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class EstadoDAO : ConexaoDB
    {
        
            //Atributos
            //idEstado, nmEstado, dsUF, nrDDI, dtCadastro, dtAtualizacao, 

            //Método para gravar dados
            public void Insert(Estado obj)
            {
                try
                {
                    OpenConection();
                    Cmd = new SqlCommand("insert into estado (nmestado, dsuf, dtcadastro, dtatualizacao, idpais ) values (@v1, @v2, @v3, @v4, @v5)", Con);

                    Cmd.Parameters.AddWithValue("@v1", obj.nmEstado);
                    Cmd.Parameters.AddWithValue("@v2", obj.dsUF);
                    Cmd.Parameters.AddWithValue("@v3", obj.dtCadastro);
                    Cmd.Parameters.AddWithValue("@v4", obj.dtAtualizacao);
                    Cmd.Parameters.AddWithValue("@v5", obj.idPais);

                Cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro ao inserir o Estado: " + ex.Message);
                }
                finally
                {
                    CloseConection();
                }
            }

            //Método para atualizar dados
            public void Update(Estado obj)
            {
                try
                {
                    OpenConection();
                    Cmd = new SqlCommand("update estado set nmestado=@v1, dsuf=@v2, dtcadastro=@v3, dtatualizacao=@v4 , dtpais=@v5 where idestado = @v6", Con);

                    Cmd.Parameters.AddWithValue("@v1", obj.nmEstado);
                    Cmd.Parameters.AddWithValue("@v2", obj.dsUF);
                    Cmd.Parameters.AddWithValue("@v3", obj.dtCadastro);
                    Cmd.Parameters.AddWithValue("@v4", obj.dtAtualizacao);
                    Cmd.Parameters.AddWithValue("@v5", obj.idPais);
                    Cmd.Parameters.AddWithValue("@v6", obj.idEstado);

                    Cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro ao atualizar o Estado: " + ex.Message);
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
                    Cmd = new SqlCommand("delete from estado where idestado = @v1", Con);

                    Cmd.Parameters.AddWithValue("@v1", id);

                    Cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro ao excluir o Estado: " + ex.Message);
                }
                finally
                {
                    CloseConection();
                }
            }

            //Método para localizar pelo Código
            public Estado FindID(int id)
            {
                try
                {
                    OpenConection();
                    Cmd = new SqlCommand("select * from estado where idestado=@v1", Con);
                    Cmd.Parameters.AddWithValue("@v1", id);
                    Dr = Cmd.ExecuteReader();

                    Estado obj = null;
                    if (Dr.Read())
                    {
                        obj = new Estado();

                        obj.idEstado = Convert.ToInt32(Dr["idestado"]);
                        obj.nmEstado = Convert.ToString(Dr["nmestado"]);
                        obj.dsUF = Convert.ToString(Dr["dsuf"]);
                        obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                        obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
                        obj.idPais = Convert.ToInt32(Dr["idpais"]);
                }
                    return obj;

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao pesquisar o Estado: " + ex.Message);
                }
                finally
                {
                    CloseConection();
                }
            }

            //Método para localizar todos os dados
            public List<Estado> FindAll()
            {
                try
                {
                    OpenConection();
                    Cmd = new SqlCommand("select * from estado", Con);
                    Dr = Cmd.ExecuteReader();

                    List<Estado> list = new List<Estado>();


                    while (Dr.Read())
                    {
                        Estado obj = new Estado();

                        obj.idEstado = Convert.ToInt32(Dr["idestado"]);
                        obj.nmEstado = Convert.ToString(Dr["nmestado"]);
                        obj.dsUF = Convert.ToString(Dr["dsuf"]);
                        obj.dtCadastro = Convert.ToDateTime(Dr["dtcadastro"]);
                        obj.dtAtualizacao = Convert.ToDateTime(Dr["dtatualizacao"]);
                        obj.idPais = Convert.ToInt32(Dr["idpais"]);

                    list.Add(obj);
                    }
                    return list;

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao pesquisar o Estado: " + ex.Message);
                }
                finally
                {
                    CloseConection();
                }
            }
        
    }
}
