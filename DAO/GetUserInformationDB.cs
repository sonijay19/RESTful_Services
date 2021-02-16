using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DemoService.BusinessLayer.DTO;
using RESTServices.DAO.Interface;

namespace RESTServices.DAO
{

    public class GetUserInformationDB : IAuthenticateUserByEmail
    {
        private SqlConnection conn;
        public GetUserInformationDB()
        {
            ConnectionDB connect = new ConnectionDB();
            this.conn = connect.ConnectDb();
        }

        private static GetUserInformationDB _instance;
        public static GetUserInformationDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null)
                    {
                        _instance = new GetUserInformationDB();
                    }
                }
                return _instance;
            }
        }

        public UserInformation AuthenticateUser(string UserEmail)
        {
            UserInformation UserDetail = new UserInformation();
            
            string query = "SELECT Email,firstName,lastName,UserType,CreatedDate,ModifiedDate FROM UserInfo WHERE Email = @EmailId AND IsDeleted = 0";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@EmailId", UserEmail);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserDetail.UserEmail = reader["Email"].ToString();
                        UserDetail.FirstName = reader["firstName"].ToString();
                        UserDetail.LastName = reader["lastName"].ToString();
                        UserDetail.UserType = reader["UserType"].ToString();
                        conn.Close();
                        return UserDetail;
                    }
                    conn.Close();
                    return null;
                }
            }
        }
    }
}
