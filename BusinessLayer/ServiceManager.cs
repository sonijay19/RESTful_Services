using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTServices.BusinessLayer.Interface;

namespace RESTServices.BusinessLayer
{
    public class ServiceManager
    {
        private static ServiceManager serviceManagerInstance = new ServiceManager();
        public static ServiceManager GetInstance()
        {

            return serviceManagerInstance;
        }

        public IGetUserDetailsService GetUserInformation()
        {
            return GetUserDetailsService.Instance;
        }
    }
}
