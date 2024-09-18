namespace MuniciPAL.Models
{
    public class ReportedIssues
    {
     public int IssueID { get; set; }
     public String IssueLocation { get; set; }

     public String IssueCategory { get; set; }

     public String IssueDescription { get; set; }

    public IFormFileCollection IssueAttachments { get; set; }
    }

}
