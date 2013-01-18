using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using AutoBody.AppointmentService;
using AutoBody.Models;

namespace AutoBody.Controllers
{
    public class APISettings
    {
        public string Username
        {
            get 
            { 
                if (HttpContext.Current.Request.Cookies["username"] != null)
                    return HttpContext.Current.Request.Cookies["username"].Value;
                return "";
            }
        }
        public string Password
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["password"] != null)
                    return HttpContext.Current.Request.Cookies["password"].Value;
                return "";
            }
        }
        public string SourceName
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["sourceName"] != null)
                    return HttpContext.Current.Request.Cookies["sourceName"].Value;
                return "";
            }
        }
        public string SourcePassword
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["sourcePassword"] != null)
                    return HttpContext.Current.Request.Cookies["sourcePassword"].Value;
                return "";
            }
        }
        public string StaffName
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["staffName"] != null)
                    return HttpContext.Current.Request.Cookies["staffName"].Value;
                return "";
            }
        }
        public string StaffPassword
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["staffPassword"] != null)
                    return HttpContext.Current.Request.Cookies["staffPassword"].Value;
                return "";
            }
        }
        public string SiteID
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["siteID"] != null)
                    return HttpContext.Current.Request.Cookies["siteID"].Value;
                return "";
            }
        }










        private readonly static AppointmentService.AppointmentService appointmentService = new AppointmentService.AppointmentService();




/************************************************   Base   Requests   ****************************************************/




        public static T getBaseAppointmentRequest<T>(APIModel model) where T : AppointmentService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new AppointmentService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new AppointmentService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = AppointmentService.XMLDetailLevel.Full
            };
        }

        public static T getBaseClassRequest<T>(APIModel model) where T : ClassService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new ClassService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new ClassService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = ClassService.XMLDetailLevel.Full
            };
        }

        public static T getBaseClientRequest<T>(APIModel model) where T : ClientService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new ClientService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new ClientService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = ClientService.XMLDetailLevel.Full
            };
        }

        public static T getBaseDataRequest<T>(APIModel model) where T : DataService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new DataService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new DataService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = DataService.XMLDetailLevel.Full
            };
        }

        public static T getBaseSaleRequest<T>(APIModel model) where T : SaleService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new SaleService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new SaleService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = SaleService.XMLDetailLevel.Full
            };
        }

        public static T getBaseSiteRequest<T>(APIModel model) where T : SiteService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new SiteService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new SiteService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = SiteService.XMLDetailLevel.Full
            };
        }

        public static T getBaseStafRequest<T>(APIModel model) where T : StaffService.MBRequest, new()
        {
            return new T
            {
                SourceCredentials = new StaffService.SourceCredentials
                {
                    Password = model.SourcePassword,
                    SiteIDs = new[] { model.SiteID },
                    SourceName = model.SourceName
                },
                UserCredentials = new StaffService.UserCredentials
                {
                    Password = model.Password,
                    SiteIDs = new[] { model.SiteID },
                    Username = model.Username
                },
                CurrentPageIndex = 0,
                PageSize = 10,
                XMLDetail = StaffService.XMLDetailLevel.Full
            };
        }




        
        public static bool checkValidCredentials(APICredentialsModel model)
        {
            //Test credentials using GetStaffAppointments

            var appointmentModel = new APIModel
                                       {
                                           SourceName = model.SourceName,
                                           SourcePassword = model.SourcePassword,
                                           StaffID = model.StaffID,
                                           StaffName = model.StaffName,
                                           StaffPassword = model.StaffPassword,
                                           Username = model.Username,
                                           Password = model.Password,
                                           SiteID = model.SiteID
                                       };
            var sourceCredentials = AppointmentAPIController.getSourceCredentials(appointmentModel);
            var userCredentials = AppointmentAPIController.getUserCredentials(appointmentModel);
            var staffCredentials = AppointmentAPIController.getStaffCredentials(appointmentModel);

            var request = new GetStaffAppointmentsRequest
            {
                SourceCredentials = sourceCredentials,
                UserCredentials = userCredentials,
                StaffCredentials = staffCredentials,
                XMLDetail = XMLDetailLevel.Full,
                PageSize = 10,
                CurrentPageIndex = 0,
                StartDate = new DateTime(2010, 1, 1, 0, 0, 0),
                EndDate = DateTime.Now,
                StaffIDs = new long[] { model.StaffID }
            };

            var response = appointmentService.GetStaffAppointments(request);

            return response.Appointments != null;
        }
    }
}
