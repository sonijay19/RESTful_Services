using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DemoService.BusinessLayer;
using DemoService.BusinessLayer.Entities.Enums;
using DemoService.Exceptions;
using RESTful_Services.ClientLayer.Validation;
using RESTServices.BusinessLayer;
using RESTServices.BusinessLayer.Interface;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.Controllers.ResponseMessage;
using RESTServices.DAO;

namespace DemoService.ClientLayer
{
    public class RequestProcessor
    {
        public string UserValidate(DefaultRequestMessage userDetails)
        {
            DefaultRequestMessage userInfo = new DefaultRequestMessage();
            userInfo = userDetails;
            DefaultResponseMessages response = new DefaultResponseMessages();
            try
            {
                RequestMessageValidator validator = new RequestMessageValidator();
                var result = validator.Validate(userInfo);
                if (result.IsValid)
                {
                    return "thai gayu bhai";
                }
                return "false";
                //GetUserDetailsService buisness = new GetUserDetailsService();
                //var buisness = ServiceManager.GetInstance().GetUserAuthentication();
                /*if (!ValidateEmail.ValidateRequestMessages(userDetails))
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                }
                if (ServiceManager.GetInstance().GetUserAuthentication().GetUserDetails(userDetails))
                {
                    response.Success = true;
                    return response;
                }*/
                //throw new MessageNotValidException(ErrorCodes.INVALID_USER);
            }
            catch (MessageNotValidException e)
            {
                response.ErrorCode = e._errorConstants.ToString();
                response.Success = false;
                return "false";
            }
            catch (TimeoutException e)
            {
                response.ErrorCode = ErrorCodes.INTERNAL_SERVER_ERROR.ToString();
                response.Success = false;
                return "false";

            }
        }
    }
}