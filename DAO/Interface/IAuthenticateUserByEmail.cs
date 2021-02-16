using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServices.DAO.Interface
{
    public interface IAuthenticateUserByEmail
    {
        UserInformation AuthenticateUser(string UserEmail);
    }
}
