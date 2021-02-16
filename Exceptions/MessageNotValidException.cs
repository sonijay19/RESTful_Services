using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoService.BusinessLayer.Entities.Enums;

namespace DemoService.Exceptions
{
    public class MessageNotValidException : Exception
    {
        public readonly ErrorCodes _errorConstants;
        public MessageNotValidException(ErrorCodes errorCode) :
            base(errorCode.ToString())
        {
            this._errorConstants = errorCode;
        }
    }
}