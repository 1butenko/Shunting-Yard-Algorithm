string input = Console.ReadLine() ?? string.Empty;

char[] operators = { '(', ')', '+', '-', '*', '/', '^' };

Tokenizer tokenizer = new Tokenizer(operators);
Queue<char> output = new();
Stack<char> stack = new();

Algorithm algorithm = new Algorithm(output, stack, operators);

Calculator calculator = new Calculator(operators, tokenizer, algorithm);

Console.WriteLine(calculator.calculate(input));