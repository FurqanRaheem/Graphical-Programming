using System;

namespace CommandParserAssignmnet
{
    // Reference: https://mariusschulz.com/blog/implementing-an-exception-helper-class-for-parameter-null-checking
    /// <summary>
    /// Contains methods for throwing exceptions.
    /// </summary>
    public static class ThrowIf
    {
        /// <summary>
        /// Contains methods for argument validation.
        /// </summary>
        public static class Argument
        {
            /// <summary>
            /// Veifies that the specified argument is not null.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentNullException"></exception>
            public static void IsNull(object argument, string argumentName, string methodName)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(argumentName, $"The method '{methodName}' expects a non-null argument, {argumentName} cannot be null.");
                }
            }
          
            /// <summary>
            /// Verifies that the specified argument is not negative.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void IsNegative(int argument, string argumentName, string methodName)
            {
                if (argument < 0)
                {
                    throw new ArgumentOutOfRangeException(argumentName, $"The method '{methodName}' expects a non-negative argument, {argumentName} cannot be negative.");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is not out of the specified range.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="minValue"></param>
            /// <param name="maxValue"></param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void IsOutOfRange(int argument, string argumentName, int minValue, int maxValue)
            {
                if (argument < minValue || argument > maxValue)
                {
                    throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} is out of the valid range [{minValue}, {maxValue}].");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is not lower than the specified value.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="maxValue"></param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void isHigherThan(int argument, string argumentName, int maxValue)
            {
                if (argument > maxValue)
                {
                    throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} is out of the valid range [{maxValue}, ∞].");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is not higher than the specified value.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="minValue"></param>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static void IsLowerThan(int argument, string argumentName, int minValue)
            {
                if (argument < minValue)
                {
                    throw new ArgumentOutOfRangeException(argumentName, $"{argumentName} is out of the valid range [0, {minValue}].");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is not an empty string.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void IsStringEmpty(string argument, string argumentName, string methodName)
            {
                if (argument == string.Empty)
                {
                    throw new ArgumentException(argumentName, $"The method '{methodName}' expects a non-empty string argument, {argumentName} cannot be empty.");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is not an empty string.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="exception"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void IsStringEmpty(string argument, Exception exception)
            {
                if (argument == string.Empty)
                {
                    throw exception;
                }
            }

            /// <summary>
            /// Verifies that the specified arguments array has the specified length.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="arguments"></param>
            /// <param name="expectedCount"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void ValidateExactArgumentCount<T>(T[] arguments, int expectedCount, string methodName)
            {
                int actualCount = arguments.Length;
                if (actualCount != expectedCount)
                {
                    throw new ArgumentException($"The method '{methodName}' expects {expectedCount} arguments, but {actualCount} were provided.");
                }
            }

            /// <summary>
            /// Verifies that the specified arguments array has the specified length.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="arguments"></param>
            /// <param name="expectedCount"></param>
            /// <param name="exception"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void ValidateExactArgumentCount<T>(T[] arguments, int expectedCount, Exception exception)
            {
                int actualCount = arguments.Length;
                if (actualCount != expectedCount)
                {
                    throw exception;
                }
            }

            /// <summary>
            /// Verifies that the specified arguments array has the specified length.
            /// </summary>
            /// <param name="actualCount"></param>
            /// <param name="expectedCount"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void ValidateExactArgumentCount(int actualCount, int expectedCount, string methodName)
            {
                if (actualCount != expectedCount)
                {
                    throw new ArgumentException($"The method '{methodName}' expects {expectedCount} arguments, but {actualCount} were provided.");
                }
            }

            /// <summary>
            /// Verifies that the specified argument is of the specified type.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="expectedType"></param>
            /// <param name="argumentName"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void EnsureArgumentType(object argument, Type expectedType, string argumentName, string methodName)
            {
                if (argument.GetType() != expectedType)
                {
                    throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be of type {expectedType.Name}.", methodName);
                }
            }

            public static void ParsableToType<T>(string argument, string argumentName, string methodName)
            {
                try
                {
                   T arg = (T)Convert.ChangeType(argument, typeof(T));
                }
                catch
                {
                    throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be of type {typeof(T).Name}.", methodName);
                }
            }

            public static void ParsableToType<T>(string argument, Exception exception)
            {
                try
                {
                    T arg = (T)Convert.ChangeType(argument, typeof(T));
                    throw exception;
                }
                catch
                {
                    // Do nothing
                }
               
            }
            public static void NotParsableToType<T>(string argument, Exception exception)
            {
                try
                {
                    T arg = (T)Convert.ChangeType(argument, typeof(T));
                }
                catch
                {
                    throw exception;
                }
            }


            /// <summary>
            /// Verifies that the specified argument is a valid colour name. Matches against the KnownColor enum.
            /// </summary>
            /// <param name="argument"></param>
            /// <param name="argumentName"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void InvalidColour(string argument, string argumentName, string methodName)
            {
                if (!Enum.GetNames(typeof(KnownColor)).Any(c => c.Equals(argument, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be a valid colour name.", methodName);
                }
            }

            /// <summary>
            /// Wrapper for the argument validation methods. 
            /// </summary>
            /// <param name="arguments"></param>
            /// <param name="methodName"></param>
            /// <exception cref="ArgumentException"></exception>
            public static void validateArguments(Dictionary<string, Dictionary<string, object>> arguments, string methodName)
            {
                foreach (var argumentPair in arguments)
                {
                    string argumentName = argumentPair.Key;
                    Dictionary<string, object> argumentProperties = argumentPair.Value;

                    // Get the argument's value and type
                    object argumentValue = argumentProperties["value"];
                    Type argumentType = argumentProperties["type"] as Type;

                    ThrowIf.Argument.IsNull(argumentValue, argumentName, methodName);

                    if(argumentType == typeof(int))
                    {
                        int argumentIntValue;

                        if(!int.TryParse(argumentValue.ToString(), out argumentIntValue))
                        {
                            throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be of type {argumentType.Name}.", methodName);
                        }   

                        if (argumentProperties.ContainsKey("minValue") && argumentProperties.ContainsKey("maxValue"))
                        {
                            int minValue = (int)argumentProperties["minValue"];
                            int maxValue = (int)argumentProperties["maxValue"];
                            ThrowIf.Argument.IsOutOfRange(argumentIntValue, argumentName, minValue, maxValue);
                        }
                        else if (argumentProperties.ContainsKey("minValue"))
                        {
                            int minValue = (int)argumentProperties["minValue"];
                            ThrowIf.Argument.IsLowerThan(argumentIntValue, argumentName, minValue);
                        }
                        else if (argumentProperties.ContainsKey("maxValue"))
                        {
                            int maxValue = (int)argumentProperties["maxValue"];
                            ThrowIf.Argument.isHigherThan(argumentIntValue, argumentName, maxValue);
                        }
                      
                        ThrowIf.Argument.IsNegative(argumentIntValue, argumentName, methodName);
                    }

                    if(argumentType == typeof(string))
                    {
                        ThrowIf.Argument.EnsureArgumentType(argumentValue, argumentType, argumentName, methodName);
                        ThrowIf.Argument.IsStringEmpty((string)argumentValue, argumentName, methodName);
                    }

                    if(argumentType == typeof(Color))
                    {
                        ThrowIf.Argument.InvalidColour(argumentValue.ToString(), argumentName, methodName);
                    }

                    if (argumentType == typeof(bool))
                    {
                        bool argumentBoolValue;

                        // Check if "accept_on-off" is present
                        if (argumentProperties.ContainsKey("accept_on-off"))
                        {
                            if (!bool.TryParse(argumentValue.ToString(), out argumentBoolValue) && 
                                !argumentValue.ToString().Equals("on", StringComparison.OrdinalIgnoreCase) && 
                                !argumentValue.ToString().Equals("off", StringComparison.OrdinalIgnoreCase))
                            {
                                throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be of type {argumentType.Name}.", methodName);
                            }
                        }
                        // If "accept_on-off" is not present, just check if it's a valid boolean
                        else if (!bool.TryParse(argumentValue.ToString(), out argumentBoolValue))
                        {
                            throw new ArgumentException($"The method '{methodName}' expects '{argumentName}' to be of type {argumentType.Name}.", methodName);
                        }
                    }

                }
            }
        }
    }
}
