//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\ama\source\repos\Calculadora\Calculadora.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CalculadoraParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface ICalculadoraVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculadoraParser.script"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScript([NotNull] CalculadoraParser.ScriptContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculadoraParser.comando"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitComando([NotNull] CalculadoraParser.ComandoContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CalculadoraParser.asignacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAsignacion([NotNull] CalculadoraParser.AsignacionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>sumORes</c>
	/// labeled alternative in <see cref="CalculadoraParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSumORes([NotNull] CalculadoraParser.SumOResContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>terminoSolo</c>
	/// labeled alternative in <see cref="CalculadoraParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerminoSolo([NotNull] CalculadoraParser.TerminoSoloContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>mulODiv</c>
	/// labeled alternative in <see cref="CalculadoraParser.termino"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMulODiv([NotNull] CalculadoraParser.MulODivContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>factorSolo</c>
	/// labeled alternative in <see cref="CalculadoraParser.termino"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFactorSolo([NotNull] CalculadoraParser.FactorSoloContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>numero</c>
	/// labeled alternative in <see cref="CalculadoraParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumero([NotNull] CalculadoraParser.NumeroContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identificador</c>
	/// labeled alternative in <see cref="CalculadoraParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentificador([NotNull] CalculadoraParser.IdentificadorContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subexpresion</c>
	/// labeled alternative in <see cref="CalculadoraParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubexpresion([NotNull] CalculadoraParser.SubexpresionContext context);
}
