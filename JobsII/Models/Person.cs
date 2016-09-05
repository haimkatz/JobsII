using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
   public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string email { get; set; }
        public Int64? idnum { get; set; }
        public int? Deptid { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string institution { get; set; }

    }

    public class Department
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int id { get; set; }

        public string shortname { get; set; }
        public string fullname { get; set; }
[ForeignKey("departmenthead")]
        public Int64? departmentheadid { get; set; }
        [ForeignKey("assdepartmenthead")]
        public Int64? assdepartmentheadid { get; set; }

   public virtual Person departmenthead { get; set; }
        public virtual Person assdepartmenthead { get; set; }


    }
}
