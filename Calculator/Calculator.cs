public class Calculator
{
    private Logger logger;
    private Algorithm algorithm;
    private Stack<int> s = new();
    public string[] Operators { get => operators; }
    private string[] operators = { "+", "-", "*", "/", "^" };

    public Calculator(Algorithm algorithm, Logger logger)
    {
        this.algorithm = algorithm;
        this.logger = logger;
    }

    public int Calculate(ArrayList<string> tokens)
    {
        string[] rpn = algorithm.ShuntingYard(tokens).ToArray();

        logger.Log(rpn: rpn);

        foreach (var t in rpn)
        {
            if (char.IsDigit(t[0]))
            {
                s.Push(int.Parse(t));
            }
            else if (operators.Contains(t) || t == "max")
            {
                int firstNumber = s.Pop();
                int secondNumber = s.Pop();

                int result = t switch
                {
                    "+" => secondNumber + firstNumber,
                    "-" => secondNumber - firstNumber,
                    "*" => secondNumber * firstNumber,
                    "/" => secondNumber / firstNumber,
                    "^" => (int)Math.Pow(secondNumber, firstNumber),
                    "max" => Math.Max(secondNumber, firstNumber),
                    _ => throw new Exception("Operation not found!")
                };

                s.Push(result);
            }
            else if (t == "clamp")
            {
                int max = s.Pop();
                int min = s.Pop();
                int val = s.Pop();

                s.Push(Math.Clamp(val, min, max));
            }
            else if (t == "sin" || t == "cos")
            {
                int num = s.Pop();
                int result = t switch
                {
                    "sin" => (int)Math.Sin(Convert.ToDouble(num)),
                    "cos" => (int)Math.Cos(Convert.ToDouble(num)),
                    _ => throw new Exception("Function not found!")
                };
                s.Push(result);
            }
        }

        return s.Pop();
    }
}