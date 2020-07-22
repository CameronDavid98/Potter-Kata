using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Potter.Core.Extentions;
using System.Linq;

namespace Potter.Core.Tests.Extensions
{
    [TestClass]
    public class WhenTestingListExtensions
    {
        [TestMethod]
        public void GivenASingleSequnceItShouldReturnOneList()
        {
            //Arrange
            var data = new List<int>() { 1, 2, 3, 4, 5 };
            var expectedListCount = 1;
            var expectedItemCount = 5;

            //Act
            var actualResult = data.DistinctSplit();

            //Assert
            Assert.AreEqual(expectedListCount, actualResult.Count);
            Assert.AreEqual(expectedItemCount, actualResult.FirstOrDefault().Count);
        }

        [TestMethod]
        public void GivenTwoSequncesItShouldReturnTwoList()
        {
            //Arrange
            var data = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var expectedListCount = 2;

            //Act
            var actualResult = data.DistinctSplit();

            //Assert
            Assert.AreEqual(expectedListCount, actualResult.Count);
        }

        [TestMethod]
        public void GivenTwoSequncesItShouldReturnTwoDifferentLists()
        {
            //Arrange
            var data = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 5 };
            var expectedList1Count = 5;
            var expectedList2Count = 3;

            //Act
            var actualResult = data.DistinctSplit();

            //Assert
            Assert.AreEqual(expectedList1Count, actualResult[0].Count);
            Assert.AreEqual(expectedList2Count, actualResult[1].Count);
        }

        [TestMethod]
        public void GivenThreeSequncesItShouldReturnTwoDifferentLists()
        {
            //Arrange
            var data = new List<int>() { 1, 1, 2, 2, 3, 3, 4, 4, 4, 5 };
            var expectedList1Count = 5;
            var expectedList2Count = 4;
            var expectedList3Count = 1;

            //Act
            var actualResult = data.DistinctSplit();

            //Assert
            Assert.AreEqual(expectedList1Count, actualResult[0].Count);
            Assert.AreEqual(expectedList2Count, actualResult[1].Count);
            Assert.AreEqual(expectedList3Count, actualResult[2].Count);
        }

        [TestMethod]
        public void GivenAnEmptyListItShouldReturnEmptyList()
        {
            //Arrange
            var data = new List<int>();
            var expectedList1Count = 0;

            //Act
            var actualResult = data.DistinctSplit();

            //Assert
            Assert.AreEqual(expectedList1Count, actualResult[0].Count);
        }
    }
}
