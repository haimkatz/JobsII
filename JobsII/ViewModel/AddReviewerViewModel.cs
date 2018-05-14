using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class AddReviewerViewModel : ViewModelBase
    {
        private DataService _ds;
        private bool isjobregistered = false;
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
                if (selectedperson == null)
                {
                    if (Persons.Count>0)
                    { selectedperson = _persons[0];}
                }
                RaisePropertyChanged(PersonsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedperson" /> property's name.
        /// </summary>
        public const string selectedPersonPropertyName = "selectedperson";

        private Models.Person _selectedPerson;
        /// <summary>
        /// Sets and gets the selectedperson property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.Person selectedperson
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
        public ObservableCollection<Department> departments
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
        private bool isselapplicantregistered;
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
            }
        }
        /// <summary>
        /// The <see cref="selectedReviewer" /> property's name.
        /// </summary>
        public const string selectedReviewerPropertyName = "selectedReviewer";

        private Reviewer _selectedReviewer ;

        /// <summary>
        /// Sets and gets the selectedReviewer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Reviewer selectedReviewer
        {
            get
            {
                return _selectedReviewer;
            }

            set
            {
                if (_selectedReviewer == value)
                {
                    return;
                }

                _selectedReviewer = value;
                RaisePropertyChanged(selectedReviewerPropertyName);
            }
        }
        public RelayCommand NewPerson { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SavePerson { get; set; }
        public RelayCommand SearchPerson { get; set; }
        public RelayCommand<Person> changeSelectedPerson { get; set; }
        public RelayCommand<Person> DeletePerson { get; set; }
        /// <summary>
        /// Gets the NewPerson.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>

        private void Sendnr(Reviewer nr)
        {
            if (nr != null)
            {
                Messenger.Default.Send(new newReviewerMessage()
                {
                    newreviewer = nr
                });
            }
        }
        private async void deletePerson(Person obj)
        {
            try
            {
                await _ds.DeletePerson(obj);
                // return "OK";
            }

            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        private void newPerson(Person nperson)
        {
            if (nperson != null)
            {
                selectedperson = nperson;
            }
        }

        private async void searchforaperson()
        {
            Persons = await _ds.FindPerson(searchtext);
        }

        private async void saveallpersons()
        {
            await _ds.SavePerson(Persons);
        }
        private async void saveaperson()
        {
            await _ds.SavePerson(selectedperson);
            AddReviewer();
        }

        private void AddReviewer()
        {
            if (selectedApplicant != null)
            {
                Reviewer nr = new Reviewer
                {
                    Applicantid = selectedApplicant.id,
                    Personid = _selectedPerson.id,
                };           
            _ds.SaveReviewer(nr);
            Sendnr(nr);
            }
        }
    
      
        private void getnewperson()
        {

            selectedperson = new Models.Person();
            Persons.Add(selectedperson);
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
        void ReceiveSelectedApplicant()
        {
            if (isselapplicantregistered == false)
           
            {
                Messenger.Default.Register<ApplicantMessage>(this, findperson);
                isselapplicantregistered = true;
            }
        }

        private void findperson(ApplicantMessage obj)
        {
            selectedApplicant = obj.applicantm;
            foreach (Person p in Persons)
            {
                if (p.id == obj.applicantm.Personid)
                {
                    selectedperson = p;

                    break;
                }
            }
        }

        public AddReviewerViewModel(DataService ds)
        {
            _ds = ds;
            NewPerson = new RelayCommand(saveaperson);
            SavePerson = new RelayCommand(AddReviewer);  // add applicant

            SearchPerson = new RelayCommand(searchforaperson);
            changeSelectedPerson = new RelayCommand<Person>(newPerson);
            DeletePerson = new RelayCommand<Person>(deletePerson);
            Persons = ds.GetAllPersons();
            departments = ds.GetAllDepartments();
            ReceiveSelectedJob();
            ReceiveSelectedApplicant();
        }
    }
}