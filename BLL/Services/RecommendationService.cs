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
    public class RecommendationService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
                cfg.CreateMap<Recommendation, RecommendationDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static bool BookmarkNews(int RID, int NID)
        {
            return DataAccessFactory.Recommendation().CreateBookmark(RID, NID);
        }
        public static bool RemoveBookmark(int RID, int NID)
        {
            return DataAccessFactory.Recommendation().RemoveBookmark(RID, NID);
        }
        public static bool GetBookmark(int RID, int NID)
        {
            return DataAccessFactory.Recommendation().GetBookmark(RID, NID);
        }
        public static List<NewsDTO> RecommendedNews(int RID)
        {
            var data = DataAccessFactory.Recommendation().RecommendedNews(RID);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsDTO> PopularNews()
        {
            var data = DataAccessFactory.Recommendation().PopularNews();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
    }
}
