using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using GalaSoft.MvvmLight.Messaging;
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
        #region "persons"0

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
            try
            {
                jobmodel.SaveChanges();
            }
            catch (Exception ex)
            {



                Messenger.Default.Send<errormessage>(new errormessage {errormsg = ex.Message, isvisible = true});
            }
        }


        #region "MergeDocs"      

        internal ObservableCollection<MergeDocType> Getmergedoctypes()
        {
            var mylist = jobmodel.MergeDocTypes.ToList();
            return new ObservableCollection<MergeDocType>(mylist);
        }

        internal void Savemergedoctype(ObservableCollection<MergeDocType> mergedoctypes)
        {
            try { 
            foreach (MergeDocType m in mergedoctypes)
            {
                SaveOneMergeDocType(m);
            }
        }
            catch ( Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }
        }

        internal void DeleteMergeDocType(MergeDocType selMD)
        {
            MergeDocType ar = jobmodel.MergeDocTypes.Where(a => a.id == selMD.id).FirstOrDefault();
            if (ar != null)
            {
                jobmodel.MergeDocTypes.Remove(ar);
                jobmodel.SaveChanges();
            }
        }

        public ObservableCollection<MergeDoc> getlettercombobyVMtype(string vmtype)
        {
            var mylist =
                jobmodel.MergeDocs.Where(m => m.mergetype == vmtype).ToList();
            return new ObservableCollection<MergeDoc>(mylist);
        }
        private void SaveOneMergeDocType(MergeDocType m)
        { var thel = jobmodel.MergeDocTypes.Find(m.id);
            if (thel == null)
            {
                thel = m;
                jobmodel.MergeDocTypes.Add(m);
            }
            else
            {
                thel = m;
            }
            try
            {
                jobmodel.SaveChanges();
            }
            catch (Exception ex)
            {

            

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });
            
        }
        }

        public MergeDoc getMergedocbyLangMergetypeDoctype(int languageid, int doctypeid, string adressee)
        {
            return
                jobmodel.MergeDocs.Where(
                    m => m.mergedoctypeid == doctypeid && m.languageid == languageid && m.mergetype == adressee)
                    .FirstOrDefault();
        }
        #endregion
        private void SaveLanguage(Language l)
        {
            var thel =  jobmodel.Languages.Find(l.id);
            if (thel == null)
            {
                thel = l;
                jobmodel.Languages.Add(l);
            }
            else
            {
                thel = l;
            }
            try
            {
                jobmodel.SaveChanges();
            }
            catch (Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = e.Message, isvisible = true });
            }
        
        }
        public void SaveLanguages(ObservableCollection<Language> languages)
        {
            foreach (var l in languages)
            {
                SaveLanguage(l);
            };
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
                jobmodel.Persons.Remove(thep);
            }
            else
            {
                thep = p;
            }
            jobmodel.SaveChanges();

        }
        #endregion
        #region Jobs

        public ObservableCollection<Job> GetAllJobs()
        {
            var mylist = jobmodel.Jobs.ToList();
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

        public ObservableCollection<Job> jobsbyDept(int deptid)
        {
            var thejoc =  jobmodel.Jobs.Where(j => j.Deptid == deptid).ToList();
            return new ObservableCollection<Job>(thejoc);
        }
        public ObservableCollection<Job> jobsbyFilter(int filter)
        {
            List<Job> thejoc = new List<Job>();
            switch (filter)
            {   // all active
                case 0:
                     thejoc = jobmodel.Jobs.Where(j => j.stage != 0).ToList();
                    break;
                case 1:
                case 2:
                    thejoc = jobmodel.Jobs.Where(j => j.stage == filter).ToList();
                    break;
                case 3:
                    thejoc = jobmodel.Jobs.ToList();
                    break;
            }
            
            return new ObservableCollection<Job>(thejoc);
        }
        public ObservableCollection<Job> jobsbyInstid(int instid)
        {
            var thejoc =  jobmodel.Jobs.Where(j => j.department.Instituteid == instid).ToList();
            return new ObservableCollection<Job>(thejoc);
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

        internal ObservableCollection<UniversalDoc> getUniversaldocs()
        {
            var mylist = jobmodel.UniversalDocs.ToList();
            return new ObservableCollection<UniversalDoc>(mylist);
        }

        internal ObservableCollection<jobDoc> getjobdocs(long myjob)
        {
            var mylist = jobmodel.JobDocs.Where(jc => jc.jobid == myjob).ToList();
            return new ObservableCollection<jobDoc>(mylist);
        }

        internal void DeleteStatus(ReviewerStatus selrevstatus)
        {
            ReviewerStatus rv = jobmodel.ReviewerStatuses.Where(r => r.id == selrevstatus.id).FirstOrDefault();

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
        public void deleteRequirement(Requirement selectedrequirement)
        {
            Requirement ar = jobmodel.Requirements.Where(a => a.id == selectedrequirement.id).FirstOrDefault();
            if (ar != null)
            {
                jobmodel.Requirements.Remove(ar);
                jobmodel.SaveChanges();
            }
        }

        public void SaveMergeDoc(MergeDoc selectedMergeDoc)
        {
            var myar = jobmodel.MergeDocs.Where(md => md.id == selectedMergeDoc.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (myar == null)
            {
                myar = selectedMergeDoc;
                jobmodel.MergeDocs.Add(myar);
            }
            else
            {
                myar = selectedMergeDoc;
            }
            jobmodel.SaveChanges();
          
        }

        internal void DeleteUnivsaldoc(UniversalDoc selectedDoc)
        {
            UniversalDoc ap = jobmodel.UniversalDocs.Where(a => a.id == selectedDoc.id).FirstOrDefault();
            if (ap != null)
            {
                jobmodel.UniversalDocs.Remove(ap);
                jobmodel.SaveChanges();
            }
        }

        internal void Saveunivdoc(UniversalDoc selectedDoc)
        {
            var myar = jobmodel.UniversalDocs.Where(ud => ud.id == selectedDoc.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (myar == null)
            {
                myar = selectedDoc;
                jobmodel.UniversalDocs.Add(myar);
            }
            else
            {
                myar = selectedDoc;
            }
            jobmodel.SaveChanges();
            selectedDoc = myar;
        }

        internal ObservableCollection<MergeDoc> Getallmergedocs()
        {
            var mylist = jobmodel.MergeDocs.ToList().OrderBy(m => m.docname);
            return new ObservableCollection<MergeDoc>(mylist);
        }

        public ObservableCollection<UniversalDoc> getallUDs()
        {
            var mylist = jobmodel.UniversalDocs.ToList();
            return new ObservableCollection<UniversalDoc>(mylist);
        }
        public ObservableCollection<UniversalDoc> getUDsbyDocname(string searchtext)
        {
            var mylist = jobmodel.UniversalDocs.Where(d => d.DocName.Contains(searchtext)).ToList();
       
           return new ObservableCollection<UniversalDoc>(mylist);
        }

        internal void Deljobrequirement(JobRequirement _selectedjr)
        {
            JobRequirement ap = jobmodel.JobRequirements.Where(a => a.id == _selectedjr.id).FirstOrDefault();
            if (ap != null)
            {
                jobmodel.JobRequirements.Remove(ap);
                jobmodel.SaveChanges();
            };
        }

        internal void Savejr(ObservableCollection<JobRequirement> jrs)
        {
            foreach (JobRequirement jr in jrs)
            {
                var myjr = jobmodel.JobRequirements.Find(jr.id);
                if (myjr == null)
                {
                    jobmodel.JobRequirements.Add(jr);
                }
                else
                {
                    myjr = jr;
                }
                jobmodel.SaveChanges();
            }
        }

        public void DeleteDoc(UniversalDoc ud)
        {
            UniversalDoc ap = jobmodel.UniversalDocs.Where(a => a.id == ud.id).FirstOrDefault();
            if (ap != null)
            {
                jobmodel.UniversalDocs.Remove(ap);
                jobmodel.SaveChanges();
            };
        }

        internal void SavejobDoc(jobDoc selecteddoc)
        {
            var myar = jobmodel.JobDocs.Where(ud => ud.id == selecteddoc.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (myar == null)
            {
                myar = selecteddoc;
                jobmodel.JobDocs.Add(myar);
            }
            else
            {
                myar = selecteddoc;
            }
            jobmodel.SaveChanges();
            selecteddoc = myar;
        }

        internal void SaveReviewerStatus(ObservableCollection<ReviewerStatus> revstatus)
        {
            ;
            foreach (ReviewerStatus p in revstatus)
            {


                var thep = jobmodel.ReviewerStatuses.Find(p.id);
                if (thep == null)
                {
                    thep = p;
                    jobmodel.ReviewerStatuses.Add(thep);
                }
                else
                {
                    thep = p;
                }
                jobmodel.SaveChanges();
            }

        }

        internal void DeletejobDoc(jobDoc selecteddoc)
        {

            jobDoc ap = jobmodel.JobDocs.Where(a => a.id == selecteddoc.id).FirstOrDefault();
            if (ap != null)
            {
                jobmodel.JobDocs.Remove(ap);
                jobmodel.SaveChanges();
            };
        }

        public void  DeleteApplicant(Applicant obj)
        {
            Applicant ap = jobmodel.Applicants.Where(a => a.id == obj.id).FirstOrDefault();
            if (ap != null)
            {
                jobmodel.Applicants.Remove(ap);
                jobmodel.SaveChanges();
            };
        }

        internal ObservableCollection<ReviewerStatus> getrevstatus()
        {
            var mylist = jobmodel.ReviewerStatuses;
            return new ObservableCollection<ReviewerStatus>(mylist);
        }

        public ObservableCollection<Job> FindJob(string searchtext)
        {
            var myjob = jobmodel.Jobs.Where(j => j.jobfullname.Contains(searchtext)).ToList();
            return new ObservableCollection<Models.Job>(myjob);
        }

        public ObservableCollection<Requirement> getjobrequirements(long j)
        {
            var mylist = jobmodel.JobRequirements.Where(jr => jr.Jobid == j).Select(jr => jr.requirement);
            return new ObservableCollection<Requirement>(mylist);
        }

        internal Task Savejobs(ObservableCollection<Job> jobs)
        {
            throw new NotImplementedException();
        }

        public void Savejob(Job selectedjob)
        {
            var myjob = jobmodel.Jobs.Where(j => j.id == selectedjob.id).FirstOrDefault();
            if (myjob == null)
            {
                myjob = selectedjob;
                jobmodel.Jobs.Add(myjob);
            }
            else
            {
                myjob = selectedjob;
            }
            jobmodel.SaveChanges();
            selectedjob = myjob;
        }

        public ObservableCollection<Applicant> getapplicantsbyjobid(long id)
        {
            var mylist = jobmodel.Applicants.Where(a => a.Jobid == id).ToList();
            return new ObservableCollection<Applicant>(mylist);
        }
        public ObservableCollection<Applicant> getapplicantsbyjobid(long id,bool stage)
        {
            var mylist = jobmodel.Applicants.Where(a => a.Jobid == id && a.flag1 == stage).ToList();
            return new ObservableCollection<Applicant>(mylist);
        }
        public void SaveApplicant(Applicant na)
        {try { 
            var myint = jobmodel.Applicants.Count(a => a.Jobid == na.Jobid && a.Personid == na.Personid);

            if (myint == 0)
            {
                jobmodel.Applicants.Add(na);
            }
            else
            {
                var myapplicant = jobmodel.Applicants.Find(na.id);
                    if (myapplicant != null)
                    { myapplicant = na;}
            }
            jobmodel.SaveChanges();


        }
            catch ( Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        public ObservableCollection<Reviewer> getreviewersbyappid(long id)
        {
            var mylist = jobmodel.Reviewers.Where(r => r.Applicantid == id).ToList();
            return new ObservableCollection<Reviewer>(mylist);
        }

        internal ObservableCollection<jobCommitteeMember> getCommMembers(long id)
        {
            var mylist = jobmodel.jobCommitteeMembers.Where(jc => jc.Jobid == id).ToList();
            return new ObservableCollection<jobCommitteeMember>(mylist);
        }

        public void SaveReviewer(Reviewer selectedReviewer)
        {
            var myrev = jobmodel.Reviewers.Where(r => r.id == selectedReviewer.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (myrev == null)
            {
                myrev = selectedReviewer;
                jobmodel.Reviewers.Add(myrev);
            }
            else
            {
                myrev = selectedReviewer;
            }
            try
            {
                jobmodel.SaveChanges();
                selectedReviewer = myrev;
            }
            catch (Exception ex)
            {

                Messenger.Default.Send < errormessage >( new errormessage {errormsg = ex.Message, isvisible = true});
            }

        }

        internal void Saveappreq(AppRequirement selectedappreq)
        {
            try
            {
  var myar = jobmodel.AppRequirements.Where(ar => ar.id == selectedappreq.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (myar == null)
            {
                myar = selectedappreq;
                jobmodel.AppRequirements.Add(myar);
            }
            else
            {
                myar = selectedappreq;
            }
            jobmodel.SaveChanges();
            selectedappreq = myar;
            }
            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage { errormsg = e.Message, isvisible = true });
            }
          
        }

        internal void SaveComMem(jobCommitteeMember jcm)
        {
            var mycm = jobmodel.jobCommitteeMembers.Where(cm => cm.id == jcm.id).FirstOrDefault();

            //maybe should see if applicant exists
            if (mycm == null)
            {
                mycm = jcm;
                jobmodel.jobCommitteeMembers.Add(mycm);
            }
            else
            {
                mycm = jcm;
            }
            try { 
            jobmodel.SaveChanges();
            jcm = mycm;
        }
            catch ( Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }
        }

        public void DeleteComMem(jobCommitteeMember selectedCM)
        {
            jobCommitteeMember jcm = jobmodel.jobCommitteeMembers.Where(j => j.id == selectedCM.id).FirstOrDefault();
            if (jcm != null)
            {
                jobmodel.jobCommitteeMembers.Remove(jcm);
                jobmodel.SaveChanges();
            }
        }


        public void Deleteappreq(AppRequirement selectedappreq)
        {

            AppRequirement ar = jobmodel.AppRequirements.Where(a => a.id == selectedappreq.id).FirstOrDefault();
            if (ar != null)
            {
                jobmodel.AppRequirements.Remove(ar);
                jobmodel.SaveChanges();
            }
        }
        public string GetLetter(long id)
        {
            var mylet =
                          jobmodel.MergeDocs.Find(id);
                             
            if (mylet != null)
            { return mylet.htmltext; }
            else { return String.Empty; }
        }
        public string GeMessageType(long id)
        {
            var mylet =
                          jobmodel.MergeDocs.Find(id);

            if (mylet != null)
            { return mylet.mergedoctype.typename; }
            else { return String.Empty; }
        }
        public string GetLetter(string messagetype, int lang, string v)
        {
  var mylet =
                jobmodel.MergeDocs.Where(
                    m => m.languageid == lang && m.mergedoctype.typename == messagetype && m.mergetype == v)
                    .FirstOrDefault();
            if (mylet != null)
            {  return mylet.htmltext;}
            else { return String.Empty;}
            }
           

        
        public ObservableCollection<ReviewerStatus> FillRevStatus()
        {
            var mylist = jobmodel.ReviewerStatuses.ToList();
            return new ObservableCollection<ReviewerStatus>(mylist);
        }

        #endregion

        #region "institutes"

        public ObservableCollection<Institute> getallinstitutes()
        {
            var mylist = jobmodel.Institutes.ToList().OrderBy(i=>i.fullname);
            return new ObservableCollection<Institute>(mylist);

        }

        public void saveinstitutes(ObservableCollection<Institute> institutes)
        {
            {
                ;
                foreach (Institute i in institutes)
                {


                    var theI = jobmodel.Institutes.Find(i.id);
                    if (theI == null)
                    {
                        theI = i;
                        jobmodel.Institutes.Add(theI);
                    }
                    else
                    {
                        theI = i;
                    }
                    jobmodel.SaveChanges();
                }

            }

            

        }

        #endregion
        #region "Queries"

        public ObservableCollection<Object> getRevReminders()
        {
            var mylist =
                jobmodel.Reviewers.Where(
                    r => r.reminderdate < DateTime.Today && (r.reviewerstatus.id == 2 | r.reviewerstatus.id == 1))
                    .Select(p => new
                    {
                        p.applicant.job.jobshortname,
                        ApplicantName = p.applicant.person.lastname,
                        ReviewerName = p.person.lastname,
                        p.reminderdate,
                        p.reviewerstatus.Status
                    }).ToList();
            return new ObservableCollection<object>(mylist);
        }
        public ObservableCollection<Object> getagreeRevReminders()
        {
            var mylist =
                jobmodel.Reviewers.Where(
                    r => r.reminderdate < DateTime.Today && (r.reviewerstatus.id == 3 ))
                    .Select(p => new
                    {
                        p.applicant.job.jobshortname,
                        ApplicantName = p.applicant.person.lastname,
                        ReviewerName = p.person.lastname,
                        p.reminderdate,
                        p.reviewerstatus.Status
                    }).ToList();
            return new ObservableCollection<object>(mylist);
        }
        public ObservableCollection<MissingAppDocs>  getAppReminders()
        {
            var mylist =
                jobmodel.MissingAppDocs.ToList();
            return new ObservableCollection<MissingAppDocs>(mylist);
        }

       
        #endregion
        public void DeleteReviewer(Reviewer reviewer)
        {
            try { 
            Reviewer r = jobmodel.Reviewers.Where(a => a.id == reviewer.id).FirstOrDefault();
            if (r != null)
            {
                jobmodel.Reviewers.Remove(r);
                jobmodel.SaveChanges();
            }
            }
            catch (Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = e.Message, isvisible = true });
            }
        }

        public void DeleteDepartment(Department selectedDepartment)
        {
            try { 
            Department dept = jobmodel.Departments.Where(d => d.id == selectedDepartment.id).FirstOrDefault();
            if (dept != null)
            {
                jobmodel.Departments.Remove(dept);
                jobmodel.SaveChanges();
            }
            }
            catch (Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = e.Message, isvisible = true });
            }
        }

        internal ObservableCollection<Language> getlanguages()
        {
            var mylist = jobmodel.Languages.ToList();
            return new ObservableCollection<Language>(mylist);
        }

        internal void DeleteLanguage(Language selectedLang)
        {
            try
            {
                Language mylang = jobmodel.Languages.Find(selectedLang.id);
                jobmodel.Languages.Remove(mylang);
                jobmodel.SaveChanges();

            }
            catch (Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }
        }

        public MergeDoc getMergeDoc(long id)
        {
           return jobmodel.MergeDocs.Find(id);
        }
    }
}

