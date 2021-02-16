using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTServices.DAO.Interface;

namespace RESTServices.DAO
{
    public class DAOServiceManager
    {
        private static DAOServiceManager daoserviceManagerInstance = new DAOServiceManager();

        public static DAOServiceManager GetInstance()
        {
            return daoserviceManagerInstance;
        }

        public IAuthenticateUserByEmail GetAuthenticateUserByEmail()
        {
            return GetUserInformationDB.Instance;
        }
    }
}
