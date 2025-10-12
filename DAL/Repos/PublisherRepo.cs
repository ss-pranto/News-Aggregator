using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PublisherRepo : INews<News, int, bool>, IPublisher
    {
        News_AggregatorEntities db;
        public PublisherRepo()
        {
            db = new News_AggregatorEntities();
        }

        public List<News> GetAllApproved()
        {
            return db.News.Where(s=> s.Status == "Approved").ToList();
        }

        public List<News> GetAllPublished()
        {
            throw new NotImplementedException();
        }

        public News GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public News GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePublishState(News news, int id)
        {
            var existingNews = db.News.FirstOrDefault(n => n.ID == news.ID);

            if (existingNews == null)
                return false;

            if (existingNews.Status == "Published")
                return false;

            existingNews.Status = news.Status;
            existingNews.PublishedDate = DateTime.Now;

            return db.SaveChanges() > 0;
        }
    }
}
