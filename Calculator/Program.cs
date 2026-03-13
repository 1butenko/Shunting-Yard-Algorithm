Logger logger = new Logger();
Tokenizer tokenizer = new Tokenizer();
Algorithm algorithm = new Algorithm();
VariableStorage storage = new VariableStorage();
Calculator calculator = new Calculator(algorithm, logger);
VariableManager variableManager = new VariableManager(storage, calculator);

while (true){
    string input = Console.ReadLine() ?? string.Empty;
    ArrayList<char> tokens = tokenizer.Tokenize(input);

    int result = variableManager.ProcessVariablesAndCalculate(tokens);

    if (tokens.Count() > 1 && char.IsLetter(tokens.Get(0)) || tokens.Count() == 1 && char.IsLetter(tokens.Get(0)))
    {
        logger.Log(result: result);
    }
    else
    {
        AbstractSyntaxTree ast = new();
        ast.Build(algorithm.ShuntingYard(tokens).ToArray());
        logger.Log(ast: ast, result: result, logAst: true);
    }
}