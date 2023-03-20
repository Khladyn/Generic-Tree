using System;
using System.Collections.Generic;

// Create class that accepts any data type
public class Branch<T>
{
    // Declare variables
    public T Data { get; set; }
    public List<Branch<T>> Branches { get; set; }


    // Create constructor
    public Branch(T data)
    {
        this.Data = data;
        this.Branches = new List<Branch<T>>();
    }

    // Create method to add branch
    public void AddBranch(T data)
    {
        Branch<T> branch = new Branch<T>(data);
        this.Branches.Add(branch);
    }

    public int FindDepth()
    {
        // End recursion if there are no more children
        if (this.Branches.Count == 0) return 0;

        // Initialize counter
        int maxDepth = 1;

        // Loop through all children
        foreach (var child in this.Branches)
        {
            // Find child depth
            int childDepth = child.FindDepth();

            // Replace max depth if child depth is greater.
            if (childDepth > maxDepth) maxDepth = childDepth;
        }

        // Increment counter per recursion
        return maxDepth + 1;
    }

}

public class GenericTree
{
    public static void Main()
    {
        // First layer
        Branch<int> Branch = new Branch<int>(1);

        // Second layer
        Branch.AddBranch(2);
        Branch.AddBranch(3);

        // Third layer
        Branch.Branches[0].AddBranch(4);
        Branch.Branches[1].AddBranch(5);
        Branch.Branches[1].AddBranch(6);
        Branch.Branches[1].AddBranch(7);

        // Fourth layer
        Branch.Branches[1].Branches[0].AddBranch(8);
        Branch.Branches[1].Branches[0].AddBranch(9);
        Branch.Branches[1].Branches[1].AddBranch(10);

        // Fifth layer
        Branch.Branches[1].Branches[1].Branches[0].AddBranch(11);

        int depth = Branch.FindDepth();
        Console.WriteLine($"The tree depth is {depth}."); // Output: 5

        Console.ReadKey();
    }
}
