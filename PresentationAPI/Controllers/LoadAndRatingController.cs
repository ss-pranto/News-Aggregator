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
            try
            {
                var data = LoadAndRatingService.ReporterRating();
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
        [Route("reporter/approvalRate/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReporterApprovalRate(int id)
        {
            try
            {
                var data = LoadAndRatingService.ApprovalRateByReporter(id);
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
        [Route("editor/review/count/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPendingNewsCount(int id)
        {
            try
            {
                var data = LoadAndRatingService.ReviewCnt(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data.Count());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("pending/count")]
        [HttpGet]
        public HttpResponseMessage GetPendingNewsCount()
        {
            try
            {
                var data = LoadAndRatingService.PendingCnt();
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data.Count());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("pending")]
        [HttpGet]
        public HttpResponseMessage GetPendingNews()
        {
            try
            {
                var data = LoadAndRatingService.PendingCnt();
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
        [Route("publish/day/{date}")]
        [HttpGet]
        public HttpResponseMessage GetPublishByDate(DateTime date)
        {
            try
            {
                var data = LoadAndRatingService.PublishDay(date);
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
        [Route("publish/freq/{type}")]
        [HttpGet]
        public HttpResponseMessage GetPublishFreqDay(string type)
        {
            try
            {
                var data = LoadAndRatingService.PublishFreq(type);
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
