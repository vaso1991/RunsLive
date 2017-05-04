using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class GamesViewModel
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string GenreName { get; set; }
            
    }
}
