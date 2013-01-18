using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class StaffAPI
    {
        private string[] apiCalls =
            {
                "GetStaff",
                "GetStaffPermissions",
                "AddOrUpdateStaff"
            };

        public string[] getStaffServiceAPI()
        {
            return apiCalls;
        }
    }
}