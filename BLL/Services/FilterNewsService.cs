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
    public class FilterNewsService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<NewsDTO> FilterByKey(string key)
        {
            var data = DataAccessFactory.FilterNews().FilterByKey(key);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsDTO> FilterBySource(string source)
        {
            var data = DataAccessFactory.FilterNews().FilterBySource(source);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsDTO> FilterByDate(DateTime date)
        {
            var data = DataAccessFactory.FilterNews().FilterByDate(date);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsDTO> FilterByDateAsc()
        {
            var data = DataAccessFactory.FilterNews().FilterByDateAsc();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static List<NewsDTO> FilterByDateDec()
        {
            var data = DataAccessFactory.FilterNews().FilterByDateDec();
            return GetMapper().Map<List<NewsDTO>>(data);
        }
        public static PagedNewsViewModel FilterByPage(int page = 1) 
        {
            int pageSize = 10;

            var totalNews = NewsService.GetNewsList().Count();
            var totalPages = (int)Math.Ceiling((double)totalNews / pageSize);

            var newsList = DataAccessFactory.FilterNews().FilterByPage(page, pageSize);

            return new PagedNewsViewModel
            {
                NewsList = newsList,
                CurrentPage = page,
                TotalPages = totalPages
            };
        }
        public static List<NewsDTO> ComplexFilter(string key = null, string source = null, DateTime? date = null, string sort = null)
        {
            var data = DataAccessFactory.FilterNews().FilterNews(key, source, date, sort);
            return GetMapper().Map<List<NewsDTO>>(data);
        }
    }
}
