namespace SequenceSumAndAverage.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class MathCalculatorTests
    {
        [TestMethod]
        public void AverageSimpleInput()
        {
            List<int> simpleList = new List<int>() {1, 2, 3, 4, 4 };
            double actual = MathCalculator.Average(simpleList);
            double expected = 2.8;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AverageWithNullInputShouldThrowArgumentException()
        {
            MathCalculator.Average(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AverageWithEmptyListShouldThrowArgumentException()
        {
            List<int> emptyList = new List<int>();
            MathCalculator.Average(emptyList);
        }


        [TestMethod]
        public void SumSimpleInput()
        {
            List<int> simpleList = new List<int>() { 1, 2, 3, 4, 4 };
            double actual = MathCalculator.Sum(simpleList);
            double expected = 14;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SumWithNullListShouldThrowArgumentException()
        {
            MathCalculator.Sum(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SumWithEmptyListShouldThrowArgumentException()
        {
            List<int> emptyList = new List<int>();
            MathCalculator.Sum(emptyList);
        }
    }
}
