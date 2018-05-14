using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for CommitteeView.
    /// </summary>
    public partial class CommitteeView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CommitteeView class.
        /// </summary>
        public CommitteeView()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {

            SimpleIoc.Default.Unregister<CommitteeViewModel>();
            SimpleIoc.Default.Register<CommitteeViewModel>();
        }
    }
}