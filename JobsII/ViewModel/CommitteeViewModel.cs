using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Models;
using JobsII.Repository;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CommitteeViewModel : ViewModelBase
    {
        private DataService _ds;
        private bool isjobregistered = false;
        private Guid myguid;
        public const string selectedJobPropertyName = "selectedJob";



        private Job _selectedjob;
        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Job selectedJob
        {
            get
            {
                return _selectedjob;
            }

            set
            {
                if (_selectedjob == value)
                {
                    return;
                }
               
                _selectedjob = value;
                 getcommmbers();
                RaisePropertyChanged(selectedJobPropertyName);
            }
        }

        ///// <summary>
        ///// The <see cref="onemem" /> property's name.
        ///// </summary>
        //public const string onememPropertyName = "onemem";

        //private bool _onemem = false;

        /// <summary>
        /// Sets and gets the onemem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        //public bool onemem
        //{
        //    get
        //    {
        //        return _onemem;
        //    }
        //    set
        //    {
        //        Set(onememPropertyName, ref _onemem, value);
        //        if (_onemem)
        //        {
        //          lettercombos=  _ds.getlettercombobyVMtype("חבר בודד");

        //        }
        //        else
        //        {
        //           lettercombos= _ds.getlettercombobyVMtype("חברי ועדה");
        //        }
        //    }
        //}
        /// <summary>
        /// The <see cref="committeemembers" /> property's name.
        /// </summary>
        public const string committeemembersPropertyName = "committeemembers";

        private ObservableCollection<jobCommitteeMember> _comitteemembers;

        /// <summary>
        /// Sets and gets the committeemembers property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<jobCommitteeMember> committeemembers
        {
            get
            {
                return _comitteemembers;
            }

            set
            {
                if (_comitteemembers == value)
                {
                    return;
                }

                _comitteemembers = value;
                if (selectedCM==null)
                {
                    if (_comitteemembers.Count > 0)
                    {
                        selectedCM = _comitteemembers[0];
                    }
                }
                
                RaisePropertyChanged(committeemembersPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedCM" /> property's name.
        /// </summary>
        public const string selectedCMPropertyName = "selectedCM";

        private jobCommitteeMember _selectedCM ;

        /// <summary>
        /// Sets and gets the selectedCM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public jobCommitteeMember selectedCM
        {
            get
            {
                return _selectedCM;
            }

            set
            {
                if (_selectedCM == value)
                {
                    return;
                }

                _selectedCM = value;
                if (_selectedCM !=null)
                { selectedPerson = _selectedCM.person;}
                else { selectedPerson = null; }
                RaisePropertyChanged(selectedCMPropertyName);
                //findperson(_selectedCM);
            }
        }
        /// <summary>
        /// The <see cref="Persons" /> property's name.
        /// </summary>
        public const string PersonsPropertyName = "Persons";

        private ObservableCollection<Models.Person> _persons;

        /// <summary>
        /// Sets and gets the Persons property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Models.Person> Persons
        {
            get
            {
                return _persons;
            }

            set
            {
                if (_persons == value)
                {

                    return;
                }

                _persons = value;
                if (_selectedPerson == null)
                {
                    if (_persons.Count > 0)
                    {
                        selectedPerson = _persons[0];
                    }

                }
                RaisePropertyChanged(PersonsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedPerson" /> property's name.
        /// </summary>
        public const string selectedPersonPropertyName = "selectedPerson";

        private Models.Person _selectedPerson;
        /// <summary>
        /// Sets and gets the person property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.Person selectedPerson
        {
            get
            {
                return _selectedPerson;
            }

            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }

                _selectedPerson = value;
                RaisePropertyChanged(selectedPersonPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="departments" /> property's name.
        /// </summary>
        /// <summary>
        /// The <see cref="searchtext" /> property's name.
        /// </summary>
        public const string searchtextPropertyName = "searchtext";

        private string _searchtext = "";

        /// <summary>
        /// Sets and gets the searchtext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string searchtext
        {
            get
            {
                return _searchtext;
            }

            set
            {
                if (_searchtext == value)
                {
                    return;
                }

                _searchtext = value;
                RaisePropertyChanged(searchtextPropertyName);
            }
        }

        public const string departmentsPropertyName = "departments";

        private ObservableCollection<Department> _departments;

        /// <summary>
        /// Sets and gets the departments property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Department> departments
        {
            get
            {
                return _departments;
            }

            set
            {
                if (_departments == value)
                {
                    return;
                }

                _departments = value;
                RaisePropertyChanged(departmentsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="lettercombos" /> property's name.
        /// </summary>
        public const string lettercombosPropertyName = "lettercombos";

        private ObservableCollection<MergeDoc> _lettercombos ;

        /// <summary>
        /// Sets and gets the lettercombos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MergeDoc> lettercombos
        {
            get
            {
                return _lettercombos;
            }
            set
            {
                Set(lettercombosPropertyName, ref _lettercombos, value);
            }
        }
        /// <summary>
        /// The <see cref="sellettercombo" /> property's name.
        /// </summary>
        public const string sellettercomboPropertyName = "sellettercombo";

        private MergeDoc _sellettercombo;

        /// <summary>
        /// Sets and gets the sellettercombo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MergeDoc sellettercombo
        {
            get
            {
                return _sellettercombo;
            }
            set
            {
                Set(sellettercomboPropertyName, ref _sellettercombo, value);
            }
        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand NewObject { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SaveObject { get; set; }
        public RelayCommand SearchCollection { get; set; }
        public RelayCommand<object> ChangeSelectedPerson { get; set; }
        public RelayCommand DeleteCM { get; set; }
        public RelayCommand AddComMem { get; set; }
        public RelayCommand SearchPerson { get; set; }
        public RelayCommand SendMail { get; set; }
        public RelayCommand Refresh { get; set; }
        public RelayCommand Edit { get; set; }

        /// <summary>
        /// Gets the NewPerson.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>

        private void getcommmbers()
        {
            committeemembers = _ds.getCommMembers(selectedJob.id);
        }
        //private async void deletaneObject(object obj)
        //{
        //    try
        //    {
        //        // await _ds.DeleteObj(obj);
        //        // return "OK";
        //    }

        //    catch (Exception e)
        //    {
        //        // return e.Message;
        //    }

        //}
        //private async void saveallpersons()
        //{
        //    // await _ds.SavePerson(Persons);
        //}
        private  void saveanObject()
        {
            // await _ds.SavePerson(obj);
        }

        //private void getnewperson()
        //{

        //    selectedPerson = new Models.Person();
        //    Persons.Add(selectedPerson);
        //}
        private void newPerson()
        {
            selectedPerson = new Person();
            Messenger.Default.Send<persontoeditmessage>(new persontoeditmessage
            {
                person = selectedPerson,
                sendingWindow = myguid,
                isnew = true
            });
        }
        private async void addcommem()
        {
            try
            {
                await _ds.SavePerson(selectedPerson);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            jobCommitteeMember jcm = new jobCommitteeMember
            {
                Jobid = selectedJob.id,
                Personid = selectedPerson.id,
                
            };
            selectedCM = jcm;
            addtocommmembers();
            _ds.SaveComMem(jcm);

        }

        private void addtocommmembers()
        {
            if (committeemembers == null)
            {
                committeemembers = new ObservableCollection<jobCommitteeMember>();
            }
            committeemembers.Add(selectedCM);
        }
        void ReceiveSelectedJob()
        {
            if (isjobregistered == false)
            //if (selectedJob != null)
            {
                Messenger.Default.Register<JobMessage>(this, (Jobm) => {
                    this.selectedJob = Jobm.jobm;
                });
                isjobregistered = true;
            }
        }
        private void deleteCM()
        {
           _ds.DeleteComMem(selectedCM);
            committeemembers.Remove(selectedCM);
        }
        private async void searchforaperson()
        {
            Persons = await _ds.FindPerson(searchtext);
        }

        private async void findperson()
        {
            try
            {
                Tuple<ObservableCollection<Person>, Person> mytuple =
                    await Repository.Utilities.findaperson(Persons, selectedPerson, searchtext, _ds);
                Persons = mytuple.Item1;
                selectedPerson = mytuple.Item2;

                if (selectedPerson == null && _selectedCM != null)
                {
                    selectedPerson = _selectedCM.person;
                }
            }
            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }
        }

        private void sendemailtocommittee()
        {
            if (sellettercombo.mergetype == "חברי ועדה")
            {
                sendemailtoallcommittee();
            }
            else if (sellettercombo.mergetype == "חבר בודד")
            {
                sendemailtoonecommittee();}
        
    }
    
        private void sendemailtoallcommittee()
        {
            ObservableCollection<string> emails = new ObservableCollection<string>();
            string mybody;
            string mysubject;
            ObservableCollection<filemessage> myattachfiles = new ObservableCollection<filemessage>();
            mybody = retrieveBody(sellettercombo.id, selectedJob);
            try
            { 
          
            foreach (var cm in committeemembers)
            {
                if (String.IsNullOrEmpty(cm.person.email) == false)
                {
                    emails.Add(cm.person.email);
                }
            }
                foreach (var applicant in selectedJob.applicants)
                {
                    foreach (var ar in applicant.apprequirements.Where(ar=>ar.jobrequirement.sendtocommittee = true))
                    {
                        if (ar.jobrequirement.sendtocommittee)
                        {
                            filemessage fm = new filemessage
                            {
                                filename =
                                    applicant.person.lastname + "_" + ar.jobrequirement.requirement.RequirementName,
                                ext = ar.ext,
                                doccontent = ar.document
                            };
                            myattachfiles.Add(fm);
                        }
                        foreach (var jd in selectedJob.jobdocs.ToList().Where(jd => jd.sendtocommittee == true))
                        {
                            filemessage fm;
                            if (jd.universaldoc == null)
                            {
                                fm = new filemessage
                                {
                                    filename = jd.DocName,
                                    ext = jd.ext,
                                    doccontent = jd.document
                                };
                            }
                            else
                            {
                                fm = new filemessage
                                {
                                    filename = jd.universaldoc.DocName,
                                    ext = jd.universaldoc.ext,
                                    doccontent = jd.universaldoc.document
                                };

                            }
                            myattachfiles.Add(fm);
                        }
                        foreach (var rev in applicant.reviewers.Where(r => r.datereceived != null && r.Statusid == 3))
                        {
                            filemessage fm = new filemessage
                            {
                                filename = rev.person.lastname + "_" + applicant.person.lastname,
                                ext = rev.ext,
                                doccontent = rev.document

                            };
                        }
                    }
                }
                mysubject = selectedJob.jobfullname;
            Outlookrepos.CreateOutlookMail(emails, mybody, mysubject, myattachfiles, true);
            }
            catch (Exception ex)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });
            }
        }
        private void sendemailtoonecommittee()
        {
            ObservableCollection<string> emails = new ObservableCollection<string>();
            string mybody;
            string mysubject;
            ObservableCollection<filemessage> myattachfiles = new ObservableCollection<filemessage>();
            mybody = retrieveBody(sellettercombo.id);
            try
            {

            
                        emails.Add(selectedCM.person.email);
                    
              
              
                      
                mysubject = selectedJob.jobfullname;
                Outlookrepos.CreateOutlookMail(emails, mybody, mysubject, myattachfiles, true);
            }
            catch (Exception ex)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });
            }
        }
        private string retrieveBody(long letterid, Job job)
        {
            //string lang ="Hebrew";
           // string letter = _ds.GetLetter(messagetype, lang, "חברי ועדה")
            //;
            string letter = _ds.GetLetter(letterid);
            CommitteeMergeFields cmf = Utilities.GetCommitteeMergeFieldsbyJob(job);
            return Utilities.mailmerge(cmf, letter);

        }
        private string retrieveBody(long letterid)
        {
            //string lang ="Hebrew";
            // string letter = _ds.GetLetter(messagetype, lang, "חברי ועדה")
            //;
            string letter = _ds.GetLetter(letterid);
            CommitteeMemberMergeFields cmf = Utilities.GetCommitteeMemberrMergeFieldsbyJob(_selectedCM);
            return Utilities.mailmerge(cmf, letter);

        }

        private void refreshevm()
        {
            SimpleIoc.Default.Unregister<CommitteeViewModel>();
            SimpleIoc.Default.Register<CommitteeViewModel>();
        }

        private void getnewperson(personreturnedmessage obj)
        {
            if (!obj.iscancelled && obj.sourceWindow == myguid && obj.isnew==true)
            {
                selectedPerson = obj.personedit;
                
                addcommem();
            }
            else if (obj.iscancelled && obj.sourceWindow == myguid && selectedCM != null)
            {
                selectedPerson = selectedCM.person;
            }
        }

        private void editPerson()
        {
            if (selectedPerson != null)
            {
                Messenger.Default.Send<persontoeditmessage>(new persontoeditmessage
                {
                    person = selectedPerson,
                    sendingWindow = myguid,
                    isnew = false
                });
            }
        }
        /// <summary>
        /// Initializes a new instance of the CommitteeViewModel class.
        /// </summary>
        public CommitteeViewModel(DataService ds)
        {
            _ds = ds;
            myguid = Guid.NewGuid();
            Messenger.Default.Register<personreturnedmessage>(this, getnewperson);
            AddComMem = new RelayCommand(addcommem);  // add applicant
            NewObject = new RelayCommand(newPerson);
            SearchPerson = new RelayCommand(findperson);
            Refresh = new RelayCommand(refreshevm);
           DeleteCM = new RelayCommand (deleteCM);
            Edit = new RelayCommand(editPerson);
            SendMail = new RelayCommand(sendemailtocommittee);
           // Persons = _ds.GetAllPersons();
            departments = _ds.GetAllDepartments();
            ReceiveSelectedJob();
            lettercombos = _ds.getlettercombobyVMtype("חברי ועדה");

          }
     
    }
    
}