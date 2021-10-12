using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HomeWork4
{
    public class FtpTests
    {
        private Server server;
        private Client client;
        private Stream fileStream;

        [SetUp]
        public void Setup()
        {
            server = new Server("127.0.0.1", 8888);
            client = new Client("127.0.0.1", 8888);
            fileStream = new MemoryStream();
            server.Start();
        }

        [TearDown]
        public void TearDown()
        {
            fileStream.Close();
            server.Stop();
        }

        [Test]
        public void GetWithIncorrectFileNameTest()
        {
            var ex = Assert.Throws<AggregateException>(() => client.Get("Text.txt", fileStream).Wait());
            Assert.IsTrue(ex.InnerException is ArgumentException);
        }

        [Test]
        public async Task ListWithIncorrectFileNameTest()
        {
            Assert.IsNull(await client.List("Text.txt"));
        }

        [Test]
        public async Task GetTest()
        {
            await client.Get("../../../../Tests/Data/Text.txt", fileStream);
            using var file = File.OpenRead("../../../../Tests/Data/Text.txt");
            using var resultStreamReader = new StreamReader(fileStream);
            var result = await resultStreamReader.ReadToEndAsync();
            using var answerStreamReader = new StreamReader(file);
            var answer = await answerStreamReader.ReadToEndAsync();
            Assert.AreEqual(answer, result);
        }

        [Test]
        public async Task ListTest()
        {
            var content = await client.List("../../../../Tests/Data");
            Assert.AreEqual("../../../../Tests/Data\\Text.txt", content[0].Item1);
            Assert.IsTrue(!content[0].Item2);
            Assert.AreEqual("../../../../Tests/Data\\DirectoryForTests", content[1].Item1);
            Assert.IsTrue(content[1].Item2);
        }
    }
}