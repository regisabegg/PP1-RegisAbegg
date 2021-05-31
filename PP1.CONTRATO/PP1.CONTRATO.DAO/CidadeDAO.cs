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
                    OpenConection();
                    Cmd = new SqlCommand("insert into cidade (nmcidade, nrddd, nribge, dtcadastro, dtatualizacao, idestado ) values (@v1, @v2, @v3, @v4, @v5, @v6)", Con);

                    Cmd.Parameters.AddWithValue("@v1", obj.nmCidade);
                    Cmd.Parameters.AddWithValue("@v2", obj.nrDDD);
                    Cmd.Parameters.AddWithValue("@v3", obj.nrIBGE);
                    Cmd.Parameters.AddWithValue("@v4", obj.dtCadastro);
                    Cmd.Parameters.AddWithValue("@v5", obj.dtAtualizacao);
                    Cmd.Parameters.AddWithValue("@v6", obj.idEstado);

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
                    OpenConection();
                    Cmd = new SqlCommand("update cidade set nmcidade=@v1, nrddd=@v2,  nribge=@v3, dtcadastro=@v4, dtatualizacao=@v5, idestado=@v6 where idcidade = @v7", Con);

                Cmd.Parameters.AddWithValue("@v1", obj.nmCidade);
                Cmd.Parameters.AddWithValue("@v2", obj.nrDDD);
                Cmd.Parameters.AddWithValue("@v3", obj.nrIBGE);
                Cmd.Parameters.AddWithValue("@v4", obj.dtCadastro);
                Cmd.Parameters.AddWithValue("@v5", obj.dtAtualizacao);
                Cmd.Parameters.AddWithValue("@v6", obj.idEstado); ;
                Cmd.Parameters.AddWithValue("@v7", obj.idCidade);

                Cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {

                    throw new Exception("Erro ao atualizar o Cidade: " + ex.Message);
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

                    throw new Exception("Erro ao excluir o Cidade: " + ex.Message);
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
                    throw new Exception("Erro ao pesquisar o Cidade: " + ex.Message);
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
                    throw new Exception("Erro ao pesquisar o Cidade: " + ex.Message);
                }
                finally
                {
                    CloseConection();
                }
            }
        
    }
}
