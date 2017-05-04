using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class Game
    {
        public Game()
        {
            this.Streamers = new List<Stream>();
            this.Vods = new List<Vod>();
        }
        [Key]
        public int Id { get; set; }

        [Required,MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string GenreName { get; set; }

        public string RecordHolder { get; set; }

        public string RecordVod { get; set; }

        public virtual ICollection<Stream> Streamers { get; set; }

        public virtual ICollection<Vod> Vods { get; set; }
    }
}
