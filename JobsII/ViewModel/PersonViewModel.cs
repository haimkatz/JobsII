using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class PersonViewModel : ViewModelBase
    {
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
        public RelayCommand  NewPerson { get; set; }

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
        public  PersonViewModel(DataService ds)
        {
            _ds = ds;
            NewPerson = new RelayCommand(getnewperson);
          //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
            SavePerson = new RelayCommand(saveallpersons);
            SearchPerson = new RelayCommand(searchforaperson);
            changeSelectedPerson = new RelayCommand<Person>(newPerson);
            DeletePerson = new RelayCommand<Person>(deletePerson);
            Persons = ds.GetAllPersons();
            departments = ds.GetAllDepartments();
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
               // return e.Message;
            }
            
        }

        private void newPerson(Person nperson)
        {
            if (nperson != null)
            {
                person = nperson;
            }
        }

        private async void searchforaperson( )
        {
          Persons = await _ds.FindPerson(searchtext);
        }

        private async void saveallpersons()
        {
            await _ds.SavePerson(Persons);
        }
        private async void saveaperson(Models.Person obj)
        {
            await _ds.SavePerson(obj);
        }

        private void getnewperson()
        {

           person = new Models.Person();
            Persons.Add(person);
        }

    }
}