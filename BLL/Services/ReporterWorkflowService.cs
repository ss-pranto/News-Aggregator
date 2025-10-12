using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ReporterWorkflowService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Tag, TagDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<NewsDTO> GetSubmits(int id)
        {
            var data = DataAccessFactory.NewsWorkflowExtend().GetSubmits(id);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static bool Submit(NewsDTO news, List<TagDTO> tags, int id)
        {
            var mapNews = GetMapper().Map<News>(news);
            bool ret = DataAccessFactory.NewsWorkflowExtend().Submit(mapNews, id);
            bool ret1 = TagService.AddTags(tags);
            bool ret2 = TagService.AddNewsTags(news, tags);

            var NewsData = DataAccessFactory.GetNews().GetByTitle(mapNews.Title);
            bool ret3 = DataAccessFactory.NewsWorkflowExtend().AddWorkFlow(NewsData.ID, id, "Submitted");

            if (ret && ret1 && ret2 && ret3) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            var newsObj = DataAccessFactory.GetNews().GetByID(id);
            if (newsObj.Status != "Pending")
            {
                return false;
            }
            var ret1 = TagService.DeleteByNews(id);
            var ret2 = DataAccessFactory.NewsWorkflowExtend().Delete(id);
            if (ret1 && ret2) return true;
            return false;
        }
        public static bool Update(NewsDTO news, List<TagDTO> tags, int id)
        {
            var mapNews = GetMapper().Map<News>(news);
            var mapTags = GetMapper().Map<List<Tag>>(tags);
            var newsObj = DataAccessFactory.NewsWorkflowBase().GetByID(mapNews.ID);
            if (newsObj.Status != "Pending")
            {
                return false;
            }
            var ret = TagService.UpdateNewsTag(newsObj.ID, mapTags);
            var ret1 = DataAccessFactory.NewsWorkflowExtend().Update(mapNews, id);
            var ret2 = DataAccessFactory.NewsWorkflowExtend().AddWorkFlow(newsObj.ID, id, "Updated");
            if(ret1 && ret2) return true;
            return false;
        }
    }
}
