using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string pass, string email)
        {
            var data = UserLoginService.Login(email, pass);
            if (data)
            {
                Session["Log_user"] = email;
                TempData["Log_info"] = "Login successful";
                return RedirectToAction("Index", "Home");
            }
            TempData["Log_info"] = "Email or Password is incorrect";
            return RedirectToAction("Index");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(string name, string pass, string email, string role)
        {
            UserDTO userDTO = new UserDTO() { Name = name, Email = email, Role = role };
            UserPassDTO passDTO = new UserPassDTO() { Password = pass };
            var data = UserLoginService.Register(userDTO, passDTO);

            TempData["Reg_info"] = "Registration successful";
            return RedirectToAction("Index");
        }
    }
}