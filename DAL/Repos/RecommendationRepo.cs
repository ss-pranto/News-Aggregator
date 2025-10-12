using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repos
{
    internal class RecommendationRepo : IRecommendation
    {
        News_AggregatorEntities db;
        public RecommendationRepo()
        {
            db = new News_AggregatorEntities();
        }

        public bool CreateBookmark(int RID, int NID)
        {
            Recommendation bookmark = new Recommendation
            {
                UserID = RID,
                NewsID = NID,
            };
            db.Recommendations.Add(bookmark);
            return db.SaveChanges()>0;
        }
        public bool RemoveBookmark(int RID, int NID)
        {
            db.Recommendations.Remove(db.Recommendations.Where(s=> s.UserID == RID && s.NewsID == NID).FirstOrDefault());
            return db.SaveChanges() > 0;
        }
        public bool GetBookmark(int RID, int NID)
        {
            var data = db.Recommendations.Where(s=> s.UserID == RID && s.NewsID == NID).FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            return false;
        }
        public List<News> RecommendedNews(int RID)
        {
            var bookmarkedNewsIds = db.Recommendations
                .Where(s => s.UserID == RID)
                .Select(s => s.NewsID)
                .ToList();

            var tagIds = db.NewsTags
                .Where(s => bookmarkedNewsIds.Contains(s.NewsID))
                .Select(s => s.TagID)
                .Distinct()
                .ToList();

            var relatedNewsIds = db.NewsTags
                .Where(s => tagIds.Contains(s.TagID))
                .Select(s => s.NewsID)
                .Distinct()
                .ToList();

            return db.News.Where(s=> relatedNewsIds.Contains(s.ID) && s.Status == "Published").ToList();
        }
        public List<News> PopularNews()
        {
            var data = db.NewsPopularities.ToList();
            foreach (var item in data)
            {
                item.PopularityScore = PopularityScore(item.OpenCnt, item.ShareCnt, item.LikeCnt);
            }
            db.SaveChanges();

            var popularNewsIds = db.NewsPopularities
                .OrderByDescending(s => s.PopularityScore)
                .Take(15)
                .Select(s => s.NID)
                .ToList();

            return db.News.Where(s => popularNewsIds.Contains(s.ID) && s.Status == "Published").OrderBy(s=> s.PublishedDate).ToList();
        }
        public float PopularityScore(int open, int shares, int likes)
        {
            var popularityScore = (float)((open * 0.2) + (shares * 0.3) + (likes * 0.2));
            return popularityScore;
        }
    }
}
