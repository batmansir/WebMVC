using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Framework;
using System.Data.SqlClient;

namespace Model
{
    public class AccountModel
    {
        private Web_MVCDBContext context = null;
        public AccountModel()
        {
            context = new Web_MVCDBContext();
        }
        
        public bool Login(string UserName, string Password)
        {
            object[] para =
            {
                new SqlParameter("@UserName",UserName),
                new SqlParameter("@Password",Password)
            };
            var res = context.Database.SqlQuery<bool>("Account_Login @UserName,@Password", para).SingleOrDefault();
            return res;
        }
    }
}
