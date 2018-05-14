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
    public class ReviwerStatusViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the RequirementViewModel class.
        /// </summary>
        private DataService _ds;

        /// <summary>
        /// The <see cref="revstatus" /> property's name.
        /// </summary>
        public const string revstatusPropertyName = "revstatus";

        private ObservableCollection<ReviewerStatus> _revstatus;

        /// <summary>
        /// Sets and gets the Persons property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ReviewerStatus> revstatus
        {
            get
            {
                return _revstatus;
            }

            set
            {
                if (_revstatus == value)
                {

                    return;
                }

                _revstatus = value;
                if (selrevstatus == null)

                {
                    if (_revstatus.Count>0) { selrevstatus = _revstatus[0];}
                }
                RaisePropertyChanged(revstatusPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="selrevstatus" /> property's name.
            /// </summary>
        public const string selrevstatusPropertyName = "selrevstatus";

        private ReviewerStatus _selrevstatus;

        /// <summary>
        /// Sets and gets the selrevstatus property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ReviewerStatus selrevstatus
        {
            get
            {
                return _selrevstatus;
            }

            set
            {
                if (_selrevstatus == value)
                {
                    return;
                }

                _selrevstatus = value;
                RaisePropertyChanged(selrevstatusPropertyName);
            }
        }
     
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

       
        public RelayCommand NewObject { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SaveObject { get; set; }
        public RelayCommand SearchCollection { get; set; }
        public RelayCommand<object> ChangeSelectedPerson { get; set; }
        public RelayCommand DeleteObject { get; set; }
        /// <summary>
        /// Gets the NewPerson.
        /// </summary>

        /// <summary>
        /// Initializes a new instance of the MvvmViewModel1 class.
        /// </summary>


        private  void deletaneObject()
        {
            try
            {
                _ds.DeleteStatus(selrevstatus);
            }

            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        //private async void anewObject()
        //{
        //    //if (newobject != null)
        //    //{
        //    //  newobject   = newobject;
        //    //}
        //}

        private  void searchthecollection()
        {
            // Persons = await _ds.FindPerson(searchtext);
        }

        //private async void saveallpersons()
        //{
        //    // await _ds.SavePerson(Persons);
        //}
        private  void saveanObject()
        {
            _ds.SaveReviewerStatus(revstatus);
        }

        private void getnewperson()
        {

            selrevstatus = new ReviewerStatus();
            if (revstatus == null)
            {
                revstatus = new ObservableCollection<ReviewerStatus>();
            }
            
            revstatus.Add(selrevstatus);
        }



        public ReviwerStatusViewModel(DataService ds)
        {
            _ds = ds;
            NewObject = new RelayCommand(getnewperson);
            //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
            SaveObject = new RelayCommand(saveanObject);
            SearchCollection = new RelayCommand(searchthecollection);
            revstatus = _ds.getrevstatus();
            //  DeleteObject = new RelayCommand<Person>(deleteobject);
            //    Persons = ds.GetAllPersons();
            //    departments = ds.GetAllDepartments();
        }
    }
}