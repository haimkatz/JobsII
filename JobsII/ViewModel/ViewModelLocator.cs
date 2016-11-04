/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:JobsII"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;
using Microsoft.Practices.ServiceLocation;
using JobsII.Models;
using JobsII.Repository;


namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
       
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<DataService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PersonViewModel>();
            SimpleIoc.Default.Register<DepartmentViewModel>();
            SimpleIoc.Default.Register<TableTemplateViewModel>();
            SimpleIoc.Default.Register<RequirementViewModel>();
            SimpleIoc.Default.Register<jobViewModel>();
            SimpleIoc.Default.Register<ApplicantShellViewModel>();
            SimpleIoc.Default.Register<AddApplicantViewModel>();
            SimpleIoc.Default.Register<ReviewerViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
               
            }
        }

        public PersonViewModel PersonViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PersonViewModel>();

            }
        }
        public DepartmentViewModel DepartmentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DepartmentViewModel>();

            }
        }
        public TableTemplateViewModel TableTemplateViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableTemplateViewModel>();

            }
        }
        public RequirementViewModel RequirementViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RequirementViewModel>();

            }
        }
        public jobViewModel jobViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<jobViewModel>();

            }
        }
        public ApplicantShellViewModel ApplicantShellViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ApplicantShellViewModel>();

            }
        }
        public AddApplicantViewModel AddApplicantViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddApplicantViewModel>();

            }
        }
        public ReviewerViewModel ReviewerViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReviewerViewModel>();

            }
        }
        public DocumentViewModel DocumentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DocumentViewModel>();

            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}