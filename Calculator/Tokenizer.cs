public class Tokenizer
{
    private char[] chars = { '(', ')', '+', '-', '*', '/', '^', 's', 'c', 'm', ',' };
    private ArrayList<char> tokens = new();

    public ArrayList<char> Tokenize(string input)
    {
        tokens = new();
        
        char[] r = input.ToCharArray();
        foreach (var s in r)
        {
            if (char.IsDigit(s) || chars.Contains(s) || char.IsLetter(s))
            {
                tokens.Add(s);
            }
            else if (!char.IsWhiteSpace(s) && s != '=')
            {
                throw new ArgumentException($"This symbol is not supported: {s}");
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