using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Messages;
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
    public class ApplicantShellViewModel : ViewModelBase
    {
        private DataService _ds;
        private bool isjobregistered = false;

       
      

        /// <summary>
        /// The <see cref="selectedJob" /> property's name.
        /// </summary>
        public const string selectedJobPropertyName = "selectedJob";

        private  Job _selectedJob;

        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public  Job selectedJob
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
                 filterapplicant();
            }
        }
        /// <summary>
        /// The <see cref="applicants" /> property's name.
        /// </summary>
        public const string applicantsPropertyName = "applicants";

        private ObservableCollection<Applicant> _applicants ;

        /// <summary>
        /// Sets and gets the applicants property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Applicant> applicants
        {
            get
            {
                return _applicants;
            }

            set
            {
                if (_applicants == value)
                {
                    return;
                }

                _applicants = value;
                RaisePropertyChanged(applicantsPropertyName);
                if (selectedApplicant == null)
                {
                    selectedApplicant = applicants.Count > 0 ?applicants[0]:null;
                }


            }
        }
        /// <summary>
        /// The <see cref="selectedApplicant" /> property's name.
        /// </summary>
        public const string selectedApplicantPropertyName = "selectedApplicant";

        private Applicant _selectedApplicant ;

        /// <summary>
        /// Sets and gets the selectedApplicant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Applicant selectedApplicant
        {
            get
            {
                return _selectedApplicant;
            }

            set
            {
                if (_selectedApplicant == value)
                {   
                    return;
                }

                _selectedApplicant = value;
                RaisePropertyChanged(selectedApplicantPropertyName);
                SendSelectedApplicant();
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
                RaisePropertyChanged(MenuMessagesPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="lettercombos" /> property's name.
        /// </summary>
        public const string lettercombosPropertyName = "lettercombos";

        private ObservableCollection<MergeDoc> _lettercombos;

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

        /// <summary>
        /// The <see cref="selectedVM" /> property's name.
        /// </summary>
        public const string selectedVMPropertyName = "selectedVM";

        private Object __selectedVM ;

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
        /// Sets and gets the MenuMessages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
    
        /// <summary>
        /// The <see cref="Addapplicantviewmodel" /> property's name.
        /// </summary>
        public const string addapplicantviewmodelPropertyName = "Addapplicantviewmodel";

        private AddApplicantViewModel _addapplicantviewmodel;


        /// <summary>
        /// Sets and gets the personviewmode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AddApplicantViewModel addapplicantviewmodel
        {
            get
            {
                return _addapplicantviewmodel;
            }

            set
            {
                if (_addapplicantviewmodel == value)
                {
                    return;
                }

                _addapplicantviewmodel = value;
                RaisePropertyChanged(addapplicantviewmodelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="reviewertviewmodel" /> property's name.
        /// </summary>
        public const string reviewertviewmodelPropertyName = "reviewertviewmodel";

        private ReviewerViewModel _reviewertviewmodel;


        /// <summary>
        /// Sets and gets the personviewmode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ReviewerViewModel reviewertviewmodel
        {
            get
            {
                return _reviewertviewmodel;
            }

            set
            {
                if (_reviewertviewmodel == value)
                {
                    return;
                }

                _reviewertviewmodel = value;
                RaisePropertyChanged(reviewertviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="addreviewerviewmodel" /> property's name.
        /// </summary>
        public const string addreviewerviewmodelPropertyName = "addreviewerviewmodel";

        private AddReviewerViewModel _addreviewerviewmodel ;

        /// <summary>
        /// Sets and gets the addreviewerviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AddReviewerViewModel addreviewerviewmodel
        {
            get
            {
                return _addreviewerviewmodel;
            }

            set
            {
                if (_addreviewerviewmodel == value)
                {
                    return;
                }

                _addreviewerviewmodel = value;
                RaisePropertyChanged(addreviewerviewmodelPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="DocumentViewModel" /> property's name.
            /// </summary>
        public const string DocumentViewModelPropertyName = "DocumentViewModel";

        private Object _DocumentViewModel;
        private bool isnewappregistered;


        /// <summary>
        /// Sets and gets the DocumentViewModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Object documentviewmodel
        {
            get
            {
                return _DocumentViewModel;
            }

            set
            {
                if (_DocumentViewModel == value)
                {
                    return;
                }

                _DocumentViewModel = value;
                RaisePropertyChanged(DocumentViewModelPropertyName);
            }
        }       
        private void switchviewmodel()
        {
            switch (selectedmenuitem.tabindex)
            {
                case 0:

                    selectedVM = addapplicantviewmodel;
                    break;
              
                case 1:
                    selectedVM = reviewertviewmodel;
                    break;
                 case 2:
                    selectedVM = documentviewmodel;
                    break;
            }
        }
        private RelayCommand _SaveApplicant;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SaveApplicant
        {
            get
            {
                return _SaveApplicant
                       ?? (_SaveApplicant = new RelayCommand(saveapplicants, () => applicants.Count > 0));
            }
        }
        private RelayCommand _SendMail;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand SendMail
        {
            get
            {
                return _SendMail ?? (_SendMail = new RelayCommand(
                    Sendemailtoapplicant,
                    CanExecuteSendMail));
            }
        }

        private void Sendemailtoapplicant()
        {
            ObservableCollection<string> emails = new ObservableCollection<string>();
            string mybody;
            string mysubject;
            ObservableCollection<filemessage> myattachfiles = new ObservableCollection<filemessage>();
            try
            {
               
                if (sellettercombo != null)
                {

                    mybody = retrieveBody(sellettercombo.htmltext, selectedApplicant);
                    string emailtype = _ds.GeMessageType(sellettercombo.id);


                    if (String.IsNullOrEmpty(selectedApplicant.person.email) == false)
                    {
                        emails.Add(selectedApplicant.person.email);
                    }

                
                mysubject = getsubject(sellettercombo.language.language, _selectedApplicant.job.jobfullname);
                Outlookrepos.CreateOutlookMail(emails, mybody, mysubject, myattachfiles, true);
                    }  
            
                else { MessageBox.Show("תבחרי סוג מכתב"); }
        }
            catch (Exception ex)
            {
                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });

            }
        }

        private string retrieveBody(string body, Applicant app)
        {
            //string lang = rev.person.country == "IL" ? "Hebrew" : "English";
            //string letter = _ds.GetLetter( messagetype,  lang, "רפרנט")
            //;
            //string letter = _ds.GetLetter(letterid);

            applicantMergeFields amf = Utilities.GetapplicantMergeFieldsbyApplicant(app);
            return Utilities.mailmerge(amf, body);
        }
        private string getsubject(string lng, string addedtext)
        {

            if (lng == "Eng")
            {
                return "Application for the position " + addedtext;
            }
            else { return "פניה למשרה " + addedtext; }


        }

        private bool CanExecuteSendMail()
        {
            if (_sellettercombo !=null)
            { return true;}
            else { return false; }
        }
        void saveapplicants()
        {
            foreach (Applicant a in applicants)
            {
                _ds.SaveApplicant(a);
            }
        }
        public ApplicantShellViewModel(DataService ds)
        {
            _ds = ds;
            ReceiveSelectedJob();
            ReceiveNewApplicant();
            ViewModelLocator vml = new ViewModelLocator();
            addapplicantviewmodel = vml.AddApplicantViewModel;
            reviewertviewmodel = vml.ReviewerViewModel;
            documentviewmodel = vml.DocumentViewModel;
            addreviewerviewmodel = vml.AddReviewerViewModel;
            //addapplicantviewmodel = new AddApplicantViewModel(ds);
            //reviewertviewmodel = new ReviewerViewModel(ds);
            //documentviewmodel = new DocumentViewModel(ds);
            //addreviewerviewmodel = new AddReviewerViewModel(ds);
            ReceiveState();
            constructMenu();
            lettercombos = _ds.getlettercombobyVMtype("מועמד");
            if (selectedVM == null)
            {
                selectedVM = addapplicantviewmodel;
                selectedmenuitem = MenuMessages[0];
            }
        }
       
        private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
            {
                menutext = "הוסף/הסר",
                isactive = true,
                newWindow = false,
                viewModelName = "AddApplicantViewModel",
                tabindex=0
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "רפרנטים",
                isactive = true,
                newWindow = false,
                viewModelName = "AddReviewer",
                tabindex=1
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מסמכים",
                isactive = true,
                newWindow = false,
                viewModelName = "DocumentViewModel",
                tabindex=2
            });
            //MenuMessages.Add(new MenuMessage
            //{
            //    menutext = "משרות",
            //    isactive = true,
            //    newWindow = false,
            //    viewModelName = "jobViewModel"
            //});
        }
            void SendSelectedApplicant()
        {
            if (selectedApplicant != null)
            {
                Messenger.Default.Send(new ApplicantMessage()
                {
                    applicantm = selectedApplicant
                });
            }
        }
        void ReceiveSelectedJob()
        {
            if (isjobregistered == false)
            {
                Messenger.Default.Register<JobMessage>(this, (JobM) => {
                    this.selectedJob = JobM.jobm;
                });
            }
        }

        void ReceiveState()
        {
            Messenger.Default.Register<string>(this, filterstage);
        }

        private void filterstage(string obj)
        {
            if (obj == "שלב 1") // stage 2
            {
                filterapps(true);
            }
            else
            {
                filterapps(false);
            }

        }

        private void filterapps(bool v)
        {

            applicants = _ds.getapplicantsbyjobid(selectedJob.id, v);
        }

        void ReceiveNewApplicant()
        {
            if (isnewappregistered == false)
            {
                Messenger.Default.Register<newApplicantMessage>(this,addnewapplicant);
                isnewappregistered = true;
            }
        }

        private void addnewapplicant(newApplicantMessage nam)
        {
            bool newapp = true;
            Applicant myappl = nam.newapplicant;
            if (!nam.isdeleted)
            {
                foreach (Applicant a in applicants)
                {
                    if (myappl == a)
                    {
                        newapp = false;
                        break;
                    }
                }
                if (newapp == true)
                {
                    applicants.Add(myappl);
                    selectedApplicant = myappl;
                }
            }
            else if (nam.isdeleted)
            {
                applicants.Remove(nam.newapplicant);
            }
        }

        private  void filterapplicant()
        {
            if (selectedJob != null)
            {
                 applicants =  _ds.getapplicantsbyjobid(selectedJob.id); 
            }
          
        }
     
    }
}