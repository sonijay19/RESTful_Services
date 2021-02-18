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
        private static string GetSortDirection(string sortbydirection, string sortbyparams)
        {
            string sortQury=$"{sortbyparams} {sortbydirection}";
            return sortQury;
        }
        private static string GetUserStatus(string userType)
        {
            if(userType == UserStatus.Active.ToString())
            {
                return "UserDetails.IsDeleted = 0 AND";
            }
            if(userType == UserStatus.Deleted.ToString())
            {
                return "UserDetails.IsDeleted = 1 AND";
            }
            return null;
        }
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
            GetQueryByProperties getQuery = new GetQueryByProperties();
            string newquery = getQuery.GetDetailQuery("SortActiveUserDetails", UserStatus.All,UserDetails.sortbyParameter,UserDetails.sortbyDirection);
            //Debug.WriteLine("Query is " + newquery);
            string getdirection = GetSortDirection(UserDetails.sortbyDirection, UserDetails.sortbyParameter);
            //string query = "SELECT UserDetails.UserEmail,UserDetails.firstName,UserDetails.lastName,UserTypeStatus.StatusCode,UserDetails.CreatedDate,UserDetails.ModifiedDate,UserDetails.IsDeleted FROM UserDetails INNER JOIN UserTypeStatus ON UserTypeStatus.TypeId = UserDetails.UserTypeId WHERE {useracess} UserTypeStatus.StatusCode = @UserType AND CreatedDate BETWEEN convert(date,@fromDate,103) and convert(date,@toDate,103) ORDER BY {sortby}";
            var queryFormmating = newquery.Replace("{sortby}", getdirection);
            var querynewone = queryFormmating.Replace("{useracess}", GetUserStatus(UserDetails.UserStatus));
            using (SqlCommand cmd = new SqlCommand(querynewone, conn))
            {
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.Parameters.AddWithValue("@UserType", UserDetails.AccessType);
                cmd.Parameters.AddWithValue("@fromDate", UserDetails.FromDate);
                cmd.Parameters.AddWithValue("@toDate", UserDetails.ToDate);
                cmd.Parameters.AddWithValue("@sortbyParameter", UserDetails.sortbyParameter);
                cmd.Parameters.AddWithValue("@sortbyDirection", UserDetails.sortbyDirection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        UserInfo.Add(
                            new UserInformation
                            {
                                UserEmail = reader["UserEmail"].ToString(),
                                FirstName = reader["firstName"].ToString(),
                                LastName = reader["lastName"].ToString(),
                                UserType = ((UserIdDeleted)Convert.ToInt16(reader["IsDeleted"])).ToString(),
                                UserStatus = reader["StatusCode"].ToString(),
                            }
                        );
                    }
                    conn.Close();
                    return UserInfo;
                }
            }
        }
    }
}
