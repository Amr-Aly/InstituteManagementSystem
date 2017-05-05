namespace InstituteManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "depId", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "facId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "depId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "facId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "facId");
            DropColumn("dbo.Students", "depId");
            DropColumn("dbo.Departments", "facId");
            DropColumn("dbo.Courses", "depId");
        }
    }
}
