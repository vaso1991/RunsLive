using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.ViewModels
{
    public class StreamsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string StreamerName { get; set; }

        public bool IsStreaming { get; set; }
    }
}
