using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Messages;
using JobsII.Models;
using JobsII.Repository;
using JobsII.Views;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class jobViewModel : ViewModelBase
    {
        private DataService _ds;
        //public ObservableCollection<KeyValuePair<int, string>> stagecollection { get; set; }
        public const string stagecollectionPropertyName = "stagecollection";
        private ObservableCollection<KeyValuePair<int,string>> _stagecollection { get; set; }
        public ObservableCollection<KeyValuePair<int,string>> stagecollection
        {
            get
            {
                return _stagecollection;
            }

            set
            {
                if (_stagecollection == value)
                {
                    return;
                }

                _stagecollection = value;
                RaisePropertyChanged(stagecollectionPropertyName);
            }
        }
        public const string stagefilterPropertyName = "stagefilter";
        private ObservableCollection<KeyValuePair<int, string>> _stagefilter { get; set; }
        public ObservableCollection<KeyValuePair<int, string>> stagefilter
        {
            get
            {
                return _stagefilter;
            }

            set
            {
                if (_stagefilter == value)
                {
                    return;
                }

                _stagecollection = value;
                RaisePropertyChanged(stagefilterPropertyName);
            }
        }
        public const string stageselectionPropertyName = "stageselection";

        private int _stageselection = 3;

        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int stageselection
        {
            get
            {
                return _stageselection;
            }

            set
            {
                if (_stageselection == value)
                {
                    return;
                }

                _stageselection = value;
                RaisePropertyChanged(stageselectionPropertyName);

                Filterjobs();
            }
        }

        private void Filterjobs()
        {
            jobsc = _ds.jobsbyFilter(stageselection);
        }

        /// <summary>
        /// Initializes a new instance of the jobViewModel class.
        /// </summary>

        /// <summary>
        /// The <see cref="jobsc" /> property's name.
        /// </summary>
        ///
        public const string jobscPropertyName = "jobsc";
        /// <summary>
        /// The <see cref="requirements" /> property's name.
        /// </summary>
        public const string requirementsPropertyName = "requirements";

        private ObservableCollection<Requirement> _requirements ;

        /// <summary>
        /// Sets and gets the requirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Requirement> requirements
        {
            get
            {
                return _requirements;
            }

            set
            {
                if (_requirements == value)
                {
                    return;
                }

                _requirements = value;
                RaisePropertyChanged(requirementsPropertyName);
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


        private ObservableCollection<Job> _jobsc;

        /// <summary>
        /// Sets and gets the jobsc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Job> jobsc
        {
            get { return _jobsc; }

            set
            {
                if (_jobsc == value)
                {
                    return;
                }

                _jobsc = value;
                if (selectedJob == null && _jobsc.Count > 0)
                {
                    selectedJob = _jobsc[0];
                }
                RaisePropertyChanged(jobscPropertyName);
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
               
                RaisePropertyChanged(PersonsPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="selectedJob" /> property's name.
        /// </summary>
        public const string selectedJobPropertyName = "selectedJob";

        private Job _selectedJob = null ;

        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Job selectedJob
        {
            get
            {
                return _selectedJob;
            }

            set
            {
                if (_selectedJob == value)
                {
                    return;
                }

                _selectedJob = value;
                RaisePropertyChanged(selectedJobPropertyName);

                if (_selectedJob != null)
                {
                    jrs = _selectedJob.jobRequirements;
                }
                else
                {
                    jrs = new ObservableCollection<JobRequirement>();}
                SendSelectedJob();
            }
        }

        /// <summary>
            /// The <see cref="searchtext" /> property's name.
            /// </summary>
        public const string searchtextPropertyName = "searchtext";

        private string _searchtext  ;

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
                Set(searchtextPropertyName, ref _searchtext, value);
            }
        }
        
        /// <summary>
        /// The <see cref="applicantshellviewmodel" /> property's name.
        /// </summary>
        public const string applicantshellviewmodelPropertyName = "applicantshellviewmodel";

        private ApplicantShellViewModel _applicantshellviewmodel;

        /// <summary>
        /// Sets and gets the applicantshellviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ApplicantShellViewModel applicantshellviewmodel
        {
            get
            {
                return _applicantshellviewmodel;
            }

            set
            {
                if (_applicantshellviewmodel == value)
                {
                    return;
                }

                _applicantshellviewmodel = value;
                RaisePropertyChanged(applicantshellviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="jrs" /> property's name.
        /// </summary>
        public const string jrsPropertyName = "jrs";

        private ObservableCollection<JobRequirement> _jrs ;

        /// <summary>
        /// Sets and gets the jrs property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<JobRequirement> jrs
        {
            get
            {
                return _jrs;
            }

            set
            {
                if (_jrs == value)
                {
                    return;
                }

                _jrs = value;
                RaisePropertyChanged(jrsPropertyName);
                if (_jrs != null && _jrs.Count > 0)
                {
                    selectedjr = _jrs[0];
                }
                else { selectedjr = null; }
            }
        }
        ///// <summary>
        //    /// The <see cref="jrs" /> property's name.
        //    /// </summary>
        //public const string jrsPropertyName = "jrs";

        //private ObservableCollection<JobRequirement> _jrs;

        ///// <summary>
        ///// Sets and gets the jrs property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public ObservableCollection<JobRequirement> jrs
        //{
        //    get
        //    {
        //        return _jrs;
        //    }
        //    set
        //    {
        //        Set(jrsPropertyName, ref _jrs, value);
        //        if (_jrs != null && _jrs.Count > 0)
        //       {
        //            selectedjr = _jrs[0];
        //            }
        //       else { selectedjr = null; }
        //    }
        //}

        /// <summary>
            /// The <see cref="selectedjr" /> property's name.
            /// </summary>
        public const string selectedjrPropertyName = "selectedjr";

        private JobRequirement _selectedjr; 

        /// <summary>
        /// Sets and gets the selectedjr property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public JobRequirement selectedjr
        {
            get
            {
                return _selectedjr;
            }
            set
            {
               
                Set(selectedjrPropertyName, ref _selectedjr, value);
                Savejr.RaiseCanExecuteChanged();
                Deljr.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// The <see cref="committeviewmodel" /> property's name.
        /// </summary>
        public const string committeviewmodelPropertyName = "committeviewmodel";

        private CommitteeViewModel _committeeviewmodel;

        /// <summary>
        /// Sets and gets the committeviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CommitteeViewModel committeviewmodel
        {
            get
            {
                return _committeeviewmodel;
            }

            set
            {
                if (_committeeviewmodel == value)
                {
                    return;
                }

                _committeeviewmodel = value;
                RaisePropertyChanged(committeviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="jobdocviewmodel" /> property's name.
        /// </summary>
        public const string jobdocviewmodelPropertyName = "jobdocviewmodel";

        private JobDocViewModel _jobdocviewmodel ;

        /// <summary>
        /// Sets and gets the jobdocviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public JobDocViewModel jobdocviewmodel
        {
            get
            {
                return _jobdocviewmodel;
            }

            set
            {
                if (_jobdocviewmodel == value)
                {
                    return;
                }

                _jobdocviewmodel = value;
                RaisePropertyChanged(jobdocviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="EntryView" /> property's name.
        /// </summary>
        public const string EntryViewPropertyName = "EntryView";

        private object _EntryView ;

        /// <summary>
        /// Sets and gets the EntryView property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object EntryView
        {
            get
            {
                return _EntryView;
            }

            set
            {
                if (_EntryView == value)
                {
                    return;
                }

                _EntryView = value;
                RaisePropertyChanged(EntryViewPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="caneditjr" /> property's name.
        /// </summary>
        public const string caneditjrPropertyName = "caneditjr";

        private bool _caneditjr = false;

        /// <summary>
        /// Sets and gets the caneditjr property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool caneditjr
        {
            get
            {
                return _caneditjr;
            }

            set
            {
                if (_caneditjr == value)
                {
                    return;
                }

                _caneditjr = value;
                RaisePropertyChanged(() => caneditjr);
            }
        }
        public RelayCommand NewJob { get; private set; }
        public RelayCommand SaveJob { get; private set; }
        public RelayCommand SearchJob { get; private set; }
       public RelayCommand Newjr { get; private set; }
        public RelayCommand ToggleEntry { get; private set; }
        public RelayCommand Refresh { get; private set; }

        private RelayCommand _Deljr;

        /// <summary>
        /// Gets the Deljr.
        /// </summary>
        public RelayCommand Deljr
        {
            get
            {
                return _Deljr ?? (_Deljr = new RelayCommand(
                    ExecuteDeljr,
                    CanExecuteDeljr));
            }
        }

        private void ExecuteDeljr()
        {
            _ds.Deljobrequirement(selectedjr);
            jrs.Remove(selectedjr);
        }

        private bool CanExecuteDeljr()
        {
            caneditjr = ( _selectedjr != null);
            return (_selectedjr != null);

        }
        private RelayCommand _Savejr;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand Savejr
        {
            get
            {
                return _Savejr ?? (_Savejr = new RelayCommand(
                    savejr,
                    CanExecuteDeljr));
            }
        }

        private void savejr()
        {
           
            _ds.Savejr(jrs);
        }

       
        public jobViewModel(DataService ds)
        {
            ViewModelLocator vml = new ViewModelLocator(); 
            _ds = ds;
            NewJob = new RelayCommand(getnewjob);
            SaveJob = new RelayCommand(savejob);
            SearchJob = new RelayCommand (searchforajob);
            Newjr = new RelayCommand(addRequirement);
            ToggleEntry = new RelayCommand(() => IsVisible = !IsVisible);
            requirements = _ds.getAllRequirements();
            stagecollection = new ObservableCollection<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0,"לא פעיל"),
                new KeyValuePair<int, string>(1,"שלב I"),
                new KeyValuePair<int, string>(2,"שלב II")
            };
            stagefilter = new ObservableCollection<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0,"כל הפעילים"),
                new KeyValuePair<int, string>(1,"שלב I"),
                new KeyValuePair<int, string>(2,"שלב II"),
                new KeyValuePair<int, string>(3, "הכל")

            };
            //applicantshellviewmodel = new ApplicantShellViewModel(_ds);
            //committeviewmodel = new CommitteeViewModel(_ds);
            //jobdocviewmodel = new JobDocViewModel(_ds);
            applicantshellviewmodel = vml.ApplicantShellViewModel;
            committeviewmodel = vml.CommitteeViewModel;
            jobdocviewmodel = vml.jobdocviewmodel;


            jobsc = ds.GetAllJobs();
            departments = ds.GetAllDepartments();
            Persons = ds.GetAllPersons();
            Refresh = new RelayCommand(refreshVM);
            constructMenu();
        //    EntryView = new JobState1Entry();
        }

        private void refreshVM()
        {
            SimpleIoc.Default.Unregister<jobViewModel>();
            SimpleIoc.Default.Register<jobViewModel>();
        }

        private void addRequirement()
        {
            if (selectedJob != null)
            {
                if (selectedJob.jobRequirements == null)
                {
                    selectedJob.jobRequirements = new ObservableCollection<JobRequirement>();
                }
                if (selectedJob.id == 0)
                {
                    savejob();}
                JobRequirement jr = new JobRequirement
                {
                    Jobid = selectedJob.id,
                    deadline = DateTime.Today.AddMonths(1),
                    sendtocommittee = false,
                    sendtoreviewer = false
                };
            //selectedJob.jobRequirements.Add(jr); 
                jrs.Add(jr);
            }
            }
          
        

        private void searchforajob()
        {
            try
            {
                if (searchtext.Length > 2)
                {
                    var myjob = _ds.FindJob(searchtext);
                    jobsc = myjob;

                }
                else if (searchtext == String.Empty)
                {
                    jobsc = _ds.GetAllJobs();
                }
            }
            catch (Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        private async void savejob()
        {
            //assign id to requirements
            //foreach (JobRequirement jr in selectedJob.jobRequirements)
            //{
            //    jr.Jobid = selectedJob.id;}
            try
            {
                selectedJob = await _ds.saveJob(selectedJob);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void getnewjob()
        {
           selectedJob = new Models.Job();
            setboolstofalse(selectedJob);
            jobsc.Add(selectedJob);
        }

        private void setboolstofalse(Job myjob)
        {
            var mytype = myjob.GetType();
            foreach (PropertyInfo p in mytype.GetProperties())
            {
                if (p.PropertyType == typeof (bool?))
                {
                    p.SetValue(myjob,false) ;
                }
            }
        }
        void SendSelectedJob()
        {
            if (selectedJob != null)
            {
                Messenger.Default.Send(new JobMessage()
                {
                    jobm = selectedJob
                });
            }
        }

        public const string selectedmenuitemPropertyName = "selectedmenuitem";

        private MenuMessage _selectedmenuitem;

        /// <summary>
        /// Sets and gets the menuitem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MenuMessage selectedmenuitem
        {
            get
            {
                return _selectedmenuitem;
            }

            set
            {
                if (_selectedmenuitem == value)
                {
                    return;
                }

                _selectedmenuitem = value;
                RaisePropertyChanged(selectedmenuitemPropertyName);
                switchviewmodel();
            }
        }

        /// <summary>
        /// The <see cref="MenuMessages" /> property's name.
        /// </summary>
        public const string MenuMessagesPropertyName = "MenuMessages";

        private ObservableCollection<MenuMessage> _menumessages;

        /// <summary>
        /// Sets and gets the MenuMessages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MenuMessage> MenuMessages
        {
            get
            {
                return _menumessages;
            }

            set
            {
                if (_menumessages == value)
                {
                    return;
                }

                _menumessages = value;
                if (selectedmenuitem == null)
                {
                    if (_menumessages.Count > 0)
                    {
                        selectedmenuitem = _menumessages[0];
                    }
                }
                RaisePropertyChanged(MenuMessagesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedVM" /> property's name.
        /// </summary>
        public const string selectedVMPropertyName = "selectedVM";

        private Object __selectedVM;

        /// <summary>
        /// Sets and gets the selectedVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Object selectedVM
        {
            get
            {
                return __selectedVM;
            }

            set
            {
                if (__selectedVM == value)
                {
                    return;
                }

                __selectedVM = value;
                
                RaisePropertyChanged(selectedVMPropertyName);

            }
        }
        /// <summary>
        /// The <see cref="IsVisible" /> property's name.
        /// </summary>
        public const string IsVisiblePropertyName = "IsVisible";

        private bool _isVisible = true;

        /// <summary>
        /// Sets and gets the IsVisible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }

            set
            {
                if (_isVisible == value)
                {
                    return;
                }

                _isVisible = value;
                entrytext = value ? "שלב 2" : "שלב 1";
                Messenger.Default.Send<string>(entrytext);
                RaisePropertyChanged(IsVisiblePropertyName);
               
            }
        }
        /// <summary>
        /// The <see cref="entrytext" /> property's name.
        /// </summary>
        public const string entrytextPropertyName = "entrytext";

        private string _entrytext = "שלב 2";

        /// <summary>
        /// Sets and gets the entrytext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string entrytext
        {
            get
            {
                return _entrytext;
            }

            set
            {
                if (_entrytext == value)
                {
                    return;
                }

                _entrytext = value;
                RaisePropertyChanged(entrytextPropertyName);
            }
        }
        private void switchviewmodel()
        {
            switch (selectedmenuitem.tabindex)
            {
                case 0:

                    selectedVM = applicantshellviewmodel;
                    break;

                case 1:
                    selectedVM = committeviewmodel;
                    break;
                case 2:
                    selectedVM = jobdocviewmodel;
                    break;
                case 3:
                    selectedVM = this;
                    break;

            }
        }
        private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מועמדים",
                isactive = true,
                newWindow = false,
                viewModelName = "ApplicantShellViewModel",
                tabindex = 0
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "ועדה",
                isactive = true,
                newWindow = false,
                viewModelName = "CommitteeViewModel",
                tabindex = 1
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מסמכים",
                isactive = true,
                newWindow = false,
                viewModelName = "JobDocViewModel",
                tabindex = 2
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "דרישות",
                isactive = true,
                newWindow = false,
                viewModelName = "jobViewModel",
                tabindex = 3
            });
        }
    }
}