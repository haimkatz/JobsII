using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
    class mySeed : DropCreateDatabaseIfModelChanges<JobsModel>
    {
        protected override void Seed(JobsModel context)
        {
            context.Departments.Add(new Department {shortname = "גדש", fullname = "גידולי שדה"});
            context.Departments.Add(new Department {shortname = "בעח", fullname = "בעלי חיים"});
            context.Departments.Add(new Department {shortname = "קקמ", fullname = "קרקע ומים"});
            context.Persons.Add(new Person
            {
                firstname = "חיים",
                lastname = "קץ",
                idnum = 017615899,
                city = "תל אביב",
                country = "ישראל",
                Deptid = 1
            });
            context.Persons.Add(new Person
            {
                firstname = "אופיר",
                lastname = "קץ",
                idnum = 12345667,
                city = "תל אביב",
                country = "ישראל",
                Deptid = 1
            });
            context.Persons.Add(new Person
            {
                firstname = "יעל",
                lastname = "ראובני",
                idnum = 987656,
                city = "רחובות",
                country = "ישראל",
                Deptid = 2
            });
            context.Persons.Add(new Person
            {
                firstname = "יוסף",
                lastname = "שמו",
                idnum = 876999,
                city = "חיפה",
                country = "ישראל",
                institution = "ולקני",
                Deptid = 1
            });
            // Seeding data here
            context.Requirements.Add(new Requirement
            {
                RequirementDescription = "3דפים ",
                RequirementName = "CV"
            });
            context.Requirements.Add(new Requirement
            {
                RequirementName = "המלצה",
                RequirementDescription = "דפ 1"
            });
            context.SaveChanges();


        }

    }
}
