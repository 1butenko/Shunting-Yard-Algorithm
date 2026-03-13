public class ArrayList<T>
{
    private T[] array = new T[10];
    private int pointer = 0;

    public int Count() => pointer;

    public T Get(int id) => array[id];

    public void Add(T element)
    {
        array[pointer] = element;
        pointer++;

        if (pointer == array.Length)
        {
            T[] extendedArray = new T[array.Length * 2];

            for (var i = 0; i < array.Length; i++)
            {
                extendedArray[i] = array[i];
            }

            array = extendedArray;
        }
    }

    public int IndexOf(T element)
    {
        for (var i = 0; i < array.Length; i++)
        {
            if (Object.Equals(array[i], element))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T element)
    {
        return IndexOf(element) != -1;
    }

    public void Remove(T element)
    {
        for (var i = 0; i < pointer; i++)
        {
            if (Object.Equals(array[i], element))
            {
                for (var j = i; j < pointer - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                pointer -= 1;
                return;
            }
        }
    }

    public T[] ToArray()
    {
        T[] result = new T[pointer];
        for (int i = 0; i < pointer; i++)
        {
            result[i] = array[i];
        }
        return result;
    }
}