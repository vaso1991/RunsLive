using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using RunsLive.Models.BindingModels;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class VodService:Service, IVodService
    {
        public IEnumerable<VodViewModel> GetAllVods()
        {
            IEnumerable<Vod> vods = Context.Vods;
            IEnumerable<VodViewModel> models = Mapper.Map<IEnumerable<Vod>, IEnumerable<VodViewModel>>(vods);
            return models;
        }

        public void AddNewRequest(RequestVodBindingModel bind, string username)
        {

            Regex regex = new Regex("[0-9]+");
            Match match = regex.Match(bind.VideoId);
            bind.VideoId = "v" + match.Value;
            VodRequest model = Mapper.Map<RequestVodBindingModel, VodRequest>(bind);
            this.Context.VodRequestses.Add(model);
            this.Context.Users.First(u=>u.UserName == username).VodRequests.Add(model);
            Context.SaveChanges();
        }

        public IEnumerable<VodRequestViewModel> GetAllGames()
        {
            IEnumerable<Game> games = this.Context.Games.ToArray();
            IEnumerable<VodRequestViewModel> models = Mapper.Map<IEnumerable<Game>, IEnumerable<VodRequestViewModel>>(games);
            return models;
        }
    }
}
