using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class NewsWorkFlowDTO
    {
        public int ID { get; set; }
        public int NewsID { get; set; }
        public string Action { get; set; }
        public int ActionBy { get; set; }
        public System.DateTime ActionDate { get; set; }
    }
}
