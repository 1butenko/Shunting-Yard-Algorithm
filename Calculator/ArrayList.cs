public class ArrayList<T>
{
    private T[] array = new T[10];
    private int pointer = 0;

    public int Count() => pointer;

    public T Get(int id) => array[id];

    public void Add(T element)
    {
        array[pointer] = element;
        pointer += 1;
        
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
}