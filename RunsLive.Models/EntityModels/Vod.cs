using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
   public class Vod
    {
        [Key]
        public int Id { get; set; }
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
