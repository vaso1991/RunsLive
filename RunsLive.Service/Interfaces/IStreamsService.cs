using System.Collections.Generic;
using RunsLive.Models.BindingModels;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IStreamsService
    {
        void AddNewRequest(RequestStreamBindingModel bind, string username);
        IEnumerable<StreamsViewModel> GetAllStreams();
    }
}