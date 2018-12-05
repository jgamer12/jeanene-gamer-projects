namespace DVDWebAPI.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorID = c.Int(nullable: false, identity: true),
                        DirectorFirstName = c.String(maxLength: 50),
                        DirectorLastName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DirectorID);
            
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        RatingId = c.Int(),
                        DirectorId = c.Int(),
                        Title = c.String(maxLength: 100),
                        RealeaseYear = c.Int(),
                        Notes = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Directors", t => t.DirectorId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.RatingId)
                .Index(t => t.DirectorId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dvds", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.Dvds", "DirectorId", "dbo.Directors");
            DropIndex("dbo.Dvds", new[] { "DirectorId" });
            DropIndex("dbo.Dvds", new[] { "RatingId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Dvds");
            DropTable("dbo.Directors");
        }
    }
}
