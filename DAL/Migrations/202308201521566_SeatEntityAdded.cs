using System;
using System.Data.Entity.Migrations;
namespace DAL.Migrations
{
   
    
    public partial class SeatEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Row = c.String(nullable: false),
                        Type = c.Boolean(nullable: false),
                        Staff_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Staffs", t => t.Staff_id, cascadeDelete: true)
                .Index(t => t.Staff_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "Staff_id", "dbo.Staffs");
            DropIndex("dbo.Seats", new[] { "Staff_id" });
            DropTable("dbo.Seats");
        }
    }
}
