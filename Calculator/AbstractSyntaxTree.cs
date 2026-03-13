public class AbstractSyntaxTree()
{
    private Stack<Node<string>> stack = new();
    private string[] operators = { "+", "-", "*", "/", "^", "sin", "cos", "max", "clamp" };

    public void Build(string[] rpn)
    {
        stack = new Stack<Node<string>>();

        foreach (var t in rpn)
        {
            if (operators.Contains(t))
            {
                if (t == "sin" || t == "cos")
                {
                    Node<string> child = stack.Pop();
                    stack.Push(new Node<string>(t, child, null));
                }
                else if (t == "clamp")
                {
                    Node<string> max = stack.Pop();
                    Node<string> min = stack.Pop();
                    Node<string> val = stack.Pop();
                    Node<string> range = new Node<string>("range", min, max);
                    stack.Push(new Node<string>(t, val, range));
                }
                else
                {
                    Node<string> right = stack.Pop();
                    Node<string> left = stack.Pop();

                    stack.Push(new Node<string>(t, left, right));
                }
            }
            else
                stack.Push(new Node<string>(t, null, null));
        }
    }

    // NOTE: In this function I used method of recursion, which I think will be studied
    // during next sessions. I asked AI how to implement visualization of tree and the best
    // approach was to use this method.
    // P.S. I've just asked about approach of making visualization, not how to write code for it.
    public void Visualize()
    {
        Node<string> root = stack.Peek();

        VisualizeTree(root, "", true, true);

        void VisualizeTree(Node<string> node, string prefix, bool isLeft, bool isRoot)
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