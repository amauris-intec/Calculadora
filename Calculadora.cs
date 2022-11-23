using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal class Calculadora : CalculadoraBaseVisitor<float>
    {
        Dictionary<string, float> variables = new Dictionary<string, float>();
        List<string> output = new List<string>();

        public List<string> Output { get { return output; } }
        public Dictionary<string, float> Variables { get { return variables; } }


        public override float VisitAsignacion([NotNull] CalculadoraParser.AsignacionContext context)//
        {
            float expr = Visit(context.expresion());
            string variable = context.ID().GetText();
            variables[variable] = expr;
            output.Add($"{variable} <= {expr}");
            return 0;
        }

        public override float VisitComando([NotNull] CalculadoraParser.ComandoContext context)//
        {
            if (context.expresion() != null)
            {
                float expr = Visit(context.expresion());
                output.Add(expr.ToString());
                return expr;
            }
            else //context.asignacion() != null
            {
                Visit(context.asignacion());
                return 0;
            }
            
        }

        public override float VisitFactorSolo([NotNull] CalculadoraParser.FactorSoloContext context)//
        {
            return Visit(context.factor());
        }

        public override float VisitIdentificador([NotNull] CalculadoraParser.IdentificadorContext context)//
        {
            return variables[context.ID().GetText()];
        }

        public override float VisitMulODiv([NotNull] CalculadoraParser.MulODivContext context)//
        {
            if (context.op.Type == CalculadoraParser.MUL)
                return Visit(context.termino()) * Visit(context.factor());
            else //(context.op.Type == CalculadoraParser.DIV)
                return Visit(context.termino()) / Visit(context.factor());
        }

        public override float VisitNumero([NotNull] CalculadoraParser.NumeroContext context)//
        {
            return float.Parse(context.NUM().GetText());
        }

        public override float VisitScript([NotNull] CalculadoraParser.ScriptContext context)
        {
            return base.VisitScript(context);
        }

        public override float VisitSubexpresion([NotNull] CalculadoraParser.SubexpresionContext context)//
        {
            return Visit(context.expresion());
        }

        public override float VisitSumORes([NotNull] CalculadoraParser.SumOResContext context)//
        {
            if (context.op.Type == CalculadoraParser.SUM)
                return Visit(context.expresion()) + Visit(context.termino());
            else //(context.op.Type == CalculadoraParser.RES)
                return Visit(context.expresion()) - Visit(context.termino());
        }

        public override float VisitTerminoSolo([NotNull] CalculadoraParser.TerminoSoloContext context)//
        {
            return Visit(context.termino());
        }
    }
}
