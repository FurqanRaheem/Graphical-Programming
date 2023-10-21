namespace Tests
{
    [TestClass]
    public class ThrowIfTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow(null)]
        public void Argument_IsNull_ThrowsArgumentNullException(object argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsNull(argument, "argumentName", "TestMethod");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-1)]
        [DataRow(-10)]
        public void Argument_IsNegative_ThrowsArgumentOutOfRangeException(int argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsNegative(argument, "argumentName", "TestMethod");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(5, 1, 3)]
        [DataRow(10, 5, 8)]
        public void Argument_IsOutOfRange_ThrowsArgumentOutOfRangeException(int argument, int minValue, int maxValue)
        {
            // Act & Assert
            ThrowIf.Argument.IsOutOfRange(argument, "argumentName", minValue, maxValue);
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(5, 2)]
        [DataRow(30, 10)]
        public void Argument_IsHigherThan_ThrowsArgumentOutOfRangeException(int argument, int maxValue)
        {
            // Act & Assert
            ThrowIf.Argument.isHigherThan(argument, "argumentName", maxValue);
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(3, 6)]
        [DataRow(2, 15)]
        public void Argument_IsLowerThan_ThrowsArgumentOutOfRangeException(int argument, int minValue)
        {
            // Act & Assert
            ThrowIf.Argument.IsLowerThan(argument, "argumentName", minValue);
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("")]
        public void Argument_IsStringEmpty_ThrowsArgumentException(string argument)
        {
            // Act & Assert
            ThrowIf.Argument.IsStringEmpty(argument, "argumentName", "TestMethod");
        }

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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("invalidColor")]
        [DataRow("invalidColor2")]
        public void Argument_InvalidColour_ThrowsArgumentException(string argument)
        {
            // Act & Assert
            ThrowIf.Argument.InvalidColour(argument, "argumentName", "TestMethod");
        }

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
