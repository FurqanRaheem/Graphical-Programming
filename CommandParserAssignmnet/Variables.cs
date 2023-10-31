using System;
using System.Collections.Generic;

namespace CommandParserAssignmnet
{
    internal class Variables
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
    }
}
