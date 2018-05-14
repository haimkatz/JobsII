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
    public class InstituteViewModel : ViewModelBase
    {
        private DataService _ds;
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
        /// The <see cref="institutes" /> property's name.
        /// </summary>
        public const string institutesPropertyName = "institutes";

        private ObservableCollection<Institute> _institutes ;

        /// <summary>
        /// Sets and gets the institutes property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Institute> institutes
        {
            get
            {
                return _institutes;
            }

            set
            {
                if (_institutes == value)
                {
                    return;
                }

                _institutes = value;
                RaisePropertyChanged(institutesPropertyName);
                if (_institutes.Count>0)
                { selectedInstitute = _institutes[0];}
            }
        }
        /// <summary>
        /// The <see cref="selectedInstitute" /> property's name.
        /// </summary>
        public const string selectedInstitutePropertyName = "selectedInstitute";

        private Institute _selectedInstitute ;

        /// <summary>
        /// Sets and gets the selectedInstitute property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Institute selectedInstitute
        {
            get
            {
                return _selectedInstitute;
            }

            set
            {
                if (_selectedInstitute == value)
                {
                    return;
                }

                _selectedInstitute = value;
                if (_selectedInstitute != null)
                {
                    getjobsbyinstitue();}
                RaisePropertyChanged(selectedInstitutePropertyName);
            }
        }

        public RelayCommand NewInst { get; set; }
        public RelayCommand SaveInst { get; set; }
        /// <summary>
        /// Initializes a new instance of the InstituteViewModel class.
        /// </summary>
        public InstituteViewModel(DataService ds)
        {
            _ds = ds;
            NewInst = new RelayCommand(newinst);
            SaveInst = new RelayCommand(saveinst);
            getinstitutes();
        }

        private void saveinst()
        {
           _ds.saveinstitutes(_institutes);
        }

        private void newinst()
        {
            selectedInstitute = new Institute();
            institutes.Add(selectedInstitute);
        }

        private void getinstitutes()
        {
            institutes = _ds.getallinstitutes();
           
            
        }
        private void getjobsbyinstitue()
        {
            jobs = _ds.jobsbyInstid(selectedInstitute.id);
        }
    }
}
