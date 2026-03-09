public class Calculator
{
    private Algorithm algorithm;
    private Tokenizer tokenizer;
    public char[] Symbols {get => operators;}
    private char[] operators = { '+', '-', '*', '/', '^', 's', 'c', 'm' };

    public Calculator(Tokenizer tokenizer, Algorithm algorithm)
    {
        this.algorithm = algorithm;
        this.tokenizer = tokenizer;
    }

    public int calculate(string input)
    {
        ArrayList<char> tokens = tokenizer.Tokenize(input);
        char[] rpn = algorithm.ShuntingYard(tokens).ToArray();
    }
}