﻿using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Views
{
    /// <summary>
    /// Description for JobParentView.
    /// </summary>
    public partial class JobParentView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the JobParentView class.
        /// </summary>
        public JobParentView()
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
        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleIoc.Default.Unregister<jobViewModel>();
            SimpleIoc.Default.Register<jobViewModel>();
        }

    }
}