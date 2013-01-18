using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBody.Models
{
    public class DataAPI
    {
        private string[] apiCalls =
            {
                "SelectDataXml",
                "SelectDataCSV",
                "SelectAggregateDataXml",
                "SelectAggregatDataCSV"
            };

        public string[] getDataServiceAPI()
        {
            return apiCalls;
        }
    }
}