public class Tokenizer
{
    private char[] operators { get; set; }
    private ArrayList<char> tokens = new();

    public Tokenizer(char[] operators)
    {
        this.operators = operators;
    }

    public ArrayList<char> Tokenize(string input)
    {
        char[] r = input.ToCharArray();
        foreach (var s in r)
        {
            if (char.IsDigit(s) || operators.Contains(s))
            {
                tokens.Add(s);
            }
            else if (!char.IsWhiteSpace(s))
            {
                throw new ArgumentException("This symbol is not supported!");
            }
        }
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