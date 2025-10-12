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

    public class LoadAndRatingController : ApiController
    {
        [Route("reporter/points")]
        [HttpGet]
        public HttpResponseMessage GetReporterPoints()
        {
            var data = LoadAndRatingService.ReporterRating();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("reporter/approvalRate/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReporterApprovalRate(int id)
        {
            var data = LoadAndRatingService.ApprovalRateByReporter(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("editor/review/count/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPendingNewsCount(int id)
        {
            var data = LoadAndRatingService.ReviewCnt(id);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data.Count());
        }
        [Route("pending/count")]
        [HttpGet]
        public HttpResponseMessage GetPendingNewsCount()
        {
            var data = LoadAndRatingService.PendingCnt();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data.Count());
        }
        [Route("pending")]
        [HttpGet]
        public HttpResponseMessage GetPendingNews()
        {
            var data = LoadAndRatingService.PendingCnt();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("publish/day/{date}")]
        [HttpGet]
        public HttpResponseMessage GetPublishByDate(DateTime date)
        {
            var data = LoadAndRatingService.PublishDay(date);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("publish/freq/{type}")]
        [HttpGet]
        public HttpResponseMessage GetPublishFreqDay(string type)
        {
            var data = LoadAndRatingService.PublishFreq(type);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
