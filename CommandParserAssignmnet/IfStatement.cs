using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CommandParserAssignmnet
{
    public class IfStatement
    {
        private Variables variables;

        public IfStatement()
        {
            this.variables = Variables.Instance;
        }

        public void Execute(string expression, Action<string[]> action, string[] parameters)
        {
            /*bool result = EvaluateExpression(expression);*/
           /* if (result)
            {
                action(parameters);
            }*/
        }

        public bool EvaluateExpression(string variableName, string comparisonOperator, int value)
        {
            if (variables.ContainsVariable(variableName))
            {
                int variableValue = variables.GetVariable(variableName);

                switch (comparisonOperator)
                {
                    case ">":
                        return variableValue > value;
                    case "<":
                        return variableValue < value;
                    case ">=":
                        return variableValue >= value;
                    case "<=":
                        return variableValue <= value;
                    case "==":
                        return variableValue == value;
                    case "!=":
                        return variableValue != value;

                    default:
                        throw new ArgumentException("Invalid comparison operator.");
                }
            }
            return false; // If expression is not in the expected format or variable not found
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void GetCodeBlock(string input)
        {
            
        }
    }
}
