using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTful_Services.BusinessLayer.Entities.DTO;
using RESTful_Services.BusinessLayer.Entities.Enums;
using RESTServices.Controllers.ControllerDTO;

namespace RESTServices.DAO.Interface
{
    public interface IGetUserInformation
    {
        List<UserInformation> GetAllUserDetails(BusinessReuqestMessage UserEmail);
    }
}
