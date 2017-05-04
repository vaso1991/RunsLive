using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class Genre
    {
        public Genre()
        {
            this.Games = new List<Game>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
