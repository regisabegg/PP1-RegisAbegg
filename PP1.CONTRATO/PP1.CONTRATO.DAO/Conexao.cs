using System;
using System.Configuration;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class ConexaoDB
    {

        //Atributos
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;


        //Abrir conexão
        protected void OpenConection()
        {
            try
            {
                //Connection String
                Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //Fechar conexão
        protected void CloseConection()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public ConexaoDB()
        //{
        //    Con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        //}

        //public static ConexaoDB saberEstado()
        //{
        //    if (objConexaoDB == null)
        //    {
        //        objConexaoDB = new ConexaoDB();
        //    }

        //    return objConexaoDB;
        //}


        //public SqlConnection getCon()
        //{
        //    return Con;
        //}

        //public void CloseDB()
        //{
        //    objConexaoDB = null;
        //}
    }
}
