public class Algorithm
{
    private ArrayList<char> tokens;
    private Queue<char> output;
    private Stack<char> stack;
    private char[] operators;
    private char[] presedence = { '*', '/', '+', '-' };
    private char[] functions = { 's', 'c', 't', 'l', 'r' };

    public Algorithm(ArrayList<char> tokens, Queue<char> output, Stack<char> stack, char[] operators)
    {
        this.tokens = tokens;
        this.output = output;
        this.stack = stack;
        this.operators = operators;
    }

    public Queue<char> ShuntigYard()
    {
        for (int i = 0; i < tokens.Count(); i++)
        {
            char token = tokens.Get(i);

            if (char.IsDigit(token))
            {
                output.Enqueue(token);
            }
            else if (functions.Contains(token))
            {
                stack.Push(token);
            }
            else if (token == '(')
            {
                stack.Push(token);
            }
            else if (token == ')')
            {
                while (stack.Count() > 0 && stack.Peek() != '(')
                {
                    output.Enqueue(stack.Pop());
                }

                stack.Pop();

                if (stack.Count() > 0 && functions.Contains(stack.Peek()))
                {
                    output.Enqueue(stack.Pop());
                }
            }
            else if (operators.Contains(token))
            {
                while (stack.Count() > 0 && stack.Peek() != '(' && Array.IndexOf(presedence, stack.Peek()) <= Array.IndexOf(presedence, token))
                {
                    output.Enqueue(stack.Pop());
                }
                stack.Push(token);
            }
        }

        while (stack.Count() > 0)
        {
            output.Enqueue(stack.Pop());
        }

        return output;
    }
}