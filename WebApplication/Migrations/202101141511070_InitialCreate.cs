namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Song = c.String(),
                        Released = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        SongId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Album = c.String(),
                        Album_AlbumId = c.Int(),
                    })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Albums", t => t.Album_AlbumId)
                .Index(t => t.Album_AlbumId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Song = c.String(),
                        Album = c.String(),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.ArtistSongs",
                c => new
                    {
                        Artist_ArtistId = c.Int(nullable: false),
                        Song_SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_ArtistId, t.Song_SongId })
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.Song_SongId, cascadeDelete: true)
                .Index(t => t.Artist_ArtistId)
                .Index(t => t.Song_SongId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Album_AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ArtistSongs", "Song_SongId", "dbo.Songs");
            DropForeignKey("dbo.ArtistSongs", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.ArtistSongs", new[] { "Song_SongId" });
            DropIndex("dbo.ArtistSongs", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Songs", new[] { "Album_AlbumId" });
            DropTable("dbo.ArtistSongs");
            DropTable("dbo.Artists");
            DropTable("dbo.Songs");
            DropTable("dbo.Albums");
        }
    }
}
