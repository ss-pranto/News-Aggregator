using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Presentation.Controllers
{
    [RoutePrefix("api/news")]
    public class LoginController : ApiController
    {
        [Route("user/register")]
        [HttpPost]
        public HttpResponseMessage Register(LoginRequestDTO login)
        {
            try
            {
                var data = UserLoginService.Register(login.User, login.Password);
                if (data == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("user/login/{email}/{pass}")]
        [HttpGet]
        public HttpResponseMessage Login(string email, string pass)
        {
            try
            {
                var data = UserLoginService.Login(email, pass);
                if (data == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [Route("user/otp/{email}/{pass}")]
        [HttpGet]
        public HttpResponseMessage GetOTP(string email, string pass)
        {
            try
            {
                var data = UserLoginService.ForgetPassOTP(email);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, "your OTP: " + data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("user/change/password/{email}/{pass}/{otp_sys}/{otp_input}")]
        [HttpPut]
        public HttpResponseMessage ChangePass(string email, string pass, int otp_sys, int otp_input)
        {
            try
            {
                var data = UserLoginService.ChangePass(email, pass, otp_sys, otp_input);
                if (data == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }   
        }
    }
}
