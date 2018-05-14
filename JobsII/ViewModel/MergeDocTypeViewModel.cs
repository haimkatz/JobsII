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
    public class MergeDocTypeViewModel : ViewModelBase
    {
        private DataService _ds;
        /// <summary>
        /// The <see cref="mergedoctypes" /> property's name.
        /// </summary>
        public const string mergedoctypesPropertyName = "mergedoctypes";

        private ObservableCollection<MergeDocType> _mergedoctypes ;

        /// <summary>
        /// Sets and gets the mergedoctypes property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MergeDocType> mergedoctypes
        {
            get
            {
                return _mergedoctypes;
            }

            set
            {
                if (_mergedoctypes == value)
                {
                    return;
                }

                _mergedoctypes = value;
                RaisePropertyChanged(mergedoctypesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SelMD" /> property's name.
        /// </summary>
        public const string SelMDPropertyName = "SelMD";

        private MergeDocType _SelMD ;

        /// <summary>
        /// Sets and gets the SelMD property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MergeDocType SelMD
        {
            get
            {
                return _SelMD;
            }
            set
            {
                Set(SelMDPropertyName, ref _SelMD, value);
            }
        }

        public RelayCommand NewMT { get; set; }
        public RelayCommand SaveMT { get; set; }
        public RelayCommand DeleteMT { get; set; }
        public RelayCommand ExitMT { get; set; }
        /// <summary>
        /// Initializes a new instance of the MergeDocTypeViewModel class.
        /// </summary>
        public MergeDocTypeViewModel(DataService ds)
        {
            _ds = ds;
            mergedoctypes = _ds.Getmergedoctypes();
            NewMT = new RelayCommand(newmdt);
            SaveMT = new RelayCommand(savemdt);
            DeleteMT = new RelayCommand(deletemt);
        }

        private void deletemt()
        {
           _ds.DeleteMergeDocType(SelMD);
            mergedoctypes.Remove(SelMD);
        }

        private void savemdt()
        {
            _ds.Savemergedoctype(mergedoctypes);
        }

        private void newmdt()
        {
            var mdt = new MergeDocType();
            mergedoctypes.Add(mdt);
        }
    }
}