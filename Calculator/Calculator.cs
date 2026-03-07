// public class Calculator
// {
//     private char[] operators;
//     private Tokenizer tokenizer;
//     private Algorithm algorithm;

//     public Calculator(char[] operators, Tokenizer tokenizer, Algorithm algorithm)
//     {
//         this.operators = operators;
//         this.tokenizer = tokenizer;
//         this.algorithm = algorithm;
//     }

//     public int calculate(string input)
//     {
//         ArrayList<char> tokens = tokenizer.Tokenize(input);
//         char[] postfixTokens = algorithm.ShuntigYard(tokens).ToArray();

//         Console.WriteLine(string.Join(" ", postfixTokens));

//         Stack<int> buffer = new();

//         foreach (var t in postfixTokens)
//         {
//             if (char.IsDigit(t))
//                 buffer.Push((int)char.GetNumericValue(t));
//             else if (operators.Contains(t))
//             {
//                 int firstNumber = buffer.Pop();
//                 int secondNumber = buffer.Pop();

//                 int result = t switch
//                 {
//                     '+' => firstNumber + secondNumber,
//                     '-' => firstNumber - secondNumber,
//                     '*' => firstNumber * secondNumber,
//                     '/' => firstNumber / secondNumber,
//                     '^' => (int)Math.Pow(firstNumber, secondNumber),
//                     _ => throw new InvalidOperationException($"Unknown operator: {t}")
//                 };

//                 buffer.Push(result);
//             }
//         }

//         return buffer.Pop();
//     }
// }