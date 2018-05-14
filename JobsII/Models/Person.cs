using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace JobsII.Models
{
    public enum sex
    {
        male=1,
        female
    }
    
    [AddINotifyPropertyChangedInterface]
    public class Person//:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [Display (Name = "שם משפחה")]
        public string lastname { get; set; }
        [Display (Name = "שם פרטי")]
        public string firstname { get; set; }
        [Display (Name ="שם משפחה אנגלית מועמד")]
        public string lastnameh { get; set; }
        [Display(Name ="שם פרטי אנגלית מועמד" )]
        public string firstnameh { get; set; }

        [Display(Name = "מייל")]
        public string email { get; set; }
        [Display(Name = "ת.ז.")]
        public Int64 idnum { get; set; }
        [ForeignKey("department")]
        public int? Deptid { get; set; }
        [Display(Name = "כתובת")]
        public string address { get; set; }
        [Display(Name = "עיר")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "ארץ")]
        public string country { get; set; }
        [Display(Name = "מיקוד")]
        public string zip { get; set; }
        [Display(Name = "מוסד")]
        public string institution { get; set; }
        public string skypeid { get; set; }
        [ForeignKey("sexfield")]
        public sex sex { get; set; }
        public virtual Department department { get; set; }
        public virtual SexField sexfield { get; set; }
       // public Audit Audit { get; set; }
    }
    [AddINotifyPropertyChangedInterface]
    public class Department//:IAudited
    {
                       
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int id { get; set; }
        [Display(Name = "מחלקה")]
        public string shortname { get; set; }
        public string fullname { get; set; }
        public string Eshortname { get; set; }
        public string Efullname { get; set; }
        [ForeignKey("institute")]
        public int Instituteid { get; set; }
        [ForeignKey("departmenthead")]
        public Int64? departmentheadid { get; set; }
        [ForeignKey("assdepartmenthead")]
        public Int64? assdepartmentheadid { get; set; }
      //  public Audit Audit { get; set; }
        public virtual Person departmenthead { get; set; }
        public virtual Person assdepartmenthead { get; set; }
        public virtual Institute institute { get; set; }
        [NotMapped]
        public virtual string Sortname {

            get
            {
                if (institute.shortname != null)
                {
                    return institute.shortname.Substring(0, 3) + "-" + shortname;
                }
                else
                {
                    return string.Empty;
                }
            }}
    }

    [AddINotifyPropertyChangedInterface]
    public class Institute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string shortname { get; set; }
        public string fullname { get; set; }
        public string Eshortname { get; set; }
        public string efullname { get; set; }
        [ForeignKey("institutehead")]
        public Int64? instituteheadid { get; set; }
        //  public Audit Audit { get; set; }
        public virtual Person institutehead { get; set; }
        //public virtual ObservableCollection<Department> departments { get; set; }
       

    }

    public class SexField
    {
       [Key]
        public sex sex { get; set; }
       
        public string VavHeh { get; set; }
        public string HooHee{ get; set; }
        public string heshe_s { get; set; }
        public string HeShe { get; set; }
        public string atatah { get; set; }
        public string hisher_s { get; set; }
        public string HisHer { get; set; }
        public string hebstring1 { get; set; }
        public string hebstring2 { get; set; }

    }
}