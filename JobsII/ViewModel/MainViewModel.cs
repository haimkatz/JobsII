using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Messages;
using JobsII.Repository;
using JobsII.Views;
namespace JobsII.ViewModel
{
    /// <summary>
        /// The <see cref="menuitem" /> property's name.
        /// </summary>
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
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
        /// The <see cref="MenuMessages" /> property's name.
        /// </summary>
        public const string MenuMessagesPropertyName = "MenuMessages";

        private ObservableCollection<MenuMessage> _menumessages ;

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
        /// The <see cref="personviewmodel" /> property's name.
        /// </summary>
        public const string personviewmodePropertyName = "personviewmodel";

        private PersonViewModel _personviewmodel;
        

        /// <summary>
        /// Sets and gets the personviewmode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public PersonViewModel personviewmodel
        {
            get
            {
                return _personviewmodel;
            }

            set
            {
                if (_personviewmodel == value)
                {
                    return;
                }

                _personviewmodel = value;
                RaisePropertyChanged(personviewmodePropertyName);
            }
        }
        /// <summary>
            /// The <see cref="departmentviewmodel" /> property's name.
            /// </summary>
        public const string departmentviewmodelPropertyName = "departmentviewmodel";

        private DepartmentViewModel _departmentviewmodel ;

        /// <summary>
        /// Sets and gets the departmentviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DepartmentViewModel departmentviewmodel
        {
            get
            {
                return _departmentviewmodel;
            }

            set
            {
                if (_departmentviewmodel == value)
                {
                    return;
                }

                _departmentviewmodel = value;
                RaisePropertyChanged(departmentviewmodelPropertyName);
            }
        }
        /// <summary>
            /// The <see cref="requirementviewmodel" /> property's name.
            /// </summary>
        public const string requirementviewmodelPropertyName = "requirementviewmodel";

        private RequirementViewModel _requirementviewmodel;

        /// <summary>
        /// Sets and gets the requirementviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RequirementViewModel requirementviewmodel
        {
            get
            {
                return _requirementviewmodel;
            }

            set
            {
                if (_requirementviewmodel == value)
                {
                    return;
                }

                _requirementviewmodel = value;
                RaisePropertyChanged(requirementviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="languageviewmodel" /> property's name.
        /// </summary>
        public const string languageviewmodelPropertyName = "languageviewmodel";

        private LanguageViewModel _languageviewmodel;

        /// <summary>
        /// Sets and gets the languageviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LanguageViewModel languageviewmodel
        {
            get
            {
                return _languageviewmodel;
            }

            set
            {
                if (_languageviewmodel == value)
                {
                    return;
                }

                _languageviewmodel = value;
                RaisePropertyChanged(languageviewmodelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="reviewerstatusviewmodel" /> property's name.
        /// </summary>
        public const string reviewerstatusviewmodelPropertyName = "reviewerstatusviewmodel";

        private ReviwerStatusViewModel _reviewerstatusviewmodel;

        /// <summary>
        /// Sets and gets the reviewerstatusviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ReviwerStatusViewModel reviewerstatusviewmodel
        {
            get
            {
                return _reviewerstatusviewmodel;
            }

            set
            {
                if (_reviewerstatusviewmodel == value)
                {
                    return;
                }

                _reviewerstatusviewmodel = value;
                RaisePropertyChanged(reviewerstatusviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="jobviewmodel" /> property's name.
        /// </summary>
        public const string jobviewmodelPropertyName = "jobviewmodel";

        private object _jobviewmodel;

        /// <summary>
        /// Sets and gets the jobviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object jobviewmodel
        {
            get
            {
                return _jobviewmodel;
            }

            set
            {
                if (_jobviewmodel == value)
                {
                    return;
                }

                _jobviewmodel = value;
                RaisePropertyChanged(jobviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="instituteviewmodel" /> property's name.
        /// </summary>
        public const string instituteviewmodelPropertyName = "instituteviewmodel";

        private object _instituteviewmodel;

        /// <summary>
        /// Sets and gets the instituteviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object instituteviewmodel
        {
            get
            {
                return _instituteviewmodel;
            }

            set
            {
                if (_instituteviewmodel == value)
                {
                    return;
                }

                _instituteviewmodel = value;
                RaisePropertyChanged(instituteviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="universaldocviewmodel" /> property's name.
        /// </summary>
        public const string universaldocviewmodelPropertyName = "universaldocviewmodel";

        private object _universaldocviewmodel;

        /// <summary>
        /// Sets and gets the universaldocviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object universaldocviewmodel
        {
            get
            {
                return _universaldocviewmodel;
            }

            set
            {
                if (_universaldocviewmodel == value)
                {
                    return;
                }

                _universaldocviewmodel = value;
                RaisePropertyChanged(universaldocviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="mergedocviewmodel" /> property's name.
        /// </summary>
        public const string mergedocviewmodelPropertyName = "mergedocviewmodel";

        private Object _mergedocviewmodel;

        /// <summary>
        /// Sets and gets the mergedocviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Object mergedocviewmodel
        {
            get
            {
                return _mergedocviewmodel;
            }

            set
            {
                if (_mergedocviewmodel == value)
                {
                    return;
                }

                _mergedocviewmodel = value;
                RaisePropertyChanged(mergedocviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="reminderviewmodelviewmodel" /> property's name.
        /// </summary>
        public const string reminderviewmodelPropertyName = "reminderviewmodel";

        private object _reminderviewmodel;

        public object reminderviewmodel
        {
            get
            {
                return _reminderviewmodel;
            }

            set
            {
                if (_reminderviewmodel == value)
                {
                    return;
                }

                _reminderviewmodel = value;
                RaisePropertyChanged(reminderviewmodelPropertyName);
            }
        }
        /// The <see cref="mergedoctypeviewmodel" /> property's name.
        /// </summary>
        public const string mergedoctypeviewmodelPropertyName = "mergedoctypeviewmodel";

        private object _mergedoctypeviewmodel;

        public object mergedoctypeviewmodel
        {
            get
            {
                return _mergedoctypeviewmodel;
            }

            set
            {
                if (_mergedoctypeviewmodel == value)
                {
                    return;
                }

                _mergedoctypeviewmodel = value;
                RaisePropertyChanged(mergedoctypeviewmodelPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsVisible" /> property's name.
        /// </summary>
        public const string IsVisiblePropertyName = "IsVisible";

        private bool _IsVisible = false;

        /// <summary>
        /// Sets and gets the IsVisible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return _IsVisible;
            }

            set
            {
                if (_IsVisible == value)
                {
                    return;
                }

                _IsVisible = value;
                RaisePropertyChanged(IsVisiblePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="errblock" /> property's name.
        /// </summary>
        public const string errblockPropertyName = "errblock";

        private string _errblock ;

        /// <summary>
        /// Sets and gets the errblock property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string errblock
        {
            get
            {
                return _errblock;
            }

            set
            {
                if (_errblock == value)
                {
                    return;
                }

                _errblock = value;
                RaisePropertyChanged(errblockPropertyName);
            }
        }
        public RelayCommand ClearErr { get; set; }
        public MainViewModel(DataService myds) 
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            ViewModelLocator vml = new ViewModelLocator();
            personviewmodel =vml.PersonViewModel;
            departmentviewmodel = vml.DepartmentViewModel;
            requirementviewmodel = vml.RequirementViewModel;
            jobviewmodel = vml.jobViewModel;
            reviewerstatusviewmodel = vml.ReviwerStatusViewModel;
            instituteviewmodel = vml.InstituteViewModel;
            universaldocviewmodel = vml.UniversalDocViewModel;
            reminderviewmodel = vml.ReminderViewModel;
            languageviewmodel =vml.LanguageViewModel;
            mergedocviewmodel = vml.MergeDocViewModel;
            mergedoctypeviewmodel = vml.MergeDocTypeViewModel;


            //personviewmodel = new PersonViewModel(myds);
            //departmentviewmodel = new DepartmentViewModel(myds);
            //requirementviewmodel = new RequirementViewModel(myds);
            //jobviewmodel = new jobViewModel(myds);
            //reviewerstatusviewmodel = new ReviwerStatusViewModel(myds);
            //instituteviewmodel = new InstituteViewModel(myds);
            //universaldocviewmodel = new UniversalDocViewModel(myds);
            //reminderviewmodel = new ReminderViewModel(myds);
            //languageviewmodel = new LanguageViewModel(myds);
            //mergedocviewmodel = new MergeDocViewModel(myds);
            //mergedoctypeviewmodel = new MergeDocTypeViewModel(myds);
            Messenger.Default.Register<errormessage>(this, geterrormessage);
            ClearErr = new RelayCommand(() =>
            {
                errblock = string.Empty;
                IsVisible = false;
            });
            constructMenu();

        }

        private void geterrormessage(errormessage obj)
        {
            errblock = obj.errormsg;
            IsVisible = obj.isvisible;
        }

        private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
         
            {
                menutext = "משרות",
                isactive = true,
                newWindow = false,
                viewModelName = "jobViewModel"
            });
             MenuMessages.Add(new MenuMessage {
                menutext = "אנשים",
                isactive = true,
                newWindow = false,
                viewModelName = "PersonViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מחלקות",
                isactive = true,
                newWindow = false,
                viewModelName = "DepartmentViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "דרישות",
                isactive = true,
                newWindow = false,
                viewModelName = "RequirementViewModel"
            });

            MenuMessages.Add(new MenuMessage
            {
                menutext = "סטטוס רפרנט",
                isactive = true,
                newWindow = false,
                viewModelName = "ReviwerStatusViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מכונים",
                isactive = true,
                newWindow = false,
                viewModelName = "InstituteViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מסמכים",
                isactive = true,
                newWindow = false,
                viewModelName = "UniversalDocViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "תזכורות",
                isactive = true,
                newWindow = false,
                viewModelName = "ReminderViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "שפות",
                isactive = true,
                newWindow = false,
                viewModelName = "LanguageViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "מכתבים",
                isactive = true,
                newWindow = false,
                viewModelName = "MergeDocViewModel"
            });
            MenuMessages.Add(new MenuMessage
            {
                menutext = "סוגי מכתבים",
                isactive = true,
                newWindow = false,
                viewModelName = "MergeDocTypeViewModel"
            });
        }
        private void switchviewmodel()
        {
            switch (selectedmenuitem.viewModelName)
            {
                case "PersonViewModel":

                    selectedVM = personviewmodel;
                    break;
                case "DepartmentViewModel":
                    selectedVM = departmentviewmodel;
                    break;
                case "RequirementViewModel":
                    selectedVM = requirementviewmodel;
                    break;
                case "jobViewModel":
                    selectedVM = jobviewmodel;
                    break;
                case "ReviwerStatusViewModel":
                    selectedVM = reviewerstatusviewmodel;
                    break;
                case "InstituteViewModel":
                    selectedVM = instituteviewmodel;
                    break;
                case "UniversalDocViewModel":
                    selectedVM = universaldocviewmodel;
                    break;
                case "ReminderViewModel":
                    selectedVM = reminderviewmodel;
                    break;
                case "LanguageViewModel":
                    selectedVM = languageviewmodel;
                    break;
                case "MergeDocViewModel":
                    selectedVM = mergedocviewmodel;
                    break;
                case "MergeDocTypeViewModel":
                    selectedVM = mergedoctypeviewmodel;
                    break;
            }
        }
    }
} 