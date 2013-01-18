using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AutoBody.Models;

namespace AutoBody.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Index

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/Login

        [AllowAnonymous]
        public ActionResult APICredentials()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        //
        // POST: /Account/Login

        [AllowAnonymous]
        [HttpPost]
        public ActionResult APICredentials(APICredentialsModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (APISettings.checkValidCredentials(model))
                {
                    Response.AppendCookie(new HttpCookie("username", model.Username));
                    Response.AppendCookie(new HttpCookie("password", model.Password));
                    Response.AppendCookie(new HttpCookie("sourceName", model.SourceName));
                    Response.AppendCookie(new HttpCookie("sourcePassword", model.SourcePassword));
                    Response.AppendCookie(new HttpCookie("siteID", model.SiteID.ToString()));
                    Response.AppendCookie(new HttpCookie("staffName", model.StaffName));
                    Response.AppendCookie(new HttpCookie("staffPassword", model.StaffPassword));
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Credentials are Invalid");
            }

            var credentials = new APISettings();

            ViewBag.Username = credentials.Username;
            ViewBag.Password = credentials.Password;
            ViewBag.SourceName = credentials.SourceName;
            ViewBag.SourcePassword = credentials.SourcePassword;
            ViewBag.SiteID = credentials.SiteID;
            ViewBag.StaffName = credentials.StaffName;
            ViewBag.StaffPassword = credentials.StaffPassword;

            // If we got this far, something failed, redisplay form
            return View();
        }
        

       
    }
}
