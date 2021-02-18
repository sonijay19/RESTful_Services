using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;
using RESTful_Services.BusinessLayer.Entities.Enums;
using StackifyHttpTracer;

namespace RESTful_Services.DAO.propeties
{
    public class GetQueryByProperties
    //FirstName LastName UserEmail UserTypeId CreatedDate StatusCode
    {
        public string GetDetailQuery(string proprtyName, UserStatus userStatus,string sortbyParameter,string sortbyDirection)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(@"G:\Training\2_16_2021\RESTful_Services\DAO\propeties\sql.ini");
            string useFullScreenStr = data["SortActiveUserDetails"]["ActiveUserDetailsSort"];
            return useFullScreenStr;
        }
    }
}
