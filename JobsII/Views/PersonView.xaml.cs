﻿using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.Repository;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for PersonView.
    /// </summary>
    public partial class PersonView : UserControl
    {
        public PersonView()
        {

            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the PersonView class.
        /// </summary>
        public PersonView(DataService DS)
        {
            InitializeComponent();
            
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<PersonViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();
        }
    
    }
}