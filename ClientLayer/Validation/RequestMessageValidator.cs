using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoService.BusinessLayer.Entities.Enums;
using DemoService.Exceptions;
using FluentValidation;
using RESTful_Services.BusinessLayer.Entities.Enums;
using RESTServices.Controllers.ControllerDTO;

namespace RESTful_Services.ClientLayer.Validation
{
    public class RequestMessageValidator : AbstractValidator<DefaultRequestMessage>
    {
        public RequestMessageValidator()
        {

            RuleFor(person => person.UserEmail).NotNull().NotEmpty().Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                .OnAnyFailure(x =>
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                });


            RuleFor(person => person.FromDate).NotNull().NotEmpty()
                .Matches(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$")
                .OnAnyFailure(x =>
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                });


            RuleFor(person => person.ToDate).NotNull().NotEmpty()
                .Matches(@"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$")
                .OnAnyFailure(x =>
                {
                    throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                });


            RuleFor(person => person.sortbyParameter).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != "firstname" && parameter != "lastname" &&
                        parameter != "createdDate")
                    {
                        throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                    }
                });


            RuleFor(person => person.sortyDirection).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != "aes" && parameter != "desc")
                    {
                        throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                    }
                });


            RuleFor(person => person.AccessType).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != UserTypes.FullAccess.ToString()
                        && parameter != UserTypes.StandardAccess.ToString()
                        && parameter != UserTypes.ViewOnlyAccess.ToString())
                    {
                        throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                    }
                });


            RuleFor(person => person.UserStatus).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != UserStatuses.Active.ToString()
                        && parameter != UserStatuses.Deleted.ToString()
                        && parameter != UserStatuses.All.ToString())
                    {
                        throw new MessageNotValidException(ErrorCodes.INVALID_USER);
                    }
                });

        }
    }
}
