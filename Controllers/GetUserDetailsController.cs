using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoService.ClientLayer;
using RESTServices.Controllers.ControllerDTO;
using RESTServices.DAO;
using System.Net;
using System.Net.Http;
using RESTServices.Controllers.ResponseMessage;
using System.Net.Http.Formatting;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RESTful_Services.Controllers
{
    [ApiController]
    [Route("api/v1/Users")]
    public class GetUserDetailsController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get(UserDetailRequestMessage userRequestMessage)
        {
            HttpRequestMessage httpResquest = new HttpRequestMessage();
            var res = new HttpResponseMessage();
            RequestProcessor client = new RequestProcessor();
            UserDetailResponseMessages message = client.UserValidate(userRequestMessage);
            return Ok(message);
            //return httpResquest.CreateResponse(HttpStatusCode.OK,message);
            //return Request.CreateResponse<DefaultResponseMessages>(HttpStatusCode.OK, message);
        }
    }
}
