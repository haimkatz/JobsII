using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
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





        /// <summary>
        /// Initializes a new instance of the ApplicantShellViewModel class.
        /// </summary>
      
              /// <summary>
              /// The <see cref="selectedJob" /> property's name.
              /// </summary>
        public const string selectedJobPropertyName = "selectedJob";

        private Job _selectedJob;

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
            /// The <see cref="DocumentViewModel" /> property's name.
            /// </summary>
        public const string DocumentViewModelPropertyName = "DocumentViewModel";

        private Object _DocumentViewModely;

        /// <summary>
        /// Sets and gets the DocumentViewModel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Object documentviewmodel
        {
            get
            {
                return _DocumentViewModely;
            }

            set
            {
                if (_DocumentViewModely == value)
                {
                    return;
                }

                _DocumentViewModely = value;
                RaisePropertyChanged(DocumentViewModelPropertyName);
            }
        }       
        private void switchviewmodel()
        {
            switch (selectedmenuitem.viewModelName)
            {
                case "AddApplicantViewModel":

                    selectedVM = addapplicantviewmodel;
                    break;
                case "DocumentViewModel":
                    selectedVM = documentviewmodel;
                    break;
                case "ReviewerViewModel":
                    selectedVM = reviewertviewmodel;
                    break;
               
            }
        }

        public ApplicantShellViewModel(DataService ds)
        {
            _ds = ds;
            addapplicantviewmodel = new AddApplicantViewModel(ds);
            reviewertviewmodel = new ReviewerViewModel(ds);
            documentviewmodel = new DocumentViewModel(ds);
           
            constructMenu();

        }

        private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
            {
                menutext = "הוסף/הסר",
                isactive = true,
                newWindow = false,
                viewModelName = "AddApplicantViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "רפרנטים",
                isactive = true,
                newWindow = false,
                viewModelName = "ReviewerViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מסמכים",
                isactive = true,
                newWindow = false,
                viewModelName = "DocumentViewModel"
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


      
    }
}