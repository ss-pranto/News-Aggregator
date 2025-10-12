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
    public class PublisherController : ApiController
    {
        [Route("publisher/all/approved")]
        [HttpGet]
        public HttpResponseMessage GetAllApproved()
        {
            var data = PublisherWorkflowService.GetAllApproved();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("publisher/update/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateReviewStatus(NewsDTO news, int id)//publisher id
        {
            var data = PublisherWorkflowService.UpdateApprovedStatus(news, id);
            if (data)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
        }
    }
}
