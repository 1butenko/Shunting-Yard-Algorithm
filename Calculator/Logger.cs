public class Logger()
{
    public void Log(AbstractSyntaxTree? ast = null, string[]? rpn = null, int? result = null, bool logAst = false)
    {
        if (rpn != null)
        {
            Console.WriteLine("================================================");
            Console.WriteLine($"Reverse Polish Notation: {string.Join(" ", rpn)}");
        }

        if (result != null)
        {
            Console.WriteLine("================================================");
            Console.WriteLine($"Result: {result}");
        }

        if (logAst && ast != null)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Visualized AST: ");
            ast.Visualize();
        }
    }
}