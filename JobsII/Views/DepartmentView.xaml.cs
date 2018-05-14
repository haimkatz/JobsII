using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for DepartmentView.
    /// </summary>
    public partial class DepartmentView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the DepartmentView class.
        /// </summary>
        public DepartmentView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<DepartmentViewModel>();
            SimpleIoc.Default.Register<DepartmentViewModel>();
        }
    }
}