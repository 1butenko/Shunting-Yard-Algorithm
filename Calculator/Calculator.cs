public class Calculator
{
    private Logger logger;
    private Algorithm algorithm;
    private Stack<int> s = new();
    public char[] Operators { get => operators; }
    private char[] operators = { '+', '-', '*', '/', '^' };

    public Calculator(Algorithm algorithm, Logger logger)
    {
        this.algorithm = algorithm;
        this.logger = logger;
    }

    public int Calculate(ArrayList<char> tokens)
    {
        char[] rpn = algorithm.ShuntingYard(tokens).ToArray();

        logger.Log(rpn: rpn);

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

        return s.Pop();
    }
}