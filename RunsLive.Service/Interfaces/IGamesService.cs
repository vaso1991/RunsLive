using System.Collections.Generic;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IGamesService
    {
        IEnumerable<VodViewModel> GetVodsByGameId(int id);
        void AddNewRequest(RequestGameBindingModel bind, string username);
        IEnumerable<GameRequestViewModel> GetAllGenres();
    }
}