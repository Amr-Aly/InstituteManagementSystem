namespace InstituteManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRequiredToAll : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Students", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Gender", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Departments", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 30));
        }
    }
}
