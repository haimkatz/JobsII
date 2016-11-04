using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace JobsII.Models
{
    [ImplementPropertyChanged]
    public class Person//:IAudited
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [Display (Name = "שם משפחה")]
        public string lastname { get; set; }
        [Display (Name = "שם פרטי")]
        public string firstname { get; set; }
        [Display(Name = "מייל")]
        public string email { get; set; }
        [Display(Name = "ת.ז.")]
        public Int64 idnum { get; set; }
        public int Deptid { get; set; }
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
       // public Audit Audit { get; set; }
    }
    [ImplementPropertyChanged]
    public class Department//:IAudited
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int id { get; set; }
        [Display(Name = "מחלקה")]
        public string shortname { get; set; }
        public string fullname { get; set; }
[ForeignKey("departmenthead")]
        public Int64? departmentheadid { get; set; }
        [ForeignKey("assdepartmenthead")]
        public Int64? assdepartmentheadid { get; set; }
      //  public Audit Audit { get; set; }
        public virtual Person departmenthead { get; set; }
        public virtual Person assdepartmenthead { get; set; }

    }
}
