namespace InstituteManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToFaculty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faculties", "Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Faculties", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faculties", "Description", c => c.String(maxLength: 200));
            AlterColumn("dbo.Faculties", "Name", c => c.String(maxLength: 30));
        }
    }
}
