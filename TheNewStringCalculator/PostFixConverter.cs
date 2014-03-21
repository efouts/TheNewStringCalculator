using System;
using System.Collections.Generic;

namespace TheNewStringCalculator
{
    public class PostFixConverter
    {
        private List<String> output;
        private Stack<String> operatorStack;
        private Comparer<Operator> operatorComparer;
        private Dictionary<String, Operator> operatorsMap;

        public PostFixConverter(Dictionary<String, Operator> operatorsMap)
        {
            this.output = new List<String>();
            this.operatorStack = new Stack<String>();
            this.operatorComparer = new OperatorComparer();
            this.operatorsMap = operatorsMap;
        }

        public String ConvertFromInfix(String input)
        {
            var tokens = input.Split(' ');

            foreach(var token in tokens)
            {
                if (operatorsMap.ContainsKey(token))
                {
                    while (operatorStack.Count > 0 && operatorComparer.Compare(operatorsMap[token], operatorsMap[operatorStack.Peek()]) <= 0)
                        output.Add(operatorStack.Pop());

                    operatorStack.Push(token);
                }
                else
                {
                    output.Add(token);
                }
            }

            while (operatorStack.Count > 0)
                output.Add(operatorStack.Pop());

            return String.Join(" ", output);
        }
    }
}
