using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsII.Models;

namespace JobsII.Repository
{
    public class DataService
    {
        private JobsModel _jobmodel;

        private JobsModel jobmodel
        {

            get
            {
                if (_jobmodel == null)
                    _jobmodel = new JobsModel();

                return _jobmodel;
            }
            //  set { jobmodel = _jobmodel; }
        }

        // persons

        public ObservableCollection<Person> GetAllPersons()
        {
            var mylist = jobmodel.Persons.ToList();
            return new ObservableCollection<Person>(mylist);

        }

        public async Task<ObservableCollection<Person>> FindPerson(string searchstring)
        {
            var mylist =
                await jobmodel.Persons.Where(p => (p.lastname + p.firstname).Contains(searchstring)).ToListAsync();
            return new ObservableCollection<Person>(mylist);
        }

        public async Task<Person> GetonePerson(int id)
        {
            return await jobmodel.Persons.FindAsync(id);

        }

        public async Task SavePerson(Person p)
        {
            var thep = await jobmodel.Persons.FindAsync(p.id);
            if (thep == null)
            {
                thep = p;
                jobmodel.Persons.Add(p);
            }
            else
            {
                thep = p;
            }
            jobmodel.SaveChanges();
            
        }

        public async Task<ObservableCollection<Person>> SavePerson(ObservableCollection<Person> persons)
        {
            foreach (var p in persons)
            {

                await SavePerson(p);
            }
            return persons;
        }
        internal async Task DeletePerson(Person p)
        {
            var thep = await jobmodel.Persons.FindAsync(p.id);
            if (thep != null)
            {

            }
            else
            {
                thep = p;
            }
            jobmodel.SaveChanges();

        }
        #region Jobs
        public  ObservableCollection<Job> GetAllJobs()
        {
            var mylist =  jobmodel.Jobs.ToList();
            return new ObservableCollection<Job>(mylist);

        }

        public async Task<Job> saveJob(Job j)
        {
            
            var thej = await jobmodel.Jobs.FindAsync(j.id);
            if (thej == null)
            {
                thej = j;
                jobmodel.Jobs.Add(j);
            }
            else
            {
                thej = j;
            }
            jobmodel.SaveChanges();
            return thej;
        }

        #endregion


        #region Departments

        public async Task<Department> GetOneDept(int id)
        {
            return await jobmodel.Departments.FindAsync(id);

        }
        public ObservableCollection<Department> GetAllDepartments()
        {
            var mylist = jobmodel.Departments.ToList();
            return new ObservableCollection<Department>(mylist);

        }
        public async Task<Department> SaveDepartment(Department d)
        {
            var thep = await jobmodel.Departments.FindAsync(d.id);
            if (thep == null)
            {
                thep = d;
                jobmodel.Departments.Add(thep);

            }
            else
            {
                thep.assdepartmenthead = d.assdepartmenthead;
                thep.assdepartmentheadid = d.assdepartmentheadid;
                thep.departmentheadid = d.departmentheadid;
                thep.fullname = d.fullname;
                thep.shortname = d.shortname;

            }
            jobmodel.SaveChanges();
           
            return thep;
        }
        #endregion
        #region Requirements

        public ObservableCollection<Requirement> getAllRequirements()
        {

            var mylist = jobmodel.Requirements.ToList();
            return new ObservableCollection<Requirement>(mylist);
        }

        public async Task<Requirement> SaveRequirement(Requirement r)
        {
           
            var thep = await jobmodel.Requirements.FindAsync(r.id);
            if (thep == null)
            {
                thep = r;
                jobmodel.Requirements.Add(thep);
               
            }
            else
            {
                thep.RequirementDescription = r.RequirementDescription;
                thep.RequirementName = r.RequirementName;


            }
            jobmodel.SaveChanges();
           
            return thep;
        }

        internal Task Savejobs(ObservableCollection<Job> jobs)
        {
            throw new NotImplementedException();
        }

        internal Task Savejob(Job selectedjob)
        {
            throw new NotImplementedException();
        }

        internal Task<ObservableCollection<Applicant>> getapplicantsbyjobid(long id)
        {
            throw new NotImplementedException();
        }


        #endregion


    }
}
