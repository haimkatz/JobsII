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
    public class AddApplicantViewModel : ViewModelBase
    {
        private DataService _ds;
        private bool isjobregistered = false;
        private Guid myguid;
        /// <summary>
        /// The <see cref="selectedapplicant" /> property's name.
        /// </summary>
        public const string selectedapplicantPropertyName = "selectedapplicant";

        private Applicant _selectedapplicant;

        /// <summary>
        /// Sets and gets the selectedapplicant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Applicant selectedapplicant
        {
            get
            {
                return _selectedapplicant;
            }

            set
            {
                if (_selectedapplicant == value)
                {
                    return;
                }

                _selectedapplicant = value;
                RaisePropertyChanged(selectedapplicantPropertyName);
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
                if (selectedperson == null)
                {
                    if (_persons.Count > 0)
                    {
                        selectedperson = _persons[0];
                    }

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
        public RelayCommand NewPerson { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SavePerson { get; set; }
        public RelayCommand SearchPerson { get; set; }
        public RelayCommand<Person> changeSelectedPerson { get; set; }
        public RelayCommand DeletePerson { get; set; }
        public RelayCommand Edit { get; set; }
        /// <summary>
        /// Gets the NewPerson.
        /// </summary>

       


        private  void deletePerson()
            {
            Applicant obj = _selectedapplicant;
            try
            {
                 _ds.DeleteApplicant(obj);
                
                Messenger.Default.Send<newApplicantMessage>(new newApplicantMessage
                {
                    newapplicant = obj,
                    isdeleted = true
                });
                // return "OK";
            }

            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        //private void newPerson(Person nperson)
        //{
        //    if (nperson != null)
        //    {
        //        selectedperson = nperson;
        //    }
        //}
        private void newPerson()
        {
            selectedperson = new Person();
            Messenger.Default.Send<persontoeditmessage>(new persontoeditmessage
            {
                person = selectedperson,
                sendingWindow = myguid
            });
        }
        private void editPerson()
        {
           if(_selectedapplicant !=null)
            {  Messenger.Default.Send<persontoeditmessage>(new persontoeditmessage
            {
                person = selectedperson,
                sendingWindow = myguid
            });}
        }

        private async void searchforaperson()
        {
            if (searchtext.Length > 1)
            {
                Tuple<ObservableCollection<Person>, Person> mytuple =
                    await Repository.Utilities.findaperson(Persons, selectedperson, searchtext, _ds);
                Persons = mytuple.Item1;
                selectedperson = mytuple.Item2;
                if (selectedperson == null && _selectedapplicant != null)
                {
                    selectedperson = _selectedapplicant.person;
                }

            }

        }

        private async void saveallpersons()
        {
            await _ds.SavePerson(Persons);
        }
        private async void saveaperson()
        {
            if (_selectedPerson != null)
            {
                await _ds.SavePerson(_selectedPerson);
                AddApplicant();
            }
        }

        private async void AddApplicant()
        {
           await _ds.SavePerson(selectedperson);
            Applicant na = new Applicant
            {
                Jobid = _selectedjob.id,
                Personid = _selectedPerson.id,
                active = true,
                flag1=false
            };
            _ds.SaveApplicant(na);
            Sendna(na);
        }
        void Sendna(Applicant na)
        {
            if (na != null)
            {
                Messenger.Default.Send(new newApplicantMessage()
                {
                    newapplicant = na,
                    isdeleted = false
                });
            }
        }
        private void getnewperson()
        {

            selectedperson = new Models.Person();
            //Persons.Add(selectedperson);
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
            //if (selectedJob != null)
            {
                Messenger.Default.Register<ApplicantMessage>(this, findperson);
                isselapplicantregistered = true;
            }
        }

        private void findperson(ApplicantMessage obj)
        {
            selectedperson = obj.applicantm.person;
            selectedapplicant = obj.applicantm;
            //foreach (Person p in Persons)
            //{
            //    if (p.id == obj.applicantm.Personid)
            //    {
            //        selectedperson = p;
            //        break;
            //     }
            //}
        }

        private void getnewperson(personreturnedmessage obj)
        {
            if (!obj.iscancelled && obj.sourceWindow == myguid)
            {
                selectedperson = obj.personedit;
                AddApplicant();
            }
            else if (obj.iscancelled && obj.sourceWindow == myguid && _selectedapplicant !=null)
            {
                selectedperson = _selectedapplicant.person;
            }
        }

        private void getnewapplicant(ApplicantMessage am)
        {
            selectedapplicant = am.applicantm;
            selectedperson = am.applicantm.person;
        }
    
        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary
        public AddApplicantViewModel(DataService ds)
        {
           _ds = ds;
            myguid = Guid.NewGuid();
            Messenger.Default.Register<personreturnedmessage>(this, getnewperson);
            NewPerson = new RelayCommand(newPerson);
            SavePerson = new RelayCommand(AddApplicant);  // add applicant
           
            SearchPerson = new RelayCommand(searchforaperson);
            //changeSelectedPerson = new RelayCommand(NewPerson);
            DeletePerson = new RelayCommand(deletePerson);
            Edit = new RelayCommand(editPerson);
           // Persons = ds.GetAllPersons();
            departments = ds.GetAllDepartments();
            ReceiveSelectedJob();
            Messenger.Default.Register<ApplicantMessage>(this, getnewapplicant);

        }

      
    }
}