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
            var data = NewsService.GetNewsList();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("get/{id}")]
        [HttpGet]
        public HttpResponseMessage GetByID(int id)
        {
            var data = NewsService.GetByID(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
