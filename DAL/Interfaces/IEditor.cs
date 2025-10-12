using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEditor
    {
        List<News> GetAllPending();
        bool UpdateReviewState(News news, int id);

    }
}
