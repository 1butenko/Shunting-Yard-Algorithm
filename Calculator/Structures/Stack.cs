public class Stack<T>
{
    private const int capacity = 50;
    private int pointer = 0;
    private T[] array = new T[capacity];

    public int Count() => pointer;
    public T Peek() => array[pointer - 1];

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

    public T[] ToArray()
    {
        T[] result = new T[pointer];

        for (int i = 0; i < pointer; i++)
        {
            result[i] = array[pointer - i - 1];
        }

        return result;
    }
}