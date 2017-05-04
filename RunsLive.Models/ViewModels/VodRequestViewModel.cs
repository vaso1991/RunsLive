using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class VodRequestViewModel
    {
        public int Id { get; set; }
        [Required, Display(Name = "Description: ")]
        public string VideoDescription { get; set; }
        [Required,Display(Name = "Game: ")]
        public string GameName { get; set; }
        [Required,Display(Name = "Streamer Name: ")]
        public string StreamerName { get; set; }
        [Required, Display(Name = "Twitch Url: ")]
        public string VideoId { get; set; }

        public string Status { get; set; }
    }
}
