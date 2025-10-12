using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NewsRepos : INews<News, int, bool>
    {
        News_AggregatorEntities db;
        public NewsRepos() { 
            db = new News_AggregatorEntities();
        }
        public News GetByID(int id)
        {
            var data = db.NewsPopularities.Where(s=> s.NID == id).FirstOrDefault();
            data.OpenCnt++;
            db.SaveChanges();
            return db.News.Find(id);
        }
        public List<News> GetAllPublished()
        {
            return db.News.Where(s => s.Status == "Published").OrderByDescending(s=> s.PublishedDate).ToList();
        }
        public News GetByTitle(string title)
        {
            return db.News.FirstOrDefault(s => s.Title == title);
        }
    }
}
