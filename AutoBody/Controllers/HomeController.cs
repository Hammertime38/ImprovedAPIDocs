using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBody.ClassService;
using AutoBody.Models;
using Staff = AutoBody.StaffService.Staff;

namespace AutoBody.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template so that you do not appear noobish.";
            ViewBag.Message2 = "This was completely designed by Hammer.";
            ViewBag.Notice = "Most API calls are managed using GET variables. However, due to the length restriction " +
                             "of URLs, certain methods must be managed through POST variables and are marked accordingly.";
            return View();
        }

        

        public ActionResult AppointmentService()
        {
            ViewBag.Message = "AppointmentService API Methods";

            var api = new AppointmentAPI();
            ViewBag.apiCalls = api.getAppointmentServiceAPI();

            return View();
        }

        public ActionResult ClassService()
        {
            ViewBag.Message = "ClassService API Methods";

            var api = new ClassAPI();
            ViewBag.apiCalls = api.getClassServiceAPI();

            return View();
        }

        public ActionResult ClientService()
        {
            ViewBag.Message = "ClientService API Methods";

            var api = new ClientAPI();
            ViewBag.apiCalls = api.getClientServiceAPI();

            return View();
        }

        public ActionResult DataService()
        {
            ViewBag.Message = "DataService API Methods";

            var api = new DataAPI();
            ViewBag.apiCalls = api.getDataServiceAPI();

            return View();
        }

        public ActionResult FinderService()
        {
            ViewBag.Message = "FinderService API Methods";

            var api = new FinderAPI();
            ViewBag.apiCalls = api.getFinderServiceAPI();

            return View();
        }

        public ActionResult SaleService()
        {
            ViewBag.Message = "SaleService API Methods";

            var api = new SaleAPI();
            ViewBag.apiCalls = api.getSaleServiceAPI();

            return View();
        }

        public ActionResult SiteService()
        {
            ViewBag.Message = "SiteService API Methods";

            var api = new SiteAPI();
            ViewBag.apiCalls = api.getSiteServiceAPI();

            return View();
        }

        public ActionResult StaffService()
        {
            ViewBag.Message = "StaffService API Methods";

            var api = new StaffAPI();
            ViewBag.apiCalls = api.getStaffServiceAPI();

            return View();
        }
    }
}
