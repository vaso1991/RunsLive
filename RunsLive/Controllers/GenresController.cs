using System.Collections.Generic;
using System.Web.Mvc;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Controllers
{
    public class GenresController : Controller
    {
        private IGenresService service;

        public GenresController(IGenresService service)
        {
            this.service = service;
        }
        
        public ActionResult All()
        {
            IEnumerable<GenresViewModel> models = service.GetGenres();
            return this.View(models);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<GamesViewModel> models = service.GetGamesFromGenre(id);
            if (models == null)
            {
                return this.Redirect("/genres/all");
            }
            return this.View(models);
        }
    }
}
