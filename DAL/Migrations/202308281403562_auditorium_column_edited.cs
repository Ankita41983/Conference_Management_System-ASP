namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class auditorium_column_edited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auditoriums", "A_Name", c => c.String(nullable: false));
            AddColumn("dbo.Auditoriums", "A_Capacity", c => c.Int(nullable: false));
            DropColumn("dbo.Auditoriums", "Name");
            DropColumn("dbo.Auditoriums", "Capacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Auditoriums", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.Auditoriums", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Auditoriums", "A_Capacity");
            DropColumn("dbo.Auditoriums", "A_Name");
        }
    }
}
