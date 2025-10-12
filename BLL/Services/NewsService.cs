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
    public class NewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Tag, TagDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<NewsDTO> GetNewsList() 
        {
            var data = DataAccessFactory.GetNews().GetAllPublished();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static NewsDTO GetByID(int id)
        {
            var data = DataAccessFactory.GetNews().GetByID(id);
            return GetMapper().Map<NewsDTO>(data);
        }
        public static bool AddActivity(int NewsID, int UserID, string activity)
        {
            return DataAccessFactory.AddActivity().AddActivity(NewsID, UserID, activity);
        }
        public static bool RemoveActivity(int NewsID, int UserID)
        {
            return DataAccessFactory.AddActivity().RemoveActivity(NewsID, UserID);
        }
        public static bool GetActivity(int NewsID, int UserID)
        {
            return DataAccessFactory.AddActivity().GetActivity(NewsID, UserID);
        }
    }
}
