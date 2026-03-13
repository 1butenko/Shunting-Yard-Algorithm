public class Algorithm
{
    private Queue<string> output = new();
    private Stack<string> stack = new();
    private string[] precedence = { "+", "-", "*", "/" };
    private string[] operators = { "+", "-", "*", "/", "^" };
    private string[] functions = { "sin", "cos", "max", "clamp" };

    public Queue<string> ShuntingYard(ArrayList<string> tokens)
    {
        output = new();
        stack = new();

        for (int i = 0; i < tokens.Count(); i++)
        {
            string token = tokens.Get(i);

            if (char.IsDigit(token[0]))
                output.Enqueue(token);
            else if (functions.Contains(token))
                stack.Push(token);
            else if (token == ",")
            {
                while (stack.Peek() != "(")
                {
                    output.Enqueue(stack.Pop());
                }
            }
            else if (operators.Contains(token))
            {
                if (stack.Count() == 0)
                    stack.Push(token);
                else
                {
                    while (stack.Count() > 0 && stack.Peek() != "(" &&  Array.IndexOf(precedence, token) <= Array.IndexOf(precedence, stack.Peek()))
                    {   
                        output.Enqueue(stack.Pop());
                    }

                    stack.Push(token);
                }
            }
            else if (token == "(")
                stack.Push(token);
            else if (token == ")")
            {
                while (stack.Count() > 0 && stack.Peek() != "(")
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count() > 0 && functions.Contains(stack.Peek()))
                    output.Enqueue(stack.Pop());
            }
        }

        while (stack.Count() != 0)
        {
            output.Enqueue(stack.Pop());
        }

        return output;
    }
}