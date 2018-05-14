using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
    class mySeed :DropCreateDatabaseIfModelChanges<JobsModel>
    {
        protected override void Seed(JobsModel context)
        {

            string mysqlstr = @"Create VIEW dbo.MissingAppDocs
AS
SELECT ROW_NUMBER() OVER(Order by Jobs.id asc, lastname asc, jobRequirementid asc) as Keyid, dbo.JobRequirements.id, dbo.JobRequirements.Jobid, dbo.JobRequirements.Requirementid, dbo.Applicants.Personid, dbo.AppRequirements.jobRequirementid, dbo.Jobs.jobshortname, dbo.Jobs.jobfullname,
                         dbo.People.lastname, dbo.People.firstname, dbo.Requirements.RequirementName
FROM            dbo.JobRequirements INNER JOIN
                         dbo.Applicants ON dbo.JobRequirements.Jobid = dbo.Applicants.Jobid INNER JOIN
                         dbo.Jobs ON dbo.JobRequirements.Jobid = dbo.Jobs.id INNER JOIN
                         dbo.People ON dbo.Applicants.Personid = dbo.People.id INNER JOIN
                         dbo.Requirements ON dbo.JobRequirements.id = dbo.Requirements.id LEFT OUTER JOIN
                         dbo.AppRequirements ON dbo.JobRequirements.Requirementid = dbo.AppRequirements.jobRequirementid AND dbo.Applicants.id = dbo.AppRequirements.Applicantid
WHERE(dbo.AppRequirements.jobRequirementid IS NULL)";
            Createview("Drop Table dbo.MissingAppDocs", context);
            Createview(mysqlstr, context);
            addrecords(context);
        }

        void addrecords(JobsModel context) { 

        context.Institutes.Add(new Institute
            {
                shortname = "מדעי הצמח",
                fullname = "מכון למדעי הצמח",
                Eshortname = "Plant Sciences"
            });
            context.Institutes.Add(new Institute
            {
                shortname = "בעלי חיים",
                fullname = "מכון לבעלי חיים",
                Eshortname = "Animal Sciences"
            });
            context.Institutes.Add(new Institute
            {
                shortname = "קרקע ומים",
                fullname = "מכון קרקע, מים והסביבה",
                Eshortname = "Soil and Water Institute"
            });
            context.MergeDocTypes.Add(new MergeDocType {typename = "request"});
            context.MergeDocTypes.Add(new MergeDocType {typename = "remind"});
            context.MergeDocTypes.Add(new MergeDocType {typename = "thank"});
            context.SaveChanges();
            context.Departments.Add(new Department {shortname = "גדש", fullname = "גידולי שדה", Instituteid = 1});
            context.Departments.Add(new Department {shortname = "עצפ", fullname = "עצי פרי", Instituteid = 1});
            context.Departments.Add(new Department {shortname = "בעח", fullname = "בעלי חיים", Instituteid = 2});
            context.Departments.Add(new Department {shortname = "דגים", fullname = "דגים", Instituteid = 2});
            context.Departments.Add(new Department {shortname = "קקמ", fullname = "קרקע ומים", Instituteid = 3});
            context.SaveChanges();
            context.ReviewerStatuses.Add(new ReviewerStatus {id = 0, Status = "ללא"});
            context.ReviewerStatuses.Add(new ReviewerStatus {id = 1, Status = "נשלח"});
            context.ReviewerStatuses.Add(new ReviewerStatus {id = 2, Status = "הסכים"});
            context.ReviewerStatuses.Add(new ReviewerStatus {id = 3, Status = "הושלם"});
            context.ReviewerStatuses.Add(new ReviewerStatus {id = 4, Status = "סירב"});
            context.Requirements.Add(new Requirement {RequirementDescription = "CV", RequirementName = "CV"});
            context.Requirements.Add(new Requirement {RequirementDescription = "המלצה", RequirementName = "המלצה"});
            context.Persons.Add(new Person
            {
                firstname = "חיים",
                lastname = "קץ",
                idnum = 017615899,
                city = "תל אביב",
                country = "ישראל",
                Deptid = 1,
                sex = sex.male
            });
            context.Persons.Add(new Person
            {
                firstname = "אופיר",
                lastname = "קץ",
                idnum = 12345667,
                city = "תל אביב",
                country = "ישראל",
                Deptid = 1,
                sex = sex.male
            });
            context.Persons.Add(new Person
            {
                firstname = "יעל",
                lastname = "ראובני",
                idnum = 987656,
                city = "רחובות",
                country = "ישראל",
                Deptid = 2,
                sex = sex.female
            });
            context.Persons.Add(new Person
            {
                firstname = "יוסף",
                lastname = "שמו",
                idnum = 876999,
                city = "חיפה",
                country = "ישראל",
                institution = "ולקני",
                Deptid = 1,
                sex = sex.male
            });
            // Seeding data here

            context.Jobs.Add(new Job
            {
                jobfullname = "First Job",
                jobshortname = "Job I",
                Deptid = 1

            });
            context.Jobs.Add(new Job
            {
                jobfullname = "Second Job",
                jobshortname = "Job II",
                Deptid = 2
            });
            context.SexFields.Add(new SexField
            {
                sex = sex.male,
                HeShe = "He",
                heshe_s = "he",
                HooHee = "הוא",
                VavHeh = "ו",
                HisHer = "His",
                hisher_s = "his"

            });
            context.SexFields.Add(new SexField
            {
                sex = sex.female,
                HeShe = "She",
                heshe_s = "she",
                HooHee = "היא",
                VavHeh = "ה",
                HisHer = "Her",
                hisher_s = "her"
            });

            context.SaveChanges();

            base.Seed(context);
        }

    

    private void Createview(string mysql, JobsModel context)
        {
            context.Database.ExecuteSqlCommand(mysql);
        }

    }
}
