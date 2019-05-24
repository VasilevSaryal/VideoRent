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
                "dbo.Disc",
                c => new
                    {
                        DiscID = c.Int(nullable: false, identity: true),
                        IsAvailable = c.Boolean(nullable: false),
                        OrderID_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.DiscID)
                .ForeignKey("dbo.Order", t => t.OrderID_OrderID)
                .Index(t => t.OrderID_OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        DepositeType = c.String(),
                        StartAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        MoneyAmount = c.Int(nullable: false),
                        Client_ClientID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Client", t => t.Client_ClientID)
                .Index(t => t.Client_ClientID);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Genre_GenreID = c.Int(),
                    })
                .PrimaryKey(t => t.FilmID)
                .ForeignKey("dbo.Genre", t => t.Genre_GenreID)
                .Index(t => t.Genre_GenreID);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Film", "Genre_GenreID", "dbo.Genre");
            DropForeignKey("dbo.Disc", "OrderID_OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "Client_ClientID", "dbo.Client");
            DropIndex("dbo.Film", new[] { "Genre_GenreID" });
            DropIndex("dbo.Order", new[] { "Client_ClientID" });
            DropIndex("dbo.Disc", new[] { "OrderID_OrderID" });
            DropTable("dbo.Genre");
            DropTable("dbo.Film");
            DropTable("dbo.Order");
            DropTable("dbo.Disc");
            DropTable("dbo.Client");
        }
    }
}
