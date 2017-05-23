using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimonSays;

namespace DataProviderTest
{
    [TestClass]
    public class DataProviderTest
    {
        private IDataProvider _provider;

        [TestInitialize]
        public void Setup()
        {
            _provider = new DataProvider();
        }

        [TestMethod]
        public void Can_Get_Sequence()
        {
            //Arrange

            // Act
            var sequence = _provider.GetSequence();

            // Assert
            Assert.IsNotNull(sequence);
        }

        [TestMethod]
        public void Increasetest()
        {
            // Arrange
            int input = 2;

            // Act
            _provider.IncreaseSequenceLength(input);

            // Assert
            Assert.IsTrue(_provider.GetSequence().Last() > 0 && _provider.GetSequence().Last() < input);
        }

        [TestMethod]
        public void MatchesWithCheckMarker()
        {
            // Arrange
            int item = 2;
            _provider.IncreaseSequenceLength(item);
            _provider.MoveCheckMarkerToNextPosition();

            // Act
            bool result = _provider.MatchesWithCheckMarker(item);

            // Assert
            Assert.AreEqual(result, _provider.GetSequence()[_provider.GetCheckMarkerPosition()] == item);
        }
    }
}
