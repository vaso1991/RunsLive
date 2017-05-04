using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Attributes;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Areas.Admin.Controllers
{
    [AdminAuthorize(Roles = "Admin")]
    public class VodRequestsController : Controller
    {
        private IAdminService service;

        public VodRequestsController(IAdminService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            IEnumerable<VodRequestViewModel> models = service.GetVodRequests();
            return View(models);
        }

        [HttpGet]
        public ActionResult Resolve(int id)
        {
            VodRequestViewModel model = service.GetVodRequestById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return this.View(model);
        }
        
        public ActionResult DenyVod(int id)
        {
            service.DenyVod(id);
            return RedirectToAction("Index");
           
        }

        public ActionResult ApproveVod(int id)
        {
            service.ApproveVod(id);
            return RedirectToAction("Index");

        }
    }
}
