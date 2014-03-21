using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNewStringCalculator
{
    public class Calculator
    {
        private ExpressionParser parser;

        public Calculator(ExpressionParser parser)
        {
            this.parser = parser;

        }
        public int Calculate(String input)
        {
            return parser.Parse(input).Evaluate();
        }
    }

    public class ExpressionParser
    {
        private String[] operators = new[] { "+", "-", "*", "/" };

        public Expression Parse(String input)
        {
            if (String.IsNullOrEmpty(input))
                return new ConstantExpression("0");

            var @operator = GetFirstOperator(input);
            var indexOfOperator = input.IndexOf(@operator, 1);
            
            if (@operator == String.Empty)
                return new ConstantExpression(input);

            var left = Parse(input.Substring(0, indexOfOperator));
            var right = Parse(input.Substring(indexOfOperator + @operator.Length));

            if (@operator == "+")
                return new AdditionExpression(left, right);

            if (@operator == "-")
                return new SubtractionExpression(left, right);

            if (@operator == "*")
                return new MultiplicationExpression(left, right);

            if (@operator == "/")
                return new DivisionExpression(left, right);

            throw new NotImplementedException();
        }

        private String GetFirstOperator(String input, Int32 startIndex = 1)
        {
            var operatorIndexes = new Dictionary<Int32, String>();

            foreach (var @operator in operators)
            {
                var index = input.IndexOf(@operator, startIndex);

                if (index != -1)
                    operatorIndexes.Add(index, @operator);
            }

            if (operatorIndexes.Any() == false)
                return String.Empty;

            var lowestIndex = operatorIndexes.Keys.Min();

            return operatorIndexes[lowestIndex];
        }
    }

    public interface Expression
    {
        Int32 Evaluate();
    }

    public class DivisionExpression : Expression
    {
        private Expression left, right;

        public DivisionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Int32 Evaluate()
        {
            return left.Evaluate() / right.Evaluate();
        }
    }

    public class MultiplicationExpression : Expression
    {
        private Expression left, right;

        public MultiplicationExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Int32 Evaluate()
        {
            return left.Evaluate() * right.Evaluate();
        }
    }

    public class SubtractionExpression : Expression
    {
        private Expression left, right;

        public SubtractionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Int32 Evaluate()
        {
            return left.Evaluate() - right.Evaluate();
        }
    }

    public class AdditionExpression : Expression
    {
        private Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Int32 Evaluate()
        {
            return left.Evaluate() + right.Evaluate();
        }
    }

    public class ConstantExpression : Expression
    {
        private String input;

        public ConstantExpression(String input)
        {
            this.input = input;
        }
    
        public Int32 Evaluate()
        {
 	        return Convert.ToInt32(input);
        }

        public override String ToString()
        {
            return input;
        }
    }
}
