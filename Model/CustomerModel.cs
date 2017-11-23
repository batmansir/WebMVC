using Model.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerModel
    {
        Web_MVCDBContext db = null;
        public CustomerModel()
        {
            db = new Web_MVCDBContext();
         
        }
        public List<object> GetList()
        {
            //IQueryable<object> reslult = db.CUSTOMERs.Select(c => new { Customer_ID = c.Customer_ID, Customer_Name = c.CustomerName, Address = c.CustomerAddress,Tel=c.Tel,Email=c.Email });

            IQueryable<object> reslult =
                from a in db.CUSTOMERs
                join b in db.CUSTOMER_GROUP
                       on a.Customer_Group_ID equals b.Customer_Group_ID
                select new
                {
                    CustomerID = a.Customer_ID,
                    Name = a.CustomerName,
                    GroupID = a.Customer_Group_ID,
                    GroupName = b.Customer_Group_Name,
                    Address = a.CustomerAddress,
                    Tel = a.Tel,
                    Email = a.Email,
                    Birthday = a.Birthday,
                    Description = a.Description,
                    CreateDate = a.CreateDate
                };
            //return db.CUSTOMERs.ToList();
            return reslult.ToList();
        }

        public string Insert(CUSTOMER c)
        {
            string rs = "OK";
            try
            {
                db.CUSTOMERs.Add(c);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                rs = e.Message;
            }
            return rs;
        }

        public string Update(CUSTOMER c)
        {
            string rs = "OK";
            var item = db.CUSTOMERs.SingleOrDefault(q => q.Customer_ID == c.Customer_ID);
            if (item != null)
            {
                try
                {
                    item.CustomerName = c.CustomerName;
                    item.Customer_Type_ID = c.Customer_Type_ID;
                    item.Customer_Group_ID = c.Customer_Group_ID;
                    item.CustomerAddress = c.CustomerAddress;
                    item.Tel = c.Tel;
                    item.Email = c.Email;
                    item.Birthday = c.Birthday;
                    item.Description = c.Description;
                    db.SaveChanges();
                    rs = "OK";
                }
                catch (Exception ex)
                {
                    rs = ex.Message;
                }
            }
            else rs = "Không tìm thấy mã khách hàng này trong dữ liệu";
            return rs;
        }

      
        public string NewID()
        {
            return NewID("KH");
        }
        public string NewID(string pre)
        {
            return GenCode(pre, "CUSTOMER", "Customer_ID", db);
        }

        public static string GenCode(string fKey, string tableName, string columnName, Model.Framework.Web_MVCDBContext dbContext)
        {
            string query = "select max([" + columnName + "]) from [" + tableName + "] where [" + columnName + "] like N'" + fKey + "%'";
            string rs = dbContext.Database.SqlQuery<string>(query).SingleOrDefault<string>();
            if (rs == null) rs = "0";
            if (fKey.Length != 0) rs = rs.Replace(fKey, "").Trim();
            int num = int.Parse(rs);
            num++;
            string format = num.ToString();
            while (format.Length < 6)
            {
                format = "0" + format;
            }
            return fKey + format;
        }
        public bool Exits(string customerID)
        {
            var entity = db.CUSTOMERs.Find(customerID);
            if (entity != null)
                return true;
            else
                return false;
        }

        public string Delete(string CustomerID)
        {
            var customer = db.CUSTOMERs.Find(CustomerID);
            if (customer != null)
            {
                try
                {
                    db.CUSTOMERs.Remove(customer);
                    db.SaveChanges();
                    return "OK";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Không tìm thấy khách hàng này trong dữ liệu.";
            }
        }
    }
}
