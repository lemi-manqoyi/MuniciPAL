namespace MuniciPAL.Models
{
    // A binary tree is a data structure in which each node has at most two children (i.e., left child and right child).
    public class Node
{
    public string Category { get; set; }
    public int IssueId { get; set; }
    public string Description { get; set; }
    public List<string> SupportingFiles { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(string category, int issueId, string description)
    {
        Category = category;
        IssueId = issueId;
        Description = description;
        SupportingFiles = new List<string>();
    }
}

}
