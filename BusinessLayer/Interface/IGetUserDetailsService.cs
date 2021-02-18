using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.DAO;

namespace RESTServices.BusinessLayer.Interface
{
    public interface IGetUserDetailsService
    {
        List<UserInformation> GetUserDetails(UserDetailRequestMessage user);
    }
}
