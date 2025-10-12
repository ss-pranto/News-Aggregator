using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherWorkflowService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Tag, TagDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<NewsDTO> GetAllApproved()
        {
            var data = DataAccessFactory.PublisherNews().GetAllApproved();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static bool UpdateApprovedStatus(NewsDTO news, int id)
        {
            var mapNews = GetMapper().Map<News>(news);
            var ret1 = DataAccessFactory.PublisherNews().UpdatePublishState(mapNews, id);
            var ret2 = DataAccessFactory.NewsWorkflowExtend().AddWorkFlow(mapNews.ID, id, mapNews.Status);
            if (ret1 && ret2) return true;
            return false;
        }
    }
}
