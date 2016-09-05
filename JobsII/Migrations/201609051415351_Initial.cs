namespace JobsII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Jobid = c.Long(nullable: false),
                        Personid = c.Long(nullable: false),
                        dateapplied = c.DateTime(),
                        dateinformed1 = c.DateTime(),
                        dateinformed2 = c.DateTime(),
                        active = c.Boolean(),
                        comments = c.String(),
                        flag1 = c.Boolean(),
                        flag2 = c.Boolean(),
                        flag3 = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Personid, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Jobid, cascadeDelete: true)
                .Index(t => t.Jobid)
                .Index(t => t.Personid);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        lastname = c.String(),
                        firstname = c.String(),
                        email = c.String(),
                        idnum = c.Long(),
                        Deptid = c.Int(),
                        address = c.String(),
                        city = c.String(),
                        state = c.String(),
                        country = c.String(),
                        zip = c.String(),
                        institution = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        RequirementName = c.String(),
                        RequirementDescription = c.String(),
                        Applicant_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_id)
                .Index(t => t.Applicant_id);
            
            CreateTable(
                "dbo.Reviewers",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Personid = c.Long(nullable: false),
                        Applicationid = c.Long(nullable: false),
                        review = c.Binary(),
                        datesent = c.DateTime(nullable: false),
                        Statusid = c.Int(nullable: false),
                        datereceived = c.DateTime(nullable: false),
                        reminderdate = c.DateTime(nullable: false),
                        Applicant_id = c.Long(),
                        Job_id = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.Personid, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_id)
                .ForeignKey("dbo.Jobs", t => t.Job_id)
                .Index(t => t.Personid)
                .Index(t => t.Applicant_id)
                .Index(t => t.Job_id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shortname = c.String(),
                        fullname = c.String(),
                        departmentheadid = c.Long(),
                        assdepartmentheadid = c.Long(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.assdepartmentheadid)
                .ForeignKey("dbo.People", t => t.departmentheadid)
                .Index(t => t.departmentheadid)
                .Index(t => t.assdepartmentheadid);
            
            CreateTable(
                "dbo.JobRequirements",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        Jobid = c.Long(nullable: false),
                        Requirementid = c.Long(nullable: false),
                        deadline = c.DateTime(nullable: false),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Jobs", t => t.Jobid, cascadeDelete: true)
                .ForeignKey("dbo.Requirements", t => t.Requirementid, cascadeDelete: true)
                .Index(t => t.Jobid)
                .Index(t => t.Requirementid);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        jobshortname = c.String(),
                        jobfullname = c.String(),
                        mercavaid = c.String(),
                        Deptid = c.Int(nullable: false),
                        coordinatorid = c.Long(nullable: false),
                        tenderstart = c.DateTime(),
                        tenderend = c.DateTime(),
                        DecisionMade = c.DateTime(),
                        committeeformed = c.DateTime(),
                        materialsent1 = c.DateTime(),
                        materialsent2 = c.DateTime(),
                        meetingdate1 = c.DateTime(),
                        meetingdate2 = c.DateTime(),
                        expenseforms = c.DateTime(),
                        roomordered = c.DateTime(),
                        fileprepared = c.DateTime(),
                        flag1 = c.Boolean(),
                        flag2 = c.Boolean(),
                        flag3 = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.coordinatorid, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Deptid, cascadeDelete: true)
                .Index(t => t.Deptid)
                .Index(t => t.coordinatorid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobRequirements", "Requirementid", "dbo.Requirements");
            DropForeignKey("dbo.JobRequirements", "Jobid", "dbo.Jobs");
            DropForeignKey("dbo.Reviewers", "Job_id", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Deptid", "dbo.Departments");
            DropForeignKey("dbo.Jobs", "coordinatorid", "dbo.People");
            DropForeignKey("dbo.Applicants", "Jobid", "dbo.Jobs");
            DropForeignKey("dbo.Departments", "departmentheadid", "dbo.People");
            DropForeignKey("dbo.Departments", "assdepartmentheadid", "dbo.People");
            DropForeignKey("dbo.Reviewers", "Applicant_id", "dbo.Applicants");
            DropForeignKey("dbo.Reviewers", "Personid", "dbo.People");
            DropForeignKey("dbo.Requirements", "Applicant_id", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "Personid", "dbo.People");
            DropIndex("dbo.Jobs", new[] { "coordinatorid" });
            DropIndex("dbo.Jobs", new[] { "Deptid" });
            DropIndex("dbo.JobRequirements", new[] { "Requirementid" });
            DropIndex("dbo.JobRequirements", new[] { "Jobid" });
            DropIndex("dbo.Departments", new[] { "assdepartmentheadid" });
            DropIndex("dbo.Departments", new[] { "departmentheadid" });
            DropIndex("dbo.Reviewers", new[] { "Job_id" });
            DropIndex("dbo.Reviewers", new[] { "Applicant_id" });
            DropIndex("dbo.Reviewers", new[] { "Personid" });
            DropIndex("dbo.Requirements", new[] { "Applicant_id" });
            DropIndex("dbo.Applicants", new[] { "Personid" });
            DropIndex("dbo.Applicants", new[] { "Jobid" });
            DropTable("dbo.Jobs");
            DropTable("dbo.JobRequirements");
            DropTable("dbo.Departments");
            DropTable("dbo.Reviewers");
            DropTable("dbo.Requirements");
            DropTable("dbo.People");
            DropTable("dbo.Applicants");
        }
    }
}
