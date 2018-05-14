using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Models;
using JobsII.Repository;
using System.Windows;
using Microsoft.VisualBasic.Devices;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class JobDocViewModel : ViewModelBase
    {
        private DataService _ds;

        /// <summary>
        

        /// <summary>
        /// The <see cref="jobdocs" /> property's name.
        /// </summary>
        public const string jobdocsPropertyName = "jobdocs";

        private ObservableCollection<jobDoc> _jobdocs;

        /// <summary>
        /// Sets and gets the apprequirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<jobDoc> Jobdocs
        {
            get { return _jobdocs; }

            set
            {
                if (_jobdocs == value)
                {
                    return;
                }

                _jobdocs = value;
                RaisePropertyChanged(jobdocsPropertyName);
                if (Selecteddoc == null && _jobdocs != null)
                {
                    if (_jobdocs.Count > 0)
                    {
                        Selecteddoc = _jobdocs[0];
                    }
                    else
                    {
                        _jobdocs = new ObservableCollection<jobDoc>();
                    }
                }
            }
        }
        /// <summary>
        /// The <see cref="selecteddoc" /> property's name.
        /// </summary>
        public const string selecteddocPropertyName = "selecteddoc";

        private jobDoc _selecteddoc;

        /// <summary>
        /// Sets and gets the selectedappreq property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public jobDoc Selecteddoc
        {
            get
            {
                return _selecteddoc;
            }

            set
            {
                if (_selecteddoc == value)
                {
                    return;
                }

                _selecteddoc = value;
                RaisePropertyChanged(selecteddocPropertyName);
            }
        }

     
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
                getjobDocs(_currentJobid);
            }
        }
        /// <summary>
        /// The <see cref="filepath" /> property's name.
        /// </summary>
      

        private void getjobDocs(long myjob)
        {
            Jobdocs = _ds.getjobdocs(myjob);
        }

        /// <summary>
        /// Sets and gets the requirements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
      

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

        public JobDocViewModel(DataService ds)
        {
            _ds = ds;
            ReceiveSelectedjob();
            ViewDoccom = new RelayCommand(viewdoc);
            EditDoccom = new RelayCommand(editdoc);
            DelDoccom = new RelayCommand(deldoc);
            SaveDoccom = new RelayCommand(savedoc);
            NewDoccom = new RelayCommand(newdoc);
            Browsecom = new RelayCommand(browse);
            DragFile = new RelayCommand<DragEventArgs>(dragtoTextBox);
            PreviewDragEnterCommand = new RelayCommand<DragEventArgs>(ExecutePreviewDragEnterCommand);
        }

        private void ExecutePreviewDragEnterCommand(DragDropEffects obj)
        {
            throw new NotImplementedException();
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
                Selecteddoc.localpath = filename;
                Savefiletodb(filename);

            }
        }

        private void Savefiletodb(string filepath)
        {

            FileStream myfs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] myarray = new byte[myfs.Length];
            myfs.Read(myarray, 0, (int)myfs.Length);
            myfs.Close();
            Selecteddoc.document = myarray;
            Selecteddoc.ext = filepath.Substring(filepath.IndexOf("."), filepath.Length - filepath.IndexOf("."));
            Selecteddoc.localpath = filepath;
            _ds.SavejobDoc(Selecteddoc);

        }

        private void newdoc()
        {
            jobDoc nar = new jobDoc()
            {
                jobid = currentJobid,
                dateupdated = DateTime.Today,
                sendtocommittee = false,
                sendtoreviewer = true
            };
            Selecteddoc = nar;
            if (Jobdocs == null)
            {
                Jobdocs = new ObservableCollection<jobDoc>();
            }
            Jobdocs.Add(Selecteddoc);
        }

        private void savedoc()
        {
            _ds.SavejobDoc(Selecteddoc);
        }

        private void deldoc()
        {
            _ds.DeletejobDoc(Selecteddoc);
        }

        private void editdoc()
        {
            throw new NotImplementedException();
        }

        private void viewdoc()
        {
            OpenDocument();
        }

        void ReceiveSelectedjob()
        {
            if (isselapplicantregistered == false)

            {
                Messenger.Default.Register<JobMessage>(this, (sa) =>
                {
                    currentJobid = sa.jobm.id;
                   
                })
                ;
                isselapplicantregistered = true;
            }
        }

        string OpenDocument()
        {

            if (Selecteddoc != null)
            {
                return Openfilefrombyte(Selecteddoc.document, Selecteddoc.ext, Selecteddoc.id.ToString() + "ar");

            }
            else
            {
                return "no file selected";
            }
        }

        string Openfilefrombyte(byte[] myarray, string fileext, string filename)
        {
            Computer myComputer = new Computer();

            string filenamef = myComputer.FileSystem.SpecialDirectories.Temp + @"\" + filename + "." + fileext;
            if (File.Exists(filenamef))
            {
                File.Delete(filenamef);
            }

            //save to file and open
            FileStream myfs = new FileStream(filenamef, FileMode.CreateNew);


            myfs.Write(myarray, 0, myarray.Length);
            myfs.Flush();
            myfs.Close();

            myfs = null;
            Process.Start(filenamef);

            return "OK";
        }
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
        private void dragtoTextBox(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                Selecteddoc.localpath = (string)e.Data.GetData("Text");
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames;
                string MyFilename;
                fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
                MyFilename = fileNames[0];
                Selecteddoc.localpath = MyFilename;
                Selecteddoc.ext = System.IO.Path.GetExtension(MyFilename);
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
                    Selecteddoc.localpath = "Outlook attachment_" + filename.ToString();
                    Selecteddoc.ext = System.IO.Path.GetExtension(Selecteddoc.localpath);
                    using (var ns = new MemoryStream())
                    {
                        os.CopyTo(ns);
                        Selecteddoc.document = os.ToArray();
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
