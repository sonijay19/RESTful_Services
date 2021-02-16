using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoService.BusinessLayer.Entities.Enums;

namespace RESTServices.Controllers.ResponseMessage
{
    public class DefaultResponseMessages
    {
        public bool Success { get; set; } 
        public string? ErrorCode { get; set; }
    }
}
