using System;
using System.Collections.Generic;
using TheNewStringCalculator.Expressions;

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
                    return new SimpleExpression(left, right, (a,b) => a.Evaluate() + b.Evaluate());

                if (@operator == Operator.Subtract)
                    return new SimpleExpression(left, right, (a, b) => a.Evaluate() - b.Evaluate());

                if (@operator == Operator.Multiply)
                    return new SimpleExpression(left, right, (a, b) => a.Evaluate() * b.Evaluate());

                if (@operator == Operator.Divide)
                    return new SimpleExpression(left, right, (a, b) => a.Evaluate() / b.Evaluate());
            }

            return new ConstantExpression(token);
        }
    }    
}
