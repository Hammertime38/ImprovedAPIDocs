using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoBody.AppointmentService;
using DayOfWeek = System.DayOfWeek;

namespace AutoBody.Models
{
    public class AppointmentAPI
    {
        private string[] apiCalls =
            {
                "GetStaffAppointments",
                "AddOrUpdateAppointments",
                "GetBookableItems",
                "GetScheduleItems",
                "AddOrUpdateAvailabilities",
                "GetActiveSessionTimes",
                "GetAppointmentOptions"
            };

        public string[] getAppointmentServiceAPI()
        {
            return apiCalls;
        }
    }

    public class GetStaffAppointmentsModel : APIModel
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }

    public class AddOrUpdateAppointmentsModel : APIModel
    {
        [Display(Name = "Update Action")]
        public string UpdateAction { get; set; }

        [Display(Name = "Test")]
        public bool Test { get; set; }

        [Display(Name = "Send Email")]
        public bool SendEmail { get; set; }

        [Display(Name = "Apply Payment")]
        public bool ApplyPayment { get; set; }

        [Display(Name = "Appointments")]
        public AppointmentModel [] Appointments { get; set; }

        [HiddenInput(DisplayValue = true)]
        public int appointmentsCount { get; set; }
    }

    public class GetBookableItemsModel : APIModel
    {
        [Display(Name = "Session Type IDs")]
        public int[] SessionTypeIDs { get; set; }

        [Display(Name = "Location IDs")]
        public int[] LocationIDs { get; set; }

        [Display(Name = "Staff IDs")]
        public long[] StaffIDs { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }

    public class GetScheduleItemsModel : APIModel
    {
        [Display(Name = "Location IDs")]
        public int[] LocationIDs { get; set; }

        [Display(Name = "Staff IDs")]
        public long[] StaffIDs { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Ignore Prep Finish Times")]
        public bool IgnorePrepFinishTimes { get; set; }
    }

    public class AddOrUpdateAvailabilitiesModel : APIModel
    {
        [Display(Name = "Update Action")]
        public string UpdateAction { get; set; }

        [Display(Name = "Test")]
        public bool Test { get; set; }

        [Display(Name = "Availablity IDs")]
        public int[] AvalibilityIDs { get; set; }

        [Display(Name = "Location IDs")]
        public int LocationID { get; set; }

        [Display(Name = "Staff IDs")]
        public long[] StaffIDs { get; set; }

        [Display(Name = "Program IDs")]
        public int[] ProgramIDs { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Days of Week")]
        public AppointmentService.DayOfWeek [] DaysOfWeek { get; set; }

        [Display(Name = "Unavailable Description")]
        public string UnavailableDescription { get; set; }

        [Display(Name = "Is Unavailable")]
        public bool IsUnavailable { get; set; }

        [Display(Name = "Public Display")]
        public AppointmentService.AvailabilityDisplay PublicDisplay { get; set; }
    }

    public class GetActiveSessionTimesModel : APIModel
    {
        [Display(Name = "Schedule Type")]
        public AppointmentService.ScheduleType ScheduleType { get; set; }

        [Display(Name = "Session Type IDs")]
        public int[] SessionTypeIDs { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndTime { get; set; }
    }

    public class GetAppointmentOptionsModel : APIModel
    {
        //Empty request, but need to follow design scheme
    }
}