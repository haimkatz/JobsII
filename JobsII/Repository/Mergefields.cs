using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Repository
{
    public class Mergefield
    {
    public string MergeValue { get; set; }
        public string Mergefieldname { get; set; }
        public string MergeMergename { get; set; }
    
   public Mergefield(string mp, string mf)
{
            Mergefieldname = mf;
            MergeValue = mp;
            //MergeMergename = "1" + mf + "1";
            MergeMergename = mf;
}
}

    public class ReviewerMergeFields
    {
        public string revFirstName { get; set; }
        public string revLastName { get; set; }
        
        public string revemail { get; set; }
        public string appFirstNameEng { get; set; }
        public string appLastNameEng { get; set; }
        public string appFirstNameHeb { get; set; }

        public string appLastnameHeb { get; set; }
        public string appemail { get; set; }
        public string jobfullname { get; set; }
        public string jobshortname { get; set; }
        public string jobEnglishname { get; set; }
        public string DeptnameEng { get; set; }
        public string DeptnameHeb { get; set; }
        public string InstNameEng { get; set; }
        public string InstNameHeb { get; set; }

        public string datesent { get; set; }

        public string app_VavHeh { get; set; }
        public string app_HooHee { get; set; }
        public string app_heshe_s { get; set; }
        public string app_HeShe { get; set; }
        public string rev_atatah { get; set; }
        public string app_hisher_s { get; set; }
        public string app_HisHer { get; set; }
      

    }
    public class applicantMergeFields
    {
      
        public string appFirstNameEng { get; set; }
        public string appLastNameEng { get; set; }
        public string appFirstNameHeb { get; set; }

        public string appLastnameHeb { get; set; }
        public string appemail { get; set; }
        public string jobfullname { get; set; }
        public string jobshortname { get; set; }
        public string jobEnglishname { get; set; }
        public string dateapplied { get; set; }
        public string DeptnameEng { get; set; }
        public string DeptnameHeb { get; set; }
        public string InstNameEng { get; set; }
        public string InstNameHeb { get; set; }
        public string app_VavHeh { get; set; }
           public string app_atatah { get; set; }
       
    }
    public class CommitteeMergeFields
    {

      
        public string jobfullname { get; set; }
        public string jobshortname { get; set; }
        public string jobEnglishname { get; set; }
        public DateTime? dateapplied { get; set; }
        public string DeptnameEng { get; set; }
        public string DeptnameHeb { get; set; }
        public string InstNameEng { get; set; }
        public string InstNameHeb { get; set; }
        public string FirstMeetingDate { get; set; }
        public string SecondMeetingDate { get; set; }
        public string NumberofCandidates { get; set; }
        public string ChairFirstNameEng { get; set; }
        public string ChairLastNameEng { get; set; }
        public string ChairFirstNameHeb { get; set; }

        public string ChairLastnameHeb { get; set; }
        public string chair_VavHeh { get; set; }
        public string chair_HooHee { get; set; }
       
    }
    public class CommitteeMemberMergeFields
    {

public string memberfirstname { get; set; }
        public string memberlastname { get; set; }
       
        public string jobfullname { get; set; }
        public string jobshortname { get; set; }
        public string jobEnglishname { get; set; }
        public DateTime? dateapplied { get; set; }
        public string DeptnameEng { get; set; }
        public string DeptnameHeb { get; set; }
        public string InstNameEng { get; set; }
        public string InstNameHeb { get; set; }
        public string FirstMeetingDate { get; set; }
        public string SecondMeetingDate { get; set; }
        public string NumberofCandidates { get; set; }
       
        public string ChairFirstNameHeb { get; set; }

        public string ChairLastnameHeb { get; set; }
        public string chair_VavHeh { get; set; }
        public string chair_HooHee { get; set; }
      
        public string mem_atatah { get; set; }
       

    }

}