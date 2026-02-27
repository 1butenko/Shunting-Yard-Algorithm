public class Stack<T>
{
    private static int capacity = 50;
    private int pointer = 0;
    private T[] array = new T[capacity];

    public void Push(T element)
    {
        if (pointer == array.Length)
        {
            throw new Exception("Stack overflow");
        }
        
        array[pointer] = element;
        pointer++;
    }

    public T Pop()
    {
        if (pointer == 0)
        {
            throw new Exception("Stack is empty");
        }
        
        pointer--;
        T element = array[pointer];

        return element;
    }
}