using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful_Services.BusinessLayer.Entities.DTO
{
    public class BusinessReuqestMessage
    {
        public string UserEmail { get; set; }
        public string sortbyParameter { get; set; }
        public string sortyDirection { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserStatus { get; set; }
        public string AccessType { get; set; }
    }
}
