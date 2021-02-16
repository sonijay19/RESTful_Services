using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Services.BusinessLayer.Entities.Enums
{
    public enum UserStatuses
    {
        Active,
        Deleted,
        All,
    }

    public enum UserTypes
    {
        FullAccess,
        StandardAccess,
        ViewOnlyAccess
    }
}
