public class VariableStorage
{
    private ArrayList<Variable> list = new();

    public void Add(Variable value)
    {
        if (list.Contains(value))
        {
            throw new Exception("Variable already exists!");
        }

        list.Add(value);
    }

    public bool ContainName(char name)
    {
        for (var i = 0; i < list.Count(); i++)
        {
            if (list.Get(i).Name == name)
            {
                return true;
            }
        }

        return false;
    }

    public bool ContainValue(char[] value)
    {
        for (var i = 0; i < list.Count(); i++)
        {
            if (list.Get(i).Value == value)
            {
                return true;
            }
        }

        return false;
    }

    public Variable? FindByName(char name)
    {
        for (var i = 0; i < list.Count(); i++)
        {
            if (list.Get(i).Name == name)
            {
                return list.Get(i);
            }
        }

        return null;
    }
}