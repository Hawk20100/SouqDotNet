namespace SouqDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 250));
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "Job", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "Description", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Description", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Job", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
