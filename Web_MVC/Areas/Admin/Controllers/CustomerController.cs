using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Framework;
using Model;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Web_MVC.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var model = new Model.CustomerModel();
            var list = model.GetList();
            var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        // /Customer/Update
        [HttpPost()]
        [ValidateInput(true)]
        public JsonResult Update(CUSTOMER cg)
        {
            var messageResult = new MyMessageResult();
            /*if (!ExistSession())
            {
                messageResult.message = "Phiên làm việc của bạn đã hết. Vui lòng đăng nhập lại.";
                messageResult.status = false;
                return Json(messageResult);
            }*/
            if (string.IsNullOrEmpty(cg.Customer_ID))
            {
                messageResult.message = "Bạn chưa nhập mã khách hàng";
                messageResult.status = false;
                return Json(messageResult);
            }

            if (string.IsNullOrEmpty(cg.CustomerName))
            {
                messageResult.message = "Bạn chưa nhập tên khách hàng";
                messageResult.status = false;
                return Json(messageResult);
            }

            var model = new Model.CustomerModel();

            string result = model.Update(cg);
            if (result == "OK")
            {
                messageResult.message = "OK";
                messageResult.status = true;
                return Json(messageResult);
            }
            else
            {
                messageResult.message = result;
                messageResult.status = false;
                return Json(messageResult);
            }
        }


        // /Product/NewID
        [HttpGet]
        [ValidateInput(true)]
        public JsonResult NewID()
        {
            var messageResult = new MyMessageResult();
            var model = new Model.CustomerModel();

            string result = model.NewID();
            messageResult.message = result;
            messageResult.status = true;
            return Json(messageResult, JsonRequestBehavior.AllowGet);
        }

        // /Customer/Insert
        [HttpPost()]
        [ValidateInput(true)]
        public JsonResult Insert(CUSTOMER cg)
        {
            var messageResult = new MyMessageResult();
            /*if (!ExistSession())
            {
                messageResult.message = "Phiên làm việc của bạn đã hết. Vui lòng đăng nhập lại.";
                messageResult.status = false;
                return Json(messageResult);
            }*/
            if (string.IsNullOrEmpty(cg.Customer_ID))
            {
                messageResult.message = "Bạn chưa nhập mã khách hàng";
                messageResult.status = false;
                return Json(messageResult);
            }

            if (string.IsNullOrEmpty(cg.CustomerName))
            {
                messageResult.message = "Bạn chưa nhập tên khách hàng";
                messageResult.status = false;
                return Json(messageResult);
            }

            var model = new Model.CustomerModel();

            if (model.Exits(cg.Customer_ID))
            {
                messageResult.message = "Trùng mã khách hàng";
                messageResult.status = false;
                return Json(messageResult);
            }
            cg.CreditLimit = 0;
            cg.Discount = 0;
            cg.Active = true;
            cg.CreateDate = DateTime.Now;
            string result = model.Insert(cg);
            if (result == "OK")
            {
                messageResult.message = "OK";
                messageResult.status = true;
                return Json(messageResult);
            }
            else
            {
                messageResult.message = "OK";
                messageResult.status = false;
                return Json(messageResult);
            }
        }


        //
        // /Customer/Delete
        [HttpPost]
        [ValidateInput(true)]
        public JsonResult Delete(string CustomerID)
        {
            var messageResult = new MyMessageResult();
            /*if (!ExistSession())
            {
                messageResult.message = "Phiên làm việc của bạn đã hết. Vui lòng đăng nhập lại.";
                messageResult.status = false;
                return Json(messageResult);
            }*/
            var model = new Model.CustomerModel();

            string result = model.Delete(CustomerID);
            if (result == "OK")
            {
                messageResult.message = "OK";
                messageResult.status = true;
                return Json(messageResult);
            }
            else
            {
                messageResult.message = result;
                messageResult.status = false;
                return Json(messageResult);
            }
        }
    }
}