using System.Windows;

namespace JobsII.Views
{
    /// <summary>
    /// Description for MvvmView1.
    /// </summary>
    public partial class MvvmView1 : Window
    {
        /// <summary>
        /// Initializes a new instance of the MvvmView1 class.
        /// </summary>
        public MvvmView1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // personViewSource.Source = [generic data source]
        }
    }
}