using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for AddReviewerView.
    /// </summary>
    public partial class AddReviewerView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AddReviewerView class.
        /// </summary>
        public AddReviewerView()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            
            SimpleIoc.Default.Unregister<AddReviewerViewModel>();
            SimpleIoc.Default.Register<AddReviewerViewModel>();
        }
    }
    
}