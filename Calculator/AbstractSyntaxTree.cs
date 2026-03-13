public class AbstractSyntaxTree()
{
    private Stack<Node<char>> stack = new();
    private char[] operators = { '+', '-', '*', '/', '^', 's', 'c' };

    public void Build(char[] rpn)
    {
        stack = new Stack<Node<char>>();

        foreach (var t in rpn)
        {
            if (operators.Contains(t))
            {
                Node<char> right = stack.Pop();
                Node<char> left = stack.Pop();

                if (operators.Contains(left.Value))
                    stack.Push(left);
                else if (operators.Contains(right.Value))
                    stack.Push(right);

                stack.Push(new Node<char>(t, left, right));
            }
            else
                stack.Push(new Node<char>(t, null, null));
        }
    }

    // NOTE: In this function I used method of recursion, which I think will be studied
    // during next sessions. I asked AI how to implement visualization of tree and the best
    // approach was to use this method.
    // P.S. I've just asked about approach of making visualization, not how to write code for it.
    public void Visualize()
    {
        Node<char> root = stack.Peek();

        VisualizeTree(root, "", true, true);

        void VisualizeTree(Node<char> node, string prefix, bool isLeft, bool isRoot)
        {
            string childPrefix;
            bool hasBoth = node.LeftNode != null && node.RightNode != null;

            if (isRoot)
            {
                Console.WriteLine($" {node.Value}");
                childPrefix = "";
            }
            else
            {
                if (isLeft)
                {
                    Console.WriteLine($"{prefix}├── {node.Value}");
                    childPrefix = prefix + "│   ";
                }
                else
                {
                    Console.WriteLine($"{prefix}└── {node.Value}");
                    childPrefix = prefix + "    ";
                }
            }

            if (node.LeftNode != null && node.RightNode != null)
            {
                VisualizeTree(node.LeftNode, childPrefix, isLeft: hasBoth, isRoot: false);
                VisualizeTree(node.RightNode, childPrefix, isLeft: false, isRoot: false);
            }
        }
    }
}