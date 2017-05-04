using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {

        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }
        [Route("Index")]
        public ActionResult Index()
        {
            IEnumerable<GamesViewModel> vms = this.service.GetAllGames();
            return View(vms);
        }
    }
}