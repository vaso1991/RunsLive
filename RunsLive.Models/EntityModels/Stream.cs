using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RunsLive.Models.EntityModels
{
    public class Stream
    {
        public Stream()
        {
            this.Vods = new List<Vod>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string StreamerName { get; set; }

        public virtual ICollection<Vod> Vods { get; set; } 

    }
}
