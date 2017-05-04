using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Controllers
{
    public class StreamController : Controller
    {
        private IStreamsService service;

        public StreamController(IStreamsService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult AllStreams()
        {
            IEnumerable<StreamsViewModel> models = service.GetAllStreams();
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public ActionResult RequestStream()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult RequestStream(RequestStreamBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewRequest(bind, username);
                return RedirectToAction("RequestedStreams","Manage");
            }
            return View();
        }
    }
}
