using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;

namespace _2._6._2
{
    public class GameTests
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game("../../../GameMapTests.txt", true);
        }

        [Test]
        public void ToTheLeftTests()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            game.ToTheLeft(this, EventArgs.Empty);
            Assert.AreEqual(x - 1, game.Player.X);
            Assert.AreEqual(y, game.Player.Y);
        }

        [Test]
        public void ToTheRightTests()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            game.ToTheRight(this, EventArgs.Empty);
            Assert.AreEqual(x + 1, game.Player.X);
            Assert.AreEqual(y, game.Player.Y);
        }

        [Test]
        public void ToTheDownTests()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            game.ToTheDown(this, EventArgs.Empty);
            Assert.AreEqual(x, game.Player.X);
            Assert.AreEqual(y + 1, game.Player.Y);
        }

        [Test]
        public void ToTheUpTests()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            game.ToTheUp(this, EventArgs.Empty);
            Assert.AreEqual(x, game.Player.X);
            Assert.AreEqual(y- 1, game.Player.Y);
        }

        [Test]
        public void PlayerMustNotPassThroughTheWall()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            for (int i = 0; i < 100; i++)
            {
                game.ToTheUp(this, EventArgs.Empty);
            }
        }

        [Test]
        public void PlayerMustNotGoBeyondTheMap()
        {
            int x = game.Player.X;
            int y = game.Player.Y;
            for (int i = 0; i < 100; i++)
            {
                game.ToTheRight(this, EventArgs.Empty);
            }
        }
    }
}