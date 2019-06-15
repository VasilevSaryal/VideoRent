namespace Videorent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        Age = c.Int(nullable: false),
                        Phone = c.Long(nullable: false),
                        InBlacklist = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.DiscFilms",
                c => new
                    {
                        DiscFilmId = c.Int(nullable: false, identity: true),
                        DiscID = c.Int(nullable: false),
                        FilmID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiscFilmId)
                .ForeignKey("dbo.Disc", t => t.DiscID, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.FilmID, cascadeDelete: true)
                .Index(t => t.DiscID)
                .Index(t => t.FilmID);
            
            CreateTable(
                "dbo.Disc",
                c => new
                    {
                        DiscID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        Films_FilmID = c.Int(),
                    })
                .PrimaryKey(t => t.DiscID)
                .ForeignKey("dbo.Film", t => t.Films_FilmID)
                .Index(t => t.Films_FilmID);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeID = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.FilmID)
                .ForeignKey("dbo.FilmType", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.FilmType",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.FilmGenres",
                c => new
                    {
                        FilmGenresID = c.Int(nullable: false, identity: true),
                        FilmID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmGenresID)
                .ForeignKey("dbo.Film", t => t.FilmID, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.FilmID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        DepositeType = c.String(),
                        StartAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        MoneyAmount = c.Int(nullable: false),
                        DiscID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .ForeignKey("dbo.Disc", t => t.DiscID, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.DiscID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "DiscID", "dbo.Disc");
            DropForeignKey("dbo.Order", "ClientID", "dbo.Client");
            DropForeignKey("dbo.FilmGenres", "GenreID", "dbo.Genre");
            DropForeignKey("dbo.FilmGenres", "FilmID", "dbo.Film");
            DropForeignKey("dbo.DiscFilms", "FilmID", "dbo.Film");
            DropForeignKey("dbo.DiscFilms", "DiscID", "dbo.Disc");
            DropForeignKey("dbo.Disc", "Films_FilmID", "dbo.Film");
            DropForeignKey("dbo.Film", "TypeID", "dbo.FilmType");
            DropIndex("dbo.Order", new[] { "DiscID" });
            DropIndex("dbo.Order", new[] { "ClientID" });
            DropIndex("dbo.FilmGenres", new[] { "GenreID" });
            DropIndex("dbo.FilmGenres", new[] { "FilmID" });
            DropIndex("dbo.Film", new[] { "TypeID" });
            DropIndex("dbo.Disc", new[] { "Films_FilmID" });
            DropIndex("dbo.DiscFilms", new[] { "FilmID" });
            DropIndex("dbo.DiscFilms", new[] { "DiscID" });
            DropTable("dbo.Order");
            DropTable("dbo.Genre");
            DropTable("dbo.FilmGenres");
            DropTable("dbo.FilmType");
            DropTable("dbo.Film");
            DropTable("dbo.Disc");
            DropTable("dbo.DiscFilms");
            DropTable("dbo.Client");
        }
    }
}
