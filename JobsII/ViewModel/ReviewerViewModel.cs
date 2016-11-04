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
    public class ReviewerViewModel : ViewModelBase
    {
        private DataService ds;

        /// <summary>
        /// Initializes a new instance of the ReviewerViewModel class.
        /// </summary>
      
        public ReviewerViewModel(DataService ds)
        {
            this.ds = ds;
        }
    }
}