using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Outlook;
using Microsoft.VisualBasic.Devices;
using System.IO.Pipes;
using GalaSoft.MvvmLight.Ioc;
using JobsII.ViewModel;

namespace JobsII.Repository
{
    class Outlookrepos
    {
        static Outlookrepos()
        {

        }

        //private static bool m_catchevents = false;
        private static Application olApp;

        //private static string xslpath;

        public static string getfilepath { get; set; }
        public static byte saveflag { get; set; }

        public static Application g_myapp
        {
            get
            {
                if (olApp == null)
                {
                    olApp = new Application();
                }
                return olApp;
            }
            set
            {
                if (value == null)
                {
                    olApp = null;
                }
                else
                {
                    olApp = value;
                }
            }
        }

        public bool catchevents { get; set; }

        public static void CreateOutlookMail(ObservableCollection<string> emails, string mybody, string mysubject,
            ObservableCollection<filemessage> myattachfiles, bool withhtml)
        {
            MailItem olMailMessage;
            Recipient olRecipient;
            //bool blnKnownRecipient;
            int i;
            //    ' Create new instance of Outlook or open current instance.
            //    ' olApp = New Outlook.Application
            //    ' Create new message.
            olMailMessage = g_myapp.CreateItem(OlItemType.olMailItem);


            for (i = 0; i < emails.Count; i++)
            {
                if (emails[i] != null)
                {
                    olRecipient = olMailMessage.Recipients.Add(emails[i]);
                }
            }
            olMailMessage.Subject = mysubject;
            if (withhtml)
            {
                olMailMessage.HTMLBody = mybody;
            }
            else
            {
                olMailMessage.Body = mybody;
            }
            //        'display message
            olMailMessage.Display();
            if (myattachfiles.Count > 0)
            {
                for (i = 0; i < myattachfiles.Count; i++)
                {
                    olMailMessage.Attachments.Add(openfilefromArray(myattachfiles[i]));
                }
            }



        }

        private static string openfilefromArray(filemessage v)
        {
            MemoryStream mystr = new MemoryStream(v.doccontent);

            Computer myComputer = new Computer();

            string filepath = myComputer.FileSystem.SpecialDirectories.Temp + @"\";
            string filename = filepath + v.filename + "." + v.ext;
            //'opentemplate
            if (File.Exists(filename))

            {
                File.Delete(filename);
            }




            //'*****
            FileStream myfs = new FileStream(filename, FileMode.CreateNew);


            myfs.Write(v.doccontent, 0, v.doccontent.Length);
            myfs.Flush();
            myfs.Close();
            //if (openit)
            //{
            //    Process.Start(filename);
            //}

            return filename;
        }

        public static string Openfilefrombyte(byte[] myarray, string fileext, string filename)
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





            //    End With
            //    olMailMessage = Nothing

            //End Sub
        }

       
    }
}






//Function CreateAppointment(Description As String, mydate As Date) As String
    //    Try
    //        Dim olAppointment As Outlook.AppointmentItem

    //        olAppointment = g_myapp.CreateItem(Outlook.OlItemType.olAppointmentItem)
    //        With olAppointment
    //            .Start = mydate
    //            .Duration = 1
    //            .Subject = Description
    //            .ReminderMinutesBeforeStart = 15
    //            .ReminderSet = True
    //            .Save()
    //        End With
    //        Return "OK"
    //    Catch ex As Exception
    //        Return ex.Message
    //    End Try


    //End Function
    //Sub CreateOutlookMail(ByVal myds As DataSet, ByVal mybody As String, ByVal mysubject As String, ByVal myattachds As CorrespDS)
    //    CreateOutlookMail(myds, mybody, mysubject, myattachds, False, False)
    //End Sub

  
    //Sub CreateOutlookMail(ByVal myds As DataSet, ByVal mybody As String, ByVal mysubject As String)
    //    Dim myattachds As New CorrespDS
    //    CreateOutlookMail(myds, mybody, mysubject, myattachds)
    //End Sub

    //Private Sub olApp_ItemSend(ByVal Item As Object, ByRef Cancel As Boolean) Handles olApp.ItemSend
    //    Try
    //        If catchevents Then
    //            Dim myrow As CorrespDS.CorrespondenceRow = Me.CorrespDS1.Correspondence.Rows(0)
    //            Dim olMailMessage As Outlook.MailItem = CType(Item, Outlook.MailItem)
    //            olMailMessage.SaveAs(filepath & myrow.Correspid.ToString & ".msg")

    //            Dim myfs As New IO.FileStream(filepath & myrow.Correspid.ToString & ".msg", IO.FileMode.Open)
    //            Dim myarray(myfs.Length) As Byte
    //            myfs.Read(myarray, 0, myfs.Length)
    //            myfs.Close()

    //            myrow.BeginEdit()
    //            myrow.Documentfield = myarray
    //            myrow.Appname = "Microsoft Outlook"
    //            myrow.EndEdit()
    //            Me.SDA_Correspondence.Update(Me.CorrespDS1.Correspondence)
    //            catchevents = False
    //        End If
    //    Catch mye As Exception
    //        Throw mye
    //    Finally


    //    End Try

    //End Sub
 