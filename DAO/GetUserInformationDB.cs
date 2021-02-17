using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DemoService.BusinessLayer.DTO;
using RESTful_Services.BusinessLayer.Entities.DTO;
using RESTful_Services.BusinessLayer.Entities.Enums;
using RESTful_Services.DAO.propeties;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.DAO.Interface;

namespace RESTServices.DAO
{

    public class GetUserInformationDB : IGetUserInformation
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

        public List<UserInformation> GetAllUserDetails(BusinessReuqestMessage UserDetails)
        {
            List<UserInformation> UserInfo = new List<UserInformation>();
            //string query = GetQueryByProperties.GetQuery("SortActiveUserDetails", UserStatus.All);
            //Debug.WriteLine("Query is ",query);
            string query = "SELECT UserDetails.Email,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId WHERE UserTypeStatus.StatusCode = @UserType AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) ORDER BY @sortbyParameter @sortbyDirection";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                //UserDetails.Email,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate
                // @UserType ORDER BY @sortbyParameter @sortbyDirection @fromDate @toDate
                conn.Open();
                cmd.Parameters.AddWithValue("@UserType", UserDetails.AccessType);
                cmd.Parameters.AddWithValue("@sortbyParameter", UserDetails.sortbyParameter);
                cmd.Parameters.AddWithValue("@sortbyDirection", UserDetails.sortbyParameter);
                cmd.Parameters.AddWithValue("@fromDate", UserDetails.FromDate);
                cmd.Parameters.AddWithValue("@toDate", UserDetails.ToDate);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserInfo.Add(
                            new UserInformation
                            {
                                UserEmail = reader["UserDetails.Email"].ToString(),
                                FirstName = reader["UserDetails.firstName"].ToString(),
                                LastName = reader["UserDetails.lastName"].ToString(),
                                UserType = ((UserIdDeleted)Convert.ToInt16(reader["UserDetails.IsDeleted"])).ToString(),
                                UserStatus = reader["UserTypeStatus.StatusCode"].ToString(),
                            }
                        );

                        conn.Close();
                        return UserInfo;
                    }
                    conn.Close();
                    return null;
                }
            }
        }
    }
}
