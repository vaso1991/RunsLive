using System.Collections.Generic;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IHomeService
    {
        IEnumerable<GamesViewModel> GetAllGames();
    }
}