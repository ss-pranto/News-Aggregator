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
    public class ReaderController : ApiController
    {
        [Route("add/activity/{newsID}/{userID}/{activity}")]
        [HttpPost]
        public HttpResponseMessage AddActivity(int NewsID, int UserID, string activity)
        {
            var data = NewsService.AddActivity(NewsID, UserID, activity);
            if (data == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("remove/like/{newsID}/{userID}")]
        [HttpDelete]
        public HttpResponseMessage RemoveActivity(int NewsID, int UserID)
        {
            var data = NewsService.RemoveActivity(NewsID, UserID);
            if (data == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
