namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_created : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auditoriums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Venue_id = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_id, cascadeDelete: true)
                .Index(t => t.Venue_id);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Auditorium_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Auditoriums", t => t.Auditorium_id, cascadeDelete: true)
                .Index(t => t.Auditorium_id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Venue_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_id, cascadeDelete: true)
                .Index(t => t.Venue_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConferenceDate = c.String(nullable: false),
                        BookingDate = c.String(),
                        Status = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Auditoriums", "Venue_id", "dbo.Venues");
            DropForeignKey("dbo.Staffs", "Venue_id", "dbo.Venues");
            DropForeignKey("dbo.Seats", "Auditorium_id", "dbo.Auditoriums");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Staffs", new[] { "Venue_id" });
            DropIndex("dbo.Seats", new[] { "Auditorium_id" });
            DropIndex("dbo.Auditoriums", new[] { "Venue_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Staffs");
            DropTable("dbo.Venues");
            DropTable("dbo.Seats");
            DropTable("dbo.Auditoriums");
        }
    }
}
