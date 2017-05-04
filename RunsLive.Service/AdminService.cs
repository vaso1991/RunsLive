using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class AdminService : Service, IAdminService
    {
        public IEnumerable<GameRequestViewModel> GetGameRequests()
        {
            IEnumerable<GameRequest> requests = Context.GameRequests.ToArray();
            IEnumerable<GameRequestViewModel> models =
                Mapper.Map<IEnumerable<GameRequest>, IEnumerable<GameRequestViewModel>>(requests);
            return models;
        }

        public IEnumerable<StreamRequestViewModel> GetStreamRequests()
        {
            IEnumerable<StreamRequest> requests = Context.StreamRequests.ToArray();
            IEnumerable<StreamRequestViewModel> models =
                Mapper.Map<IEnumerable<StreamRequest>, IEnumerable<StreamRequestViewModel>>(requests);
            return models;
        }

        public IEnumerable<VodRequestViewModel> GetVodRequests()
        {
            IEnumerable<VodRequest> requests = Context.VodRequestses.ToArray();
            IEnumerable<VodRequestViewModel> models =
                Mapper.Map<IEnumerable<VodRequest>, IEnumerable<VodRequestViewModel>>(requests);
            return models;
        }

        public VodRequestViewModel GetVodRequestById(int id)
        {
            VodRequest request;
            try
            {
                request = Context.VodRequestses.First(v => v.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            VodRequestViewModel model = Mapper.Map<VodRequest, VodRequestViewModel>(request);
            return model;
        }

        public void DenyVod(int id)
        {
            VodRequest request = Context.VodRequestses.First(v => v.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.VodRequests.First(v => v.Id == id).Status = "Denied";
            Context.VodRequestses.First(v=>v.Id == id).Status = "Denied";
            Context.SaveChanges();
        }

        public void ApproveVod(int id)
        {
            VodRequest request = Context.VodRequestses.First(v => v.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.VodRequests.First(v => v.Id == id).Status = "Approved";
            Context.VodRequestses.First(v => v.Id == id).Status = "Approved";
            Vod vod = Mapper.Map<VodRequest, Vod>(request);
            if (!Context.Streamers.Any(s=>s.StreamerName == vod.StreamerName))
            {
                Context.Streamers.Add(new Stream()
                {
                    StreamerName = vod.StreamerName,
                    Vods = new List<Vod>()
                });
                Context.SaveChanges();
            }
            Context.Games.First(g=>g.Name == vod.GameName).Vods.Add(vod);
            Context.Streamers.First(s=>s.StreamerName == vod.StreamerName).Vods.Add(vod);
            Context.SaveChanges();
        }

        public GameRequestViewModel GetGameRequestById(int id)
        {
            GameRequest request;
            try
            {
                request = Context.GameRequests.First(v => v.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            GameRequestViewModel model = Mapper.Map<GameRequest, GameRequestViewModel>(request);
            return model;
        }

        public void DenyGame(int id)
        {
            GameRequest request = Context.GameRequests.First(g => g.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.GameRequestses.First(g => g.Id == id).Status = "Denied";
            Context.GameRequests.First(g => g.Id == id).Status = "Denied";
            Context.SaveChanges();
        }

        public void ApproveGame(int id)
        {
            GameRequest request = Context.GameRequests.First(v => v.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.GameRequestses.First(v => v.Id == id).Status = "Approved";
            Context.GameRequests.First(v => v.Id == id).Status = "Approved";
            Game game = Mapper.Map<GameRequest, Game>(request);
            if (!Context.Genres.Any(g => g.Name == game.GenreName))
            {
                Context.Genres.Add(new Genre()
                {
                    Name = game.GenreName,
                    Games = new List<Game>()
                });
                Context.SaveChanges();
            }
            Context.Games.Add(game);
            Context.Genres.First(g => g.Name == game.GenreName).Games.Add(game);
            Context.SaveChanges();
        }

        public void DenyStream(int id)
        {
            StreamRequest request = Context.StreamRequests.First(g => g.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.StreamRequests.First(g => g.Id == id).Status = "Denied";
            Context.StreamRequests.First(g => g.Id == id).Status = "Denied";
            Context.SaveChanges();
        }

        public void ApproveStream(int id)
        {
            StreamRequest request = Context.StreamRequests.First(v => v.Id == id);
            string username = request.RequestedBy;
            ApplicationUser user = Context.Users.First(u => u.UserName == username);
            user.StreamRequests.First(v => v.Id == id).Status = "Approved";
            Context.StreamRequests.First(v => v.Id == id).Status = "Approved";
            Stream stream = Mapper.Map<StreamRequest, Stream>(request);
            Context.Streamers.Add(stream);
            Context.SaveChanges();
        }

        public StreamRequestViewModel GetStreamRequestById(int id)
        {
            StreamRequest request;
            try
            {
                request = Context.StreamRequests.First(v => v.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            StreamRequestViewModel model = Mapper.Map<StreamRequest, StreamRequestViewModel>(request);
            return model;
        }
    }
}
