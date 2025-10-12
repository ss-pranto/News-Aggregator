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
    public class NewsController : ApiController
    {
        [Route("get/all")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = NewsService.GetNewsList();
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("get/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByID(int id)
        {
            try
            {
                var data = NewsService.GetByID(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
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
