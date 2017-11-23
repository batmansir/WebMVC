using Common.Login;
using Common.Public;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_MVC.Areas.Admin.Controllers
{
    public class BaseController: System.Web.Mvc.Controller
    {
       
        protected bool ExistSession()
        {
            var ses = (LoginClient)Session[MyCommon.SESSION_KEY_USER];
            if (ses == null)
            {
                return false;
            }
            return true;
        }
        protected string GetUserID()
        {
            var rs = "";
            rs = Session[Common.Public.MyCommon.SESSION_KEY_USERID] != null ? Session[Common.Public.MyCommon.SESSION_KEY_USERID].ToString() : "";
            return rs;
        }
    }
}