using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using DemoService.BusinessLayer;
using DemoService.BusinessLayer.Entities.Enums;
using DemoService.Exceptions;
using FluentValidation;
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
        public UserDetailResponseMessages UserValidate(UserDetailRequestMessage userDetails)
        {
            UserDetailResponseMessages response = new UserDetailResponseMessages();
            try
            {
                DateTime fromDate = DateTime.ParseExact(userDetails.FromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime toDate = DateTime.ParseExact(userDetails.ToDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.Compare(fromDate, toDate) >= 0)
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_FROMDATE);
                }
                RequestMessageValidator validator = new RequestMessageValidator();
                var result = validator.Validate(userDetails);
                if (!(userDetails is null))
                {
                    if (result.IsValid)
                    {
                        var userInfoNew = ServiceManager.GetInstance().GetUserInformation()
                            .GetUserDetails(userDetails);
                        if (userInfoNew != null)
                        {
                            response.Total_Count = userInfoNew.Count;
                            response.userDetails = userInfoNew;
                            return response;
                        }
                        throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                    }
                    throw new MessageNotValidException(ErrorCodes.ERROR_FROM_VALIDATE);
                }
                throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                //GetUserDetailsService buisness = new GetUserDetailsService();
                //var buisness = ServiceManager.GetInstance().GetUserInformation();
                /*if (!ValidateEmail.ValidateRequestMessages(userDetails))
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                }
                if (ServiceManager.GetInstance().GetUserInformation().GetUserDetails(userDetails))
                {
                    response.Success = true;
                    return response;
                }*/
                //throw new MessageNotValidException(ErrorCodes.INVALID_USER);
            }
            catch (MessageNotValidException e)
            {
                response.ErrorCodes = e._errorConstants.ToString();
                return response;
            }
            catch (TimeoutException e)
            {
                response.ErrorCodes = ErrorCodes.INTERNAL_SERVER_ERROR.ToString();
                return response;

            }
        }
    }
}