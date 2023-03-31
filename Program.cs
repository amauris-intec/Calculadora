using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;
using Calculadora;


string getInput()
{
    string input = "";
    string? line = "";
    int n = 0;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("     0.........1.........2.........3.........4.........5.........\n" +
                      "     012345678901234567890123456789012345678901234567890123456789\n");
    Console.ResetColor();
    do
    {
        n++;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{n}:   ");
        Console.ResetColor();
        line = Console.ReadLine();
        input += line + "\n";
    } while (line != "");

    return input;
}

IParseTree parse(string input)
{
    ImmediateErrorListener errListener = ImmediateErrorListener.Instance;
    var inputStream = CharStreams.fromString(input);
    var lexer = new CalculadoraLexer(inputStream);
    var tokenStream = new CommonTokenStream(lexer);
    var parser = new CalculadoraParser(tokenStream);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(errListener);
    var tree = parser.script();
    return tree;
}

Console.WriteLine("Escribe lo que quieres calcular " +
"(deja una linea vacía para iniciar él cálculo)");

bool todoBien = false;
IParseTree? tree = null;
string input;

do
{
    input = getInput();
    try
    { 
        tree = parse(input);
        todoBien = true;
    }
    catch (ParseCanceledException e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        Console.WriteLine("Vuelva a escribir lo que quiera calcular, y esta vez, hágalo bien...");
        continue;
    }

} while (!todoBien);


var calculadora = new Calculadora.Calculadora();
calculadora.Visit(tree);

Console.WriteLine("Output:");
int n = 0;
foreach (string line in calculadora.Output)
{
    n++;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write($"{n}:   ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(line);
    Console.ResetColor();
}

Console.WriteLine("Presione cualquier tecla para finalizar...");
Console.ReadKey();