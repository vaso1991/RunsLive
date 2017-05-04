using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class AccountService:Service, IAccountService
    {
        public IEnumerable<VodRequestViewModel> GetUserRequestedVods(string username)
        {
            IEnumerable<VodRequest> requests =
                this.Context.Users.First(u => u.UserName == username).VodRequests.ToArray();
            IEnumerable<VodRequestViewModel> models =
                Mapper.Map<IEnumerable<VodRequest>, IEnumerable<VodRequestViewModel>>(requests).OrderByDescending(m => m.Id);
            return models;
        }

        public IEnumerable<GameRequestViewModel> GetUserRequestedGames(string username)
        {
            IEnumerable<GameRequest> requests =
                this.Context.Users.First(u => u.UserName == username).GameRequestses.ToArray();
            IEnumerable<GameRequestViewModel> models =
                Mapper.Map<IEnumerable<GameRequest>, IEnumerable<GameRequestViewModel>>(requests).OrderByDescending(m => m.Id);
            return models;
        }

        public IEnumerable<StreamRequestViewModel> GetUserRequestedStreams(string username)
        {
            IEnumerable<StreamRequest> requests =
              this.Context.Users.First(u => u.UserName == username).StreamRequests.ToArray();
            IEnumerable<StreamRequestViewModel> models =
                Mapper.Map<IEnumerable<StreamRequest>, IEnumerable<StreamRequestViewModel>>(requests).OrderByDescending(m=>m.Id);
            return models;
        }
    }
}
