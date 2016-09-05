using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
   public class Job
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 id { get; set; }

        public string jobshortname { get; set; }

        
        public string jobfullname { get; set; }
        public string mercavaid { get; set; }
        [ForeignKey("department")]
        public int Deptid { get; set; }
        [ForeignKey("coordinator")]
        public Int64 coordinatorid { get; set; }
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



        virtual public Person coordinator { get; set; }
       virtual public Department department { get; set; }
     virtual public ObservableCollection<Applicant> applicants { get; set; }
        virtual public ObservableCollection<Reviewer> reviewer { get; set; }
        virtual  public ObservableCollection<JobRequirement> jobRequirements { get; set; }

        
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


    public class Applicant { 
[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int64 id { get; set; }
    public Int64 Jobid { get; set; }
        public Int64 Personid { get; set; }
        public DateTime? dateapplied { get; set; }
        public DateTime? dateinformed1 { get; set; }
        public DateTime? dateinformed2 { get; set; }
        public bool? active { get; set; }
        public string comments { get; set; }
        public bool? flag1 { get; set; }
        public bool? flag2 { get; set; }
        public bool? flag3 { get; set; }
        virtual public  Person person { get; set; }
        virtual public ObservableCollection<Reviewer> reviewers { get; set; }
        virtual public ObservableCollection<Requirement> requirements { get; set; }



}

   

    public class AppRequirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [ForeignKey("applicant")]
        public Int64 Applicantid { get; set; }
        [ForeignKey("requirement")]
        public Int64 Requirementid { get; set; }
        public string comments { get; set; }
        public byte[] document { get; set; }
       public DateTime? datereceived { get; set; }
        public virtual Applicant applicant { get; set; }
        public virtual Requirement requirement { get; set; }
    }

    public class Reviewer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public Int64 Personid { get; set; }
        public Int64 Applicationid { get; set; }
        public byte[] review { get; set; }
        public DateTime datesent { get; set; }
        public int Statusid { get; set; }
        public DateTime datereceived { get; set; }
        public DateTime reminderdate { get; set; }

        public virtual Person person { get; set; }

    }

    public class Requirement
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string RequirementName { get; set; }
        public string RequirementDescription { get; set; }

    }
}
