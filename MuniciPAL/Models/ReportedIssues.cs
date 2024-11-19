namespace MuniciPAL.Models
{
    public class ReportedIssues
    {
     public int IssueID { get; set; }
     public String? IssueLocation { get; set; }

     public String? IssueCategory { get; set; }

     public String? IssueDescription { get; set; }

    public IFormFileCollection? IssueAttachments { get; set; }

       //for the service requests page | removes need for extra class, and keeps code in followable manner
        
       public int ServiceID { get; set; }

       public String? ServiceCategory { get; set; } 

       public String? ServiceItem { get; set; }

       public String? ServiceStatus { get; set; }
    }


}
