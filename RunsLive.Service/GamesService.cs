using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.BindingModels;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class GamesService : Service, IGamesService
    {

        public IEnumerable<VodViewModel> GetVodsByGameId(int id)
        {
            string gameName;
            try
            {
                gameName = Context.Games.First(g => g.Id == id).Name;
            }
            catch (Exception)
            {
                return null;
            }
            IEnumerable<Vod> vods = Context.Vods.Where(v => v.GameName == gameName);
            IEnumerable<VodViewModel> vms = Mapper.Map<IEnumerable<Vod>, IEnumerable<VodViewModel>>(vods);
            return vms;
        }

        public void AddNewRequest(RequestGameBindingModel bind, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == username);
            GameRequest model = Mapper.Map<RequestGameBindingModel, GameRequest>(bind);
            this.Context.GameRequests.Add(model);
            currentUser.GameRequestses.Add(model);
            Context.SaveChanges();
        }

        public IEnumerable<GameRequestViewModel> GetAllGenres()
        {
            IEnumerable<Genre> genres = Context.Genres.ToArray();
            IEnumerable<GameRequestViewModel> vms = Mapper.Map<IEnumerable<Genre>, IEnumerable<GameRequestViewModel>>(genres);
            return vms;
        }
    }
}

