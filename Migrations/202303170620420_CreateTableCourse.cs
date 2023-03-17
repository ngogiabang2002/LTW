namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Lecturerid = c.String(nullable: false, maxLength: 128),
                        Place = c.String(nullable: false, maxLength: 255),
                        DataTime = c.String(),
                        CategoryId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecturerid, cascadeDelete: true)
                .Index(t => t.Lecturerid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecturerid", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Lecturerid" });
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
        }
    }
}
