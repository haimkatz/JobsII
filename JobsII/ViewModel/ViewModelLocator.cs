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

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using JobsII.ViewModel;
using CommonServiceLocator;
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
           
            SimpleIoc.Default.Register<ApplicantShellViewModel>();
            SimpleIoc.Default.Register<AddApplicantViewModel>();
            SimpleIoc.Default.Register<ReviewerViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();
            SimpleIoc.Default.Register<AddReviewerViewModel>();
            SimpleIoc.Default.Register<ReviwerStatusViewModel>();
            SimpleIoc.Default.Register<CommitteeViewModel>();
            SimpleIoc.Default.Register<InstituteViewModel>();
            SimpleIoc.Default.Register<UniversalDocViewModel>();
            SimpleIoc.Default.Register<JobDocViewModel>();
            SimpleIoc.Default.Register<jobViewModel>();
            SimpleIoc.Default.Register<ReminderViewModel>();
            SimpleIoc.Default.Register <LanguageViewModel>();
            SimpleIoc.Default.Register<MergeDocViewModel>();
            SimpleIoc.Default.Register<MergeDocTypeViewModel>();
        } 
        /// <summary>
        /// Gets the view's ViewModel.
        /// </summary>
        public JobDocViewModel jobdocviewmodel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<JobDocViewModel>();
            }
        }
        public UniversalDocViewModel UniversalDocViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UniversalDocViewModel>();
            }
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

        public AddReviewerViewModel AddReviewerViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AddReviewerViewModel>(); }
        }
        public DocumentViewModel DocumentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DocumentViewModel>();

            }
        }
        public ReviwerStatusViewModel ReviwerStatusViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReviwerStatusViewModel>();

            }
        }
        public CommitteeViewModel CommitteeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommitteeViewModel>();

            }
        }
         public InstituteViewModel InstituteViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InstituteViewModel>();

            }
        }
        public ReminderViewModel ReminderViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReminderViewModel>();

            }
        }
        public LanguageViewModel LanguageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LanguageViewModel>();

            }
        }
        public MergeDocViewModel MergeDocViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MergeDocViewModel>();

            }
        }
        public MergeDocTypeViewModel MergeDocTypeViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MergeDocTypeViewModel>();

            }
        }
        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<UniversalDocViewModel>();
            SimpleIoc.Default.Unregister<InstituteViewModel>();
            SimpleIoc.Default.Unregister<DepartmentViewModel>();
            SimpleIoc.Default.Unregister<RequirementViewModel>();
            SimpleIoc.Default.Unregister<ReviwerStatusViewModel>();
            SimpleIoc.Default.Unregister<CommitteeViewModel>();
            SimpleIoc.Default.Unregister<DocumentViewModel>();
            SimpleIoc.Default.Unregister<ReviewerViewModel>();
            SimpleIoc.Default.Unregister<AddApplicantViewModel>();
            SimpleIoc.Default.Unregister<ApplicantShellViewModel>();
            SimpleIoc.Default.Unregister<JobDocViewModel>();
            SimpleIoc.Default.Unregister<jobViewModel>();
            SimpleIoc.Default.Unregister<PersonViewModel>();
            SimpleIoc.Default.Unregister<ReminderViewModel>();
            SimpleIoc.Default.Unregister<LanguageViewModel>();
            SimpleIoc.Default.Unregister<MergeDocTypeViewModel>();
            SimpleIoc.Default.Unregister<MergeDocViewModel>();

        }
    }
}