using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoService.BusinessLayer.Entities.Enums
{
    public enum ErrorCodes
    {
        INVALID_USER,
        INTERNAL_SERVER_ERROR,
        ERROR_FROM_VALIDATE,
        INVALID_SORTBYPARAMETER,
        INVALID_SORTBY_DIRECTION,
        INVALID_DATE,
        INVALID_USER_STATUS,
        INVALID_USER_ACCESSTYPE,
    }
}