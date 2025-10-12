using DAL.EF;
using DAL.Interfaces;
using DLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoadRatingRepo : ILoadRating
    {
        News_AggregatorEntities db;
        public LoadRatingRepo()
        {
            db = new News_AggregatorEntities();
        }
        public List<ReporterRating> GetAll()
        {
            return db.ReporterRatings.ToList();
        }
        public List<News> GetAllPending()
        {
            return db.News.Where(s => s.Status == "Pending").ToList();
        }
        public List<News> GetNewsByEmpID(int id)
        {
            return db.News.Where(s=> s.SubmittedBy == id).ToList();
        }
        public List<NewsWorkFlow> GetWorkFlowByEmpID(int id)
        {
            return db.NewsWorkFlows.Where(s=> s.ActionBy == id).ToList();
        }
        public List<News> PublishDay(DateTime date)
        {
            return db.News.Where(s => DbFunctions.TruncateTime(s.PublishedDate) == DbFunctions.TruncateTime(date)).ToList();
        }
        public List<PublishFrequency> GetPublishFrequency(string type)
        {
            switch (type.ToLower())
            {
                case "day":
                    return db.News
                        .Where(n => n.PublishedDate != null)
                        .GroupBy(n => DbFunctions.TruncateTime(n.PublishedDate))
                        .Select(g => new PublishFrequency
                        {
                            PublishDate = g.Key.Value,
                            Frequency = g.Count()
                        })
                        .ToList();

                case "month":
                    return db.News
                        .Where(n => n.PublishedDate != null)
                        .GroupBy(n => new
                        {
                            Year = n.PublishedDate.Value.Year,
                            Month = n.PublishedDate.Value.Month
                        })
                        .Select(g => new PublishFrequency
                        {
                            Year = g.Key.Year,
                            Month = g.Key.Month,
                            Frequency = g.Count()
                        })
                        .ToList();

                case "year":
                    return db.News
                        .Where(n => n.PublishedDate != null)
                        .GroupBy(n => n.PublishedDate.Value.Year)
                        .Select(g => new PublishFrequency
                        {
                            Year = g.Key,
                            Frequency = g.Count()
                        })
                        .ToList();

                default:
                    throw new ArgumentException("Invalid type. Use 'day', 'month', or 'year'.");
            }
        }
    }
}
