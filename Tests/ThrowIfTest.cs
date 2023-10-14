using CommandParserAssignmnet;

namespace Tests
{
    [TestClass]
    public class ThrowIfTests
    {
        [TestMethod]
        public void IsNull_ThrowsException_WhenArgumentIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ThrowIf.Argument.IsNull(null, "argumentName", "MethodName"));
        }

        [TestMethod]
        public void IsNull_DoesNotThrowException_WhenArgumentIsNotNull()
        {
            ThrowIf.Argument.IsNull(new object(), "argumentName", "MethodName");
        }

        [TestMethod]
        public void IsNegative_ThrowsException_WhenArgumentIsNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ThrowIf.Argument.IsNegative(-1, "argumentName", "MethodName"));
        }

        [TestMethod]
        public void IsNegative_DoesNotThrowException_WhenArgumentIsNonNegative()
        {
            ThrowIf.Argument.IsNegative(0, "argumentName", "MethodName");
        }

        [TestMethod]
        public void IsOutOfRange_ThrowsException_WhenArgumentIsOutOfRange()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ThrowIf.Argument.IsOutOfRange(10, "argumentName", 1, 5));
        }

        [TestMethod]
        public void IsOutOfRange_DoesNotThrowException_WhenArgumentIsInRange()
        {
            ThrowIf.Argument.IsOutOfRange(3, "argumentName", 1, 5);
        }

        [TestMethod]
        public void IsStringEmpty_ThrowsException_WhenArgumentIsEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => ThrowIf.Argument.IsStringEmpty(string.Empty, "argumentName", "MethodName"));
        }

        [TestMethod]
        public void IsStringEmpty_DoesNotThrowException_WhenArgumentIsNotEmpty()
        {
            ThrowIf.Argument.IsStringEmpty("SomeValue", "argumentName", "MethodName");
        }

        [TestMethod]
        public void ValidateExactArgumentCount_ThrowsException_WhenArgumentCountIsIncorrect()
        {
            Assert.ThrowsException<ArgumentException>(() => ThrowIf.Argument.ValidateExactArgumentCount(3, 2, "MethodName"));
        }

        [TestMethod]
        public void ValidateExactArgumentCount_DoesNotThrowException_WhenArgumentCountIsCorrect()
        {
            ThrowIf.Argument.ValidateExactArgumentCount(2, 2, "MethodName");
        }

        [TestMethod]
        public void EnsureArgumentType_ThrowsException_WhenArgumentTypeIsIncorrect()
        {
            Assert.ThrowsException<ArgumentException>(() => ThrowIf.Argument.EnsureArgumentType(1, typeof(string), "argumentName", "MethodName"));
        }

        [TestMethod]
        public void EnsureArgumentType_DoesNotThrowException_WhenArgumentTypeIsCorrect()
        {
            ThrowIf.Argument.EnsureArgumentType("SomeString", typeof(string), "argumentName", "MethodName");
        }

        [TestMethod]
        public void IsHigherThan_ThrowsException_WhenArgumentIsLowerThanMinValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ThrowIf.Argument.isHigherThan(2, "argumentName", 5));
        }

        [TestMethod]
        public void IsHigherThan_DoesNotThrowException_WhenArgumentIsHigherThanMinValue()
        {
            ThrowIf.Argument.isHigherThan(6, "argumentName", 5);
        }

        [TestMethod]
        public void IsLowerThan_ThrowsException_WhenArgumentIsHigherThanMaxValue()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ThrowIf.Argument.IsLowerThan(7, "argumentName", 5));
        }

        [TestMethod]
        public void IsLowerThan_DoesNotThrowException_WhenArgumentIsLowerThanMaxValue()
        {
            ThrowIf.Argument.IsLowerThan(4, "argumentName", 5);
        }
    }
}



