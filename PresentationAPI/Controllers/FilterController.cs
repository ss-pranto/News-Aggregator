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
            try
            {
                var data = FilterNewsService.FilterByKey(key);
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
        [Route("filter/source/{source}")]
        [HttpGet]
        public HttpResponseMessage GetFilterBySource(string source)
        {
            try
            {
                var data = FilterNewsService.FilterBySource(source);
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
        [Route("filter/date/{date}")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDate(DateTime date)
        {
            try
            {
                var data = FilterNewsService.FilterByDate(date);
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
        [Route("filter/date/asc")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDateAsc()
        {
            try
            {
                var data = FilterNewsService.FilterByDateAsc();
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
        [Route("filter/date/dec")]
        [HttpGet]
        public HttpResponseMessage GetFilterByDateDec()
        {
            try
            {
                var data = FilterNewsService.FilterByDateDec();
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
        [Route("filter/complex")]
        [HttpGet]
        public HttpResponseMessage GetComplexFilter(string key = null, string source = null, DateTime? date = null, string sort = null)
        {
            try
            {
                var data = FilterNewsService.ComplexFilter(key, source, date, sort);
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
