using System.Collections.Generic;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<VodRequestViewModel> GetUserRequestedVods(string username);
        IEnumerable<GameRequestViewModel> GetUserRequestedGames(string username);
        IEnumerable<StreamRequestViewModel> GetUserRequestedStreams(string username);
    }
}