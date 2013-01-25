using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using AutoBody.ClientService;
using AutoBody.Models;

namespace AutoBody.Controllers
{
    public class ClientAPIController : Controller
    {

        private ClientService.ClientService clientService = new ClientService.ClientService();

        public ActionResult Index()
        {
            return Redirect("/Home/ClientService");
        }

        public ActionResult GetClients()
        {
            ViewBag.Credentials = new APISettings();
            return View();
        }


/*****************************************  Get Clients  *********************************************/


        private ClientService.GetClientsRequest getClients(GetClientsModel model)
        {
            var request = APISettings.getBaseClientRequest<GetClientsRequest>(model);

            request.ClientIDs = model.ClientIDs;
            request.SearchText = model.SearchText;

            return request;
        }

        public ActionResult GetClientsRequest(GetClientsModel model)
        {
            var request = getClients(model);
            var response = clientService.GetClients(request);

            //@ViewBag.Request = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonConverter[] { new StringEnumConverter() });
            @ViewBag.Request = SoapSerializer.SerializeToSoap<GetClientsRequest>(request);
            @ViewBag.Response = SoapSerializer.SerializeToSoap<GetClientsResult>(response);

            return View();
        }

        
    }
}
