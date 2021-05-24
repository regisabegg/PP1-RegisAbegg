using System.Configuration;
using System.Data.SqlClient;

namespace PP1.CONTRATO.DAO
{
    public class ConexaoDB
    {

        private static ConexaoDB objConexaoDB = null;
        private SqlConnection con;

        public ConexaoDB()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }

        public static ConexaoDB saberEstado()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }

            return objConexaoDB;
        }


        public SqlConnection getCon()
        {
            return con;
        }

        public void CloseDB()
        {
            objConexaoDB = null;
        }
    }
}
