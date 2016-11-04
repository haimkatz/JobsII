using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class ApplicantViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the RequirementViewModel class.
        /// </summary>
        private DataService _ds;

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
        /// The <see cref="person" /> property's name.
        /// </summary>
        public const string selectedPersonPropertyName = "selectedPerson";

       
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
 /// <summary>
        /// The <see cref="departments" /> property's name.
        /// </summary>
        /// <summary>
        /// The <see cref="searchtext" /> property's name.
        /// </summary>
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
        /// The <see cref="applicants" /> property's name.
        /// </summary>
        public const string applicantsPropertyName = "applicants";

        private ObservableCollection<Applicant> _applicants;

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
        /// The <see cref="selectedapplicant" /> property's name.
        /// </summary>
        public const string selectedapplicantPropertyName = "selectedapplicant";

        private Applicant __applicant;

        /// <summary>
        /// Sets and gets the selectedapplicant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Applicant selectedapplicant
        {
            get
            {
                return __applicant;
            }

            set
            {
                if (__applicant == value)
                {
                    return;
                }

                __applicant = value;
                RaisePropertyChanged(selectedapplicantPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedJob" /> property's name.
        /// </summary>
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
                RaisePropertyChanged(selectedJobPropertyName);
            }
        }
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand NewObject { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SaveObject { get; set; }
        public RelayCommand SearchCollection { get; set; }
        public RelayCommand<object> ChangeSelectedPerson { get; set; }
        public RelayCommand<object> DeleteObject { get; set; }
        /// <summary>
        /// Gets the NewPerson.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>


        private async void deletaneObject(object obj)
        {
            try
            {
                // await _ds.DeleteObj(obj);
                // return "OK";
            }

            catch (Exception e)
            {
                // return e.Message;
            }

        }

        private async void anewObject()
        {
            //if (newobject != null)
            //{
            //  newobject   = newobject;
            //}
        }

        private async void searchthecollection()
        {
            // Persons = await _ds.FindPerson(searchtext);
        }

        private async void saveallpersons()
        {
            // await _ds.SavePerson(Persons);
        }
        private async void saveanObject()
        {
            // await _ds.SavePerson(obj);
        }

        private void getnewapplicant()
        {
            if (selectedJob != null)
            {
            
            selectedapplicant = new Models.Applicant();
                selectedapplicant.Jobid = selectedJob.id;
            applicants.Add(selectedapplicant);
        }
    }



        public ApplicantViewModel(DataService ds)
        {
            _ds = ds;
            NewObject = new RelayCommand(anewObject);
            //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
            SaveObject = new RelayCommand(saveanObject);
            SearchCollection = new RelayCommand(searchthecollection);
            jobMessage();
            //  DeleteObject = new RelayCommand<Person>(deleteobject);
            //    Persons = ds.GetAllPersons();
            //    departments = ds.GetAllDepartments();
        }

        private async Task<ObservableCollection<Applicant>> getapplicants()
        {
           return await _ds.getapplicantsbyjobid(selectedJob.id);
        }
       private void jobMessage()
        {
           
                Messenger.Default.Register(this, (JobMessage jobm) => {
                    this.selectedJob = jobm.jobm;
                });
            
        }
    }
}