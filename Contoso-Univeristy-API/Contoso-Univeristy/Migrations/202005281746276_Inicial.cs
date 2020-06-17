namespace Contoso_Univeristy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Department_Id", c => c.Int());
            AddColumn("dbo.Courses", "Instructor_Id", c => c.Int());
            AddColumn("dbo.Student_Enrollment", "Course_Id", c => c.Int());
            AddColumn("dbo.Student_Enrollment", "Student_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Department_Id");
            CreateIndex("dbo.Courses", "Instructor_Id");
            CreateIndex("dbo.Student_Enrollment", "Course_Id");
            CreateIndex("dbo.Student_Enrollment", "Student_Id");
            AddForeignKey("dbo.Courses", "Department_Id", "dbo.Departments", "Id");
            AddForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors", "Id");
            AddForeignKey("dbo.Student_Enrollment", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Student_Enrollment", "Student_Id", "dbo.Students", "Id");
            DropColumn("dbo.Courses", "DepartmentId");
            DropColumn("dbo.Courses", "InstructorId");
            DropColumn("dbo.Student_Enrollment", "CourseId");
            DropColumn("dbo.Student_Enrollment", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student_Enrollment", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Student_Enrollment", "CourseId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "InstructorId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Student_Enrollment", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Student_Enrollment", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Courses", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Student_Enrollment", new[] { "Student_Id" });
            DropIndex("dbo.Student_Enrollment", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Instructor_Id" });
            DropIndex("dbo.Courses", new[] { "Department_Id" });
            DropColumn("dbo.Student_Enrollment", "Student_Id");
            DropColumn("dbo.Student_Enrollment", "Course_Id");
            DropColumn("dbo.Courses", "Instructor_Id");
            DropColumn("dbo.Courses", "Department_Id");
        }
    }
}
