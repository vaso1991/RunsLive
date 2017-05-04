using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class HomeService:Service, IHomeService
    {
        public IEnumerable<GamesViewModel> GetAllGames()
        {
            IEnumerable<Game> games = this.Context.Games.ToArray();
            IEnumerable<GamesViewModel> vms = Mapper.Map<IEnumerable<Game>, IEnumerable<GamesViewModel>>(games);
            return vms;
        }
    }
}
