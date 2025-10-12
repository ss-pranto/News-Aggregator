using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EditorWorkflowService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Tag, TagDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        //public static List<NewsDTO> GetNewsList()
        //{
        //    var data = DataAccessFactory.GetNews().GetAll();
        //    return GetMapper().Map<List<NewsDTO>>(data);
        //}
        public static List<NewsDTO> GetAllPending()
        {
            var data = DataAccessFactory.EditorNews().GetAllPending();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static bool UpdateReviewStatus(NewsDTO news, int id)
        {
            var mapNews = GetMapper().Map<News>(news);
            var ret = DataAccessFactory.EditorNews().UpdateReviewState(mapNews, id);
            ret = DataAccessFactory.NewsWorkflowExtend().AddWorkFlow(mapNews.ID, id, mapNews.Status);

            return ret;
        }
    }
}
