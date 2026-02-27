public class Tokenizer
{
    private char[] operators { get; set; }
    private ArrayList<string> tokens = new();
    private string buffer = String.Empty;
    public Tokenizer(char[] operators)
    {
        this.operators = operators;
    }

    public ArrayList<string> Tokenize(string input)
    {
        char[] r = input.ToCharArray();

        foreach (var s in r)
        {
            {
                if (char.IsDigit(s))
                {
                    buffer += s;
                }
                else if (char.IsWhiteSpace(s))
                {
                    if (!string.IsNullOrEmpty(buffer))
                    {
                        tokens.Add(buffer);
                        buffer = String.Empty;
                    }
                }
                else if (operators.Contains(s))
                {
                    if (!string.IsNullOrEmpty(buffer))
                    {
                        tokens.Add(buffer);
                        buffer = String.Empty;
                    }
                    tokens.Add(s.ToString());
                }
                else
                {
                    throw new ArgumentException("This symbol is not supported!");
                }
            }
        }

        if (!string.IsNullOrEmpty(buffer))
            tokens.Add(buffer);

        return tokens;
    }

    public void GetTokens()
    {
        Console.WriteLine($"Total tokens: {tokens.Count()}\nTokens:");

        for (int i = 0; i < tokens.Count(); i++)
        {
            Console.Write(tokens.Get(i));
        }
    }
}