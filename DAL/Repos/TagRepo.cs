using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DAL.Repos
{
    internal class TagRepo : INews<Tag, int, bool>, ITags
    {
        News_AggregatorEntities db;

        public TagRepo()
        {
            db = new News_AggregatorEntities();
        }

        public List<Tag> GetAllPublished()
        {
            return db.Tags.ToList();
        }

        public Tag GetByID(int id)
        {
            return db.Tags.Find(id);
        }

        public Tag GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public Tag GetByName(string tagName)
        {
            return db.Tags.FirstOrDefault(t => t.TagName == tagName);
        }

        public bool AddTag(Tag tag)
        {
            db.Tags.Add(tag);
            return db.SaveChanges() > 0;
        }

        public bool AddNewsTag(News news, Tag tag)
        {
            var newsEntity = db.News.Where(s=> s.Title == news.Title);
            var tagEntity = db.Tags.Where(s => s.TagName == tag.TagName);

            if (newsEntity == null || tagEntity == null)
                return false;

            NewsTag newsTag = new NewsTag
            {
                NewsID = newsEntity.FirstOrDefault().ID,
                TagID = tagEntity.FirstOrDefault().ID
            };

            db.NewsTags.Add(newsTag);
            return db.SaveChanges() > 0;
        }
        public bool UpdateNewsTag(int newsID, Tag tag)
        {
            var existingTag = db.Tags.FirstOrDefault(s => s.TagName == tag.TagName);

            NewsTag newsTag = new NewsTag()
            {
                NewsID = newsID,
                TagID = existingTag.ID
            };
            db.NewsTags.Add(newsTag);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var data = db.NewsTags.Where(s => s.NewsID == id);
            if (data == null) return false;
            foreach (var item in data)
            {
                db.NewsTags.Remove(item);
            }
            return db.SaveChanges() > 0;
        }
    }
}
