using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRecommendation
    {
        bool CreateBookmark(int RID, int NID);
        List<News> RecommendedNews(int RID);
        List<News> PopularNews();
        bool GetBookmark(int RID, int NID);
        bool RemoveBookmark(int RID, int NID);
    }
}
