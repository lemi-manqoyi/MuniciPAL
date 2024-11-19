namespace MuniciPAL.Models
{
     public class BinarySearchTree
    {
    private Node _root;

    public void AddIssue(string category, int issueId, string description, List<string> supportingFiles)
    {
        Node newNode = new Node(category, issueId, description);
        newNode.SupportingFiles = supportingFiles;

        if (_root == null)
        {
            _root = newNode;
        }
        else
        {
            AddNode(_root, newNode);
        }
    }

    private void AddNode(Node currentNode, Node newNode)
    {
        if (newNode.IssueId < currentNode.IssueId)
        {
            if (currentNode.Left == null)
            {
                currentNode.Left = newNode;
            }
            else
            {
                AddNode(currentNode.Left, newNode);
            }
        }
        else
        {
            if (currentNode.Right == null)
            {
                currentNode.Right = newNode;
            }
            else
            {
                AddNode(currentNode.Right, newNode);
            }
        }
    }
        
    //BFS is used to traverse the tree level by level, starting from the root. In our case, it will be used to display all approved reported issues across categories.
   
    public void PerformBFS()
    {
        if (_root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            
            // Display the issue information
            Console.WriteLine($"Category: {current.Category}, Issue ID: {current.IssueId}");
            Console.WriteLine($"Description: {current.Description}");
            Console.WriteLine($"Supporting Files: {string.Join(", ", current.SupportingFiles)}");
            Console.WriteLine();

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }
    }

    //DFS traverses the tree depth-first, exploring as far as possible along each branch before backtracking. I'll use it to find a specific issue based on its ID.
    public Node FindIssueById(int issueId)
    {
        return DfsRecursive(_root, issueId);
    }

    private Node DfsRecursive(Node node, int targetId)
    {
        if (node == null || node.IssueId == targetId)
            return node;

        Node result = DfsRecursive(node.Left, targetId);
        if (result != null) return result;

        return DfsRecursive(node.Right, targetId);
    }
}
}


