using System;
using NUnit;
using FutChampsSummary;

namespace FutChamps.Test
{
    public class Tests
    {
        public class TypeTest
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void GetPlayer_ShouldReturnDifferentObjects()
            {
                var player1 = new PlayerInMemory("Messi", "POTM");
                var player2 = new PlayerInMemory("Ronaldo", "TOTW");

                Assert.AreNotEqual(player1, player2);
            }

            [Test]
            public void GetPlayer_ShouldReturnStatistics()
            {
                var player1 = new PlayerInMemory("Messi", "POTM");
                player1.AddScore(10);
                player1.AddScore(7);
                player1.AddScore(9);
                player1.AddScore(8);
                player1.AddScore(9);

                var result = player1.GetStatistics();

                Assert.AreEqual(10, result.Max);
                Assert.AreEqual(7, result.Min);
                Assert.AreEqual(5, result.Count);
            }
        }
    }
}