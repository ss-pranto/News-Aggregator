using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INews<CLASS,ID,RET>
    {
        List<CLASS> GetAllPublished();
        CLASS GetByID(ID id);
        CLASS GetByTitle(string title);
    }
}
