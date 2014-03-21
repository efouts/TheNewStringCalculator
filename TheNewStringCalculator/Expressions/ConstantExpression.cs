using System;

namespace TheNewStringCalculator.Expressions
{
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
