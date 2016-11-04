using GalaSoft.MvvmLight;
using JobsII.Repository;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DocumentViewModel : ViewModelBase
    {
        private DataService ds;

        /// <summary>
        /// Initializes a new instance of the DocumentViewModel class.
        /// </summary>
     
        public DocumentViewModel(DataService ds)
        {
            this.ds = ds;
        }
    }
}