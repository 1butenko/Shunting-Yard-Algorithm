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

    public ArrayList<char> Tokens {get => tokens;}

    private char name;
    private ArrayList<char> tokens;

    private VariableStorage storage;

    public Variable(char name, VariableStorage storage, ArrayList<char> tokens)
    {
        this.name = name;
        this.storage = storage;
        this.tokens = tokens;
    }
}