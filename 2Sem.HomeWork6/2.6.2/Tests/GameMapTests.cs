using NUnit.Framework;
using System.IO;

namespace _2._6._2
{
    public class Tests
    {
        GameMap gameMap;

        [Test]
        public void NotFoundFileTest()
        {
            Assert.Throws<FileNotFoundException>(() => gameMap = new GameMap("/../../GameMapTests1.txt"));
        }

        [Test]
        public void CreateTheMapTests()
        {
            gameMap = new GameMap("../../../GameMapTests.txt");
            Assert.IsFalse(gameMap.map[0, 0]);
            Assert.IsFalse(gameMap.map[0, 1]);
            Assert.IsFalse(gameMap.map[0, 2]);
            Assert.AreEqual(gameMap.x, 4);
            Assert.AreEqual(gameMap.y, 7);
            Assert.IsTrue(gameMap.map[0, 4]);
            Assert.IsTrue(gameMap.map[0, 5]);
            Assert.IsTrue(gameMap.map[0, 6]);
            Assert.IsFalse(gameMap.map[0, 7]);
        } 
    }
}