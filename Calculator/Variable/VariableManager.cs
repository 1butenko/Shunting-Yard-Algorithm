public class VariableManager
{
    private Calculator calculator;
    private VariableStorage variableStorage;
    private string? variableName = null;

    public VariableManager(VariableStorage variableStorage, Calculator calculator)
    {
        this.variableStorage = variableStorage;
        this.calculator = calculator;
    }

    public int ProcessVariablesAndCalculate(ArrayList<string> tokens)
    {
        if (tokens.Count() == 1 && tokens.Get(0).Length == 1 && char.IsLetter(tokens.Get(0)[0]))
        {
            Variable? v = variableStorage.FindByName(tokens.Get(0)[0]);

            if (v == null)
            {
                throw new Exception("Variable not found!");
            }

            return calculator.Calculate(ExpandTokens(v.Tokens));
        }

        ArrayList<string> TokensToCalculate = tokens;

        if (tokens.Count() > 0 && tokens.Get(0).Length == 1 && char.IsLetter(tokens.Get(0)[0]))
        {
            variableName = tokens.Get(0);
            tokens.Remove(tokens.Get(0));
        }

        if (variableName != null)
        {
            variableStorage.AddOrUpdate(new Variable(variableName[0], variableStorage, TokensToCalculate));
            variableName = null;
            return 0;
        }

        return calculator.Calculate(ExpandTokens(TokensToCalculate));
    }

    private ArrayList<string> ExpandTokens(ArrayList<string> tokens, ArrayList<string>? visited = null)
    {
        ArrayList<string> result = new();
        if (visited == null)
        {
            visited = new ArrayList<string>();
        }

        for (int i = 0; i < tokens.Count(); i++)
        {
            string token = tokens.Get(i);
            Variable? v = token.Length == 1 ? variableStorage.FindByName(token[0]) : null;

            if (v != null)
            {
                if (visited.Contains(token))
                    throw new Exception($"Cycle dependecy: {token}");
                
                visited.Add(token);
                result.Add("(");

                ArrayList<string> inner = ExpandTokens(v.Tokens, visited);
                
                for (int j = 0; j < inner.Count(); j++)
                {
                    result.Add(inner.Get(j));
                }

                result.Add(")");
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