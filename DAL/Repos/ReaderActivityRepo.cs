using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReaderActivityRepo : IActivity
    {
        News_AggregatorEntities db;
        public ReaderActivityRepo()
        {
            db = new News_AggregatorEntities();
        }
        public bool GetActivity(int NewsID, int UserID)
        {
            var data = db.ReaderActivities.Where(s => s.NewsID == NewsID && s.ReaderID == UserID && s.Activity == "like").FirstOrDefault();
            if (data != null)
            {
                return true;
            }
            return false;
        }
        public bool AddActivity(int NewsID, int UserID, string activity)
        {

            ReaderActivity readerActivity = new ReaderActivity()
            {
                NewsID = NewsID,
                ReaderID = UserID,
                Activity = activity,
            };
            db.ReaderActivities.Add(readerActivity);

            return db.SaveChanges() > 0;
        }
        public bool RemoveActivity(int NewsID, int UserID)
        {

            db.ReaderActivities.Remove(db.ReaderActivities.FirstOrDefault(ra => ra.NewsID == NewsID && ra.ReaderID == UserID));
            db.NewsPopularities.Where(s=> s.NID == NewsID).FirstOrDefault().LikeCnt--;

            return db.SaveChanges() > 0;
        }

    }
}
