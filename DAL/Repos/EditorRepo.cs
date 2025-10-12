using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EditorRepo : INews<News, int, bool>, IEditor
    {
        News_AggregatorEntities db;
        public EditorRepo()
        {
            db = new News_AggregatorEntities();
        }
        public List<News> GetAllPending()
        {
            return db.News.Where(s=> s.Status == "Pending").ToList();
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

        public bool UpdateReviewState(News news, int id)
        {
            var existingNews = db.News.FirstOrDefault(n => n.ID == news.ID);
            var existingUser = db.ReporterRatings.FirstOrDefault(u => u.UserID == news.SubmittedBy);

            if (existingNews == null)
                return false;

            if (existingNews.Status == "Published")
                return false;

            existingNews.Status = news.Status;

            if(news.Status == "Approved" && existingUser != null)
            {
                existingUser.Rating += 1;
            }
            else
            {
                existingUser.Rating = Math.Max(0, existingUser.Rating - 1);
            }

            return db.SaveChanges() > 0;
        }
    }
}
