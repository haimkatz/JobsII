using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    public class TableTemplateViewModel : ViewModelBase
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

        private void getnewperson()
        {

            person = new Models.Person();
            Persons.Add(person);
        }

    

    public TableTemplateViewModel(DataService ds)
    {
        _ds = ds;
        NewObject = new RelayCommand(anewObject);
        //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
        SaveObject = new RelayCommand(saveanObject);
        SearchCollection= new RelayCommand(searchthecollection);
     
      //  DeleteObject = new RelayCommand<Person>(deleteobject);
    //    Persons = ds.GetAllPersons();
    //    departments = ds.GetAllDepartments();
    }
    }
}