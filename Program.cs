using Antlr4.Runtime;

Console.WriteLine("Escribe lo que quieres calcular " + 
    "(deja una linea vacía para iniciar él cálculo)");

string input = "";
string? line = "";

do
{
    line = Console.ReadLine();
    input += line + "\n";
} while (line != "");

Console.WriteLine("Iniciando Cálculo:");

var inputStream = CharStreams.fromString(input);
var lexer = new CalculadoraLexer(inputStream);
var tokenStream = new CommonTokenStream(lexer);
var parser = new CalculadoraParser(tokenStream);
var tree = parser.script();
var calculadora = new Calculadora.Calculadora();
calculadora.Visit(tree);
