public class Tokenizer
{
    private char[] chars = { '(', ')', '+', '-', '*', '/', '^', ',' };
    private ArrayList<string> tokens = new();

    public ArrayList<string> Tokenize(string input)
    {
        tokens = new();
        
        for (int i = 0; i < input.Length; i++)
        {
            char s = input[i];

            if (char.IsDigit(s))
            {
                string number = "";
                while (i < input.Length && char.IsDigit(input[i]))
                {
                    number += input[i];
                    i++;
                }
                i--;
                tokens.Add(number);
            }
            else if (char.IsLetter(s))
            {
                string word = "";
                while (i < input.Length && char.IsLetter(input[i]))
                {
                    word += input[i];
                    i++;
                }
                i--;
                tokens.Add(word);
            }
            else if (chars.Contains(s))
            {
                tokens.Add(s.ToString());
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