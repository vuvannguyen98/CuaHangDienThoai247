using DesignWeb_Project.Areas.Admin.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DesignWeb_Project
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer ( new InitializerConnectionDB() );
        }


        protected void Session_Start()
        {
            Session["UserID"] = null;
            Session["Username"] = null;
            Session["Email"] = null;
            Session["Password"] = null;
            Session["Image"] = null;
            Session["CartItem"] = null;

            Session["countnewcart"] = null;

        }
    }
}
