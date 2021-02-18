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
    [Route("[controller]")]
    public class GetUserDetailsController : ControllerBase
    {
        
        [HttpPost]
        public HttpResponseMessage Post(DefaultRequestMessage userRequestMessage)
        {
            HttpRequestMessage httpResquest = new HttpRequestMessage();
            var res = new HttpResponseMessage();
            RequestProcessor client = new RequestProcessor();
            DefaultResponseMessages message = client.UserValidate(userRequestMessage);

            if (message == null)
            {
                res.StatusCode = HttpStatusCode.NotFound;
                res.Content = new StringContent("Can't find any user", Encoding.UTF8, "application/json");
                return res;
                //httpResquest.CreateErrorResponse(HttpStatusCode.NotFound, "Can not find any user");
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Can not find");
            }
            res.StatusCode = HttpStatusCode.OK;
            res.Content = new ObjectContent<String>(JsonConvert.SerializeObject(message), new JsonMediaTypeFormatter());
            return res;
            //return httpResquest.CreateResponse(HttpStatusCode.OK,message);
            //return Request.CreateResponse<DefaultResponseMessages>(HttpStatusCode.OK, message);
        }
    }
}
