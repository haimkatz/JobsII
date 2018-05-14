using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JobsII.Views;

namespace JobsII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      //  public PersonView pagePersonView { get; set; }
        private NewPersonView _myview;
        public MainWindow()
        {
            InitializeComponent();
            //      pagePersonView = new PersonView();
             _myview = new NewPersonView();
            Closing += closeform;

        }

        private void closeform(object sender, EventArgs e)
        {
            _myview.Close();
        }
    }
}
