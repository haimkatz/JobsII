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
       public int? tabindex { get; set; } = 0;
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

public class newApplicantMessage
{
    public Applicant newapplicant { get; set; }
    public bool isdeleted { get; set; }
}

public class newReviewerMessage
{
    public Reviewer newreviewer { get; set; }
}

public class filemessage
{
    public string filename { get; set; }
    public string ext { get; set; }
    public byte[] doccontent { get; set; }
}

public class persontoeditmessage
{
    public Person person { get; set; }
    public bool isnew { get; set; }
    public Guid sendingWindow { get; set; }
}
public class personreturnedmessage
{
    public Person personedit { get; set; }
   public Guid sourceWindow { get; set; }
    public bool isnew { get; set; }
    public bool iscancelled { get; set; }
}

public class errormessage
{
    public string errormsg { get; set; }
    public bool isvisible { get; set; }
}

public class appreqcombo
{
    public long id { get; set; }
    public string Requirementname { get; set; }
}

public class lettercombo
{
    public long id { get; set; }
    public string docname { get; set; }
    public string language { get; set; }
 public int? mergedoctypeid { get; set; }
    public string mergetype { get; set; }

}
