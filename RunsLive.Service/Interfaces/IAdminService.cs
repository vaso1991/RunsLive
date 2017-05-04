using System.Collections.Generic;
using RunsLive.Models.ViewModels;

namespace RunsLive.Service.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<GameRequestViewModel> GetGameRequests();
        IEnumerable<StreamRequestViewModel> GetStreamRequests();
        IEnumerable<VodRequestViewModel> GetVodRequests();
        VodRequestViewModel GetVodRequestById(int id);
        void DenyVod(int id);
        void ApproveVod(int id);
        GameRequestViewModel GetGameRequestById(int id);
        void DenyGame(int id);
        void ApproveGame(int id);
        void DenyStream(int id);
        void ApproveStream(int id);
        StreamRequestViewModel GetStreamRequestById(int id);
    }
}