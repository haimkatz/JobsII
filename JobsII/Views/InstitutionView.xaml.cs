using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for InstitutionView.
    /// </summary>
    public partial class InstitutionView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the InstitutionView class.
        /// </summary>
        public InstitutionView()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        { 
            SimpleIoc.Default.Unregister<InstituteViewModel>();
            SimpleIoc.Default.Register<InstituteViewModel>();
        }
    }
}