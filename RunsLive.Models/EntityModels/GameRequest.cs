using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class GameRequest
    {
      
        [Key]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string GenreName { get; set; }

        public string Status { get; set; }

        [Required]
        public string RequestedBy { get; set; }

    }
}
