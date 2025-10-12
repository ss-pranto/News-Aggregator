using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PublishFrequencyBLL
    {
        public DateTime? PublishDate { get; set; }   // for daily frequency
        public int? Year { get; set; }               // for yearly/monthly
        public int? Month { get; set; }              // for monthly
        public int Frequency { get; set; }           // count of news
    }
}
