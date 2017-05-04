using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Controllers
{
    [RoutePrefix("Games")]
    public class GamesController : Controller
    {
        private IGamesService service;

        public GamesController(IGamesService service)
        {
            this.service = service;
        }
        [Route("Vods/{id}")]
        public ActionResult Vods (int id)
        {
            IEnumerable<VodViewModel> models = service.GetVodsByGameId(id);
            if (models == null)
            {
                return this.Redirect("/home/index");
            }
            return View(models);
        }
        [HttpGet]
        [Route("RequestGame")]
        [Authorize]
        public ActionResult RequestGame()
        {
            IEnumerable<GameRequestViewModel> models = service.GetAllGenres();
            return View(models);
        }

        [HttpPost]
        [Authorize]
        [Route("RequestGame")]
        public ActionResult RequestGame(RequestGameBindingModel bind)
        {
            IEnumerable<GameRequestViewModel> models = service.GetAllGenres();
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewRequest(bind, username);
                return RedirectToAction("RequestedGames", "Manage");
            }
            return View(models);
        }

    }
}
