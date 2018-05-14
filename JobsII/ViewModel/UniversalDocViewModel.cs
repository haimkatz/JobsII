using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using JobsII.Models;
using JobsII.Repository;
using Microsoft.VisualBasic.Devices;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>






    public class UniversalDocViewModel : ViewModelBase
    {

        private DataService _ds;

        /// <summary>
        /// Initializes a new instance of the UniversalDocViewModel class.
        /// </summary>
        /// <summary>
        /// The <see cref="universaldocs" /> property's name.
        /// </summary>
        public const string MyPropertyPropertyName = "universaldocs";

        private ObservableCollection<UniversalDoc> _universaldocs ;

        /// <summary>
        /// Sets and gets the MyProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<UniversalDoc> Universaldocs
        {
            get
            {
                return _universaldocs;
            }

            set
            {
                if (_universaldocs == value)
                {
                    return;
                }

                _universaldocs = value;
                RaisePropertyChanged(MyPropertyPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="selectedDoc" /> property's name.
        /// </summary>
        public const string selectedDocPropertyName = "selectedDoc";

        private UniversalDoc _selectedDoc;

        /// <summary>
        /// Sets and gets the selectedDoc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public UniversalDoc selectedDoc
        {
            get
            {
                return _selectedDoc;
            }

            set
            {
                if (_selectedDoc == value)
                {
                    return;
                }

                _selectedDoc = value;
                RaisePropertyChanged(selectedDocPropertyName);
            }
        }

        #region "Relay commands"

        public RelayCommand SearchTxt { get; set; }
        public RelayCommand SaveDoc { get; set; }
        public RelayCommand NewDoc { get; set; }
        public RelayCommand DelDoc { get; set; }
        public RelayCommand Browse { get; set; }
        public RelayCommand OpenDoc { get; set; }
        public RelayCommand<DragEventArgs> DragFile { get; set; }
        public RelayCommand<DragEventArgs> PreviewDragEnterCommand { get; set; }
        #endregion
        public UniversalDocViewModel(DataService ds)
        {
            _ds = ds;
            SearchTxt = new RelayCommand(searchtext);
            NewDoc = new RelayCommand(newdoc);
            DelDoc = new RelayCommand(deldoc);
            Browse = new RelayCommand(browse);
            OpenDoc = new RelayCommand(viewdoc);
            SaveDoc = new RelayCommand(savedoc);
            DragFile = new RelayCommand<DragEventArgs>(dragtoTextBox);
            PreviewDragEnterCommand = new RelayCommand<DragEventArgs>(ExecutePreviewDragEnterCommand);
            Universaldocs  = _ds.getUniversaldocs();

        }

    

       

       
       

        private void searchtext()
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
                selectedDoc.localpath = filename;
                Savefiletodb(filename);

            }
        }

        private void Savefiletodb(string filepath)
        {

            FileStream myfs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] myarray = new byte[myfs.Length];
            myfs.Read(myarray, 0, (int)myfs.Length);
            myfs.Close();
            selectedDoc.document = myarray;
            selectedDoc.ext = filepath.Substring(filepath.IndexOf("."), filepath.Length - filepath.IndexOf("."));
            selectedDoc.localpath = filepath;
            _ds.Saveunivdoc(selectedDoc);
           }

        private void newdoc()
        {
            UniversalDoc doc = new UniversalDoc
            {
                dateupdated = DateTime.Today
            };
            Universaldocs.Add(doc);
            selectedDoc = doc;
           
            
        }

        private void savedoc()
        {
            selectedDoc.dateupdated = DateTime.Today;
            _ds.Saveunivdoc(selectedDoc);
        }

        private void deldoc()
        {
            _ds.DeleteUnivsaldoc(selectedDoc);
        }

        private void editdoc()
        {
            throw new NotImplementedException();
        }

        private void viewdoc()
        {
            OpenDocument();
        }

      

        string OpenDocument()
        {

            if (selectedDoc != null)
            {
                return Openfilefrombyte(selectedDoc.document, selectedDoc.ext, selectedDoc.id.ToString() + "ud");
                
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
                selectedDoc.localpath = (string)e.Data.GetData("Text");
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] fileNames;
                string MyFilename;
                fileNames = (string[])(e.Data.GetData(DataFormats.FileDrop));
                MyFilename = fileNames[0];
                selectedDoc.localpath = MyFilename;
                selectedDoc.ext = System.IO.Path.GetExtension(MyFilename);
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
                    selectedDoc.localpath = "Outlook attachment_" + filename.ToString();
                    selectedDoc.ext = System.IO.Path.GetExtension(selectedDoc.localpath);
                    using (var ns = new MemoryStream())
                    {
                        os.CopyTo(ns);
                        selectedDoc.document = os.ToArray();
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