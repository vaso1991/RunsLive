using System.Collections.Generic;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IGenresService
    {
        IEnumerable<GenresViewModel> GetGenres();
        IEnumerable<GamesViewModel> GetGamesFromGenre(int id);
    }
}