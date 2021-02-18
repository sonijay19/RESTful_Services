using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using RESTServices.Controllers.ControllerDTO;

namespace DemoService.ClientLayer
{
    public abstract partial class ValidateEmail
    {
        public static bool ValidateRequestMessages(UserDetailRequestMessage userInfo)
        {
            /*Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = emailRegex.Match(userInfo.UserEmail);
            if (match.Success)
            {
                return true;
            }
            return false;*/
            return true;
        }
    }
}