using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DemoService.ClientLayer;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.DAO;

namespace RESTful_Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUserDetailsController : ControllerBase
    {
        
        [HttpPost]
        public string Post(DefaultRequestMessage userRequestMessage)
        {
            RequestProcessor client = new RequestProcessor();
            var message = client.UserValidate(userRequestMessage);
            //return message;
            List<string> arr = new List<string>();
            arr.Add(message);
            return message;
        }
    }
}
