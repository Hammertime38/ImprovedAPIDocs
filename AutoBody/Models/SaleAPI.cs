using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class SaleAPI
    {
        private string[] apiCalls =
            {
                "GetAcceptedCardType",
                "CheckoutShoppingCart",
                "GetSales",
                "GetItemPrograms",
                "GetServices",
                "UpdateServices",
                "GetPackages",
                "GetProducts",
                "UpdateProducts",
                "RedeemSpaFinderWellnessCard",
                "GetCustomPaymentMethods"
            };

        public string[] getSaleServiceAPI()
        {
            return apiCalls;
        }
    }
}