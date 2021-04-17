using FTP;
using HomeWork6;
using NUnit.Framework;
using System.IO;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Tests
{
    public class ViewModelTests
    {
        private Server server;
        private ViewModel viewModel;

        [SetUp]
        public void Setup()
        {
            viewModel = new ViewModel();
            server = new Server("127.0.0.1", 8888);
            _ = server.Start();
            viewModel.ConnectCommand.Execute(null);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
        }

        [TearDown]
        public void TearDown()
        {
            viewModel.DeleteDownloadedFilesCommand.Execute(null);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
        }

        [Test]
        public void ConnectionTest()
        {
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            Assert.AreEqual(2, viewModel.DirectoriesAndFiles.Count);
            Assert.AreEqual("../../../../FTP/Data\\TextFile.txt", viewModel.DirectoriesAndFiles[0]);
            Assert.AreEqual("../../../../FTP/Data\\Data1", viewModel.DirectoriesAndFiles[1]);
        }

        [Test]
        public void DownloadFileTest()
        {
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(0);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            Assert.AreEqual("../../../../FTP/Data\\TextFile.txt", viewModel.DownloadedFiles[0]);
            using var streamReader = new StreamReader("../../../DirectoryForDownload\\TextFile.txt");
            var content = streamReader.ReadToEnd();
            Assert.AreEqual("Hello, my name is Nikita!\r\n", content);
        }

        [Test]
        public void ChangeDirectoryTest()
        {
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(1);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            Assert.AreEqual(3, viewModel.DirectoriesAndFiles.Count);
            Assert.AreEqual("..", viewModel.DirectoriesAndFiles[0]);
            Assert.AreEqual("../../../../FTP/Data\\Data1\\TextFile1.txt", viewModel.DirectoriesAndFiles[1]);
            Assert.AreEqual("../../../../FTP/Data\\Data1\\TextFile2.txt", viewModel.DirectoriesAndFiles[2]);
        }

        [Test]
        public void DownloadAllFilesInDirectoryTest()
        {
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(1);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(1);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(2);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }

            using var streamReader1 = new StreamReader("../../../DirectoryForDownload\\TextFile1.txt");
            var content1 = streamReader1.ReadToEnd();
            Assert.AreEqual("../../../../FTP/Data\\Data1\\TextFile1.txt", viewModel.DownloadedFiles[0]);
            Assert.AreEqual("Hello, my name is Oleg!\r\n", content1);

            using var streamReader2 = new StreamReader("../../../DirectoryForDownload\\TextFile2.txt");
            var content2 = streamReader2.ReadToEnd();
            Assert.AreEqual("../../../../FTP/Data\\Data1\\TextFile2.txt", viewModel.DownloadedFiles[1]);
            Assert.AreEqual("Hello, my name is Slava!\r\n", content2);
        }

        [Test]
        public void DeleteAllFilesInDirectoryTest()
        {
            viewModel.DownloadFileOrGoToAnotherFolderCommand.Execute(0);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            viewModel.DeleteDownloadedFilesCommand.Execute(null);
            for (int i = 0; i < 7; i++)
            {
                DispatcherUtil.DoEventsSync();
                Thread.Sleep(100);
            }
            Assert.IsFalse(Directory.Exists("../../../DirectoryForDownload"));
        }
    }
}