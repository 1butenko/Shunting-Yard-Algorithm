Tokenizer tokenizer = new Tokenizer();
Algorithm algorithm = new Algorithm();
VariableStorage storage = new VariableStorage();
Calculator calculator = new Calculator(tokenizer, algorithm, storage);

while (true)
{
    string input = Console.ReadLine() ?? string.Empty;

    if (input != string.Empty)
    {
        ArrayList<char> tokens = tokenizer.Tokenize(input);
        char[] rpn = algorithm.ShuntingYard(tokens).ToArray();

        if (storage.ContainName(input[0]))
        {
            Variable? variable = storage.FindByName(input[0]);
            if (variable != null)
                Console.WriteLine($"> {variable.Result}");
        } else if (tokens.Count() == 1 && char.IsLetter(input[0]) && !storage.ContainName(input[0]))
        {
            throw new Exception("Variable not found!");
        }
        else
        {
            Console.WriteLine("================================================");
            Console.WriteLine($"Reverse Polish Notation: {string.Join("", rpn)}");
            Console.WriteLine("================================================");
            Console.WriteLine($"Result: {calculator.calculate(input)}");
            Console.WriteLine("================================================");
            Console.WriteLine("Visualized AST: ");

            AbstractSyntaxTree ast = new();

            ast.Build(algorithm.ShuntingYard(tokens).ToArray());
            ast.Visualize();
        }
    }
}