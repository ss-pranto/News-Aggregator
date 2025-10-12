using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILogin
    {
        User GetUser(string email);
        UserPassword GetPass(int uid);
        bool AddUser(string name, string email, string role);
        bool AddPass(int uid, string pass);
        bool UpdatetPass(int uid, string pass);
    }
}
