using DAL.EF;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILoadRating
    {
        List<ReporterRating> GetAll();
        List<News> GetNewsByEmpID(int id);//Reporter, Editor, Publisher
        List<NewsWorkFlow> GetWorkFlowByEmpID(int id);
        List<News> GetAllPending();
        List<News> PublishDay(DateTime date);
        List<PublishFrequency> GetPublishFrequency(string type);
    }
}
