using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Attributes;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Areas.Admin.Controllers
{
    [AdminAuthorize(Roles = "Admin")]
    public class GameRequestsController : Controller
    {
        private IAdminService service;

        public GameRequestsController(IAdminService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            IEnumerable<GameRequestViewModel> models = service.GetGameRequests();
            return View(models);
        }
        [HttpGet]
        public ActionResult Resolve(int id)
        {
            GameRequestViewModel model = service.GetGameRequestById(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return this.View(model);
        }
        public ActionResult DenyGame(int id)
        {
            service.DenyGame(id);
            return RedirectToAction("Index");

        }
        public ActionResult ApproveGame(int id)
        {
            service.ApproveGame(id);
            return RedirectToAction("Index");

        }
    }
}
