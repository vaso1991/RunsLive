using System.Collections.Generic;

namespace RunsLive.Models.ViewModels
{
    public class GenresViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GamesViewModel> Games { get; set; }
    }
}
