using System;
using System.Collections.ObjectModel;
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
    public partial class JobsViewModel : ViewModelBase
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
                if (person == null)
                {
                    person = _persons[0];
                }
                RaisePropertyChanged(PersonsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="person" /> property's name.
        /// </summary>
        public const string selectedPersonPropertyName = "selectedPerson";

        private Models.Person selectedPerson;
        /// <summary>
        /// Sets and gets the person property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.Person person
        {
            get
            {
                return selectedPerson;
            }

            set
            {
                if (selectedPerson == value)
                {
                    return;
                }

                selectedPerson = value;
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
        /// <summary>
        /// The <see cref="jobs" /> property's name.
        /// </summary>
        public const string jobsPropertyName = "jobs";

        private ObservableCollection<Job> _jobs;

        /// <summary>
        /// Sets and gets the jobs property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Job> jobs
        {
            get
            {
                return _jobs;
            }

            set
            {
                if (_jobs == value)
                {
                    return;
                }

                _jobs = value;
                RaisePropertyChanged(jobsPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedjob" /> property's name.
        /// </summary>
        public const string selectedjobPropertyName = "selectedjob";

        private Job _selectedjob ;

        /// <summary>
        /// Sets and gets the selectedjob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Job selectedjob
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
                RaisePropertyChanged(selectedjobPropertyName);
                SendSelectedJob();

            }
        }
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


        private async void deleteanObject(object obj)
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
            selectedjob = new Job();
            jobs.Add(selectedjob);
        }

        private async void searchthecollection()
        {
            // Persons = await _ds.FindPerson(searchtext);
        }

        private async void savealljobs()
        {
             await _ds.Savejobs(jobs);
        }
        private async void saveanObject()
        {
            await _ds.Savejob(selectedjob);
        }

        private void getnewjob()
        {

            selectedjob = new Models.Job();
            jobs.Add(selectedjob);
        }

        void SendSelectedJob() 
        {
            if (selectedjob != null)
            {
                Messenger.Default.Send(new JobMessage()
                {
                    jobm = selectedjob
                });
            }
        }

        public JobsViewModel(DataService ds)
        {
            _ds = ds;
            NewObject = new RelayCommand(anewObject);
            //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
            SaveObject = new RelayCommand(saveanObject);
            SearchCollection = new RelayCommand(searchthecollection);

            //  DeleteObject = new RelayCommand<Person>(deleteobject);
               Persons = ds.GetAllPersons();
               departments = ds.GetAllDepartments();
            //jobs = ds.GetAllJobs().Result;

        }
    }
}