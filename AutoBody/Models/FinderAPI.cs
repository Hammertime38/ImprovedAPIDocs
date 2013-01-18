using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class FinderAPI
    {
        private string[] apiCalls =
            {
                "GetClassesWithinRadius",
                "GetSessionTypesWithinRadius",
                "GetBusinessLocationsWithinRadius",
                "FinderCheckoutShoppingCart",
                "AddOrUpdateFinderUsers",
                "GetFinderUser",
                "SendUserNewPassword"
            };

        public string[] getFinderServiceAPI()
        {
            return apiCalls;
        }
    }
}