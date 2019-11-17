using DesignWeb_Project.Areas.Admin.Models.BusinessModel;
using DesignWeb_Project.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignWeb_Project.Models
{
    public class ProductCart
    {
        ConnectionDBContext db = null;

        public ProductCart()
        {
            db = new ConnectionDBContext();
        }
        public Product ViewDetail(int ProductID)
        {
            return db.Products.Find(ProductID);
        }
    }
}