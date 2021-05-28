using PP1.CONTRATO.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class EstadoDAO : ConexaoDB
    {
        //private ConexaoDB objConexaoDB;
        //private SqlCommand comando;

        //public EstadoDAO()
        //{
        //    objConexaoDB = ConexaoDB.saberEstado();
        //}

        //public void create(Estado objEstado)
        //{
        //    string create = "insert into estado(nmestado, dsUF, nrddd, dtcadastro, dtatualizacao, idpais) VALUES ('" + objEstado.nmEstado + "', '" + objEstado.dsUF + "' , '" + objEstado.nrDDD + "' , '" + objEstado.dtCadastro + "', '" + objEstado.dtAtualizacao + "', '" + objEstado.idPais + "' )";
        //    try
        //    {
        //        comando = new SqlCommand(create, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public void delete(Estado objEstado)
        //{
        //    string delete = "delete from estado where idestado = '" + objEstado.idEstado + "' ";
        //    try
        //    {
        //        comando = new SqlCommand(delete, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        //objEstado.Estado = 1;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public void update(Estado objEstado)
        //{
        //    string update = "update estado set nmestado='" + objEstado.nmEstado + "', '" + objEstado.dsUF + "' , '" + objEstado.nrDDD + "' , '" + objEstado.dtCadastro + "', '" + objEstado.dtAtualizacao + "', '" + objEstado.dtAtualizacao + "', '" + objEstado.idPais + "' where idestado='" + objEstado.idEstado + "'";
        //    try
        //    {
        //        comando = new SqlCommand(update, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        //objEstado.Estado = 1;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }
        //}

        //public bool find(Estado objEstado)
        //{
        //    bool temRegistros;
        //    string find = "select * from estado where idestado  = '" + objEstado.idEstado + "' ";
        //    try
        //    {
        //        comando = new SqlCommand(find, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        temRegistros = reader.Read();
        //        if (temRegistros)
        //        {
        //            objEstado.nmEstado = reader[1].ToString();
        //            objEstado.dsUF = reader[2].ToString();
        //            objEstado.nrDDD = reader[3].ToString();
        //            objEstado.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objEstado.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
        //            objEstado.idPais = Convert.ToInt32(reader[6].ToString());

        //        }
        //        else
        //        {
        //            //objEstado.Estado = 1;
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return temRegistros;
        //}

        //public List<Estado> findAll()
        //{
        //    List<Estado> listaEstados = new List<Estado>();
        //    string findAll = "select * from estado order by idestado";

        //    try
        //    {
        //        comando = new SqlCommand(findAll, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Estado objEstado = new Estado();
        //            objEstado.idEstado = Convert.ToInt32(reader[0].ToString());
        //            objEstado.nmEstado = reader[1].ToString();
        //            objEstado.dsUF = reader[2].ToString();
        //            objEstado.nrDDD = reader[3].ToString();
        //            objEstado.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objEstado.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
        //            objEstado.idPais = Convert.ToInt32(reader[6].ToString());
        //            listaEstados.Add(objEstado);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return listaEstados;
        //}

        //public List<Estado> findAllEstado(Estado objEstado)
        //{
        //    List<Estado> listaEstados = new List<Estado>();
        //    string findAll = "select* from estado where nmestado like '%" + objEstado.nmEstado + "%' or dssigla like '%" + objEstado.dsUF + "%' or idestado like '%" + objEstado.idEstado + "%' ";
        //    try
        //    {

        //        comando = new SqlCommand(findAll, objConexaoDB.getCon());
        //        objConexaoDB.getCon().Open();
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Estado objEstados = new Estado();
        //            objEstado.idEstado = Convert.ToInt32(reader[0].ToString());
        //            objEstado.nmEstado = reader[1].ToString();
        //            objEstado.dsUF = reader[2].ToString();
        //            objEstado.nrDDD = reader[3].ToString();
        //            objEstado.dtCadastro = Convert.ToDateTime(reader[4].ToString());
        //            objEstado.dtAtualizacao = Convert.ToDateTime(reader[5].ToString());
        //            objEstado.idPais = Convert.ToInt32(reader[6].ToString());
        //            listaEstados.Add(objEstado);

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    finally
        //    {
        //        objConexaoDB.getCon().Close();
        //        objConexaoDB.CloseDB();
        //    }

        //    return listaEstados;

        //}
    }
}
