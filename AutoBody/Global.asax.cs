using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutoBody
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            if (Request.Cookies["username"] == null) Response.AppendCookie(new HttpCookie("username", "owner"));
            if (Request.Cookies["password"] == null) Response.AppendCookie(new HttpCookie("password", "owner1234"));
            if (Request.Cookies["sourceName"] == null) Response.AppendCookie(new HttpCookie("sourceName", "autobots"));
            if (Request.Cookies["sourcePassword"] == null) Response.AppendCookie(new HttpCookie("sourcePassword", "autobots1234"));
            if (Request.Cookies["siteID"] == null) Response.AppendCookie(new HttpCookie("siteID", "-40001"));
            if (Request.Cookies["staffName"] == null) Response.AppendCookie(new HttpCookie("staffName", "Tommy.Chong"));
            if (Request.Cookies["staffPassword"] == null) Response.AppendCookie(new HttpCookie("staffPassword", "staff1234"));
        }
    }
}