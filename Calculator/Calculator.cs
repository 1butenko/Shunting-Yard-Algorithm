public class Calculator
{
    private Algorithm algorithm;
    private Tokenizer tokenizer;
    private VariableStorage variableStorage;
    private char? variableName = null;
    private Stack<int> s = new();
    public char[] Operators { get => operators; }
    private char[] operators = { '+', '-', '*', '/', '^' };

    public Calculator(Tokenizer tokenizer, Algorithm algorithm, VariableStorage variableStorage)
    {
        this.algorithm = algorithm;
        this.tokenizer = tokenizer;
        this.variableStorage = variableStorage;
    }

    public int calculate(string input)
    {
        ArrayList<char> tokens = tokenizer.Tokenize(input);

        if (char.IsLetter(tokens.Get(0)))
        {
            variableName = tokens.Get(0);
            tokens.Remove(tokens.Get(0));
        }

        char[] rpn = algorithm.ShuntingYard(tokens).ToArray();

        foreach (var t in rpn)
        {
            if (char.IsDigit(t))
            {
                s.Push(t - '0');
            }
            else if (operators.Contains(t) || t == 'm')
            {
                int firstNumber = s.Pop();
                int secondNumber = s.Pop();

                int result = t switch
                {
                    '+' => secondNumber + firstNumber,
                    '-' => secondNumber - firstNumber,
                    '*' => secondNumber * firstNumber,
                    '/' => secondNumber / firstNumber,
                    '^' => (int)Math.Pow(secondNumber, firstNumber),
                    'm' => Math.Max(secondNumber, firstNumber),
                    _ => throw new Exception("Operation not found!")
                };

                s.Push(result);
            }
            else if (t == 's' || t == 'c')
            {
                int num = s.Pop();
                int result = t switch
                {
                    's' => (int)Math.Sin(Convert.ToDouble(num)),
                    'c' => (int)Math.Cos(Convert.ToDouble(num)),
                    _ => throw new Exception("Function not found!")
                };
                s.Push(result);
            }
        }

        if (variableName.HasValue)
        {
            variableStorage.Add(new Variable(variableName.Value, rpn, variableStorage, s.Peek()));
        }

        return s.Pop();
    }
}