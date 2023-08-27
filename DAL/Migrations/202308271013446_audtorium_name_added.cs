namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class audtorium_name_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoriums", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auditoriums", "Name");
        }
    }
}
