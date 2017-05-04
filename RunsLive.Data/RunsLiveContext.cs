using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RunsLive.Models.EntityModels;

namespace RunsLive.Data
{
    public class RunsLiveContext : IdentityDbContext<ApplicationUser>
    {

        public RunsLiveContext()
            : base("RunsLiveContext", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Stream> Streamers { get; set; }

        public virtual DbSet<Vod> Vods { get; set; }

        public virtual DbSet<StreamRequest> StreamRequests { get; set; }

        public virtual DbSet<VodRequest> VodRequestses { get; set; }

        public virtual DbSet<GameRequest> GameRequests { get; set; }

        public static RunsLiveContext Create()
        {
            return new RunsLiveContext();
        }
    }


}