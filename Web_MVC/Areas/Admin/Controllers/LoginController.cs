using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Framework;
using Web_MVC.Areas.Admin.Models;
using Model;
using Web_MVC.Areas.Admin.Code;
using System.Web.Security;

namespace Web_MVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel model)
        {
           // var result = new AccountModel().Login(model.UserName,model.Password);
            if(Membership.ValidateUser(model.UserName,model.Password) && ModelState.IsValid && (model.UserName!=null && model.Password!=null))
            {
                // SessionHelper.SetSession(new UserSession() { UserName = model.UserName });

                FormsAuthentication.SetAuthCookie(model.UserName,model.RememberMe);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}