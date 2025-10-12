using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SubmitNewsRequestDTO
    {
        public NewsDTO News { get; set; }
        public List<TagDTO> Tags { get; set; }

    }
}
