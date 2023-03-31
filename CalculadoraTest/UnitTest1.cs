using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Calculadora;
using FluentAssertions;

namespace CalculadoraTest
{
    public class UnitTest1
    {

        private IParseTree ParseInput(string input)
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

        private CalculadoraParser GetParser(string input)
        {
            ImmediateErrorListener errListener = ImmediateErrorListener.Instance;
            var inputStream = CharStreams.fromString(input);
            var lexer = new CalculadoraLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new CalculadoraParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errListener);
            return parser;
        }

        [Fact]
        public void Assign_command_should_create_variable_in_list()
        {
            // Arrange
            string input = "a=5+5";
            var tree = ParseInput(input);
            var sut = new Calculadora.Calculadora();

            // Act
            sut.Visit(tree);

            // Assert
            sut.Variables.Should().ContainKey("a");
            sut.Variables.Should().HaveCount(1);
            sut.Variables["a"].Should().Be(10);
        }

        [Fact]
        public void Single_line_syntax_errors_should_throw_exception()
        {
            // Arrange
            string input = "a==5+5";
            CalculadoraParser sut = GetParser(input);

            // Act
            Action action = () => { sut.script(); };

            // Assert
            action.Should().Throw<ParseCanceledException>();
        }
    }
}