using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class ClassAPI
    {
        private string[] apiCalls =
            {
                "GetClasses",
                "UpdateClientVisits",
                "GetClassVisits",
                "GetClassDescriptions",
                "GetEnrollments",
                "GetClassSchedules",
                "AddClientsToClasses",
                "RemoveClientsFromClasses",
                "AddClientsToEnrollments",
                "RemoveFromWaitlist",
                "GetSemesters",
                "GetCourses",
                "GetWaitlistEntries"
            };

        public string[] getClassServiceAPI()
        {
            return apiCalls;
        }
    }
}