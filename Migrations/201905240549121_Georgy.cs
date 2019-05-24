namespace Videorent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Georgy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Film", "Genre_GenreID", "dbo.Genre");
            DropIndex("dbo.Film", new[] { "Genre_GenreID" });
            RenameColumn(table: "dbo.Film", name: "Genre_GenreID", newName: "GenreId");
            AlterColumn("dbo.Film", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Film", "GenreId");
            AddForeignKey("dbo.Film", "GenreId", "dbo.Genre", "GenreID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Film", "GenreId", "dbo.Genre");
            DropIndex("dbo.Film", new[] { "GenreId" });
            AlterColumn("dbo.Film", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Film", name: "GenreId", newName: "Genre_GenreID");
            CreateIndex("dbo.Film", "Genre_GenreID");
            AddForeignKey("dbo.Film", "Genre_GenreID", "dbo.Genre", "GenreID");
        }
    }
}
