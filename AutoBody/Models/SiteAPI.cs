using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class SiteAPI
    {
        private string[] apiCalls =
            {
                "GetSites",
                "GetLocations",
                "GetActivationCode",
                "GetPrograms",
                "GetSessionTypes",
                "GetResources",
                "GetRelationships"
            };

        public string[] getSiteServiceAPI()
        {
            return apiCalls;
        }
    }
}