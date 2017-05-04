using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class VodViewModel
    {
        [Required]
        public string VideoId { get; set; }
        [Required]
        public string StreamerName { get; set; }
        [Required]
        public string VideoDescription { get; set; }
        [Required]
        public string GameName { get; set; }
    }
}
