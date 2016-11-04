using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsII.Models
{
   public class Audit
    {
   
            public System.DateTime? Created { get; set; }
            public System.DateTime? Updated { get; set; }
            public string User { get; set; }
        }
    }

