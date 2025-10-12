using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation.Controllers
{
    [RoutePrefix("api/news")]
    public class LoginController : ApiController
    {
        [Route("user/Register")]
        [HttpPost]
        public HttpResponseMessage Register(UserDTO user, UserPassDTO pass)
        {
            var data = UserLoginService.Register(user, pass);
            if (data == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("user/Login/{email}/{pass}")]
        [HttpGet]
        public HttpResponseMessage Login(string email, string pass)
        {
            var data = UserLoginService.Login(email, pass);
            if (data == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
