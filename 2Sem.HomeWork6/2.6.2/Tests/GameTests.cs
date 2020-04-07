using NUnit.Framework;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._6._2
{
    public class GameTests
    {
        Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game("../../../GameMapTests.txt");
        }

        [Test]
        public void ToTheLeftTests()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            game.ToTheLeft(this, EventArgs.Empty);
            Assert.AreEqual(game.gameMap.x, x - 1);
            Assert.AreEqual(game.gameMap.y, y);
        }

        [Test]
        public void ToTheRightTests()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            game.ToTheRight(this, EventArgs.Empty);
            Assert.AreEqual(game.gameMap.x, x + 1);
            Assert.AreEqual(game.gameMap.y, y);
        }

        [Test]
        public void ToTheDownTests()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            game.ToTheDown(this, EventArgs.Empty);
            Assert.AreEqual(game.gameMap.x, x);
            Assert.AreEqual(game.gameMap.y, y + 1);
        }

        [Test]
        public void ToTheUpTests()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            game.ToTheUp(this, EventArgs.Empty);
            Assert.AreEqual(game.gameMap.x, x);
            Assert.AreEqual(game.gameMap.y, y - 1);
        }

        [Test]
        public void PlayerMustNotPassThroughTheWall()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            for (int i = 0; i < 100; i++)
            {
                game.ToTheUp(this, EventArgs.Empty);
            }
            Assert.AreEqual(game.gameMap.x, x);
            Assert.AreEqual(game.gameMap.y, y - 1);
        }

        [Test]
        public void PlayerMustNotGoBeyondTheMap()
        {
            int x = game.gameMap.x;
            int y = game.gameMap.y;
            for (int i = 0; i < 100; i++)
            {
                game.ToTheRight(this, EventArgs.Empty);
            }
            Assert.AreEqual(game.gameMap.x, x + 2);
            Assert.AreEqual(game.gameMap.y, y);
        }
    }
}