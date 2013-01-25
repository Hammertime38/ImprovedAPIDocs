using System;
using System.ComponentModel.DataAnnotations;

namespace AutoBody.Models
{
    public class APIModel
    {
        [Required]
        [Display(Name = "Source Username")]
        public string SourceName { get; set; }

        [Required]
        [Display(Name = "Source Password")]
        public string SourcePassword { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Staff Username")]
        public string StaffName { get; set; }

        [Display(Name = "Staff Password")]
        public string StaffPassword { get; set; }

        [Required]
        [Display(Name = "Site ID")]
        public int SiteID { get; set; }

        [Display(Name = "Staff ID")]
        public int StaffID { get; set; }

        
    }

    public class AppointmentModel
    {
        [Display(Name = "ID")]
        public long appt_ID { get; set; }

        [Display(Name = "Status")]
        public AppointmentService.AppointmentStatus appt_Status { get; set; }

        [Display(Name = "Start Date")]
        public DateTime appt_StartDateTime { get; set; }

        [Display(Name = "End Date")]
        public DateTime appt_EndDateTime { get; set; }

        [Display(Name = "Notes")]
        public string appt_Notes { get; set; }

        [Display(Name = "Staff Requested")]
        public bool appt_StaffRequested { get; set; }

        [Display(Name = "Program")]
        public ProgramModel appt_Program { get; set; }

        [Display(Name = "Session Type")]
        public SessionTypeModel appt_SessionType { get; set; }

        [Display(Name = "Location")]
        public LocationModel appt_Location { get; set; }

        [Display(Name = "Staff")]
        public StaffModel appt_Staff { get; set; }

        [Display(Name = "Client")]
        public ClientModel appt_Client { get; set; }

        [Display(Name = "First Appointment")]
        public bool appt_FirstAppointment { get; set; }

        [Display(Name = "Client Service")]
        public ClientServiceModel appt_ClientService{ get; set; }

        [Display(Name = "Resources")]
        public ResourceModel [] appt_Resources { get; set; }
    }

    public class ProgramModel
    {
        [Display(Name = "ID")]
        public int prgm_ID { get; set; }

        [Display(Name = "Name")]
        public string prgm_Name { get; set; }
    }

    public class SessionTypeModel
    {
        [Display(Name = "ID")]
        public int sestp_ID { get; set; }

        [Display(Name = "Name")]
        public string sestp_Name { get; set; }
    }

    public class LocationModel
    {
        [Display(Name = "Business ID")]
        public int loc_BusinessID { get; set; }

        [Display(Name = "Site ID")]
        public int loc_SiteID { get; set; }

        [Display(Name = "Business Description")]
        public string loc_BusinessDescription { get; set; }

        [Display(Name = "Additional Image URLs")]
        public string [] loc_AddImageUrls { get; set; }

        [Display(Name = "Facility Square Feet")]
        public int loc_FacilitySqFt { get; set; }

        [Display(Name = "Treatment Rooms")]
        public int loc_TreamentRooms { get; set; }

        [Display(Name = "Pro Spa Finder Site")]
        public bool loc_SpaFinderSite { get; set; }

        [Display(Name = "Has Classes")]
        public bool loc_HasClasses { get; set; }

        [Display(Name = "Phone Extension")]
        public string loc_PhoneExt { get; set; }

        [Display(Name = "ID")]
        public int loc_ID { get; set; }

        [Display(Name = "Name")]
        public string loc_Name { get; set; }

        [Display(Name = "Latitude")]
        public double loc_Latitude { get; set; }

        [Display(Name = "Longitude")]
        public long loc_Longitude { get; set; }

        [Display(Name = "Distance in Miles")]
        public double loc_DistanceInMiles { get; set; }

        [Display(Name = "Image URL")]
        public string loc_ImageURL { get; set; }

        [Display(Name = "Description")]
        public string loc_Description { get; set; }

        [Display(Name = "Has Site")]
        public bool loc_HasSite { get; set; }

        [Display(Name = "Can Book")]
        public bool loc_CanBook { get; set; }
    }

    public class StaffModel
    {
        [Display(Name = "Email")]
        public string staff_Email { get; set; }

        [Display(Name = "Mobile Phone")]
        public string staff_MobilePhone { get; set; }

        [Display(Name = "Home Phone")]
        public string staff_HomePhone { get; set; }

        [Display(Name = "Work Phone")]
        public string staff_WorkPhone { get; set; }

        [Display(Name = "Address")]
        public string staff_Address { get; set; }

        [Display(Name = "Address 2")]
        public string staff_Address2 { get; set; }

        [Display(Name = "City")]
        public string staff_City { get; set; }

        [Display(Name = "State")]
        public string staff_State { get; set; }

        [Display(Name = "Country")]
        public string staff_Country { get; set; }

        [Display(Name = "Postal Code")]
        public string staff_PostalCode { get; set; }

        [Display(Name = "Foreign Zip")]
        public string staff_ForeignZip { get; set; }

        [Display(Name = "ID")]
        public long staff_ID { get; set; }

        [Display(Name = "Name")]
        public string staff_Name { get; set; }

        [Display(Name = "First Name")]
        public string staff_FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string staff_LastName { get; set; }
    }

    public class ClientModel
    {
        [Display(Name = "ID")]
        public string clt_ID { get; set; }

        [Display(Name = "First Name")]
        public string clt_FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string clt_LastName { get; set; }

        [Display(Name = "Email")]
        public string clt_Email { get; set; }

        [Display(Name = "Mobile Phone")]
        public string clt_MobilePhone { get; set; }

        [Display(Name = "Home Phone")]
        public string clt_HomePhone { get; set; }
    }

    public class ClientServiceModel
    {
        [Display(Name = "ID")]
        public long cltsv_ID { get; set; }

        [Display(Name = "Name")]
        public string cltsv_Name { get; set; }
    }

    public class ResourceModel
    {
        [Display(Name = "ID")]
        public int res_ID { get; set; }

        [Display(Name = "Name")]
        public string res_Name { get; set; }
    }
}