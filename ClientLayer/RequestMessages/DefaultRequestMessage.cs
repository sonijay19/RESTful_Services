﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServices.Controllers.ControllerDTO
{
    public class UserDetailRequestMessage
    {
        //public string UserEmail { get; set; }
        public string sortbyParameter { get; set; }
        public string sortbyDirection { get; set; }
        public string FromDate{ get; set; }
        public string ToDate { get; set; }
        public string UserStatus { get; set; }
        public string AccessType { get; set; }
    }
}
