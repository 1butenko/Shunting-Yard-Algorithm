string input = Console.ReadLine() ?? string.Empty;

char[] operators = { '(', ')', '+', '-', '*', '/', '^', 's', 'c', 'm', ',' };

Tokenizer tokenizer = new Tokenizer(operators);

ArrayList<char> tokens = tokenizer.Tokenize(input);

Algorithm algorithm = new Algorithm();

Calculator calculator = new Calculator(tokenizer, algorithm);
Console.WriteLine(calculator.calculate(input));