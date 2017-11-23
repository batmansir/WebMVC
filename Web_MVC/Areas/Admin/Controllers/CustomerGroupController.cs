using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_MVC.Areas.Admin.Controllers
{
    public class CustomerGroupController : Controller
    {
        // GET: Admin/CustomerGroup
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var model = new CustomerGroupModel();
            return Json(model.GetList(), JsonRequestBehavior.AllowGet);
        }
    }
}