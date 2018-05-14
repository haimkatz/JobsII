using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using JobsII.Models;
using System.Diagnostics;

namespace JobsII.Repository
{
    class Utilities
    {
        public static async Task<Tuple<ObservableCollection<Person>,Person>> findaperson(ObservableCollection<Person> Persons, 
            Person selectedperson, string searchtext, DataService ds)
        {


            if (searchtext.Length > 1)
            {
                Persons = await ds.FindPerson(searchtext);
                if (Persons.Count > 0)
                {
                    selectedperson = Persons[0];
                  
                }
            }
            else if (searchtext.Length == 0)
            {
                Persons.Clear();

                selectedperson = null;

            }
            return new Tuple<ObservableCollection<Person>, Person>(Persons, selectedperson);
        }
        public static ReviewerMergeFields GetReviewerMergeFieldsbyReviewer(Reviewer rev)
        {
            ReviewerMergeFields mrev = new ReviewerMergeFields
            {
                revFirstName = rev.person.firstname,
                revLastName = rev.person.lastname,
              revemail = rev.person.email,
                appemail = rev.applicant.person.email,
                appFirstNameEng = rev.applicant.person.firstname,
                appLastNameEng = rev.applicant.person.lastname,
                appFirstNameHeb = rev.applicant.person.firstnameh,
                appLastnameHeb = rev.applicant.person.lastnameh,
                jobfullname = rev.applicant.job.jobfullname,
                jobshortname = rev.applicant.job.jobshortname,
                jobEnglishname=rev.applicant.job.jobnameEnglish,
                datesent = String.Format("{0:dd/M/yy}", rev.datesent),
                DeptnameEng = rev.applicant.job.department.Efullname,
                DeptnameHeb = rev.applicant.job.department.fullname,
                InstNameEng = rev.applicant.job.department.institute.efullname,
                InstNameHeb = rev.applicant.job.department.institute.fullname,
                app_HeShe = rev.applicant.person.sexfield.HeShe,
                app_heshe_s = rev.applicant.person.sexfield.heshe_s,
                app_HisHer = rev.applicant.person.sexfield.HisHer,
                app_hisher_s = rev.applicant.person.sexfield.hisher_s,
                app_VavHeh = rev.applicant.person.sexfield.VavHeh,
                app_HooHee = rev.applicant.person.sexfield.HooHee,
                rev_atatah = rev.person.sexfield.atatah

            };
            return mrev;
        }
        public static applicantMergeFields GetapplicantMergeFieldsbyApplicant(Applicant applicant)
        {
            applicantMergeFields arev = new applicantMergeFields
            {

                appemail = applicant.person.email,
                appFirstNameHeb = applicant.person.firstname,
                appLastnameHeb = applicant.person.lastname,
                appFirstNameEng = applicant.person.firstnameh,
                appLastNameEng = applicant.person.lastnameh,
                jobfullname = applicant.job.jobfullname,
                jobshortname = applicant.job.jobshortname,
                jobEnglishname = applicant.job.jobnameEnglish,
                DeptnameEng = applicant.job.department.Efullname,
                DeptnameHeb = applicant.job.department.fullname,
                InstNameEng = applicant.job.department.institute.efullname,
                InstNameHeb = applicant.job.department.institute.fullname,
                dateapplied = String.Format("{0:dd/M/yy}", applicant.dateapplied),
                app_atatah = applicant.person.sexfield.atatah,
                app_VavHeh = applicant.person.sexfield.VavHeh
            };
            return arev;
        }

        public static CommitteeMergeFields GetCommitteeMergeFieldsbyJob(Job j)
        {
            CommitteeMergeFields mj = new CommitteeMergeFields
            {
                ChairFirstNameEng = j.coordinator.firstname,
                ChairFirstNameHeb = j.coordinator.firstnameh,
                ChairLastNameEng = j.coordinator.lastname,
                ChairLastnameHeb = j.coordinator.lastnameh,
                DeptnameEng = j.department.Efullname,
                DeptnameHeb = j.department.fullname,
                FirstMeetingDate = String.Format("{0:dd/M/yy}", j.meetingdate1),
                InstNameEng = j.department.institute.efullname,
                InstNameHeb = j.department.institute.fullname,
                jobfullname = j.jobfullname,
                jobshortname = j.jobshortname,
                jobEnglishname = j.jobnameEnglish,
                NumberofCandidates = j.stage1candidates.ToString(),
                SecondMeetingDate = String.Format("{0:dd/M/yy}", j.meetingdate2),
                chair_HooHee = j.coordinator.sexfield.HooHee,
                chair_VavHeh = j.coordinator.sexfield.VavHeh
            };
            return mj;
        }
        public static CommitteeMemberMergeFields GetCommitteeMemberrMergeFieldsbyJob(jobCommitteeMember c)
        {
            Job j = c.job;
            CommitteeMemberMergeFields mj = new CommitteeMemberMergeFields

            {
                memberfirstname = c.person.firstname,
                memberlastname = c.person.lastname,
               ChairFirstNameHeb = j.coordinator.firstname,
             ChairLastnameHeb = j.coordinator.lastname,
                DeptnameEng = j.department.Efullname,
                DeptnameHeb = j.department.fullname,
                FirstMeetingDate = String.Format("{0:dd/M/yy}", j.meetingdate1),
                InstNameEng = j.department.institute.efullname,
                InstNameHeb = j.department.institute.fullname,
                jobfullname = j.jobfullname,
                jobshortname = j.jobshortname,
                jobEnglishname = j.jobnameEnglish,
                NumberofCandidates = j.stage1candidates.ToString(),
                SecondMeetingDate = String.Format("{0:dd/M/yy}", j.meetingdate2),
                chair_VavHeh = j.coordinator.sexfield.VavHeh,
                chair_HooHee= j.coordinator.sexfield.HooHee,
                mem_atatah = c.person.sexfield.atatah

            };
            return mj;
        }
        public static string mailmerge(Object myobj, string htmltext)
        {
            StringBuilder b = new StringBuilder(htmltext);
            var mytype = myobj.GetType();
            foreach (PropertyInfo p in mytype.GetProperties())
            {
                Mergefield mf = new Mergefield((string)p.GetValue(myobj), p.Name);
                b.Replace(mf.MergeMergename, mf.MergeValue);
            }

            return b.ToString();
        }

       
    }
   

public sealed class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is bool?)
            {
                var nullable = (bool?)value;
                flag = nullable.GetValueOrDefault();
            }
            if (parameter != null)
            {
                if (bool.Parse((string)parameter))
                {
                    flag = !flag;
                }
            }
            if (flag)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var back = ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
            if (parameter != null)
            {
                if ((bool)parameter)
                {
                    back = !back;
                }
            }
            return back;
        }
      

    }
    public sealed class DebugDataBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Debugger.Break();
            return value;
        }
    }
}

