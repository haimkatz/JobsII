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
    public class AddApplicantViewModel : ViewModelBase
    {
        private DataService ds;

        /// <summary>
        /// Initializes a new instance of the AddApplicantViewModel class.
        /// </summary>
       

        public AddApplicantViewModel(DataService ds)
        {
            this.ds = ds;
        }
    }
}