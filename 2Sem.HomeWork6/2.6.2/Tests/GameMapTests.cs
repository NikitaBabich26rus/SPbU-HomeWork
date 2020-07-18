using NUnit.Framework;
using System.IO;

namespace _2._6._2
{
    public class GameMapTests
    {
        private GameMap gameMap;

        [Test]
        public void NotFoundFileTest()
        {
            Assert.Throws<FileNotFoundException>(() => gameMap = new GameMap("/../../GameMapTests1.txt"));
        }

        [Test]
        public void CreateTheMapTests()
        {
            gameMap = new GameMap("../../../GameMapTests.txt");
            Assert.IsFalse(gameMap.Map[0, 0]);
            Assert.IsFalse(gameMap.Map[0, 1]);
            Assert.IsFalse(gameMap.Map[0, 2]);
            Assert.AreEqual(gameMap.X, 6);
            Assert.AreEqual(gameMap.Y, 7);
            Assert.IsTrue(gameMap.Map[0, 4]);
            Assert.IsTrue(gameMap.Map[0, 5]);
            Assert.IsFalse(gameMap.Map[0, 6]);
            Assert.IsFalse(gameMap.Map[0, 7]);
        } 
    }
}