using System;
using System.Collections.Generic;

namespace CommandParserAssignmnet
{
    public class Variables
    {
        private static Variables instance;
        private Dictionary<string, int> variableKeyValuePairs = new Dictionary<string, int>();

        private Variables()
        {
            // Private constructor to prevent external instantiation.
        }

        public static Variables Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Variables();
                }
                return instance;
            }
        }

        public void AddVariable(string variableName, int variableValue)
        {
            variableKeyValuePairs.Add(variableName, variableValue);
        }

        public int GetVariable(string variableName)
        {
            return variableKeyValuePairs[variableName];
        }

        public void SetVariable(string variableName, int variableValue)
        {
            variableKeyValuePairs[variableName] = variableValue;
        }

        public bool ContainsVariable(string variableName)
        {
            return variableKeyValuePairs.ContainsKey(variableName);
        }

        public void RemoveVariable(string variableName)
        {
            variableKeyValuePairs.Remove(variableName);
        }

        public void clearVariables()
        {
            variableKeyValuePairs.Clear();
        }

        public void ParseDeclaration(string input)
        {
            // Split input into parts
            string[] parts = input.Split('=');

            ThrowIf.Argument.ValidateExactArgumentCount(parts, 2, new Exception("Invalid variable assignment."));
            ThrowIf.Argument.IsStringEmpty(parts[0], new Exception("Variable name cannot be empty."));
            ThrowIf.Argument.ParsableToType<int>(parts[0], new Exception("Variable name cannot be a number."));
            ThrowIf.Argument.NotParsableToType<int>(parts[1], new Exception("Invalid value type. Value must be an integer."));

            string variableName = parts[0].Trim().ToLower();
            int variableValue = int.Parse(parts[1]);

            // Check if variable is already in dictionary
            if (ContainsVariable(variableName))
            {
                // If variable is already in dictionary, update the value
                SetVariable(variableName, variableValue);
            }
            else
            {
                // If variable is not in dictionary, add it
                AddVariable(variableName, variableValue);
            }
        }
    }
}
