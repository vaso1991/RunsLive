using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RunsLive.Models.EntityModels;
using RunsLive.Models.ViewModels;
using RunsLive.Service.Interfaces;

namespace RunsLive.Service
{
    public class GenresService : Service, IGenresService
    {
        public IEnumerable<GenresViewModel> GetGenres()
        {
            IEnumerable<Genre> genres = Context.Genres.ToArray();
            IEnumerable<GenresViewModel> vms = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenresViewModel>>(genres);
            return vms;
        }

        public IEnumerable<GamesViewModel> GetGamesFromGenre(int id)
        {
            Genre genre;

            try
            {
                genre = Context.Genres.First(g => g.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            IEnumerable<Game> games = Context.Games.Where(g => g.GenreName == genre.Name);
            IEnumerable<GamesViewModel> vms = Mapper.Map<IEnumerable<Game>, IEnumerable<GamesViewModel>>(games);
            return vms;
        }
    }
}
