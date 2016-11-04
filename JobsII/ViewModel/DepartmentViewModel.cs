using System;
using System.Collections.ObjectModel;
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
    public class DepartmentViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the DepartmentViewModel class.
        /// </summary>
        /// 
        /// <summary>
        /// The <see cref="departments" /> property's name.
        /// </summary>

        private DataService _ds;

        public const string departmentsPropertyName = "departments";

        private ObservableCollection<Department> _departments ;

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
        /// <summary>
        /// The <see cref="selectedDepartment" /> property's name.
        /// </summary>
        public const string selectedDepartmentPropertyName = "selectedDepartment";

        private Department _selectedDepartment;

        /// <summary>
        /// Sets and gets the selectedDepartment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Department selectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }

            set
            {
                if (_selectedDepartment == value)
                {
                    return;
                }

                _selectedDepartment = value;
                RaisePropertyChanged(selectedDepartmentPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="persons" /> property's name.
        /// </summary>
        public const string personsPropertyName = "persons";

        private ObservableCollection<Person>  _persons;

        /// <summary>
        /// Sets and gets the persons property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Person> persons
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
                RaisePropertyChanged(personsPropertyName);
            }
        }

        public RelayCommand SaveDepartments { get; set; }
        public RelayCommand NewDepartment { get; set; }
        public RelayCommand DeleteDepartment { get; set; }

        public DepartmentViewModel(DataService ds)
        {
            _ds = ds;
            NewDepartment = new RelayCommand(newdepartment);
            //  SavePerson = new RelayCommand<Models.Person>(saveaperson);
            SaveDepartments = new RelayCommand(savedepartments);
         
          
            DeleteDepartment = new RelayCommand(deleteDepartment);
            persons = ds.GetAllPersons();
            departments = ds.GetAllDepartments();
        }

        private void deleteDepartment()
        {
            throw new NotImplementedException();
        }

        private async void  savedepartments()
        {
            await _ds.SaveDepartment(selectedDepartment);
        }

        private void newdepartment()
        {
            throw new NotImplementedException();
        }
    }
}