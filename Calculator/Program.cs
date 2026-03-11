string input = Console.ReadLine() ?? string.Empty;

Tokenizer tokenizer = new Tokenizer();
Algorithm algorithm = new Algorithm();

Calculator calculator = new Calculator(tokenizer, algorithm);
Console.WriteLine(calculator.calculate(input));