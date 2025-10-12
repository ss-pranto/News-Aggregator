using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PagedNewsViewModel
    {
        public List<News> NewsList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
