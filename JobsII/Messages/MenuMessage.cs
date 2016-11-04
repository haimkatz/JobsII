using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsII.Models;

namespace JobsII.Messages
{
   public class MenuMessage
    {
        public string viewModelName { get; set; }
        public bool newWindow { get; set; } = false;
        public string menutext { get; set; }
        public bool isactive { get; set; } = true;
    }
}

public class JobMessage
{
    public Job jobm { get; set; }
}

public class ApplicantMessage
{
    public Applicant applicantm { get; set; }
}
