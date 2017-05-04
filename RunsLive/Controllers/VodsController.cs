using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Controllers
{
    public class VodsController : Controller
    {
        private IVodService service;

        public VodsController(IVodService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult AllVods()
        {
            IEnumerable<VodViewModel> models = service.GetAllVods();
            return View(models);
        }

        [HttpGet]
        [Authorize]
        public ActionResult RequestVod()
        {
            IEnumerable<VodRequestViewModel> models = service.GetAllGames();
            return View(models);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RequestVod(RequestVodBindingModel bind)
        {
            IEnumerable<VodRequestViewModel> models = service.GetAllGames();
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewRequest(bind,username);
                return RedirectToAction("RequestedVods","Manage");
            }
            return View(models);
        }



    }
}
