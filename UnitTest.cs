using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFolder;

namespace UnitTestJustJewels
{
    [TestClass]
    public class GameFolderTest
    {
        [TestMethod]
        public void TestIsEmpty_ShouldBeTrue()
        {
            bool[,] test = new bool[2, 2];
            bool expectedResult = JustJewels.isEmpty(test);

            Assert.AreEqual(true, expectedResult);
        }
    }
}
