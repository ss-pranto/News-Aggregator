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
    public class EditorController : ApiController
    {
        [Route("editor/all/pending")]
        [HttpGet]
        public HttpResponseMessage GetAllPending()
        {
            var data = EditorWorkflowService.GetAllPending();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("editor/update/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateReviewStatus(NewsDTO news, int id)//editor id
        {
            var data = EditorWorkflowService.UpdateReviewStatus(news, id);
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
