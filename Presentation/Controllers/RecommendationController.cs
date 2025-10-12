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
    public class RecommendationController : ApiController
    {
        [Route("bookmark/{RID}/{NID}")]
        [HttpPost]
        public HttpResponseMessage BookmarkNews(int RID, int NID)
        {
            var data = RecommendationService.BookmarkNews(RID, NID);
            if (data == false)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("recommend/{RID}")]
        [HttpGet]
        public HttpResponseMessage GetRecommendedNews(int RID)
        {
            var data = RecommendationService.RecommendedNews(RID);
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("popular/top")]
        [HttpGet]
        public HttpResponseMessage GetPopularNews()
        {
            var data = RecommendationService.PopularNews();
            if (data == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
