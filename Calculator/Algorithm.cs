public class Algorithm
{
    private ArrayList<char> tokens;
    private Queue<char> output = new();
    private Stack<char> stack = new();
    private char[] precedence = { '+', '-', '*', '/' };
    private char[] operators = { '+', '-', '*', '/', '^' };

    public Algorithm(ArrayList<char> tokens)
    {
        this.tokens = tokens;
    }

    public Queue<char> ShuntingYard()
    {
        for (int i = 0; i < tokens.Count(); i++)
        {
            char token = tokens.Get(i);

            if (char.IsDigit(token))
                output.Enqueue(token);
            else if (operators.Contains(token))
            {
                if (stack.Count() == 0)
                    stack.Push(token);
                else
                {
                    while (stack.Count() > 0 && stack.Peek() != '(' &&  precedence.IndexOf(token) < precedence.IndexOf(stack.Peek()))
                    {   
                        output.Enqueue(stack.Pop());
                    }

                    stack.Push(token);
                }
            }
            else if (token == '(')
                stack.Push(token);
            else if (token == ')')
            {
                while (stack.Count() > 0 && stack.Peek() != '(')
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Pop();
            }
        }

        while (stack.Count() != 0)
        {
            output.Enqueue(stack.Pop());
        }

        return output;
    }
}