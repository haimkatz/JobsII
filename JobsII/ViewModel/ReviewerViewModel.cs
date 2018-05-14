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
using System.Linq;

namespace JobsII.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ReviewerViewModel : ViewModelBase
    {
        private DataService _ds;
        private bool isjobregistered = false;
        private Guid myguid;
        /// <summary>
        /// The <see cref="Persons" /> property's name.
        /// </summary>
        public const string PersonsPropertyName = "Persons";

        private ObservableCollection<Models.Person> _persons;

        /// <summary>
        /// Sets and gets the Persons property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Models.Person> Persons
        {
            get { return _persons; }

            set
            {
                if (_persons == value)
                {

                    return;
                }

                _persons = value;
                if (selectedperson == null)
                {
                    if (_persons.Count > 0)
                    {
                        selectedperson = _persons[0];
                    }

                }
                RaisePropertyChanged(PersonsPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedperson" /> property's name.
        /// </summary>
        public const string selectedPersonPropertyName = "selectedperson";

        private Models.Person _selectedPerson;

        /// <summary>
        /// Sets and gets the selectedperson property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Models.Person selectedperson
        {
            get { return _selectedPerson; }

            set
            {
                if (_selectedPerson == value)
                {
                    return;
                }

                _selectedPerson = value;
                RaisePropertyChanged(selectedPersonPropertyName);
                SavePerson.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// The <see cref="revstatuses" /> property's name.
        /// </summary>
        public const string revstatusesPropertyName = "revstatuses";

        private ObservableCollection<ReviewerStatus> _revstatuses;

        /// <summary>
        /// Sets and gets the revstatuses property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ReviewerStatus> revstatuses
        {
            get { return _revstatuses; }

            set
            {
                if (_revstatuses == value)
                {
                    return;
                }

                _revstatuses = value;
                RaisePropertyChanged(revstatusesPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="searchtext" /> property's name.
        /// </summary>
        public const string searchtextPropertyName = "searchtext";

        private string _searchtext = "";

        /// <summary>
        /// Sets and gets the searchtext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string searchtext
        {
            get { return _searchtext; }

            set
            {
                if (_searchtext == value)
                {
                    return;
                }

                _searchtext = value;
                RaisePropertyChanged(searchtextPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="reviewers" /> property's name.
        /// </summary>
        public const string reviewersPropertyName = "reviewers";

        private ObservableCollection<Reviewer> _reviewers;

        /// <summary>
        /// Sets and gets the reviewers property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Reviewer> reviewers
        {
            get { return _reviewers; }

            set
            {
                if (_reviewers == value)
                {
                    return;
                }

                _reviewers = value;
                RaisePropertyChanged(reviewersPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedReviewer" /> property's name.
        /// </summary>
        public const string selectedReviewerPropertyName = "selectedReviewer";

        private Reviewer _selectedReviewer;

        private bool isselapplicantregistered;

        /// <summary>
        /// Sets and gets the selectedReviewer property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Reviewer selectedReviewer
        {
            get
            {
                return _selectedReviewer;
                ;
            }

            set
            {
                if (_selectedReviewer == value)
                {
                    return;
                }

                _selectedReviewer = value;
                RaisePropertyChanged(selectedReviewerPropertyName);
                SendEmail.RaiseCanExecuteChanged();
                SaveReviewer.RaiseCanExecuteChanged();
                DeletePerson.RaiseCanExecuteChanged();
            }
        }

        public const string selectedJobPropertyName = "selectedJob";
        private Job _selectedjob;

        /// <summary>
        /// Sets and gets the selectedJob property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Job selectedJob
        {
            get { return _selectedjob; }

            set
            {
                if (_selectedjob == value)
                {
                    return;
                }

                _selectedjob = value;
                RaisePropertyChanged(selectedJobPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="selectedApplicant" /> property's name.
        /// </summary>
        public const string selectedApplicantPropertyName = "selectedApplicant";

        private Applicant _selectedApplicant;
        private bool isnewrevmessageregistered = false;

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
            }
        }

        /// <summary>
        /// The <see cref="lettercombos" /> property's name.
        /// </summary>
        public const string lettercombosPropertyName = "lettercombos";

        private ObservableCollection<MergeDoc> _lettercombos;

        /// <summary>
        /// Sets and gets the lettercombos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MergeDoc> lettercombos
        {
            get
            {
                return _lettercombos;
            }
            set
            {
                Set(lettercombosPropertyName, ref _lettercombos, value);
            }
        }
        /// <summary>
        /// The <see cref="sellettercombo" /> property's name.
        /// </summary>
        public const string sellettercomboPropertyName = "sellettercombo";

        private MergeDoc _sellettercombo;

        /// <summary>
        /// Sets and gets the sellettercombo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MergeDoc sellettercombo
        {
            get
            {
                return _sellettercombo;
            }
            set
            {
                Set(sellettercomboPropertyName, ref _sellettercombo, value);
            }
        }

        void ReceiveSelectedJob()
        {
            if (isjobregistered == false)
                //if (selectedJob != null)
            {
                Messenger.Default.Register<JobMessage>(this, (Jobm) => {
                                                                           this.selectedJob = Jobm.jobm;
                });
                isjobregistered = true;
            }
        }

        void ReceiveSelectedApplicant()
        {
            if (isselapplicantregistered == false)
                //if (selectedJob != null)
            {
                Messenger.Default.Register<ApplicantMessage>(this, getreviewers);
                isselapplicantregistered = true;
            }
        }

        private void ReceiveNewReviewer()
        {
            if (isnewrevmessageregistered == false)
            {
                Messenger.Default.Register<newReviewerMessage>(this, addnewrev);
            }
        }

        private void addnewrev(newReviewerMessage obj)
        {
            if (obj != null)
            {
                if (!reviewers.Contains(obj.newreviewer))
                {
                    reviewers.Add(obj.newreviewer);
                }
            }
        }

        private void getreviewers(ApplicantMessage obj)
        {
            selectedApplicant = obj.applicantm;
            if (selectedApplicant != null)
            {
                reviewers = _ds.getreviewersbyappid(selectedApplicant.id);
            }
        }

        private void saveareviewer()
        {
            _ds.SaveReviewer(selectedReviewer);

        }

        /// <summary>
        /// Initializes a new instance of the ReviewerViewModel class.
        /// </summary>
        public RelayCommand NewPerson { get; set; }

        //public RelayCommand<Models.Person> SavePerson { get; set; }
        public RelayCommand SavePerson { get; set; }
        public RelayCommand SearchPerson { get; set; }
        public RelayCommand<Person> changeSelectedPerson { get; set; }
        public RelayCommand DeletePerson { get; set; }
        public RelayCommand SendEmail { get; set; }
      public RelayCommand ViewDoccom { get; set; }
        public RelayCommand EditDoccom { get; set; }
        public RelayCommand DelDoccom { get; set; }
        public RelayCommand SaveDoccom { get; set; }
        public RelayCommand NewDoccom { get; set; }
        public RelayCommand Browsecom { get; set; }
        public RelayCommand<DragEventArgs> DragFile { get; set; }
        public RelayCommand<DragEventArgs> PreviewDragEnterCommand { get; set; }
        public RelayCommand SaveReviewer { get; set; }
       
        private void findperson(ApplicantMessage obj)
        {
            foreach (Person p in Persons)
            {
                if (p.id == obj.applicantm.Personid)
                {
                    selectedperson = p;
                    break;
                }
            }
        }

        private  void deletePerson()
        {
            Reviewer obj = selectedReviewer;
            try
            {
                 _ds.DeleteReviewer(obj);
                reviewers.Remove(obj);
            }

            catch (Exception e)
            {
                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }

        }

        //private void newPerson(Person nperson)
        //{
        //    if (nperson != null)
        //    {
        //        selectedperson = nperson;
        //    }
        //}
        private void newPerson()
        {
            selectedperson = new Person();
            Messenger.Default.Send<persontoeditmessage>(new persontoeditmessage
            {
                person = selectedperson,
                sendingWindow = myguid
            });
        }

        private async void searchforaperson()
        {
            try
            {
                Tuple<ObservableCollection<Person>, Person> mytuple =
                await Repository.Utilities.findaperson(Persons, selectedperson, searchtext, _ds);
                Persons = mytuple.Item1;
                selectedperson = mytuple.Item2;

                if (selectedperson == null && _selectedReviewer != null)
            {
                selectedperson = _selectedReviewer.person;
            }
        }

    catch (Exception ex)
            {

                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });
            }

        }

        private async void saveallpersons()
        {
            await _ds.SavePerson(Persons);
        }

        private async void saveaperson()
        {
            await _ds.SavePerson(_selectedPerson);
            AddReviewer();
        }

        private bool personexists()
        {
            return (_selectedPerson != null);
        }
        private void AddReviewer()
        {
            //try
            //{
            //    await _ds.SavePerson(selectedperson);
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            if (_selectedPerson != null)
            {
                Reviewer nr = new Reviewer
                {
                    Applicantid = selectedApplicant.id,
                    Personid = _selectedPerson.id,
                    Statusid = 1
                };
           
            selectedReviewer = nr;
            addtoreviwers();
            _ds.SaveReviewer(nr);
        }
    }

        private void addtoreviwers()
        {
            if (reviewers == null)
            {
                reviewers = new ObservableCollection<Reviewer>();
            }
            reviewers.Add(selectedReviewer);
        }

        private void sendemailtoreviewer()
        {
            ObservableCollection<string> emails = new ObservableCollection<string>();
            string mybody;
            string mysubject;
            ObservableCollection<filemessage> myattachfiles = new ObservableCollection<filemessage>();
            try
            {
                if (sellettercombo != null)
                {
                    MergeDoc md = getmergedoc(sellettercombo.id);
                    mybody = retrieveBody(md.htmltext, selectedReviewer);
                    string emailtype = _ds.GeMessageType(sellettercombo.id);


                    if (String.IsNullOrEmpty(selectedReviewer.person.email) == false)
                    {
                        emails.Add(selectedReviewer.person.email);
                    }


                    if (emailtype == "request" || emailtype == "remind")
                    {
                        foreach (
                            var ar in
                                _selectedApplicant.apprequirements.ToList()
                                    .Where(ar => ar.jobrequirement.sendtoreviewer == true))

                        {
                            filemessage fm = new filemessage
                            {
                                filename =
                                    _selectedApplicant.person.lastname + "_" +
                                    ar.jobrequirement.requirement.RequirementName,
                                ext = ar.ext,
                                doccontent = ar.document
                            };
                            myattachfiles.Add(fm);
                        }  //end foreach
                    
                    foreach (var jd in _selectedApplicant.job.jobdocs.ToList().Where(jd => (jd.sendtoreviewer == true && jd.universaldoc?.languageid == md.languageid)
                            || ( jd.sendtoreviewer == true && jd.languageid == md.languageid)))
                    {
                        filemessage fm;
                        if (jd.universaldoc == null)
                        {
                            fm = new filemessage
                            {
                                filename = jd.DocName,
                                ext = jd.ext,
                                doccontent = jd.document
                            };
                        }
                        else
                        {
                            fm = new filemessage
                            {
                                filename = jd.universaldoc.DocName,
                                ext = jd.universaldoc.ext,
                                doccontent = jd.universaldoc.document
                            };

                        }
                        myattachfiles.Add(fm);
                    }
                } // end if request or remind
                mysubject = getsubject(md.language.language, _selectedApplicant.job.jobfullname);
                    Outlookrepos.CreateOutlookMail(emails, mybody, mysubject, myattachfiles, true);
                    updateReviewer(emailtype);
                }
                else { MessageBox.Show("תבחרי סוג מכתב"); }
            }
            catch (Exception ex)
            {
                Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });

            }
        }

        private string getsubject( string lng, string addedtext)
        {
         
                    if (lng =="Eng")
                    {
                        return "Reference for " + addedtext; 
                       }
                    else { return " חוות דעת ל" + addedtext; }
                    
             
            }
        
        private void updateReviewer(string messagetype)
        {
            switch (messagetype)
            {
                case "request":
                    selectedReviewer.datesent = DateTime.Today;
                    selectedReviewer.reminderdate = DateTime.Today.AddDays(21);
                    selectedReviewer.Statusid = 2;
                    break;
                case "thank":
                    selectedReviewer.datereceived = DateTime.Today;
                    selectedReviewer.reminderdate = null;
                    selectedReviewer.Statusid = 4;
                    break;
                case "remind":
 selectedReviewer.reminderdate = DateTime.Today.AddDays(5);
                    break;
                case "refuse":
                    selectedReviewer.datereceived = DateTime.Today;
                    selectedReviewer.reminderdate = null;
                    selectedReviewer.Statusid = 5;
                    break;
                    
            }
            try
            {
                _ds.SaveReviewer(selectedReviewer);
            }
            catch ( Exception e)
            {

                Messenger.Default.Send<errormessage>(new errormessage {errormsg = e.Message, isvisible = true});
            }
        }
        private string retrieveBody(string body, Reviewer rev)
        {
            //string lang = rev.person.country == "IL" ? "Hebrew" : "English";
            //string letter = _ds.GetLetter( messagetype,  lang, "רפרנט")
            //;
            //string letter = _ds.GetLetter(letterid);
           
            ReviewerMergeFields rmf = Utilities.GetReviewerMergeFieldsbyReviewer(rev);
            return Utilities.mailmerge(rmf, body);

        }

        private MergeDoc getmergedoc(long letterid)
        {
            return _ds.getMergeDoc( letterid);
            
            ;
        }
        private void getnewperson(personreturnedmessage obj)
        {
            if (!obj.iscancelled && obj.sourceWindow == myguid)
            {
                selectedperson = obj.personedit;
                AddReviewer();
            }
        }

        public ReviewerViewModel(DataService ds)


        {
            this._ds = ds;
            myguid = Guid.NewGuid();
            ReceiveSelectedApplicant();
            Messenger.Default.Register<personreturnedmessage>(this, getnewperson);
            //ReceiveSelectedJob();
            SaveReviewer = new RelayCommand(saveareviewer, reviewerexists);
            NewPerson = new RelayCommand(newPerson);
            SavePerson = new RelayCommand(AddReviewer, personexists); // add applicant

            SearchPerson = new RelayCommand(searchforaperson);
            //changeSelectedPerson = new RelayCommand(NewPerson);
            DeletePerson = new RelayCommand(deletePerson,reviewerexists);
            SendEmail = new RelayCommand(sendemailtoreviewer, reviewerexists);
            ViewDoccom = new RelayCommand(viewdoc);
            EditDoccom = new RelayCommand(editdoc);
            DelDoccom = new RelayCommand(deldoc);

            Browsecom = new RelayCommand(browse);
            DragFile = new RelayCommand<DragEventArgs>(dragtoTextBox);
            PreviewDragEnterCommand = new RelayCommand<DragEventArgs>(ExecutePreviewDragEnterCommand);
            lettercombos = _ds.getlettercombobyVMtype("רפרנט");
        }

        private bool reviewerexists(string v)
        {
            return reviewerexists();
        }

        private bool reviewerexists()
        {
            return (_selectedReviewer != null);
        }
        #region Documents
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
                selectedReviewer.localpath = filename;
                Savefiletodb(filename);

            }
        }

        private void Savefiletodb(string filepath)
        {

            FileStream myfs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] myarray = new byte[myfs.Length];
            myfs.Read(myarray, 0, (int) myfs.Length);
            myfs.Close();
            selectedReviewer.document = myarray;
            selectedReviewer.ext = filepath.Substring(filepath.IndexOf("."), filepath.Length - filepath.IndexOf("."));
            selectedReviewer.localpath = filepath;


        }
        
        private void deldoc()
        {
            selectedReviewer.document = null;
            _ds.SaveReviewer(selectedReviewer);
        }

        private void editdoc()
        {
           
        }

        private void viewdoc()
        {
            OpenDocument();
        }

        string OpenDocument()
        {

            if (selectedReviewer.document != null)
            {
                return Openfilefrombyte(selectedReviewer.document, selectedReviewer.ext,
                    selectedReviewer.id.ToString() + selectedReviewer.person.lastname);

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
                selectedReviewer.localpath = (string) e.Data.GetData("Text");
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
 string[] fileNames;
                string MyFilename;
                fileNames = (string[]) (e.Data.GetData(DataFormats.FileDrop));
                MyFilename = fileNames[0];
                selectedReviewer.localpath = MyFilename;
                selectedReviewer.ext = System.IO.Path.GetExtension(MyFilename);
                Savefiletodb(MyFilename);
                }
                catch (Exception ex)
                {

                    Messenger.Default.Send<errormessage>(new errormessage { errormsg = ex.Message, isvisible = true });
                }
               
            }
            else if (e.Data.GetDataPresent("RenPrivateItem"))
            {
                System.IO.MemoryStream thestream = (System.IO.MemoryStream) e.Data.GetData("FileGroupDescriptor");
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


                    MemoryStream os = (MemoryStream) e.Data.GetData("FileContents", true);
                    selectedReviewer.localpath = "Outlook attachment_" + filename.ToString();
                    selectedReviewer.ext = System.IO.Path.GetExtension(selectedReviewer.localpath);
                    using (var ns = new MemoryStream())
                    {
                        os.CopyTo(ns);
                        selectedReviewer.document = os.ToArray();
                    }
                } //end try


                catch (Exception )
                {
                    Messenger.Default.Send<errormessage>(new errormessage { errormsg = "רק קבצים אפשר לגרור פה", isvisible = true });
                }

                finally
                {
                    if (thestream != null)
                    {
                        thestream.Close();
                    }
                }  //end try block
 }
                updateReviewer("thank");
               
                int langid;
                if (selectedReviewer.person.country == "Il")
                {
                    langid = 2;//Hebrew
                }
                else
                {
                    langid = 1;}//English
                sellettercombo = _ds.getMergedocbyLangMergetypeDoctype(langid, 3, "רפרנט"); //thank id
                sendemailtoreviewer();
                

           
        }
        #endregion

    }
}