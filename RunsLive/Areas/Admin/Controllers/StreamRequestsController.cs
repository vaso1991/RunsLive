using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Attributes;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Areas.Admin.Controllers
{
    [AdminAuthorize(Roles = "Admin")]
    public class StreamRequestsController : Controller
    {
        private IAdminService service;

        public StreamRequestsController(IAdminService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<StreamRequestViewModel> models = service.GetStreamRequests();
            return View(models);
        }

        public ActionResult Resolve(int id)
        {
            StreamRequestViewModel model = service.GetStreamRequestById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return this.View(model);
        }
        public ActionResult DenyStream(int id)
        {
            service.DenyStream(id);
            return RedirectToAction("Index");

        }

        public ActionResult ApproveStream(int id)
        {
            service.ApproveStream(id);
            return RedirectToAction("Index");

        }
    }
}
