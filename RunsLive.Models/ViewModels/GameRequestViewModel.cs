using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class GameRequestViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(3),Display(Name = "Game Name: ")]
        public string Name { get; set; }

        [Required,Display(Name = "Image Url: ")]
        public string ImageUrl { get; set; }

        [Required,Display(Name = "Genre: ")]
        public string GenreName { get; set; }

        public string Status { get; set; }
    }
}
