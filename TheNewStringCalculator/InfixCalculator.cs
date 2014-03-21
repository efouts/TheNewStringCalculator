using System;
using System.Collections.Generic;

namespace TheNewStringCalculator
{
    public class InfixCalculator
    {
        private Stack<Expression> operands;
        private PostFixConverter postfixConverter;
        private Dictionary<String, Operator> operatorsMap;
        
        public InfixCalculator(Dictionary<String, Operator> operatorsMap)
        {
            this.postfixConverter = new PostFixConverter(operatorsMap);
            this.operatorsMap = operatorsMap;
        }

        public Double Calculate(String input)
        {
            if (String.IsNullOrEmpty(input))
                return 0;

            var postfixInput = postfixConverter.ConvertFromInfix(input);

            operands = new Stack<Expression>();

            var tokens = postfixInput.Split(' ');

            foreach(var token in tokens)
                operands.Push(CreateExpression(token));

            return operands.Pop().Evaluate();
        }

        private Expression CreateExpression(String token)
        {
            if (operatorsMap.ContainsKey(token))
            {
                var right = operands.Pop();
                var left = operands.Pop();
                var @operator = operatorsMap[token];

                if (@operator == Operator.Add)
                    return new AdditionExpression(left, right);

                if (@operator == Operator.Subtract)
                    return new SubtractionExpression(left, right);

                if (@operator == Operator.Multiply)
                    return new MultiplicationExpression(left, right);

                if (@operator == Operator.Divide)
                    return new DivisionExpression(left, right);
            }

            return new ConstantExpression(token);
        }
    }

    public interface Expression
    {
        Double Evaluate();
    }

    public class DivisionExpression : Expression
    {
        private Expression left, right;

        public DivisionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public Double Evaluate()
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

        public Double Evaluate()
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

        public Double Evaluate()
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

        public Double Evaluate()
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

        public Double Evaluate()
        {
            return Convert.ToDouble(input);
        }

        public override String ToString()
        {
            return input;
        }
    }
}
