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
    public class ReminderViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ReminderViewModel class.
        /// </summary>
        /// 
        /// <summary>
        /// The <see cref="applicantreminders" /> property's name.
        /// </summary>
        private DataService _ds;

        public const string applicantremindersPropertyName = "applicantreminders";

        private ObservableCollection<MissingAppDocs> _applicantreminders;

        /// <summary>
        /// Sets and gets the applicantreminders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MissingAppDocs> applicantreminders
        {
            get
            {
                return _applicantreminders;
            }

            set
            {
                if (_applicantreminders == value)
                {
                    return;
                }

                _applicantreminders = value;
                RaisePropertyChanged(applicantremindersPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="reviewerreminders" /> property's name.
        /// </summary>
        public const string reviewerremindersPropertyName = "reviewerreminders";

        private Object _reviewerreminders;

        /// <summary>
        /// Sets and gets the reviewerreminders property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Object reviewerreminders
        {
            get
            {
                return _reviewerreminders;
            }

            set
            {
                if (_reviewerreminders == value)
                {
                    return;
                }

                _reviewerreminders = value;
                RaisePropertyChanged(reviewerremindersPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="appcollapsed" /> property's name.
        /// </summary>
        public const string appcollapsedPropertyName = "appcollapsed";

        private bool _appcollapsed = false;

        /// <summary>
        /// Sets and gets the appcollapsed property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool appcollapsed
        {
            get
            {
                return _appcollapsed;
            }

            set
            {
                if (_appcollapsed == value)
                {
                    return;
                }

                _appcollapsed = value;
               buttontext = value ? "רפרפנטים" :"מועמדים" ;
                RaisePropertyChanged(appcollapsedPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="buttontext" /> property's name.
        /// </summary>
        public const string buttontextPropertyName = "buttontext";

        private string _buttontext = "מועמדים";

        /// <summary>
        /// Sets and gets the buttontext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string buttontext
        {
            get
            {
                return _buttontext;
            }

            set
            {
                if (_buttontext == value)
                {
                    return;
                }

                _buttontext = value;
                RaisePropertyChanged(buttontextPropertyName);
            }
        }

      public RelayCommand  AppRem { get; set; }
      
        public ReminderViewModel(DataService ds)
        {
            _ds = ds;
            AppRem = new RelayCommand(getrem);
        }

        private void getrem()
        {
            getreminders(appcollapsed);
            appcollapsed = !appcollapsed;
        }

        private void getreminders(bool appcollapsed)
        {
            if (appcollapsed)
            {
                reviewerreminders = _ds.getRevReminders();
            }
            else
            {
                applicantreminders = _ds.getAppReminders();
            }
        }
    }
}