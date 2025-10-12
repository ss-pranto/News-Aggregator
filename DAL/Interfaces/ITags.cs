using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITags
    {
        bool AddTag(Tag tag);
        bool AddNewsTag(News news, Tag tag);
        Tag GetByName(string tagName);
        bool Delete(int id);
        bool UpdateNewsTag(int newsID, Tag tag);
    }
}
