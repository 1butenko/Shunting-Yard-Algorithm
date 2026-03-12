public class Variable
{
    public char Name {
        get => name;
        set
        {
            if (storage.ContainName(value) && value != name)
            {
                throw new Exception("Name already takend");
            }
            
            name = value;
        }
    }

    public char[] Value
    {
        get => value;
        set
        {
            if (storage.ContainValue(value) && value != this.value)
            {
                throw new Exception("Name already takend");
            }
            
            this.value = value;
        }
    }

    public int Result{get => result;}

    private char name;
    private char[] value;
    private int result;
    private VariableStorage storage;

    public Variable(char name, char[] value, VariableStorage storage, int result)
    {
        this.name = name;
        this.value = value;
        this.storage = storage;
        this.result = result;
    }
}