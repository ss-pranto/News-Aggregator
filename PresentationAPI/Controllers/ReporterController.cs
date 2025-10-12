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
    public class ReporterController : ApiController
    {
        [Route("reporter/all/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAll(int id)
        {
            try
            {
                var data = ReporterWorkflowService.GetSubmits(id);
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
        [Route("reporter/submit/{id}")]
        [HttpPost]
        public HttpResponseMessage Submit(SubmitNewsRequestDTO request, int id)
        {
            try
            {
                var data = ReporterWorkflowService.Submit(request.News, request.Tags, id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("reporter/delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)//news id
        {
            try
            {
                var data = ReporterWorkflowService.Delete(id);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("reporter/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(SubmitNewsRequestDTO request, int id)
        {
            try
            {
                var data = ReporterWorkflowService.Update(request.News, request.Tags, id);//id reporter id
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
