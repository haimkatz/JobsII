using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using JobsII.Models;
using JobsII.Repository;
using GalaSoft.MvvmLight.Command;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LanguageViewModel : ViewModelBase
    {
        private DataService _ds;

        /// <summary>
            /// The <see cref="languages" /> property's name.
            /// </summary>
        public const string languagesPropertyName = "languages";

        private ObservableCollection<Language> _languages;

        /// <summary>
        /// Sets and gets the languages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Language> languages
        {
            get
            {
                return _languages;
            }

            set
            {
                if (_languages == value)
                {
                    return;
                }

                _languages = value;
                RaisePropertyChanged(languagesPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedLang" /> property's name.
        /// </summary>
        public const string selectedLangPropertyName = "selectedLang";

        private Language _selectedLang;

        /// <summary>
        /// Sets and gets the selectedLang property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Language selectedLang
        {
            get
            {
                return _selectedLang;
            }

            set
            {
                if (_selectedLang == value)
                {
                    return;
                }

                _selectedLang = value;
                RaisePropertyChanged(selectedLangPropertyName);
            }
        }

        public RelayCommand NewLang { get; set; }
        public RelayCommand DeleteLang { get; set; }
        public RelayCommand SaveLang { get; set; }
        /// <summary>
        /// Initializes a new instance of the LanguageViewModel class.
        /// </summary>
        public LanguageViewModel(DataService ds)
        {
            _ds = ds;
            languages = _ds.getlanguages();
            NewLang = new RelayCommand(newlanguage);
            DeleteLang = new RelayCommand(deletelanguage);
            SaveLang = new RelayCommand(savelanguages);
        }

        private void savelanguages()
        {
            _ds.SaveLanguages(languages);
        }

        private void deletelanguage()
        {
            try
            {
                _ds.DeleteLanguage(selectedLang);
                languages.Remove(selectedLang);
            }
            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        private void getlanguages()
        {
            languages = _ds.getlanguages();
        }

        private void newlanguage()
        {
            selectedLang = new Language();
            languages.Add(selectedLang);
        }
    }
}