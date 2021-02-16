using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoService.BusinessLayer.DTO;
using RESTServices.BusinessLayer.Interface;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.Controllers.ResponseMessage;
using RESTServices.DAO;

namespace RESTServices.BusinessLayer
{
    public class GetUserDetailsService : IGetUserDetailsService
    {
        //private GetUserInformationDB userAuth = new GetUserInformationDB();

        private static GetUserDetailsService _instance;
        public static GetUserDetailsService Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (_instance == null) 
                    {
                            _instance = new GetUserDetailsService();
                    }
                }
                return _instance;
            }
        }
        public bool GetUserDetails(DefaultRequestMessage user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserInformation, UserInfo>()
            );

            UserInfo userInformation = new UserInfo();
            var userEmail = config.CreateMapper();
            userInformation = userEmail.Map<UserInfo>(user);
            var userInfo = DAOServiceManager.GetInstance().GetAuthenticateUserByEmail()
                .AuthenticateUser(userInformation.UserEmail);

            if (userInfo == null)
            {
                return false;
            }

            return true;
        }
    }
}
