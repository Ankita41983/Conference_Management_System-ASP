namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Token_created : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropPrimaryKey("dbo.Logins");
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        Email = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logins", t => t.Email)
                .Index(t => t.Email);
            
            AlterColumn("dbo.Logins", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Logins", "Email");
            DropColumn("dbo.Logins", "Id");
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Logins", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Tokens", "Email", "dbo.Logins");
            DropIndex("dbo.Tokens", new[] { "Email" });
            DropPrimaryKey("dbo.Logins");
            AlterColumn("dbo.Logins", "Email", c => c.String());
            DropTable("dbo.Tokens");
            AddPrimaryKey("dbo.Logins", "Id");
            CreateIndex("dbo.Tickets", "UserId");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
