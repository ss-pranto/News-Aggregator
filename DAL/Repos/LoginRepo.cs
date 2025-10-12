using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class LoginRepo : ILogin
    {
        News_AggregatorEntities db;
        public LoginRepo()
        {
            db = new News_AggregatorEntities();
        }
        public bool AddPass(int uid, string pass)
        {
            UserPassword password = new UserPassword()
            {
                UID = uid,
                Password = pass
            };
            db.UserPasswords.Add(password);
            return db.SaveChanges() > 0;
        }

        public bool AddUser(string name, string email, string role)
        {
            User user = new User() 
            {
                Name = name,
                Email = email,
                Role = role,
                CreatedAt = DateTime.Now
            };
            db.Users.Add(user);
            return db.SaveChanges() > 0;
        }

        public UserPassword GetPass(int uid)
        {
            return db.UserPasswords.Where(s=> s.UID == uid).FirstOrDefault();
        }

        public bool UpdatetPass(int uid, string pass)
        {
            var data = db.UserPasswords.Where(s => s.UID == uid).FirstOrDefault();
            if (data != null)
            {
                data.Password = pass;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public User GetUser(string email)
        {
            return db.Users.Where(s => s.Email == email).FirstOrDefault();
        }
    }
}
