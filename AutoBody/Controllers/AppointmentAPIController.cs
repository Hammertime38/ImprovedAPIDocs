using System.Collections.Generic;
using System.Web.Mvc;
using AutoBody.AppointmentService;
using AutoBody.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoBody.Controllers
{
    public class AppointmentAPIController : Controller
    {
        //
        // GET: /Appointment/

        private AppointmentService.AppointmentService appointmentService = new AppointmentService.AppointmentService();

        public ActionResult Index()
        {
            return Redirect("/Home/AppointmentService");
        }

        public static AppointmentService.UserCredentials getUserCredentials(APIModel model)
        {
            return new AppointmentService.UserCredentials
            {
                Password = model.Password,
                SiteIDs = new[] { model.SiteID },
                Username = model.Username
            };
        }

        public static AppointmentService.SourceCredentials getSourceCredentials(APIModel model)
        {
            return new AppointmentService.SourceCredentials
            {
                Password = model.SourcePassword,
                SiteIDs = new[] { model.SiteID },
                SourceName = model.SourceName
            };
        }

        public static AppointmentService.StaffCredentials getStaffCredentials(APIModel model)
        {
            return new AppointmentService.StaffCredentials
            {
                Password = model.StaffPassword,
                SiteIDs = new[] { model.SiteID },
                Username = model.StaffName
            };
        }


        /***********************************************GetStaffAppointments*********************************************************/

        public ActionResult GetStaffAppointments()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        private GetStaffAppointmentsRequest getStaffAppointments(GetStaffAppointmentsModel model)
        {
            var request = APISettings.getBaseAppointmentRequest<GetStaffAppointmentsRequest>(model);

            System.Diagnostics.Debug.WriteLine("Request is: " + request);

            request.StaffIDs = new long[] {model.StaffID};
            request.StartDate = model.StartDate;
            request.EndDate = model.EndDate;


            return request;
        }

        public ActionResult GetStaffAppointmentsRequest(GetStaffAppointmentsModel model)
        {
            var request = getStaffAppointments(model);
            var response = appointmentService.GetStaffAppointments(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<GetStaffAppointmentsRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<GetStaffAppointmentsResult>(response);

            return View();
        }

        /**********************************************AddOrUpdateAppointments******************************************************/
        //This is a hefty-ass one

        private AppointmentService.Program getProgram(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.Program
                       {
                           ID = model.Appointments[index].appt_Program.prgm_ID,
                           Name = model.Appointments[index].appt_Program.prgm_Name
                       };
        }

        private AppointmentService.SessionType getSessionType(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.SessionType
                       {
                           ID = model.Appointments[index].appt_SessionType.sestp_ID,
                           Name = model.Appointments[index].appt_SessionType.sestp_Name,

                           IDSpecified = model.Appointments[index].appt_SessionType.sestp_ID >= 0
                       };
        }

        private AppointmentService.Location getLocation(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.Location
                       {
                           BusinessID = model.Appointments[index].appt_Location.loc_BusinessID,
                           SiteID = model.Appointments[index].appt_Location.loc_SiteID,
                           BusinessDescription = model.Appointments[index].appt_Location.loc_BusinessDescription,
                           AdditionalImageURLs = ("," + model.Appointments[index].appt_Location.loc_AddImageUrls).Split(','),
                           FacilitySquareFeet = model.Appointments[index].appt_Location.loc_FacilitySqFt,
                           TreatmentRooms = model.Appointments[index].appt_Location.loc_TreamentRooms,
                           ProSpaFinderSite = model.Appointments[index].appt_Location.loc_SpaFinderSite,
                           HasClasses = model.Appointments[index].appt_Location.loc_HasClasses,
                           PhoneExtension = model.Appointments[index].appt_Location.loc_PhoneExt,
                           ID = model.Appointments[index].appt_Location.loc_ID,
                           Name = model.Appointments[index].appt_Location.loc_Name,
                           Latitude = model.Appointments[index].appt_Location.loc_Latitude,
                           Longitude = model.Appointments[index].appt_Location.loc_Longitude,
                           DistanceInMiles = model.Appointments[index].appt_Location.loc_DistanceInMiles,
                           ImageURL = model.Appointments[index].appt_Location.loc_ImageURL,
                           Description = model.Appointments[index].appt_Location.loc_Description,
                           HasSite = model.Appointments[index].appt_Location.loc_HasSite,
                           CanBook = model.Appointments[index].appt_Location.loc_CanBook
                       };
        }

        private AppointmentService.Staff getStaff(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.Staff
                       {
                           Email = model.Appointments[index].appt_Staff.staff_Email,
                           MobilePhone = model.Appointments[index].appt_Staff.staff_MobilePhone,
                           HomePhone = model.Appointments[index].appt_Staff.staff_HomePhone,
                           WorkPhone = model.Appointments[index].appt_Staff.staff_WorkPhone,
                           Address = model.Appointments[index].appt_Staff.staff_Address,
                           Address2 = model.Appointments[index].appt_Staff.staff_Address2,
                           City = model.Appointments[index].appt_Staff.staff_City,
                           State = model.Appointments[index].appt_Staff.staff_State,
                           Country = model.Appointments[index].appt_Staff.staff_Country,
                           PostalCode = model.Appointments[index].appt_Staff.staff_PostalCode,
                           ForeignZip = model.Appointments[index].appt_Staff.staff_ForeignZip,
                           ID = model.Appointments[index].appt_Staff.staff_ID,
                           Name = model.Appointments[index].appt_Staff.staff_Name,
                           FirstName = model.Appointments[index].appt_Staff.staff_FirstName,
                           LastName = model.Appointments[index].appt_Staff.staff_LastName
                       };
        }

        private AppointmentService.Client getClient(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.Client
                       {
                           ID = model.Appointments[index].appt_Client.clt_ID,
                           FirstName = model.Appointments[index].appt_Client.clt_FirstName,
                           LastName = model.Appointments[index].appt_Client.clt_LastName,
                           Email = model.Appointments[index].appt_Client.clt_Email,
                           MobilePhone = model.Appointments[index].appt_Client.clt_MobilePhone,
                           HomePhone = model.Appointments[index].appt_Client.clt_HomePhone
                       };
        }

        private AppointmentService.ClientService getClientService(AddOrUpdateAppointmentsModel model, int index)
        {
            return new AppointmentService.ClientService
                       {
                           ID = model.Appointments[index].appt_ClientService.cltsv_ID,
                           Name = model.Appointments[index].appt_ClientService.cltsv_Name
                       };
        }

        //TODO Support multiple resources
        private AppointmentService.Resource[] getResources(AddOrUpdateAppointmentsModel model, int index)
        {
            return new []
                       {
                           new Resource
                               {
                                   ID = model.Appointments[index].appt_Resources[0].res_ID,
                                   Name = model.Appointments[index].appt_Resources[0].res_Name
                               }
                       };
        }

        private AppointmentService.Appointment[] getAppointments(AddOrUpdateAppointmentsModel model)
        {
            var appointments = new List<AppointmentService.Appointment>();
            System.Diagnostics.Debug.WriteLine("appointmentsCount is " + model.appointmentsCount);
            for (int i = 0; i < model.appointmentsCount; i++)
            {
                var appointment = new Appointment
                                      {
                                          ID = model.Appointments[i].appt_ID,
                                          Status = model.Appointments[i].appt_Status,

                                          StartDateTime = model.Appointments[i].appt_StartDateTime,
                                          StartDateTimeSpecified = model.Appointments[i].appt_StartDateTime != null,

                                          Notes = model.Appointments[i].appt_Notes,
                                          Program = getProgram(model, i),
                                          SessionType = getSessionType(model, i),
                                          Location = getLocation(model, i),
                                          Staff = getStaff(model, i),
                                          Client = getClient(model, i),
                                          FirstAppointment = model.Appointments[i].appt_FirstAppointment,
                                          ClientService = getClientService(model, i),
                                          Resources = getResources(model, i)
                                      };
                appointments.Add(appointment);
            }
            return appointments.ToArray();
        }



        private AddOrUpdateAppointmentsRequest addOrUpdateAppointments(AddOrUpdateAppointmentsModel model)
        {
            System.Diagnostics.Debug.WriteLine("User Credentials: " + getUserCredentials(model));

            var request = APISettings.getBaseAppointmentRequest<AddOrUpdateAppointmentsRequest>(model);

            request.UpdateAction = model.UpdateAction;
            request.Test = model.Test;
            request.SendEmail = model.SendEmail;
            request.ApplyPayment = model.ApplyPayment;
            request.Appointments = getAppointments(model);

            return request;
        }

        public ActionResult AddOrUpdateAppointments()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        public ActionResult AddOrUpdateAppointmentsRequest(AddOrUpdateAppointmentsModel model)
        {
            var request = addOrUpdateAppointments(model);
            var response = appointmentService.AddOrUpdateAppointments(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<AddOrUpdateAppointmentsRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<AddOrUpdateAppointmentsResult>(response);

            return View();
        }

        /*************************************************GetBookableItems*********************************************************/


        private AppointmentService.GetBookableItemsRequest getBookableItems(GetBookableItemsModel model)
        {
            var request = APISettings.getBaseAppointmentRequest<GetBookableItemsRequest>(model);

            request.SessionTypeIDs = model.SessionTypeIDs;
            request.LocationIDs = model.LocationIDs;
            request.StaffIDs = model.StaffIDs;
            request.StartDate = model.StartDate;
            request.EndDate = model.EndDate;

            return request;
        }

        public ActionResult GetBookableItems()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        public ActionResult GetBookableItemsRequest(GetBookableItemsModel model)
        {
            var request = getBookableItems(model);
            var response = appointmentService.GetBookableItems(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<GetBookableItemsRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<GetBookableItemsResult>(response);

            return View();
        }

        /*************************************************GetScheduleItems********************************************************/

        private AppointmentService.GetScheduleItemsRequest getScheduleItems(GetScheduleItemsModel model)
        {
            var request = APISettings.getBaseAppointmentRequest<GetScheduleItemsRequest>(model);

            request.LocationIDs = model.LocationIDs;
            request.StaffIDs = model.StaffIDs;
            request.StartDate = model.StartDate;
            request.EndDate = model.EndDate;
            request.IgnorePrepFinishTimes = model.IgnorePrepFinishTimes;

            return request;
        }

        public ActionResult GetScheduleItems()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        public ActionResult GetScheduleItemsRequest(GetScheduleItemsModel model)
        {
            var request = getScheduleItems(model);
            var response = appointmentService.GetScheduleItems(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<GetScheduleItemsRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<GetScheduleItemsResult>(response);
            
            return View();
        }

        /**********************************************AddOrUpdateAvailabilities*****************************************************/


        private AppointmentService.AddOrUpdateAvailabilitiesRequest addOrUpdateAvailabilities(
            AddOrUpdateAvailabilitiesModel model)
        {
            var request = APISettings.getBaseAppointmentRequest<AddOrUpdateAvailabilitiesRequest>(model);

            request.UpdateAction = model.UpdateAction;
            request.Test = model.Test;
            request.AvailabilityIDs = model.AvalibilityIDs;
            request.LocationID = model.LocationID;
            request.StaffIDs = model.StaffIDs;
            request.ProgramIDs = model.ProgramIDs;
            request.StartDateTime = model.StartDate;
            request.EndDateTime = model.EndDate;
            request.DaysOfWeek = model.DaysOfWeek;
            request.UnavailableDescription = model.UnavailableDescription;
            request.IsUnavailable = model.IsUnavailable;
            request.PublicDisplay = model.PublicDisplay;

            return request;
        }

        public ActionResult AddOrUpdateAvailabilities()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        public ActionResult AddOrUpdateAvailabilitiesRequest(AddOrUpdateAvailabilitiesModel model)
        {
            var request = addOrUpdateAvailabilities(model);
            var response = appointmentService.AddOrUpdateAvailabilities(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<AddOrUpdateAvailabilitiesRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<AddOrUpdateAvailabilitiesResult>(response);

            return View();
        }

        /**********************************************GetActiveSessionTimes*****************************************************/


        private AppointmentService.GetActiveSessionTimesRequest getActiveSessionTimes(GetActiveSessionTimesModel model)
        {
            var request = APISettings.getBaseAppointmentRequest<GetActiveSessionTimesRequest>(model);

            request.ScheduleType = model.ScheduleType;
            request.SessionTypeIDs = model.SessionTypeIDs;
            request.StartTime = model.StartTime;
            request.EndTime = model.EndTime;

            return request;
        }

        public ActionResult GetActiveSessionTimesRequest(GetActiveSessionTimesModel model)
        {
            var request = getActiveSessionTimes(model);
            var response = appointmentService.GetActiveSessionTimes(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<GetActiveSessionTimesRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<GetActiveSessionTimesResult>(response);

            return View();
        }

        public ActionResult GetActiveSessionTimes()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }

        /**********************************************GetAppointmentOptions*****************************************************/

        private AppointmentService.GetAppointmentOptionsRequest getAppointmentOptions(GetAppointmentOptionsModel model)
        {
            return APISettings.getBaseAppointmentRequest<GetAppointmentOptionsRequest>(model);
        }

        public ActionResult GetAppointmentOptionsRequest(GetAppointmentOptionsModel model)
        {
            var request = getAppointmentOptions(model);
            var response = appointmentService.GetAppointmentOptions(request);

            @ViewBag.Request_JSON = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Response_JSON = JsonConvert.SerializeObject(response, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });

            @ViewBag.Request_SOAP = SoapSerializer.SerializeToSoap<GetAppointmentOptionsRequest>(request);
            @ViewBag.Response_SOAP = SoapSerializer.SerializeToSoap<GetAppointmentOptionsResult>(response);

            return View();
        }

        public ActionResult GetAppointmentOptions()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }
    }
}
