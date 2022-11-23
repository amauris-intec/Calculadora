using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Calculadora : CalculadoraBaseVisitor<int>
    {
        Dictionary<string, int> variables = new Dictionary<string, int>();
        List<string> output = new List<string>();

        public List<string> Output { get { return output; } }
        public Dictionary<string, int> Variables { get { return variables; } }


        public override int VisitAsignacion([NotNull] CalculadoraParser.AsignacionContext context)//
        {
            int expr = Visit(context.expresion());
            string variable = context.ID().GetText();
            variables[variable] = expr;
            output.Add($"{variable} <= {expr}");
            return 0;
        }

        public override int VisitComando([NotNull] CalculadoraParser.ComandoContext context)//
        {
            if (context.expresion() != null)
            {
                int expr = Visit(context.expresion());
                output.Add(expr.ToString());
                return expr;
            }
            else //context.asignacion() != null
            {
                Visit(context.asignacion());
                return 0;
            }
            
        }

        public override int VisitFactorSolo([NotNull] CalculadoraParser.FactorSoloContext context)//
        {
            return Visit(context.factor());
        }

        public override int VisitIdentificador([NotNull] CalculadoraParser.IdentificadorContext context)//
        {
            return variables[context.ID().GetText()];
        }

        public override int VisitMulODiv([NotNull] CalculadoraParser.MulODivContext context)//
        {
            if (context.op.Type == CalculadoraParser.MUL)
                return Visit(context.termino()) * Visit(context.factor());
            else //(context.op.Type == CalculadoraParser.DIV)
                return Visit(context.termino()) / Visit(context.factor());
        }

        public override int VisitNumero([NotNull] CalculadoraParser.NumeroContext context)//
        {
            return int.Parse(context.NUM().GetText());
        }

        public override int VisitScript([NotNull] CalculadoraParser.ScriptContext context)
        {
            return base.VisitScript(context);
        }

        public override int VisitSubexpresion([NotNull] CalculadoraParser.SubexpresionContext context)//
        {
            return Visit(context.expresion());
        }

        public override int VisitSumORes([NotNull] CalculadoraParser.SumOResContext context)//
        {
            if (context.op.Type == CalculadoraParser.SUM)
                return Visit(context.expresion()) + Visit(context.termino());
            else //(context.op.Type == CalculadoraParser.RES)
                return Visit(context.expresion()) - Visit(context.termino());
        }

        public override int VisitTerminoSolo([NotNull] CalculadoraParser.TerminoSoloContext context)//
        {
            return Visit(context.termino());
        }
    }
}
