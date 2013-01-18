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
    public class FinderAPIController : Controller
    {

        public ActionResult Index()
        {
            return Redirect("/Home/FinderService");
        }
    }
}
