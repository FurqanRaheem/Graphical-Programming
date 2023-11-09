namespace Tests
{
    [TestClass]
    public class ThrowIfTests
    {
        /// <summary>
        /// Tests the ThrowIf.Argument.IsNull method. It should throw an ArgumentNullException if the argument is null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null)]
        public void Argument_IsNull_ThrowsArgumentNullException(object argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsNull(argument, "argumentName", "TestMethod");
        }

        /// <summary>
        /// Tests the ThrowIf.Argument.IsNull method. It should not throw an ArgumentNullException if the argument is not null.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow("null")]
        public void Argument_IsNull_DoesNotThrowArgumentNullException(object argument)
        {
            try
            {
                ThrowIf.Argument.IsNull(argument, "argumentName", "TestMethod");
            }
            catch (ArgumentNullException)
            {
                Assert.Fail("ArgumentNullException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsNegative method. It should throw an ArgumentOutOfRangeException if the argument is negative.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Argument_IsNegative_ThrowsArgumentOutOfRangeException(int argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsNegative(argument, "argumentName", "TestMethod");
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsNegative method. It should not throw an ArgumentOutOfRangeException if the argument is not negative.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void Argument_IsNegative_DoesNotThrowArgumentOutOfRangeException(int argument)
        {
            try
            {
                ThrowIf.Argument.IsNegative(argument, "argumentName", "TestMethod");
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ArgumentOutOfRangeException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsOutOfRange method. It should throw an ArgumentOutOfRangeException if the argument is negative or zero.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(5, 1, 3)]
        [DataRow(10, 5, 8)]
        public void Argument_IsOutOfRange_ThrowsArgumentOutOfRangeException(int argument, int minValue, int maxValue)
        {
            // Act & Assert
            ThrowIf.Argument.IsOutOfRange(argument, "argumentName", minValue, maxValue);
        }

        /// <summary>   
        /// Test the ThrowIf.Argument.IsOutOfRange method. It should not throw an ArgumentOutOfRangeException if the argument is not negative or zero.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        [TestMethod]
        [DataRow(2, 1, 3)]
        [DataRow(6, 5, 8)]
        public void Argument_IsOutOfRange_DoesNotThrowArgumentOutOfRangeException(int argument, int minValue, int maxValue)
        {
            try
            {
                ThrowIf.Argument.IsOutOfRange(argument, "argumentName", minValue, maxValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ArgumentOutOfRangeException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsHigherThan method. It should throw an ArgumentOutOfRangeException if the argument is higher than the maximum value.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="maxValue">The maximum value.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(5, 2)]
        [DataRow(30, 10)]
        public void Argument_IsHigherThan_ThrowsArgumentOutOfRangeException(int argument, int maxValue)
        {
            // Act & Assert
            ThrowIf.Argument.isHigherThan(argument, "argumentName", maxValue);
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsHigherThan method. It should not throw an ArgumentOutOfRangeException if the argument is not higher than the maximum value.
        /// <param name="argument">The argument.</param>
        /// <param name="maxValue">The maximum value.</param>
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(-5, 5)]
        public void Argument_IsHigherThan_DoesNotThrowArgumentOutOfRangeException(int argument, int maxValue)
        {
            try
            {
                ThrowIf.Argument.isHigherThan(argument, "argumentName", maxValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ArgumentOutOfRangeException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsLowerThan method. It should throw an ArgumentOutOfRangeException if the argument is lower than the minimum value.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="minValue">The minimum value.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(3, 6)]
        [DataRow(2, 15)]
        public void Argument_IsLowerThan_ThrowsArgumentOutOfRangeException(int argument, int minValue)
        {
            // Act & Assert
            ThrowIf.Argument.IsLowerThan(argument, "argumentName", minValue);
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsLowerThan method. It should not throw an ArgumentOutOfRangeException if the argument is not lower than the minimum value.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="minValue">The minimum value.</param>
        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(15, 5)]
        public void Argument_IsLowerThan_DoesNotThrowArgumentOutOfRangeException(int argument, int minValue)
        {
            try
            {
                ThrowIf.Argument.IsLowerThan(argument, "argumentName", minValue);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.Fail("ArgumentOutOfRangeException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsStringEmpty method. It should throw an ArgumentException if the argument is empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        public void Argument_IsStringEmpty_ThrowsArgumentException(string argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsStringEmpty(argument, "argumentName", "TestMethod");
        }

        /// <summary>
        /// Test the ThrowIf.Argument.IsStringEmpty method. It should not throw an ArgumentException if the argument is not empty.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow(" ")]
        [DataRow("not empty")]
        public void Argument_IsStringEmpty_DoesNotThrowArgumentException(string argument)
        {
            try
            {
                ThrowIf.Argument.IsStringEmpty(argument, "argumentName", "TestMethod");
            }
            catch (ArgumentException)
            {
                Assert.Fail("ArgumentException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidColour method. It should throw an ArgumentException if the argument is not a valid colour.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("invalidColor")]
        [DataRow("invalidColor2")]
        public void Argument_InvalidColour_ThrowsArgumentException(string argument)
        {
            // Act & Assert
            ThrowIf.Argument.InvalidColour(argument, "argumentName", "TestMethod");
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidColour method. It should not throw an ArgumentException if the argument is a valid colour.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow("red")]
        [DataRow("blue")]
        public void Argument_ValidColour_DoesNotThrowArgumentException(string argument)
        {
            try
            {
                ThrowIf.Argument.InvalidColour(argument, "argumentName", "TestMethod");
            }
            catch (ArgumentException)
            {
                Assert.Fail("ArgumentException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidBool method. It should throw an ArgumentException if the argument is not a valid bool.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("invalidBool")]
        [DataRow("invalidBool2")]
        public void Argument_InvalidBool_ThrowsArgumentException(string argument)
        {
            var arguments = new Dictionary<string, Dictionary<string, object>>
            {
                ["BoolArg"] = new Dictionary<string, object>
                {
                    { "value", argument },
                    { "type", typeof(bool) }
                }
            };

            // Act & Assert
            ThrowIf.Argument.validateArguments(arguments, "TestMethod");
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidBool method. It should not throw an ArgumentException if the argument is a valid bool.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow("true")]
        [DataRow("false")]
        public void Argument_ValidBool_DoesNotThrowArgumentException(string argument)
        {
            var arguments = new Dictionary<string, Dictionary<string, object>>
            {
                ["BoolArg"] = new Dictionary<string, object>
                {
                    { "value", argument },
                    { "type", typeof(bool) }
                }
            };

            try
            {
                ThrowIf.Argument.validateArguments(arguments, "TestMethod");
            }
            catch (ArgumentException)
            {
                Assert.Fail("ArgumentException was thrown for a valid value.");
            }
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidBool method with the accept_on-off parameter. It should throw an ArgumentException if the argument is not a valid bool.
        /// </summary>
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("invalidBool")]
        [DataRow("invalidBool2")]
        public void Argument_InvalidBool_Accept_On_Off_ThrowsArgumentException(string argument)
        {
            var arguments = new Dictionary<string, Dictionary<string, object>>
            {
                ["BoolArg"] = new Dictionary<string, object>
                {
                    { "value", argument },
                    { "type", typeof(bool) },
                    { "accept_on-off", true }
                }
            };

            // Act & Assert
            ThrowIf.Argument.validateArguments(arguments, "TestMethod");
        }

        /// <summary>
        /// Test the ThrowIf.Argument.InvalidBool method with the accept_on-off parameter. It should not throw an ArgumentException if the argument is a valid bool.
        /// <param name="argument">The argument.</param>
        [TestMethod]
        [DataRow("true")]
        [DataRow("false")]
        [DataRow("on")]
        [DataRow("off")]
        public void Argument_ValidBool_Accept_On_Off_DoesNotThrowArgumentException(string argument)
        {
            var arguments = new Dictionary<string, Dictionary<string, object>>
            {
                ["BoolArg"] = new Dictionary<string, object>
                {
                    { "value", argument },
                    { "type", typeof(bool) },
                    { "accept_on-off", true }
                }
            };

            try
            {
                ThrowIf.Argument.validateArguments(arguments, "TestMethod");
            }
            catch (ArgumentException)
            {
                Assert.Fail("ArgumentException was thrown for a valid value.");
            }
        }
    }
}
