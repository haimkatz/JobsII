using System;
using System.Collections.ObjectModel;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Models;
using JobsII.Repository;
using System.Windows;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class DocumentViewModel : ViewModelBase
    {
        private DataService _ds;

        /// <summary>
        /// The <see cref="selectedApplicant" /> property's name.
        /// </summary>
        public const string selectedApplicantPropertyName = "selectedApplicant";

        private Applicant _selectedApplicant;

        /// <summary>
        /// Sets and gets the selectedApplicant property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Applicant selectedApplicant
        {
            get { return _selectedApplicant; }

            set
            {
                if (_selectedApplicant == value)
                {
                    return;
                }

                _selectedApplicant = value;
                RaisePropertyChanged(selectedApplicantPropertyName);
                apprequirements = selectedApplicant.apprequirements;

                if (selectedApplicant.Jobid != currentJobid)
                {
                    currentJobid = selectedApplicant.Jobid;
                }
            }
        }

        /// <summary>
        /// The <see cref="apprequirements" /> property's name.
        /// </summary>
        public const string apprequirementsPropertyName = "apprequirements";

        private ObservableCollection<AppRequirement> _apprequirements;

        /// <summary>
        /// Sets and gets the apprequirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<AppRequirement> apprequirements
        {
            get { return _apprequirements; }

            set
            {
                if (_apprequirements == value)
                {
                    return;
                }

                _apprequirements = value;
                RaisePropertyChanged(apprequirementsPropertyName);
                if (selectedappreq != null && selectedappreq.Applicantid != selectedApplicant.id) { selectedappreq = null; }

                {
                    if (_apprequirements != null && _apprequirements.Count > 0)
                    {
                        selectedappreq = _apprequirements[0];
                    }
                    //else
                    //{
                    //    _apprequirements = new ObservableCollection<AppRequirement>();
                    //}
                }
            }
        }
        /// <summary>
        /// The <see cref="selectedappreq" /> property's name.
        /// </summary>
        public const string selectedappreqPropertyName = "selectedappreq";

        private AppRequirement _selectedappreq;

        /// <summary>
        /// Sets and gets the selectedappreq property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AppRequirement selectedappreq
        {
            get
            {
                return _selectedappreq;
            }

            set
            {
                if (_selectedappreq == value)
                {
                    return;
                }

                _selectedappreq = value;
                RaisePropertyChanged(selectedappreqPropertyName);
                SaveDoccom.RaiseCanExecuteChanged();
            }
        }
        /// <summary>
        /// The <see cref="jobrequirements" /> property's name.
        /// </summary>
        public const string jobrequirementsPropertyName = "jobrequirements";

        private ObservableCollection<appreqcombo> _jobrequirements;

        /// <summary>
        /// Sets and gets the jobrequirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<appreqcombo> jobrequirements
        {
            get
            {
                return _jobrequirements;
            }

            set
            {
                if (_jobrequirements == value)
                {
                    return;
                }

                _jobrequirements = value;
                RaisePropertyChanged(jobrequirementsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selarcombo" /> property's name.
        /// </summary>
        public const string selarcomboPropertyName = "selarcombo";

        private appreqcombo _selarcombo;

        /// <summary>
        /// Sets and gets the selarcombo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public appreqcombo selarcombo
        {
            get
            {
                return _selarcombo;
            }

            set
            {
                if (_selarcombo == value)
                {
                    return;
                }

                _selarcombo = value;
                RaisePropertyChanged(selarcomboPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="requirements" /> property's name.
        /// </summary>
        public const string requirementsPropertyName = "requirements";

        private ObservableCollection<Requirement> _requirements ;
        /// <summary>
        /// The <see cref="currentJobid" /> property's name.
        /// </summary>
        public const string currentJobidPropertyName = "currentJobid";

        private long _currentJobid;

        /// <summary>
        /// Sets and gets the currentJobid property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public long currentJobid
        {
            get
            {
                return _currentJobid;
            }

            set
            {
                if (_currentJobid == value)
                {
                    return;
                }

                _currentJobid = value;
                RaisePropertyChanged(currentJobidPropertyName);
                getapplicants(_currentJobid);
            }
        }
        /// <summary>
        /// The <see cref="filepath" /> property's name.
        /// </summary>
        //public const string filepathPropertyName = "filepath";

        //private string _filepath;

        ///// <summary>
        ///// Sets and gets the filepath property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public string filepath
        //{
        //    get
        //    {
        //        return _filepath;
        //    }

        //    set
        //    {
        //        if (_filepath == value)
        //        {
        //            return;
        //        }

        //        _filepath = value;
        //        RaisePropertyChanged(filepathPropertyName);
        //    }
        //}

        private void getapplicants(long myjob)
        {
           requirements = _ds.getjobrequirements(myjob);
        }

        /// <summary>
        /// Sets and gets the requirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Requirement> requirements
        {
            get
            {
                return _requirements;
            }

            set
            {
                if (_requirements == value)
                {
                    return;
                }

                _requirements = value;
                RaisePropertyChanged(requirementsPropertyName);
            }
        }

        public RelayCommand ViewDoccom { get; set; }
        public RelayCommand EditDoccom { get; set; }
        public RelayCommand DelDoccom { get; set; }
        public RelayCommand SaveDoccom { get; set; }
        public RelayCommand NewDoccom { get; set; }
        public RelayCommand Browsecom { get; set; }
        public RelayCommand<DragEventArgs> DragFile { get; set; }
        public RelayCommand<DragEventArgs> PreviewDragEnterCommand { get; set; }

        private bool isselapplicantregistered;

        /// <summary>
        /// Gets the DelDoc.
        /// </summary>
     

        /// <summary>
        /// Initializes a new instance of the DocumentViewModel class.
        /// </summary>

        public DocumentViewModel(DataService ds)
        {
            _ds = ds;
            ReceiveSelectedApplicant();
            ViewDoccom = new RelayCommand(viewdoc);
            EditDoccom = new RelayCommand(editdoc);
            DelDoccom = new RelayCommand(deldoc);
            SaveDoccom = new RelayCommand(savedoc,()=> _selectedappreq != null);
            NewDoccom = new RelayCommand(newdoc);
            Browsecom = new RelayCommand(browse);
            DragFile = new RelayCommand<DragEventArgs>(dragtoTextBox);
            PreviewDragEnterCommand = new RelayCommand<DragEventArgs>(ExecutePreviewDragEnterCommand);
        }

     

        private void browse()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            //// Set filter for file extension and default file extension 
            //dlg.DefaultExt = ".png";
            //dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
               selectedappreq.localpath = filename;
                Savefiletodb(filename);

            }
        }

        private void Savefiletodb(string filepath)
        {
           
            FileStream myfs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] myarray= new byte[myfs.Length];
            myfs.Read(myarray, 0, (int) myfs.Length);
            myfs.Close();
            selectedappreq.document = myarray;
            selectedappreq.ext = filepath.Substring(filepath.IndexOf("."),filepath.Length-filepath.IndexOf("."));
            selectedappreq.localpath = filepath;
            _ds.Saveappreq(selectedappreq);

        }
            
        private void newdoc()
        {
            AppRequirement nar = new AppRequirement
            {
                Applicantid = selectedApplicant.id
                
           };
            selectedappreq = nar;
            if (apprequirements == null)
            {
                apprequirements = new ObservableCollection<AppRequirement>();
            }
            apprequirements.Add(selectedappreq);
        }

        private void savedoc()
        {
            if(selectedappreq!= null)
            { _ds.Saveappreq(selectedappreq);}
        }

        private void deldoc()
        {
            _ds.Deleteappreq(selectedappreq);
        }

        private void editdoc()
        {
            throw new NotImplementedException();
        }

        private void viewdoc()
        {
            OpenDocument();
        }

        void ReceiveSelectedApplicant()
        {
            if (isselapplicantregistered == false)

            {
                Messenger.Default.Register<ApplicantMessage>(this, (sa) =>
                {
                    selectedApplicant = sa.applicantm;
                    currentJobid = selectedApplicant.Jobid;
                    if (selectedApplicant != null)
                    {
                        var mylist = new ObservableCollection<appreqcombo>();
                        if (selectedApplicant.job.jobRequirements != null)
                        {

                            foreach (JobRequirement r in selectedApplicant.job.jobRequirements)
                            {
                                mylist.Add(new appreqcombo
                                {
                                    id = r.id,
                                    Requirementname = r.requirement.RequirementName
                                });
                            }
                        }
                        jobrequirements = mylist;
                        requirements = _ds.getAllRequirements();
  }
                    })
                    ;
                    isselapplicantregistered = true;
                }
        }

        string OpenDocument()
        {

            if (selectedappreq != null)
            {
                return Outlookrepos.Openfilefrombyte(selectedappreq.document, selectedappreq.ext,selectedappreq.id.ToString() +"ar");

            }
            else
            {
                return "no file selected";
            }
        }
        
        //     string Openfilefrombyte(byte[] myarray, string fileext, string filename)
        //     {
        //    Computer myComputer = new Computer();

        //       string  filenamef = myComputer.FileSystem.SpecialDirectories.Temp + @"\" + filename + "." +fileext;
        //    if (File.Exists(filenamef))
        //         {
        //             File.Delete(filenamef);
        //         }

        //      //save to file and open
        //    FileStream myfs = new FileStream(filenamef, FileMode.CreateNew);


        //         myfs.Write(myarray, 0, myarray.Length);
        //         myfs.Flush();
        //         myfs.Close();

        //    myfs = null;
        //         Process.Start(filenamef);

        //    return "OK";
        //}
        private void ExecutePreviewDragEnterCommand(DragEventArgs drgevent)
        {
            drgevent.Handled = true;
            drgevent.Effects = DragDropEffects.All;

            //// Check that the data being dragged is a file
            //if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
            //{
            //    // Get an array with the filenames of the files being dragged
            //    string[] files = (string[])drgevent.Data.GetData(DataFormats.FileDrop);

            //    if ((String.Compare(System.IO.Path.GetExtension(files[0]), ".xls", true) == 0)
            //        && files.Length == 1)
            //        drgevent.Effects = DragDropEffects.Move;
            //    else
            //        drgevent.Effects = DragDropEffects.None;

            //}
            //else
            //    drgevent.Effects = DragDropEffects.None;
        }
        private void dragtoTextBox( DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                selectedappreq.localpath = (string)e.Data.GetData("Text");
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames;
                string MyFilename;
                fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
                MyFilename = fileNames[0];
                selectedappreq.localpath = MyFilename;
                selectedappreq.ext = System.IO.Path.GetExtension(MyFilename);
                Savefiletodb(MyFilename);
            }
            else if (e.Data.GetDataPresent("RenPrivateItem"))
            {
                System.IO.MemoryStream thestream = (System.IO.MemoryStream)e.Data.GetData("FileGroupDescriptor");
                System.Text.StringBuilder filename = new System.Text.StringBuilder("");
                Byte[] fileGroupDescriptor = new Byte[700];
                try
                {
                    thestream.Read(fileGroupDescriptor, 0, 700);

                    int i = 76;
                    while (fileGroupDescriptor[i] != 0)
                    {
                        filename.Append(Convert.ToChar(fileGroupDescriptor[i]));
                        i += 1;
                    }


                    MemoryStream os = (MemoryStream)e.Data.GetData("FileContents", true);
                    selectedappreq.localpath = "Outlook attachment_" + filename.ToString();
                    selectedappreq.ext =  System.IO.Path.GetExtension(selectedappreq.localpath);
                    using (var ns = new MemoryStream())
                    {
                        os.CopyTo(ns);
                        selectedappreq.document = os.ToArray();
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Only file can be dragged into this box");
                }

                finally
                {
                    if (thestream != null)
                    {
                        thestream.Close();
                    }
                }
            }

        }
    }
    }
