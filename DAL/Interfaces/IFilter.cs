using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFilter
    {
        List<News> FilterByKey(string key);
        List<News> FilterBySource(string source);
        List<News> FilterByDate(DateTime date);
        List<News> FilterByDateAsc();
        List<News> FilterByDateDec();
        List<News> FilterByPage(int page, int pageSize);
        List<News> FilterNews(string key = null, string source = null, DateTime? date = null, string sort = null);
    }
}
