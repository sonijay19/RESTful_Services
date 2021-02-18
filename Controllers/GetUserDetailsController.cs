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
using Microsoft.AspNetCore.Mvc;

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
            //UserDetailrequest mesg same for response
            UserDetailsResponseMessages message = client.UserValidate(userRequestMessage);

            if (message.userDetails == null)
            {
                return Ok(message);
                //httpResquest.CreateErrorResponse(HttpStatusCode.NotFound, "Can not find any user");
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Can not find");
            }
            return Ok(message);
            //return httpResquest.CreateResponse(HttpStatusCode.OK,message);
            //return Request.CreateResponse<DefaultResponseMessages>(HttpStatusCode.OK, message);
        }
    }
}
