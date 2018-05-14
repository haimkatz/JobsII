using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for MergeDocTypeView.
    /// </summary>
    public partial class MergeDocTypeView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the MergeDocTypeView class.
        /// </summary>
        public MergeDocTypeView()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<MergeDocTypeViewModel>();
            SimpleIoc.Default.Register<MergeDocTypeViewModel>();
        }
    }
}