using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NewsFilterRepo : IFilter
    {
        News_AggregatorEntities db;
        public NewsFilterRepo()
        {
            db = new News_AggregatorEntities();
        }
        public List<News> FilterByKey(string key)
        {
            var tagID = db.Tags.Where(s => s.TagName == key).Select(s => s.ID).FirstOrDefault();
            var newsIdByTags = db.NewsTags.Where(s => s.TagID == tagID && s.News.Status == "Published").Select(s => s.News).ToList();

            return newsIdByTags;
        }
        public List<News> FilterBySource(string source)
        {
            var newsIdBySource = db.News.Where(s => s.Source == source && s.Status == "Published").ToList();

            return newsIdBySource;
        }
        public List<News> FilterByDate(DateTime date)
        {
            var newsIdByDate = db.News.Where(s => s.PublishedDate.Value.Year == date.Year && s.PublishedDate.Value.Month == date.Month && s.PublishedDate.Value.Day == date.Day && s.Status == "Published").ToList();
            return newsIdByDate;
        }
        public List<News> FilterByDateAsc()
        {
            var newsIdByDate = db.News.Where(s=> s.Status == "Published").OrderBy(s => s.PublishedDate).ToList();
            return newsIdByDate;
        }
        public List<News> FilterByDateDec()
        {
            var newsIdByDate = db.News.Where(s => s.Status == "Published").OrderByDescending(s => s.PublishedDate).ToList();
            return newsIdByDate;
        }
        public List<News> FilterByPage(int page, int pageSize)
        {
            var newsList = db.News
            .OrderByDescending(n => n.PublishedDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return newsList;
        }
        public List<News> FilterNews(string key = null, string source = null, DateTime? date = null, string sort = null)
        {
            var query = db.News.AsQueryable();

            // Only published news
            query = query.Where(s => s.Status == "Published");

            // Filter by keyword/tag
            if (!string.IsNullOrEmpty(key))
            {
                var tagID = db.Tags
                    .Where(t => t.TagName == key)
                    .Select(t => t.ID)
                    .FirstOrDefault();

                query = query.Where(n => db.NewsTags.Any(nt => nt.NewsID == n.ID && nt.TagID == tagID));
            }

            // Filter by source
            if (!string.IsNullOrEmpty(source))
            {
                query = query.Where(s => s.Source == source);
            }

            // Filter by date
            if (date.HasValue)
            {
                query = query.Where(s =>
                    s.PublishedDate.HasValue &&
                    s.PublishedDate.Value.Year == date.Value.Year &&
                    s.PublishedDate.Value.Month == date.Value.Month &&
                    s.PublishedDate.Value.Day == date.Value.Day);
            }

            // Sort order
            if (sort == "asc")
            {
                query = query.OrderBy(s => s.PublishedDate);
            }
            else if (sort == "desc")
            {
                query = query.OrderByDescending(s => s.PublishedDate);
            }

            return query.ToList();
        }
    }
}
