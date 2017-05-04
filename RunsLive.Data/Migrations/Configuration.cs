using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RunsLive.Models.EntityModels;

namespace RunsLive.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RunsLive.Data.RunsLiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "RunsLive.Data.RunsLiveContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RunsLive.Data.RunsLiveContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }
            if (!context.Games.Any())
            {
                context.Games.Add(new Game()
                {
                    Name = "Doom",
                    GenreName = "Action",
                    ImageUrl = "https://static-cdn.jtvnw.net/ttv-boxart/Doom-272x380.jpg",
                    RecordHolder = "",
                    RecordVod = "",
                    Streamers = new List<Stream>(),
                    Vods = new List<Vod>()
                });
                context.Games.Add(new Game()
                {
                    Name = "Dark Souls 2",
                    GenreName = "Action RPG",
                    ImageUrl = "https://static-cdn.jtvnw.net/ttv-boxart/Dark%20Souls%20II-272x380.jpg",
                    RecordHolder = "distortion2",
                    RecordVod = "v95721114",
                    Streamers = new List<Stream>(),
                    Vods = new List<Vod>()
                });
                context.Games.Add(new Game()
                {
                    Name = "Bloodborne",
                    GenreName = "Action RPG",
                    ImageUrl = "https://static-cdn.jtvnw.net/ttv-boxart/Bloodborne-272x380.jpg",
                    RecordHolder = "ssp0313",
                    RecordVod = "v129291283",
                    Streamers = new List<Stream>(),
                    Vods = new List<Vod>()
                });
                context.Games.Add(new Game()
                {
                    Name = "Shovel Knight",
                    GenreName = "Platformer",
                    ImageUrl =
                        "http://www.mobygames.com/images/covers/l/303373-shovel-knight-playstation-4-front-cover.jpg",
                    RecordHolder = "smaugy",
                    RecordVod = "v123529612",
                    Streamers = new List<Stream>(),
                    Vods = new List<Vod>()
                });
                context.Games.Add(new Game()
                {
                    Name = "Super Meat Boy",
                    GenreName = "Platformer",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/aa/SuperMeatBoy_cover.png",
                    RecordHolder = "vorpal",
                    RecordVod = "v39940968",
                    Streamers = new List<Stream>(),
                    Vods = new List<Vod>()
                });

                context.SaveChanges();
            }
            if (!context.Genres.Any())
            {

                context.Genres.Add(new Genre()
                {
                    Name = "Action",
                    Games = new List<Game>()
                });

                context.Genres.Add(new Genre()
                {
                    Name = "Action RPG",
                    Games = new List<Game>()
                });

                context.Genres.Add(new Genre()
                {
                    Name = "Platformer",
                    Games = new List<Game>()
                });

                context.Genres.Add(new Genre()
                {
                    Name = "Shooter",
                    Games = new List<Game>()
                });

                context.Genres.Add(new Genre()
                {
                    Name = "RPG",
                    Games = new List<Game>()
                });

                context.Genres.Add(new Genre()
                {
                    Name = "Other",
                    Games = new List<Game>()
                });

                context.SaveChanges();
            }

            if (!context.Streamers.Any())
            {
                context.Streamers.Add(new Stream()
                {
                    StreamerName = "ssp0313",
                    Vods = new List<Vod>()
                });

                context.Streamers.Add(new Stream()
                {
                    StreamerName = "bloodthunder",
                    Vods = new List<Vod>()
                });

                context.Streamers.Add(new Stream()
                {
                    StreamerName = "vorpal",
                    Vods = new List<Vod>()
                });

                context.Streamers.Add(new Stream()
                {
                    StreamerName = "smaugy",
                    Vods = new List<Vod>()
                });

                context.Streamers.Add(new Stream()
                {
                    StreamerName = "distortion2",
                    Vods = new List<Vod>()
                });

                context.SaveChanges();
            }

            if (!context.Vods.Any())
            {
                context.Vods.Add(new Vod()
                {
                    GameName = "Bloodborne",
                    StreamerName = "ssp0313",
                    VideoDescription = "Bloodborne - Any% Current Patch IGT 30:48 world record",
                    VideoId = "v129291283"
                });

                context.Vods.Add(new Vod()
                {
                    GameName = "Doom",
                    StreamerName = "bloodthunder",
                    VideoDescription = "Doom - 43:00",
                    VideoId = "v112691689"
                });

                context.Vods.Add(new Vod()
                {
                    GameName = "Super Meat Boy",
                    StreamerName = "vorpal",
                    VideoDescription = "Super Meat Boy any% speedrun in 0:17:43",
                    VideoId = "v39940968"
                });

                context.Vods.Add(new Vod()
                {
                    GameName = "Shovel Knight",
                    StreamerName = "smaugy",
                    VideoDescription = "World Record - Shovel Knight Any%, The Legendary 42:54",
                    VideoId = "v123529612"
                });

                context.Vods.Add(new Vod()
                {
                    GameName = "Dark Souls 2",
                    StreamerName = "distortion2",
                    VideoDescription = "DS2 SOTFS All Bosses Speedrun in 2:39:21 RTA (World Record)",
                    VideoId = "v95721114"
                });

                context.SaveChanges();
            }

            if (context.Games.First(g => g.Name == "Doom").Streamers.Count < 1)
            {
                context.Genres.First(g => g.Name == "Action").Games.Add(context.Games.First(g => g.Name == "Doom"));

                context.Genres.First(g => g.Name == "Platformer").Games.Add(context.Games.First(g => g.Name == "Super Meat Boy"));

                context.Genres.First(g => g.Name == "Platformer").Games.Add(context.Games.First(g => g.Name == "Shovel Knight"));

                context.Genres.First(g => g.Name == "Action RPG").Games.Add(context.Games.First(g => g.Name == "Bloodborne"));

                context.Genres.First(g => g.Name == "Action RPG").Games.Add(context.Games.First(g => g.Name == "Dark Souls 2"));

                context.Streamers.First(s => s.StreamerName == "ssp0313").Vods.Add(context.Vods.First(v => v.VideoId == "v129291283"));

                context.Streamers.First(s => s.StreamerName == "bloodthunder").Vods.Add(context.Vods.First(v => v.VideoId == "v112691689"));

                context.Streamers.First(s => s.StreamerName == "vorpal").Vods.Add(context.Vods.First(v => v.VideoId == "v39940968"));

                context.Streamers.First(s => s.StreamerName == "smaugy").Vods.Add(context.Vods.First(v => v.VideoId == "v123529612"));

                context.Streamers.First(s => s.StreamerName == "distortion2").Vods.Add(context.Vods.First(v => v.VideoId == "v95721114"));

                context.Games.First(g => g.Name == "Doom").Streamers.Add(context.Streamers.First(s => s.StreamerName == "bloodthunder"));

                context.Games.First(g => g.Name == "Super Meat Boy").Streamers.Add(context.Streamers.First(s => s.StreamerName == "vorpal"));

                context.Games.First(g => g.Name == "Shovel Knight").Streamers.Add(context.Streamers.First(s => s.StreamerName == "smaugy"));

                context.Games.First(g => g.Name == "Dark Souls 2").Streamers.Add(context.Streamers.First(s => s.StreamerName == "distortion2"));

                context.Games.First(g => g.Name == "Bloodborne").Streamers.Add(context.Streamers.First(s => s.StreamerName == "ssp0313"));

                context.Games.First(g => g.Name == "Doom").Vods.Add(context.Vods.First(v => v.VideoId == "v112691689"));

                context.Games.First(g => g.Name == "Bloodborne").Vods.Add(context.Vods.First(v => v.VideoId == "v129291283"));

                context.Games.First(g => g.Name == "Super Meat Boy").Vods.Add(context.Vods.First(v => v.VideoId == "v39940968"));

                context.Games.First(g => g.Name == "Shovel Knight").Vods.Add(context.Vods.First(v => v.VideoId == "v123529612"));

                context.Games.First(g => g.Name == "Dark Souls 2").Vods.Add(context.Vods.First(v => v.VideoId == "v95721114"));

                context.SaveChanges();
            }
        }
    }
}
