using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class ClientAPI
    {
        private string[] apiCalls =
            {
                "AddArrival",
                "AddOrUpdateClients",
                "GetClients",
                "GetCustomClientFields",
                "GetClientIndexes",
                "GetClientContactLogs",
                "AddOrUpdateContactLogs",
                "GetContactLogTypes",
                "UploadClientDocument",
                "GetClientReferralTypes",
                "GetActiveClientMemberships",
                "GetClientContracts",
                "GetClientAccountBalances",
                "GetClientServices",
                "GetClientVisits",
                "GetClientPurchases",
                "GetClientSchedule",
                "GetRequiredClientFields",
                "ValidateLogin",
                "UpdateClientServices",
                "SendUserNewPassword"
            };

        public string[] getClientServiceAPI()
        {
            return apiCalls;
        }

        public static ClientService.UserCredentials getUserCredentials(APIModel model)
        {
            return new ClientService.UserCredentials
            {
                Password = model.Password,
                SiteIDs = new[] { model.SiteID },
                Username = model.Username
            };
        }

        public static ClientService.SourceCredentials getSourceCredentials(APIModel model)
        {
            return new ClientService.SourceCredentials
            {
                Password = model.SourcePassword,
                SiteIDs = new[] { model.SiteID },
                SourceName = model.SourceName
            };
        }
    }

    public class GetClientsModel : APIModel
    {
        [Display(Name = "ClientIDs")]
        public string[] ClientIDs { get; set; }

        [Display(Name = "Search Text")]
        public string SearchText { get; set; }
    }
}