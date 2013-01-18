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
    public class StaffAPIController : Controller
    {
        //
        // GET: /Appointment/

        private StaffService.StaffService staffService = new StaffService.StaffService();

        public ActionResult Index()
        {
            return Redirect("/Home/StaffService");
        }
    }
}
