using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNewStringCalculator.Expressions
{
    public class SimpleExpression : Expression
    {
        private Expression left;
        private Expression right;
        private Func<Expression, Expression, Double> evaluationFunction;

        public SimpleExpression(Expression left, Expression right, Func<Expression, Expression, Double> evaluationFunction)
        {
            this.left = left;
            this.right = right;
            this.evaluationFunction = evaluationFunction;
        }

        public Double Evaluate()
        {
            return evaluationFunction(left, right);
        }
    }
}
