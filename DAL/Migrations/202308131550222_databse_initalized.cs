namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databse_initalized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Venue_id = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_id, cascadeDelete: true)
                .Index(t => t.Venue_id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auditoriums", "Venue_id", "dbo.Venues");
            DropIndex("dbo.Auditoriums", new[] { "Venue_id" });
            DropTable("dbo.Venues");
            DropTable("dbo.Auditoriums");
        }
    }
}
