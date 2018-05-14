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
    public class RequirementViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the RequirementViewModel class.
        /// </summary>
        private DataService _ds;

        /// <summary>
        /// The <see cref="requirements" /> property's name.
        /// </summary>
        public const string requirementsPropertyName = "Requirements";

        private ObservableCollection<Models.Requirement> _requirements;

        /// <summary>
        /// Sets and gets the Requirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Models.Requirement> requirements
        {
            get
            {
                return _requirements;
            }

            set
            {
                if (_requirements == value)
                {

                    return;
                }

                _requirements = value;
               
                RaisePropertyChanged(requirementsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="person" /> property's name.
        /// </summary>
        public const string selectedrequirementPropertyName = "__selectedrequirement";

        private Models.Requirement __selectedrequirement;
        /// <summary>
        /// Sets and gets the person property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.Requirement selectedrequirement
        {
            get
            {
                return __selectedrequirement;
            }

            set
            {
                if (__selectedrequirement == value)
                {
                    return;
                }

                __selectedrequirement = value;
                RaisePropertyChanged(selectedrequirementPropertyName);
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

      
        public GalaSoft.MvvmLight.CommandWpf.RelayCommand NewObject { get; set; }

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
      

        private  void deletaneObject(object obj)
        {
            try
            {
               // await _ds.DeleteObj(obj);
                // return "OK";
            }

            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage { errormsg = e.Message, isvisible = true });
            }

        }

        private  void anewObject()
        {
            selectedrequirement = new Models.Requirement();
            requirements.Add(selectedrequirement);
        }

        private  void searchthecollection()
        {
           // Requirements = await _ds.FindPerson(searchtext);
        }

        //private async void saveallpersons()
        //{
        //   // await _ds.SavePerson(Requirements);
        //}
        private async void saveanObject()
        {
            await _ds.SaveRequirement(selectedrequirement);
        }

        private void getnewperson()
        {

            selectedrequirement = new Models.Requirement();
            requirements.Add(selectedrequirement);
        }
  private void deleteobject()
        {
            if (selectedrequirement != null)
            {
                _ds.deleteRequirement(selectedrequirement);
                requirements.Remove(selectedrequirement);
            }
        }
    

    public RequirementViewModel(DataService ds)
    {
        _ds = ds;
        NewObject = new RelayCommand(anewObject);
        //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
        SaveObject = new RelayCommand(saveanObject);
        SearchCollection= new RelayCommand(searchthecollection);
        DeleteObject = new RelayCommand(deleteobject);
     
      //  DeleteObject = new RelayCommand<Person>(deleteobject);
      requirements = ds.getAllRequirements();
    //    departments = ds.GetAllDepartments();
    }

      
    }
}