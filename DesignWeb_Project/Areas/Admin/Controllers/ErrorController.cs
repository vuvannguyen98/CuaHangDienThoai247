using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignWeb_Project.Areas.Admin.Controllers
{
    [HandleError]
    public class ErrorController : Controller
    {
        // GET: Admin/Error
        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}