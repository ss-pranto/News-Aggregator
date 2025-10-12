using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IWorkflow
    {
        bool Submit(News news, int id);
        List<News> GetSubmits(int id);
        bool Delete(int id);
        bool Update(News news, int id);
        bool AddWorkFlow(int newsID, int id, string action);
    }
}
