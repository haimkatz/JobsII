using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
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

            personviewmodel = new PersonViewModel(myds);
            departmentviewmodel = new DepartmentViewModel(myds);
            requirementviewmodel = new RequirementViewModel(myds);
            jobviewmodel = new jobViewModel(myds);
            constructMenu();

        }

        private void constructMenu()
        {
            MenuMessages = new ObservableCollection<MenuMessage>();
            MenuMessages.Add(new MenuMessage
            {
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
                menutext = "משרות",
                isactive = true,
                newWindow = false,
                viewModelName = "jobViewModel"
            });
           
            // MenuMessages.Add(new MenuMessage
            //{
            //    menutext = "משרות",
            //    isactive = true,
            //    newWindow = false,
            //    viewModelName = "JobsViewModel"
            //});

        }
    }
} 