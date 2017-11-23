using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_MVC.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Bạn phải nhập tài khoản ")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu ")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}