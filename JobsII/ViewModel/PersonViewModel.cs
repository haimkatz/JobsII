using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    public class PersonViewModel : ViewModelBase
    {
        private DataService _ds;
        /// <summary>
            /// The <see cref="genders" /> property's name.
            /// </summary>
        public const string gendersPropertyName = "genders";

        private ObservableCollection<sex> _genders ;

        /// <summary>
        /// Sets and gets the genders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<sex> genders
        {
            get
            {
                return _genders;
            }

            set
            {
                if (_genders == value)
                {
                    return;
                }

                _genders = value;
                RaisePropertyChanged(() => genders);
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
                if (person == null)
                 
                    {
                        if (_persons.Count > 0)
                        {
                            person = _persons[0];
                        }

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

        private Guid _sendingwindowid;
        private bool isnew;

        public RelayCommand  NewPerson { get; set; }

        public RelayCommand SaveaPerson { get; set; }
        public RelayCommand SavePerson { get; set; }
        public RelayCommand SearchPerson { get; set; }
        public RelayCommand<Person> changeSelectedPerson { get; set; }
        public RelayCommand DeletePerson { get; set; }
        public RelayCommand CancelPerson { get; set; }
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
            SaveaPerson = new RelayCommand(saveaperson);
            SavePerson = new RelayCommand(saveallpersons);
            SearchPerson = new RelayCommand(searchforaperson);
            CancelPerson = new RelayCommand(cancelperson);
            fillgenders();
            changeSelectedPerson = new RelayCommand<Person>(newPerson);
            DeletePerson = new RelayCommand (deletePerson);
            Persons = ds.GetAllPersons();
            departments = ds.GetAllDepartments();
            Messenger.Default.Register<persontoeditmessage>(this, getpersonmessage);
        }

        private void cancelperson()
        {
            person = Persons[0];
            Messenger.Default.Send<personreturnedmessage>(new personreturnedmessage
            {
                personedit = null,
                iscancelled = true,
                sourceWindow = _sendingwindowid,
                isnew = isnew
            });
        }

        private void getpersonmessage(persontoeditmessage obj)
        {
            this._sendingwindowid = obj.sendingWindow;
            person = obj.person;
            Persons.Add(person);
            this.isnew = obj.isnew;
        }   

        private async void deletePerson()
        {
            Person obj = person;
            Persons.Remove(person);
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
        private async void saveaperson()
        {
            Person obj = selectedPerson;
            if(obj.lastname== String.Empty)
            { MessageBox.Show("חובה להכניס שם משפחה"); }
            else if (selectedPerson.sex == 0)
            {
                MessageBox.Show("חובה לבחור מין");
            }
            else
            {
                await _ds.SavePerson(obj);
                if (_sendingwindowid != Guid.Empty)
                {
                    Messenger.Default.Send<personreturnedmessage>(new personreturnedmessage
                    {
                        personedit = obj,
                        sourceWindow = _sendingwindowid,
                        iscancelled = false,
                        isnew = isnew
                    });
                    _sendingwindowid = Guid.Empty;

                }
            }
        }

        private void getnewperson()
        {

           person = new Models.Person();
            Persons.Add(person);
        }

        //private void fillgenders()
        //{
        //    genders = new ObservableCollection<object>();
        //    genders.Add(new {val = 1, descript = sex.male});
        //    genders.Add(new {val = 2, descript = sex.female});
        //}
       private void fillgenders()
        {
            genders = new ObservableCollection<sex>();
            genders.Add( sex.male);
            genders.Add(sex.female);
        }
    }
}