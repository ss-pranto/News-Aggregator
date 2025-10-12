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
    public class FilterController : ApiController
    {
        [Route("filter/keyword/{key}")]
        [HttpGet]
        public HttpResponseMessage GetFilterByKey(string key)
        {
            var data = FilterNewsService.FilterByKey(key);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("filter/source/{source}")]
        [HttpGet]
        public HttpResponseMessage GetFilterBySource(string source)
        {
            var data = FilterNewsService.FilterBySource(source);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("filter/date/{date}")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDate(DateTime date)
        {
            var data = FilterNewsService.FilterByDate(date);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("filter/date/asc")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDateAsc()
        {
            var data = FilterNewsService.FilterByDateAsc();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("filter/date/dec")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDateDec()
        {
            var data = FilterNewsService.FilterByDateDec();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
