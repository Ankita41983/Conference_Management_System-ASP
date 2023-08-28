namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class entity_changed : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Logins", newName: "StaffLogins");
            RenameTable(name: "dbo.Tokens", newName: "StaffTokens");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StaffTokens", newName: "Tokens");
            RenameTable(name: "dbo.StaffLogins", newName: "Logins");
        }
    }
}
