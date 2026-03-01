string input = Console.ReadLine() ?? string.Empty;
char[] r = input.ToCharArray();

char[] operators = { '(', ')', '+', '-', '*', '/' };

Tokenizer tokenizer = new Tokenizer(operators);
ArrayList<char> tokens = tokenizer.Tokenize(input);
Queue<char> output = new();
Stack<char> stack = new();

Algorithm algorithm = new Algorithm(tokens, output, stack, operators);

Console.WriteLine(string.Join(" ", algorithm.ShuntigYard().ToArray()));