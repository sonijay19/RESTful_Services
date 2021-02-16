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
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GetUserDetailsController> _logger;

        public GetUserDetailsController(ILogger<GetUserDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public Object Post(DefaultRequestMessage userRequestMessage)
        {
            RequestProcessor client = new RequestProcessor();
            var message = client.UserValidate(userRequestMessage);
            //return message;
            List<string> arr = new List<string>();
            arr.Add(message);
            return arr;
        }
    }
}
