using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTful_Services.BusinessLayer.Entities.Enums;
using StackifyHttpTracer;

namespace RESTful_Services.DAO.propeties
{
    public class GetQueryByProperties
    //FirstName LastName UserEmail UserTypeId CreatedDate StatusCode
    {
        private static IniParser parser = new IniParser(@"G:\Training\2_16_2021\RESTful_Services\DAO\propeties\sql.ini");
        public static string GetQuery(string proprtyName, UserStatus userStatus)
        {
            string query = String.Empty;
            switch (userStatus)
            {
                case UserStatus.Active:
                    query = parser.GetSetting("SortActiveUserDetails", "ActiveUserDetailsSort");
                    return query; 
                case UserStatus.Deleted:
                    query = parser.GetSetting("SortDeletedUserDetails", "DeletedUserDetailsSort");
                    return query;
                case UserStatus.All:
                    query = parser.GetSetting("SortAllUserDetails", "AllUserDetailsSort");
                    return query;
                default:
                    return null;
            }
        }
    }
}
