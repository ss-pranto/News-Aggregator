using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IActivity
    {
        bool GetActivity(int NewsID, int UserID);
        bool AddActivity(int NewsID, int UserID, string activity);
        bool RemoveActivity(int NewsID, int UserID);
    }
}
