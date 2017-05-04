using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class StreamRequest
    {
        public int Id { get; set; }

        [Required]
        public string StreamName { get; set; }

        public string Status { get; set; }

        [Required]
        public string RequestedBy { get; set; }
    }
}
