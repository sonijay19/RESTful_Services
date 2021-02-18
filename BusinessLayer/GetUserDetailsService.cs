using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoService.BusinessLayer.DTO;
using RESTful_Services.BusinessLayer.Entities.DTO;
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
        public List<UserInformation> GetUserDetails(UserDetailRequestMessage user)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserDetailRequestMessage, BusinessReuqestMessage>()
            );

            BusinessReuqestMessage requestMessage = new BusinessReuqestMessage();
            var mapperBusiness = config.CreateMapper();
            requestMessage = mapperBusiness.Map<BusinessReuqestMessage>(user);
            var userInfo = DAOServiceManager.GetInstance().GetAuthenticateUserByEmail()
                .GetAllUserDetails(requestMessage);

            if (userInfo != null)
            {
                return userInfo;
            }
            return null;
        }
    }
}
