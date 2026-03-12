string input = Console.ReadLine() ?? string.Empty;

Tokenizer tokenizer = new Tokenizer();
Algorithm algorithm = new Algorithm();

ArrayList<char> tokens = tokenizer.Tokenize(input);

Calculator calculator = new Calculator(tokenizer, algorithm);

char[] rpn = algorithm.ShuntingYard(tokens).ToArray();

Console.WriteLine("================================================");
Console.WriteLine($"Reverse Polish Notation: {string.Join("", rpn)}");
Console.WriteLine("================================================");
Console.WriteLine($"Result: {calculator.calculate(input)}");
Console.WriteLine("================================================");
Console.WriteLine("Visualized AST: ");

AbstractSyntaxTree ast = new();

ast.Build(algorithm.ShuntingYard(tokens).ToArray());
ast.Visualize();