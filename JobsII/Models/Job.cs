using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace JobsII.Models
{
    [ImplementPropertyChanged]
   public class Job  //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 id { get; set; }

        public string jobshortname { get; set; }

        
        public string jobfullname { get; set; }
        public string mercavaid { get; set; }
        [ForeignKey("department")]
        public int? Deptid { get; set; }
        [ForeignKey("coordinator")]
        public Int64? coordinatorid { get; set; }
        public DateTime? tenderstart { get; set; }
        public DateTime? tenderend { get; set; }
        public DateTime? DecisionMade { get; set; }
public DateTime? committeeformed {get;set;}
        public DateTime? materialsent1 { get; set; }
        public DateTime? materialsent2 { get; set; }
        public DateTime? meetingdate1 { get; set; }
        public DateTime? meetingdate2 { get; set; }
        public DateTime? expenseforms{ get; set; }
        public DateTime? roomordered { get; set; }
        public DateTime? fileprepared{ get; set; }
      //  public DateTime committeeformed { get; set; }
      public bool? flag1 { get; set; }
        public bool? flag2 { get; set; }
        public bool? flag3{ get; set; }
      //  public Audit Audit { get; set; }


        public virtual Person coordinator { get; set; }
       public virtual Department department { get; set; }
     public virtual ObservableCollection<Applicant> applicants { get; set; }
        public virtual ObservableCollection<Reviewer> reviewer { get; set; }
        public  virtual ObservableCollection<JobRequirement> jobRequirements { get; set; }

        
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
        public string comment { get; set; }
        public virtual  Job job { get; set; }
        public virtual  Requirement requirement { get; set; }
    }

    [ImplementPropertyChanged]
    public class Applicant //:IAudited
    { 
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 id { get; set; }
    public Int64 Jobid { get; set; }
        [ForeignKey("person")]
        public Int64 Personid { get; set; }
        public DateTime? dateapplied { get; set; }
        public DateTime? dateinformed1 { get; set; }
        public DateTime? dateinformed2 { get; set; }
        public bool? active { get; set; }
        public string comments { get; set; }
        public bool? flag1 { get; set; }
        public bool? flag2 { get; set; }
        public bool? flag3 { get; set; }
     //   public Audit Audit { get; set; }

        public virtual  Person person { get; set; }
        public virtual ObservableCollection<Reviewer> reviewers { get; set; }
        public virtual ObservableCollection<AppRequirement> apprequirements { get; set; }



}


    [ImplementPropertyChanged]
    public class AppRequirement//:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [ForeignKey("applicant")]
        public Int64 Applicantid { get; set; }
        [ForeignKey("jobrequirement")]
        public Int64 jobRequirementid { get; set; }
        public string comments { get; set; }
        public byte[] document { get; set; }
       public DateTime? datereceived { get; set; }
        public Audit Audit { get; set; }
        public virtual Applicant applicant { get; set; }
        public virtual JobRequirement jobrequirement { get; set; }
    }
    [ImplementPropertyChanged]
    public class Reviewer//:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public Int64 Personid { get; set; }
        [ForeignKey("applicant")]
        public Int64 Applicantid { get; set; }
        public byte[] review { get; set; }
        public DateTime datesent { get; set; }
        public int Statusid { get; set; }
        public DateTime datereceived { get; set; }
        public DateTime reminderdate { get; set; }
      //  public Audit Audit { get; set; }
        public virtual Person person { get; set; }
        public virtual Applicant applicant { get; set; }
    }
    [ImplementPropertyChanged]
    public class Requirement //:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string RequirementName { get; set; }
        public string RequirementDescription { get; set; }
      //  public Audit Audit { get; set; }
    }
}
