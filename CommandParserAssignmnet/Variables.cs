using System;
using System.Collections.Generic;

namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents a singleton class for managing variables and their values in the command parser.
    /// </summary>  
    public class Variables
    {
        private static Variables instance;
        private Dictionary<string, int> variableKeyValuePairs = new Dictionary<string, int>();

        /// <summary>
        /// Private constructor to prevent external instantiation.
        /// </summary>
        private Variables() {}

        /// <summary>
        /// Gets the instance of the <see cref="Variables"/> class.
        /// </summary>
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

        /// <summary>
        /// Adds a variable with the specified name and value.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="variableValue">The value of the variable.</param>
        public void AddVariable(string variableName, int variableValue)
        {
            variableKeyValuePairs.Add(variableName, variableValue);
        }

        /// <summary>
        /// Gets the value of the variable with the specified name.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <returns>The value of the variable.</returns>
        public int GetVariable(string variableName)
        {
            return variableKeyValuePairs[variableName];
        }

        /// <summary>
        /// Sets the value of the variable with the specified name.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <param name="variableValue">The new value of the variable.</param>
        public void SetVariable(string variableName, int variableValue)
        {
            variableKeyValuePairs[variableName] = variableValue;
        }

        /// <summary>
        /// Checks if the dictionary contains a variable with the specified name.
        /// </summary>
        /// <param name="variableName">The name of the variable.</param>
        /// <returns>True if the variable is present; otherwise, false.</returns>
        public bool ContainsVariable(string variableName)
        {
            return variableKeyValuePairs.ContainsKey(variableName);
        }

        /// <summary>
        /// Removes the variable with the specified name from the dictionary.
        /// </summary>
        /// <param name="variableName">The name of the variable to remove.</param>
        public void RemoveVariable(string variableName)
        {
            variableKeyValuePairs.Remove(variableName);
        }

        /// <summary>
        /// Clears all variables from the dictionary.
        /// </summary>
        public void clearVariables()
        {
            variableKeyValuePairs.Clear();
        }

        /// <summary>
        /// Parses a variable declaration from the input and updates the dictionary accordingly.
        /// </summary>
        /// <param name="input">The input string representing the variable declaration.</param>
        /// <exception cref="Exception">Thrown when there is an issue with the variable assignment.</exception>
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
