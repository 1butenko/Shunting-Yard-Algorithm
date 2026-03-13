public class VariableManager
{
    private Calculator calculator;
    private VariableStorage variableStorage;
    private char? variableName = null;

    public VariableManager(VariableStorage variableStorage, Calculator calculator)
    {
        this.variableStorage = variableStorage;
        this.calculator = calculator;
    }

    public int ProcessVariablesAndCalculate(ArrayList<char> tokens)
    {
        if (tokens.Count() == 1 && char.IsLetter(tokens.Get(0)))
        {
            Variable? v = variableStorage.FindByName(tokens.Get(0));

            if (v == null)
            {
                throw new Exception("Variable not found!");
            }

            return calculator.Calculate(ExpandTokens(v.Tokens));
        }

        ArrayList<char> TokensToCalculate = tokens;

        if (char.IsLetter(TokensToCalculate.Get(0)))
        {
            variableName = tokens.Get(0);
            tokens.Remove(tokens.Get(0));
        }

        if (variableName.HasValue)
        {
            variableStorage.AddOrUpdate(new Variable(variableName.Value, variableStorage, TokensToCalculate));
            variableName = null;
            return 0;
        }

        return calculator.Calculate(ExpandTokens(TokensToCalculate));
    }

    // Here also I used method of recursion calling of ExpandTokens function, which was propoused by AI.
    // I sat about 1 hour thinking how can I rewrite this function without making recursion,
    // but I didn't come up with better idea ;( 
    // NOTE: I didn't use AI to write this code, I just asked about how can I implement this function.

    private ArrayList<char> ExpandTokens(ArrayList<char> tokens, ArrayList<char>? visited = null)
    {
        ArrayList<char> result = new();
        if (visited == null)
        {
            visited = new ArrayList<char>();
        }

        for (int i = 0; i < tokens.Count(); i++)
        {
            char token = tokens.Get(i);
            Variable? v = variableStorage.FindByName(token);

            if (v != null)
            {
                if (visited.Contains(token))
                    throw new Exception($"Cycle dependecy: {token}");
                
                visited.Add(token);
                result.Add('(');

                ArrayList<char> inner = ExpandTokens(v.Tokens, visited);
                
                for (int j = 0; j < inner.Count(); j++)
                {
                    result.Add(inner.Get(j));
                }

                result.Add(')');
                visited.Remove(token);
            }
            else
            {
                result.Add(token);
            }
        }

        return result;
    }
}