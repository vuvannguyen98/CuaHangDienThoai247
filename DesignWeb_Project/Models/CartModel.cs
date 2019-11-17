using DesignWeb_Project.Areas.Admin.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignWeb_Project.Models
{
    [Serializable]
    public class CartModel
    {

        public Product Product { get; set; }

        public int Quanlity { get; set; }

    }
}