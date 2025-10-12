using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class NewsWorkflowRepo : INews<News, int, bool>, IWorkflow
    {
        News_AggregatorEntities db;
        public NewsWorkflowRepo()
        {
            db = new News_AggregatorEntities();
        }
        public News GetByID(int id)
        {
            return db.News.Find(id);
        }

        public List<News> GetAllPublished()
        {
            throw new NotImplementedException();
        }

        public News GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public List<News> GetSubmits(int id)
        {
            return db.News.Where(s => s.SubmittedBy == id).ToList();
        }

        public bool Submit(News news, int id)
        {
            var existingNews = db.News.Where(s=> s.Title == news.Title).Count();
            if (existingNews != 0) 
            {
                return false;
            }
            news.Status = "Pending";
            news.CreatedAt = DateTime.Now;
            news.PublishedDate = null;
            news.SubmittedBy = id;
            db.News.Add(news);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.News.Remove(db.News.Find(id));
            return db.SaveChanges() > 0;
        }

        public bool Update(News news, int id)
        {
            var existingNews = db.News.FirstOrDefault(n => n.ID == news.ID);

            if (existingNews == null)
                return false;

            if (existingNews.Status == "Published")
                return false;

            existingNews.Title = news.Title;
            existingNews.Description = news.Description;
            existingNews.Category = news.Category;
            existingNews.Source = news.Source;
            //existingNews.CreatedAt = news.CreatedAt;

            return db.SaveChanges() > 0;
        }
        public bool AddWorkFlow(int newsID, int id, string action)
        {
            NewsWorkFlow workFlow = new NewsWorkFlow() 
            {
                NewsID = newsID,
                ActionBy = id,
                Action = action,
                ActionDate = DateTime.Now,
            };
            db.NewsWorkFlows.Add(workFlow);
            return db.SaveChanges() > 0;
        }
    }
}
