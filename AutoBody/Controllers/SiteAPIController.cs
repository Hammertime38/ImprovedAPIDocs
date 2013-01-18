using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBody.AppointmentService;
using AutoBody.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoBody.Controllers
{
    public class SiteAPIController : Controller
    {
        //
        // GET: /Appointment/

        private SiteService.SiteService siteService = new SiteService.SiteService();

        public ActionResult Index()
        {
            return Redirect("/Home/SiteService");
        }
    }
}
