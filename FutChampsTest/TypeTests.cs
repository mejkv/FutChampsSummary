using System.Xml.Linq;

namespace FutChampsTest
{
    public class TypeTests
    {
        [Test]
        public void GetStatisticMin_ShouldReturnMinValue()
        {
            var player = new PlayerInMemory("Messi", "Gold");
            player.AddScore(10);
            player.AddScore(9);
            player.AddScore(8);

            var statistics = player.GetStatistics();

            Assert.AreEqual(8, statistics.Min);
        }
    }
}