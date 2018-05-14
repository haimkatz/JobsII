using System.Windows;
using System.Windows.Controls;

namespace JobsII.Views
{
    /// <summary>
    /// Description for LanguagesView.
    /// </summary>
    public partial class LanguagesView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the LanguagesView class.
        /// </summary>
        public LanguagesView()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

              // Load data by setting the CollectionViewSource.Source property:
            // languageViewSource.Source = [generic data source]
        }
    }
}