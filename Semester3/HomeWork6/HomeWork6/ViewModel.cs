using FTP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace HomeWork6
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Client client;

        private Server server;

        public string serverPath;

        private string currentServerPath;

        private const string defaultPathToDownload = "../../../../FTP/Data";

        private const string pathToSaveFiles = "../../../DirectoryForDownload";

        private const string defaultIp = "127.0.0.1";

        private const int defaultPort = 8888;

        private Stack<string> openFolder = new Stack<string>();

        public ObservableCollection<string> DownloadingFiles { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> DownloadedFiles { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> DirectoriesAndFiles { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<bool> IsDirectory { get; set; } = new ObservableCollection<bool>();

        private string ip = defaultIp;

        public string Ip
        {
            get => ip;
            set
            {
                ip = value;
                OnPropertyChanged("Ip");
            }
        }

        private int port = defaultPort;

        public int Port
        {
            get => port;
            set
            {
                port = value;
                OnPropertyChanged("Port");
            }
        }

        private string pathToDownload = defaultPathToDownload;

        public string PathToDownload
        {
            get => pathToDownload;
            set
            {
                pathToDownload = value;
                OnPropertyChanged("PathToDownload");
            }
        }

        public void Connection(string ip, string port)
        {
            try
            {
                if (InputValidation.IpValidation(ip) && InputValidation.PortValidation(port))
                {
                    MessageBox.Show("Incorrect port or ip.");
                    return;
                }
                server = new Server(ip, int.Parse(port));
                client = new Client(ip, int.Parse(port), this);
                _ = server.Start();
            }
            catch (Exception)
            {
                MessageBox.Show($"Failed to connect to server {ip}:{port}");
                return;
            }
            ShowCurrentFoldersAndFilesAsync(serverPath);
        }

        private async void ShowCurrentFoldersAndFilesAsync(string path)
        {
            ClearFileList();
            if (path == "..")
            {
                ShowCurrentFoldersAndFilesAsync(openFolder.Pop());
                return;
            }
            var foldersAndFiles = await client.List(path);
            if (path != serverPath)
            {
                DirectoriesAndFiles.Add("..");
                IsDirectory.Add(true);
                openFolder.Push(currentServerPath);
            }
            currentServerPath = path;
            foreach (var item in foldersAndFiles)
            {
                DirectoriesAndFiles.Add(item.Item1);
                IsDirectory.Add(item.Item2);
            }
        }

        private void ClearFileList()
        {
            IsDirectory.Clear();
            DirectoriesAndFiles.Clear();
        }

        public void EditListBox(string path)
        {
            ShowCurrentFoldersAndFilesAsync(path);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public async Task DownloadFile(string path)
        {
            try
            {
                if (!Directory.Exists(pathToSaveFiles))
                {
                    Directory.CreateDirectory(pathToSaveFiles);
                }
                DownloadingFiles.Add(path);
                var fileStream = new MemoryStream();
                await client.Get(path, fileStream);
                using var contentStreamReader = new StreamReader(fileStream);
                var content = await contentStreamReader.ReadToEndAsync();
                var currentPath = new DirectoryInfo(path).Name;
                using var textFile = new StreamWriter(pathToSaveFiles + @"\" + currentPath);
                textFile.WriteLine(content);
                DownloadingFiles.Remove(path);
                DownloadedFiles.Add(path);
            }
            catch (SocketException)
            {
                MessageBox.Show("You are not connected to the server");
            }
        }

        public void DownloadAllFilesInFolderAsync()
        {
            if (client == null)
            {
                MessageBox.Show("You are not connected to the server");
                return;
            }
            var tasks = new List<Task>();
            for (int i = 0; i < DirectoriesAndFiles.Count; i++)
            {
                var localIndex = i;
                if (!IsDirectory[localIndex])
                {
                    tasks.Add(new Task(async () => await DownloadFile(DirectoriesAndFiles[localIndex])));
                }
            }
            foreach (var item in tasks)
            {
                item.RunSynchronously();
            }
        }

        public void DeleteDownloadedFiles()
        {
            if (!Directory.Exists(pathToSaveFiles))
            {
                return;
            }
            DownloadedFiles.Clear();
            var directory = new DirectoryInfo(pathToSaveFiles);
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
            Directory.Delete(pathToSaveFiles);
        }
    }
}