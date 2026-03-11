public class Node<T>
{
    public T Value;
    public Node<T>? LeftNode;
    public Node<T>? RightNode;

    public Node(T value, Node<T>? leftNode, Node<T>? rightNode)
    {
        Value = value;
        LeftNode = leftNode;
        RightNode = rightNode;
    }
}