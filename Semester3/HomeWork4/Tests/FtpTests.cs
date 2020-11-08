using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class FtpTests
    {
        private Server server;
        private Client client;

        [SetUp]
        public void Setup()
        {
            server = new Server("127.0.0.1", 8888);
            client = new Client("127.0.0.1", 8888);
        }

        [Test]
        public async Task GetWithIncorrectFileNameTest()
        {
            server.Start();
            Assert.IsNull(await client.Get("Text.txt"));
            server.Stop();
        }

        [Test]
        public async Task ListWithIncorrectFileNameTest()
        {
            server.Start();
            Assert.IsNull(await client.List("Text.txt"));
            server.Stop();
        }

        [Test]
        public async Task GetTest()
        {
            server.Start();
            var content = await client.Get("../../../../Tests/Data/Text.txt");
            Assert.AreEqual("EF-BB-BF-53-61-6C-61-6D-0D-0A-50-6F-63-68-61-6E-69", BitConverter.ToString(content));
            server.Stop();
        }

        [Test]
        public async Task ListTest()
        {
            server.Start();
            var content = await client.List("../../../../Tests/Data");
            Assert.AreEqual("../../../../Tests/Data\\Text.txt", content[0].Item1);
            Assert.AreEqual(false, content[0].Item2);
            Assert.AreEqual("../../../../Tests/Data\\DirectoryForTest", content[1].Item1);
            Assert.AreEqual(true, content[1].Item2);
            server.Stop();
        }
    }
}