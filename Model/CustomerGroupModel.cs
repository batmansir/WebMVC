using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerGroupModel
    {
        Web_MVCDBContext db = null;
        public CustomerGroupModel()
        {
            db = new Web_MVCDBContext();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<CUSTOMER_GROUP> GetList()
        {
            return db.CUSTOMER_GROUP.ToList();
        }
    }
}
