using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for AddApplicantView.
    /// </summary>
    public partial class AddApplicantView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AddApplicantView class.
        /// </summary>
        public AddApplicantView()
        {
            InitializeComponent();
        }
        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<AddApplicantViewModel>();
            SimpleIoc.Default.Register<AddApplicantViewModel>();
        }

    }
}