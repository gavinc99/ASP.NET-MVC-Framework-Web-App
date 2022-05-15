namespace WebApplication.Migrations.ApplicationDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using WebApplication.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication.Models.SongsModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication.Models.SongsModelContext";
        }

        protected override void Seed(WebApplication.Models.SongsModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var songs = new List<Song>
            {
                new Song {Name="Wonderwall", Album="What's the Story, Morning Glory?" },
                new Song {Name="Bitter Sweet Symphony", Album="Urban Hymns" },
                new Song {Name="Cast No Shadow", Album="What's the Story, Morning Glory?" },
                new Song {Name="Yesterday", Album="Help!" },
                new Song {Name="Live Forever", Album="Definitely Maybe" }
            };
            songs.ForEach(b => context.Songs.AddOrUpdate(song=>song.Name, b));
            context.SaveChanges();

            var artists = new List<Artist>
            {
                new Artist {Name = "Oasis",
                Songs = songs.Where(b => (b.Name=="Wonderwall") || (b.Album=="What's the Story, Morning Glory?")).ToList() },
                new Artist {Name = "The Verve",
                Songs = songs.Where(b => (b.Name=="Bitter Sweet Symphony") || (b.Album=="Urban Hymns")).ToList() },
                new Artist {Name = "Oasis",
                Songs = songs.Where(b => (b.Name=="Cast No Shadow") || (b.Album=="What's the Story, Morning Glory?")).ToList() },
                new Artist {Name = "Oasis",
                Songs = songs.Where(b => (b.Name=="Yesterday") || (b.Album=="Help!")).ToList() },
                new Artist {Name = "Oasis",
                Songs = songs.Where(b => (b.Name=="Live Forever") || (b.Album=="Definitely Maybe")).ToList() },

            };
            artists.ForEach(a => context.Artists.AddOrUpdate(artist => artist.Name, a));
            context.SaveChanges();
}
        }
    }
