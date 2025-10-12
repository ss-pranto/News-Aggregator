using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class NewsDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> PublishedDate { get; set; }
        public string Status { get; set; }
        public int SubmittedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
    }
}
