using System.Collections.Generic;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IVodService
    {
        IEnumerable<VodViewModel> GetAllVods();
        void AddNewRequest(RequestVodBindingModel bind, string username);
        IEnumerable<VodRequestViewModel> GetAllGames();
    }
}