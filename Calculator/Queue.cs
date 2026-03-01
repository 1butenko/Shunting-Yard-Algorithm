public class Queue<T>
{
    private const int capacity = 50;
    private int inPointer = 0;
    private int outPointer = 0;
    private int counter = 0;
    private T[] array = new T[capacity];

    public void Enqueue(T element)
    {
        if (counter == array.Length)
            throw new Exception("Queue overflow");

        array[inPointer] = element;
        inPointer = (inPointer + 1) % array.Length;
        counter++;
    }

    public T Dequeue()
    {
        if (counter == 0)
            throw new Exception("Queue is empty");

        T element = array[outPointer];
        outPointer = (outPointer + 1) % array.Length;
        counter--;

        return element;
    }

    public T[] ToArray()
    {
        T[] result = new T[counter];

        for (int i = 0; i < counter; i++)
            result[i] = array[(outPointer + i) % array.Length];
        
        return result;
    }
}