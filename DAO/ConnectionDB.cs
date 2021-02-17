using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServices.DAO
{
    public class ConnectionDB
    {
        private SqlConnection conn;
        public SqlConnection ConnectDb()
        {

            string connectionstring =
                "Data Source=DESKTOP-02T0GUH\\SQLEXPRESS;Initial Catalog = UserDetails; User ID = DESKTOP-02T0GUH\\sonij; Password='';Integrated Security=true";
            try
            {
                conn = new SqlConnection(connectionstring);
                return conn;
            }
            catch (Exception)
            { }
            return conn;
        }
    }
}
