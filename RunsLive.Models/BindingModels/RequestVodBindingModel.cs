using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.BindingModels
{
    public class RequestVodBindingModel
    {
        [Required]
        public string VideoDescription { get; set; }

        [Required]
        public string GameName { get; set; }
        [Required,MinLength(3)]
        public string StreamerName { get; set; }
        [Required]
        public string VideoId { get; set; }

        [Required]
        public string RequestedBy { get; set; }
    }
}
