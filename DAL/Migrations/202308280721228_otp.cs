namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PassOTPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        OTP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PassOTPs");
        }
    }
}
