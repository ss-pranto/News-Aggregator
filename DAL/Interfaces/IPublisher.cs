using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPublisher
    {
        List<News> GetAllApproved();
        bool UpdatePublishState(News news, int id);
    }
}
