string input = Console.ReadLine() ?? string.Empty;

char[] operators = { '(', ')', '+', '-', '*', '/', '^' };

Tokenizer tokenizer = new Tokenizer(operators);

ArrayList<char> tokens = tokenizer.Tokenize(input);

Algorithm algorithm = new Algorithm(tokens);

Queue<char> output = algorithm.ShuntingYard();

// Calculator calculator = new Calculator(operators, tokenizer, algorithm);

Console.WriteLine(String.Join("", output.ToArray()));