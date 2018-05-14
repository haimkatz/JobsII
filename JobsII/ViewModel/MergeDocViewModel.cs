using System;
using System.Collections.ObjectModel;
using System.Reflection;
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
    public class MergeDocViewModel : ViewModelBase
    {
        private DataService _ds;
        /// <summary>
        /// The <see cref="mergedocs" /> property's name.
        /// </summary>
        public const string mergedocsPropertyName = "mergedocs";

        private ObservableCollection<MergeDoc> _mergedocs;

        /// <summary>
        /// Sets and gets the mergedocs property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MergeDoc> mergedocs
        {
            get
            {
                return _mergedocs;
            }

            set
            {
                if (_mergedocs == value)
                {
                    return;
                }

                _mergedocs = value;
                RaisePropertyChanged(mergedocsPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedMergeDoc" /> property's name.
        /// </summary>
        public const string selectedMergeDocPropertyName = "selectedMergeDoc";

        private MergeDoc _selectedMergeDoc;

        /// <summary>
        /// Sets and gets the selectedMergeDoc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MergeDoc selectedMergeDoc
        {
            get
            {
                return _selectedMergeDoc;
            }

            set
            {
                if (_selectedMergeDoc == value)
                { 
                   
                    return;
                }

                _selectedMergeDoc = value;
                if (_selectedMergeDoc != null)
                {
                     canselect = true;
                    if (_selectedMergeDoc.mergedoctype !=null)
                    { doctype = _selectedMergeDoc.mergedoctype.typename;}
                   // languagep = _selectedMergeDoc.languageid;
                }
                else { canselect = false; }
                RaisePropertyChanged(selectedMergeDocPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="mergefields" /> property's name.
        /// </summary>
        public const string mergefieldsPropertyName = "mergefields";

        private ObservableCollection<Mergefield> _mergefields;

        /// <summary>
        /// Sets and gets the mergefields property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Mergefield> mergefields
        {
            get
            {
                return _mergefields;
            }

            set
            {
                if (_mergefields == value)
                {
                    return;
                }

                _mergefields = value;
                RaisePropertyChanged(mergefieldsPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedMergeField" /> property's name.
        /// </summary>
        public const string selectedMergeFieldPropertyName = "selectedMergeField";

        private Mergefield _selectedMergeField ;

        /// <summary>
        /// Sets and gets the selectedMergeField property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Mergefield selectedMergeField
        {
            get
            {
                return _selectedMergeField;
            }

            set
            {
                if (_selectedMergeField == value)
                {
                    return;
                }

                _selectedMergeField = value;
               
                RaisePropertyChanged(selectedMergeFieldPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="doctypes" /> property's name.  To whom the letter is addressed
        /// </summary>
        public const string doctypesPropertyName = "doctypes";

        private ObservableCollection<string> _doctypes ;

        /// <summary>
        /// Sets and gets the doctypes property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> doctypes
        {
            get
            {
                return _doctypes;
            }

            set
            {
                if (_doctypes == value)
                {
                    return;
                }

                _doctypes = value;
                RaisePropertyChanged(doctypesPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="doctype" /> property's name.
        /// </summary>
        public const string doctypePropertyName = "doctype";

        private string _doctype = "רפרנט" ;

        /// <summary>
        /// Sets and gets the doctype property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string doctype
        {
            get
            {
                return _doctype;
            }

            set
            {
                if (_doctype == value)
                {
                    return;
                }

                _doctype = value;
                fillmergefields(_doctype);
                RaisePropertyChanged(doctypePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="languagep" /> property's name.
        /// </summary>
        public const string languagepPropertyName = "languagep";

        private string _languagep = "English";

        /// <summary>
        /// Sets and gets the language property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string languagep
        {
            get
            {
                return _languagep;
            }

            set
            {
                if (_languagep == value)
                {
                    return;
                }

                _languagep = value;
                RaisePropertyChanged(languagepPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="canselect" /> property's name.
        /// </summary>
        public const string canselectPropertyName = "canselect";

        private bool _canselect = false;

        /// <summary>
        /// Sets and gets the canselect property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canselect
        {
            get
            {
                return _canselect;
            }

            set
            {
                if (_canselect == value)
                {
                    return;
                }

                _canselect = value;
                RaisePropertyChanged(() => canselect);
            }
        }
        public RelayCommand NewDoc { get; set; }
        public RelayCommand SaveDoc { get; set; }
        public RelayCommand EditDoc { get; set; }
        /// <summary>
        /// Initializes a new instance of the MergeDocViewModel class.
        /// </summary>
        public MergeDocViewModel(DataService ds)

        {
            _ds = ds;
            NewDoc = new RelayCommand(newdoc);
            SaveDoc = new RelayCommand(savedoc);
            EditDoc = new RelayCommand(getdoc);
            initializedoctypes();
            getalldocs();
        }

        private void getdoc()
        {
          
        }

        private void savedoc()
        {
            _ds.SaveMergeDoc(selectedMergeDoc);
        }

        private void newdoc()
        {
            selectedMergeDoc = new MergeDoc
            {
                datecreated = DateTime.Today,
                htmltext="<html><body>Dear    ,<p/>   </body></html>", 
               // language= languagep,
               languageid = 1,
                mergetype=doctype
            };
            mergedocs.Add(selectedMergeDoc);
        }

        private void initializedoctypes()
        {
            doctypes = new ObservableCollection<string>();
            doctypes.Add("רפרנט");
            doctypes.Add("מועמד");
            doctypes.Add("חברי ועדה");
            doctypes.Add("חבר בודד");


        }

        private void getalldocs()
        {
            mergedocs = _ds.Getallmergedocs();
        }

        private void fillmergefields(string doctype)
        {
            object myobj = new object();
            switch (doctype)
            {
                case "רפרנט":
                    myobj = new ReviewerMergeFields();
                    break;
                case "חברי ועדה":
                    myobj = new CommitteeMergeFields();
                    break;
                case "מועמד":
                    myobj = new applicantMergeFields();
                    break;
                case "חבר בודד":
                    myobj = new CommitteeMemberMergeFields();
                    break;
            }
            mergefields = new ObservableCollection<Mergefield>();
            var mytype = myobj.GetType();
            foreach (PropertyInfo p in mytype.GetProperties())
            {
                Mergefield mf = new Mergefield(p.Name, p.Name);
                mergefields.Add(mf);
               

            }
        }
    }
}