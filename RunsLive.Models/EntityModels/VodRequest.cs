using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class VodRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VideoId { get; set; }

        [Required]
        public string StreamerName { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string VideoDescription { get; set; }
        public string Status { get; set; }
        [Required]
        public string RequestedBy { get; set; }
    }
}
