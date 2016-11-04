using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
    public class jobViewModel : ViewModelBase
    {
        private DataService _ds;

        /// <summary>
        /// Initializes a new instance of the jobViewModel class.
        /// </summary>

        /// <summary>
        /// The <see cref="jobsc" /> property's name.
        /// </summary>
        ///
        public const string jobscPropertyName = "jobsc";
        /// <summary>
        /// The <see cref="requirements" /> property's name.
        /// </summary>
        public const string jobrequirementsPropertyName = "requirements";

        private ObservableCollection<Requirement> _requirements ;

        /// <summary>
        /// Sets and gets the requirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Requirement> requirements
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
                RaisePropertyChanged(jobrequirementsPropertyName);
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


        private ObservableCollection<Job> _jobsc;

        /// <summary>
        /// Sets and gets the jobsc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Job> jobsc
        {
            get { return _jobsc; }

            set
            {
                if (_jobsc == value)
                {
                    return;
                }

                _jobsc = value;
                RaisePropertyChanged(jobscPropertyName);
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
               
                RaisePropertyChanged(PersonsPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="selectedJob" /> property's name.
        /// </summary>
        public const string selectedJobPropertyName = "selectedJob";

        private Job _selectedJob ;

        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Job selectedJob
        {
            get
            {
                return _selectedJob;
            }

            set
            {
                if (_selectedJob == value)
                {
                    return;
                }

                _selectedJob = value;
                RaisePropertyChanged(selectedJobPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="applicantshellviewmodel" /> property's name.
        /// </summary>
        public const string applicantshellviewmodelPropertyName = "applicantshellviewmodel";

        private ApplicantShellViewModel _applicantshellviewmodel;

        /// <summary>
        /// Sets and gets the applicantshellviewmodel property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ApplicantShellViewModel applicantshellviewmodel
        {
            get
            {
                return _applicantshellviewmodel;
            }

            set
            {
                if (_applicantshellviewmodel == value)
                {
                    return;
                }

                _applicantshellviewmodel = value;
                RaisePropertyChanged(applicantshellviewmodelPropertyName);
            }
        }
        public RelayCommand NewJob { get; private set; }
        public RelayCommand SaveJob { get; private set; }
        public RelayCommand<string> SearchJob { get; private set; }
       public RelayCommand Newjr { get; private set; }

        public jobViewModel(DataService ds)
        {
            _ds = ds;
            NewJob = new RelayCommand(getnewjob);
            SaveJob = new RelayCommand(savejob);
            SearchJob = new RelayCommand<string>(searchforajob);
            Newjr = new RelayCommand(addRequirement);
            requirements = _ds.getAllRequirements();
            jobsc = ds.GetAllJobs();
            departments = ds.GetAllDepartments();
            Persons = ds.GetAllPersons();
            applicantshellviewmodel = new ApplicantShellViewModel(_ds);
        }

        private void addRequirement()
        {
            JobRequirement jr = new JobRequirement();
            jr.Jobid = selectedJob.id;
            jr.deadline = DateTime.Today.AddMonths(1);
            selectedJob.jobRequirements.Add(jr);
        }

        private void searchforajob(string obj)
        {
            throw new NotImplementedException();
        }

        private async void savejob()
        {
            //assign id to requirements
            //foreach (JobRequirement jr in selectedJob.jobRequirements)
            //{
            //    jr.Jobid = selectedJob.id;}

            selectedJob = await _ds.saveJob(selectedJob);
        }

        private void getnewjob()
        {
           selectedJob = new Models.Job();
            jobsc.Add(selectedJob);
        }
        void SendSelectedJob()
        {
            if (selectedJob != null)
            {
                Messenger.Default.Send(new JobMessage()
                {
                    jobm = selectedJob
                });
            }
        }
    }
}