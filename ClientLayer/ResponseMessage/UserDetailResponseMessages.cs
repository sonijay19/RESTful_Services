using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoService.BusinessLayer.Entities.Enums;
using RESTServices.DAO;

namespace RESTServices.Controllers.ResponseMessage
{
    public class UserDetailResponseMessages
    {
        public int Total_Count { get; set; }
        public List<UserInformation> userDetails{ get; set; }
        public string ErrorCodes { get; set; }
    }
}
