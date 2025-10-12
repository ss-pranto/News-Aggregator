using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RecommendationDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int NewsID { get; set; }
        public double Score { get; set; }
        public System.DateTime RecommendDate { get; set; }
    }
}
