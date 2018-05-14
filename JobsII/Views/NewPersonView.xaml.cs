using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using JobsII.ViewModel;


namespace JobsII.Views
{
    /// <summary>
    /// Description for NewPersonView.
    /// </summary>
    public partial class NewPersonView : Window
    {
        //private const int GWL_STYLE = -16;
        //private const int WS_SYSMENU = 0x80000;
        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        //[DllImport("user32.dll")]
        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private bool _isopen;
        //private PersonViewModel personviewmodel;
        /// <summary>
        /// Initializes a new instance of the NewPersonView class.
        /// </summary>
        public NewPersonView()
        {
            InitializeComponent();
          
            Messenger.Default.Register<persontoeditmessage>(this, Handleperson);
            Messenger.Default.Register<personreturnedmessage>(this, hidewindow);
            this.MouseDown += (sender,e)=>this.DragMove();

        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //var hwnd = new WindowInteropHelper(this).Handle;
            //SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void hidewindow(personreturnedmessage obj)
        {
            _isopen = false;
            this.Hide();
            
            SimpleIoc.Default.Unregister<PersonViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();
        }

        private void Handleperson(persontoeditmessage obj)
        {
            _isopen = true;
            this.Show();
        }
    }
}