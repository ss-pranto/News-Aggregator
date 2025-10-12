using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserLoginService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>().ReverseMap();
                cfg.CreateMap<UserPassword, UserPassDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static UserDTO GetUser(string email)
        {
            var data = DataAccessFactory.UserLoginControl().GetUser(email);
            return GetMapper().Map<UserDTO>(data);
        }
        public static UserPassDTO GetPass(int uid)
        {
            var data = DataAccessFactory.UserLoginControl().GetPass(uid);
            return GetMapper().Map<UserPassDTO>(data);
        }
        public static bool Login(string email, string pass)
        {
            var userData = DataAccessFactory.UserLoginControl().GetUser(email);
            if (userData == null) return false;
            var passData = DataAccessFactory.UserLoginControl().GetPass(userData.ID);
            var hashPass = GetMd5Hash(pass);
            //new MailService().SendEmail(email, "Login Alert", $"Hello {userData.Name},\n\nThere was a login to your account on {DateTime.Now}.\nIf this wasn't you, please reset your password immediately.\n\nBest regards,\nNews Aggregator Team");
            if (passData.Password != hashPass)
            {
                return false;
            }
            return true;
        }
        public static bool Register(UserDTO user, UserPassDTO pass)
        {
            var userData = GetMapper().Map<User>(user);
            var passData = GetMapper().Map<UserPassword>(pass);
            var addUser = DataAccessFactory.UserLoginControl().AddUser(userData.Name, userData.Email, userData.Role);
            var userID = GetUser(userData.Email);
            var addPass = DataAccessFactory.UserLoginControl().AddPass(userID.ID, GetMd5Hash(passData.Password));
            new MailService().SendEmail(userData.Email, "Registration Successful", $"Hello {userData.Name},\n\nYour registration was successful!\n\nBest regards,\nNews Aggregator Team");
            if (addUser && addPass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int? ForgetPassOTP(string email)
        {
            var userData = DataAccessFactory.UserLoginControl().GetUser(email);
            if (userData == null)
            {
                return null;
            }
            var otp = new Random().Next(10000, 99999);
            new MailService().SendEmail(email, "Forget Password.", $"Hello {userData.Name},\n\nYour OTP is {otp}\n\nBest regards,\nNews Aggregator Team");
            return otp;
        }
        public static bool ChangePass(string email, string pass, int otp_sys, int otp_input)
        {
            var userID = GetUser(email).ID;
            var hashPass = GetMd5Hash(pass);
            if (otp_sys != otp_input)
            {
                return false;
            }
            return DataAccessFactory.UserLoginControl().UpdatetPass(userID, hashPass);
        }
        static string GetMd5Hash(string input)
        {
            // Create MD5 instance
            using (MD5 md5 = MD5.Create())
            {
                // Convert input string to byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the MD5 hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));  // x2 = lowercase hex format

                return sb.ToString();
            }
        }
    }
}
