using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace JobsII.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Job //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        public string jobshortname { get; set; }


        public string jobfullname { get; set; }
        public string jobnameEnglish { get; set; }
        public string mercavaid { get; set; }

        [ForeignKey("department")]
        public int? Deptid { get; set; }

        [ForeignKey("coordinator")]
        public Int64? coordinatorid { get; set; }
        public int? stage1candidates { get; set; }
        public string skypeid { get; set; }

        public DateTime? tenderstart { get; set; }
        public DateTime? tenderend { get; set; }
        public DateTime? DecisionMade { get; set; }
        [DefaultValue("false")]
        public bool? committeeformed_s1 { get; set; }
        [DefaultValue("false")]
        public bool? commlettersent { get; set; }
        [DefaultValue("false")]
        public bool? calendersent { get; set; }
        [DefaultValue("false")]
        public bool? meetingdateset { get; set; }
     
        public DateTime? meetingdate1 { get; set; }
        
        public DateTime? meetingdate2 { get; set; }
        public DateTime? expenseforms { get; set; }
        [DefaultValue("false")]
        public bool? roomordered { get; set; }
        [DefaultValue("false")]
        public bool? fileprepared { get; set; }

        [DefaultValue("false")]
        public bool? materialsent { get; set; }
        [DefaultValue("false")]
        public bool? fileprepared2 { get; set; }

        [DefaultValue("false")]
        public bool? materialsent2 { get; set; }
        [DefaultValue("false")]
        public bool? candidatesinformed { get; set; }
        [DefaultValue("false")]
        public bool? candidatesinformed2 { get; set; }
        public bool? calenderset { get; set; }
        public byte? stage { get; set; }
        public bool? firstmeetingsummarysent { get; set; }

        public string Comments { get; set; }

        //  public Audit Audit { get; set; }


        public virtual Person coordinator { get; set; }
        public virtual Department department { get; set; }

      
        public virtual ObservableCollection<Applicant> applicants { get; set; }

       
        public virtual ObservableCollection<Reviewer> reviewer { get; set; }
        public virtual ObservableCollection<JobRequirement> jobRequirements { get; set; }
        public virtual ObservableCollection<jobDoc> jobdocs { get; set; }
        [NotMapped]
    
        public virtual string foreignapplicants {
            get
            {
                string fa= string.Empty;
                if (applicants !=null)
                { foreach (Applicant a in applicants)
                {

                    if (a.person.country != "ישראל")
                    {
                      string  t = a.person.country == "USA" ? a.person.state : a.person.country;
                        fa += t + ", ";

                    }
                        
                }}
                if (fa.Length > 2)
                {
                    return fa.Substring(0, fa.Length - 2);
                }
                else
                { return fa;}
            }
            
            private set {}}
        [NotMapped]

        public virtual string skypeids
        {
            get
            {
                string fa = string.Empty;

                foreach (Applicant a in applicants)
                {
                    if (a.person.country != "ישראל")
                    {
                       string t = a.person.skypeid;
                        fa += t +", ";

                    }

                }
                if (fa.Length > 2)
                {
                    return fa.Substring(0, fa.Length - 2);
                }
                else
                { return fa; }
            }

            private set { }
        }
        public virtual ObservableCollection<jobCommitteeMember> committee { get; set; }
    }

    public class JobRequirement

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        [ForeignKey("job")]
        public Int64 Jobid { get; set; }

        [ForeignKey("requirement")]
        public Int64 Requirementid { get; set; }

        public DateTime deadline { get; set; }
        [DefaultValue("false")]
        public bool sendtoreviewer { get; set; }
        [DefaultValue("false")]
        public bool sendtocommittee { get; set; }
        public string comment { get; set; }
      
        public virtual Job job { get; set; }
        public virtual Requirement requirement { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Applicant //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        [ForeignKey("job")]
        public Int64 Jobid { get; set; }

        [ForeignKey("person")]
        public Int64 Personid { get; set; }

        public DateTime? dateapplied { get; set; }
        public DateTime? dateinformed1 { get; set; }
        public DateTime? dateinformed2 { get; set; }
        public bool? active { get; set; }
        public string comments { get; set; }
        // flag1 true  = advance to stage 2
        public bool? flag1 { get; set; }
        public bool? flag2 { get; set; }
        public bool? flag3 { get; set; }
        //   public Audit Audit { get; set; }
        public virtual Job job { get; set; }
        public virtual Person person { get; set; }
        public virtual ObservableCollection<Reviewer> reviewers { get; set; }
        public virtual ObservableCollection<AppRequirement> apprequirements { get; set; }



    }


    [AddINotifyPropertyChangedInterface]
    public class AppRequirement //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        [ForeignKey("applicant")]
        public Int64 Applicantid { get; set; }

        [ForeignKey("jobrequirement")]
        public Int64 jobRequirementid { get; set; }

        public string comments { get; set; }
        public byte[] document { get; set; }
        public string ext { get; set; }
        public string localpath { get; set; }
        public DateTime? datereceived { get; set; }
        public int? ordersent { get; set; }
        // public Audit Audit { get; set; }
        public virtual Applicant applicant { get; set; }
        public virtual JobRequirement jobrequirement { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Reviewer //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        public Int64 Personid { get; set; }

        [ForeignKey("applicant")]
        public Int64 Applicantid { get; set; }

        public byte[] document { get; set; }
        public string localpath { get; set; }
        public DateTime? datesent { get; set; }

        [ForeignKey("reviewerstatus")]
        [DefaultValue(0)]

        public int? Statusid { get; set; }

        public string comments { get; set; }
        public string whynot { get; set; }
        public DateTime? datereceived { get; set; }
        public DateTime? reminderdate { get; set; }
      
        //  public Audit Audit { get; set; }
        public virtual Person person { get; set; }
        public virtual Applicant applicant { get; set; }
        public virtual ReviewerStatus reviewerstatus { get; set; }
        public string ext { get; internal set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class Requirement //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        public string RequirementName { get; set; }
        public string RequirementDescription { get; set; }
        [DefaultValue("false")]
        public bool stage2 { get; set; }
        //  public Audit Audit { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class ReviewerStatus //:IAudited
    {
        public int id { get; set; }
        public string Status { get; set; }
        //public Audit Audit(get;set;}
    }

    [AddINotifyPropertyChangedInterface]
    public class jobCommitteeMember //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        [ForeignKey("person")]
        public Int64 Personid { get; set; }

        [ForeignKey("job")]
        public Int64 Jobid { get; set; }

        public string Comments { get; set; }

        public virtual Job job { get; set; }
        public virtual Person person { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class UniversalDoc
    {
      

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        public string DocName { get; set; }
        public string localpath { get; set; }
        public byte[] document { get; set; }
        public DateTime? dateupdated { get; set; }
        public string mergeobject { get; set; }
        [ForeignKey("language")]
        public int languageid { get; set; }
      
        public virtual Language language { get; set; }
  public string ext { get; set; }

    }
    [AddINotifyPropertyChangedInterface]
    public class jobDoc
    {
       

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }

        [ForeignKey("job")]
        public Int64 jobid { get; set; }

        public string DocName { get; set; }
        public string localpath { get; set; }
        public byte[] document { get; set; }
        public DateTime? dateupdated { get; set; }
        [ForeignKey("language")]
        public int languageid { get; set; }
        public int? ordersent { get; set; }
        [ForeignKey("universaldoc")]
        public Int64? UniversalDocid { get; set; }
        [DefaultValue("false")]
        public bool sendtocommittee { get; set; }
        [DefaultValue("false")]
        public bool sendtoreviewer { get; set; }
        [DefaultValue("false")]
        public bool sendtoapplicant { get; set; }
        public virtual UniversalDoc universaldoc { get; set; }
        public virtual Job job { get; set; }
        public virtual Language language { get; set; }
        public  string ext { get; set; }
    }

    public class Language
    {
        public int id { get; set; }
        public string language { get; set; }
    }
    [AddINotifyPropertyChangedInterface]
    public class MergeDoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string docname { get; set; }
      
        [ForeignKey("mergedoctype")]
        public int? mergedoctypeid { get; set; }
        public string mergetype { get; set; }
        public string htmltext { get; set; }
        public DateTime? datecreated { get; set; }
        [ForeignKey("language")]
        public int languageid { get; set; }
        public virtual Language language { get; set; }
        public virtual MergeDocType mergedoctype { get; set; }

    }
    [AddINotifyPropertyChangedInterface]
    public class MergeDocType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string typename { get; set; }
    }

    [Table("MissingAppDocs")]
    public class MissingAppDocs
    {[Key]
        public Int64 Keyid { get; set; }
        public Int64? id { get; set; }
        //[ForeignKey("job")]
        public Int64 Jobid { get; set; }
        //[ForeignKey("requirement")]
        public Int64 Requirementid { get; set; }
        //[ForeignKey("person")]
        public Int64? Personid { get; set; }
        public Int64? jobRequirementid { get; set; }
        public string jobshortname { get; set; }
       // public string jobfullname { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string RequirementName { get; set; }
        public DateTime deadline { get; set; }
        //public virtual Job job { get; set; }
        //    public virtual Requirement requirement { get; set; }
        //public virtual Person person { get;set;}

    }

}
