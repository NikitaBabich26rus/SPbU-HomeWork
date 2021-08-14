using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HomeWork6
{
    /// <summary>
    /// ViewModel class for MVVM pattern;
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

        private Client client;

        private string serverPath;

        private string currentServerPath;

        private const string defaultPathToDownload = "../../../../FTP/Data";

        private const string pathToSaveFiles = "../../../DirectoryForDownload";

        private const string defaultIp = "127.0.0.1";

        private const string defaultPort = "8888";

        private Stack<string> openFolder = new();

        /// <summary>
        /// List for downloading files.
        /// </summary>
        public ObservableCollection<string> DownloadingFiles { get; } = new();

        /// <summary>
        /// List for downloaded files.
        /// </summary>
        public ObservableCollection<string> DownloadedFiles { get; } = new();

        /// <summary>
        /// Current directories and files.
        /// </summary>
        public ObservableCollection<string> DirectoriesAndFiles { get; } = new();

        /// <summary>
        /// Checks if the path is a directory.
        /// </summary>
        private ObservableCollection<bool> IsDirectory { get; } = new();

        private string ip = defaultIp;

        /// <summary>
        /// Ip to connect.
        /// </summary>
        public string Ip
        {
            get => ip;
            set
            {
                if (!isDisconnected)
                {
                    throw new Exception("Can't change the ip once connected");
                }
                ip = value;
                OnPropertyChanged("Ip");
            }
        }

        private string port = defaultPort;

        /// <summary>
        /// Port to connect.
        /// </summary>
        public string Port
        {
            get => port;
            set
            {
                if (!isDisconnected)
                {
                    throw new Exception("Can't change the port once connected");
                }
                port = value;
                OnPropertyChanged("Port");
            }
        }

        private string pathToDownload = defaultPathToDownload;

        /// <summary>
        /// Path to download files.
        /// </summary>
        public string PathToDownload
        {
            get => pathToDownload;
            set
            {
                if (!isDisconnected)
                {
                    throw new Exception("Can't change the path once connected");
                }
                pathToDownload = value;
                OnPropertyChanged("PathToDownload");
            }
        }

        private bool isDisconnected = true;

        /// <summary>
        /// Check connection with server.
        /// </summary>
        public bool IsDisconnected
        {
            get => isDisconnected;
            set
            {
                isDisconnected = value;
                OnPropertyChanged("IsDisconnected");
            }
        }

        /// <summary>
        /// Command for downloading all files in the folder.
        /// </summary>
        public Command DownloadAllInFolderCommand { get; }

        /// <summary>
        /// Command for download file or go to another folder.
        /// </summary>
        public Command DownloadFileOrGoToAnotherFolderCommand { get; }

        /// <summary>
        /// Command for connect to server.
        /// </summary>
        public Command ConnectCommand { get; }

        /// <summary>
        /// Command for delete downloaded files.
        /// </summary>
        public Command DeleteDownloadedFilesCommand { get; }

        /// <summary>
        /// Initialize commands.
        /// </summary>
        public ViewModel()
        {
            ConnectCommand = new Command(ConnectAsync, (object parameter) => IsDisconnected);
            DownloadFileOrGoToAnotherFolderCommand = new Command(DownloadFileOrGoToAnotherFolderAsync);
            DeleteDownloadedFilesCommand = new Command(RunDeleteDownloadedFilesAsync);
            DownloadAllInFolderCommand = new Command(RunDownloadAllFilesInFolderAsync);
        }

        /// <summary>
        /// Start download all files in folder.
        /// </summary>
        private async void RunDownloadAllFilesInFolderAsync(object parameter) => await Task.Run(() => DownloadAllFilesInFolderAsync());

        /// <summary>
        /// Start delete downloaded files.
        /// </summary>
        private async void RunDeleteDownloadedFilesAsync(object parameter) => await Task.Run(() => DeleteDownloadedFilesAsync());

        /// <summary>
        /// Download file or go to another folder.
        /// </summary>
        private async void DownloadFileOrGoToAnotherFolderAsync(object parameter)
        {
            var index = Convert.ToInt32(parameter);
            if (IsDirectory[index])
            {
                await Task.Run(() => ShowCurrentFoldersAndFilesAsync(DirectoriesAndFiles[index]));
                return;
            }
            await Task.Run(() => DownloadFile(DirectoriesAndFiles[index]));
        }

        /// <summary>
        /// Connection to server.
        /// </summary>
        private async void ConnectAsync(object parameter)
        {
            try
            {
                client = new Client(this.ip, int.Parse(this.port));
                serverPath = pathToDownload;
                IsDisconnected = false;
                await Task.Run(() => ShowCurrentFoldersAndFilesAsync(serverPath));
            }
            catch (Exception)
            {
                MessageBox.Show($"Failed to connect to server {this.ip}:{this.port}");
                IsDisconnected = true;
                return;
            }
        }

        /// <summary>
        /// Show current folder.
        /// </summary>
        /// <param name="path">Path</param>
        private async Task ShowCurrentFoldersAndFilesAsync(string path)
        {
            await dispatcher.BeginInvoke(() => ClearFileList());
            if (path == "..")
            {
                await ShowCurrentFoldersAndFilesAsync(openFolder.Pop());
                return;
            }
            var foldersAndFiles = await client.ListAsync(path);
            if (path != serverPath)
            {
                await dispatcher.BeginInvoke(() => DirectoriesAndFiles.Add(".."));
                IsDirectory.Add(true);
                openFolder.Push(currentServerPath);
            }
            currentServerPath = path;
            foreach (var item in foldersAndFiles)
            {
                await dispatcher.BeginInvoke(() => DirectoriesAndFiles.Add(item.Item1));
                IsDirectory.Add(item.Item2);
            }
        }

        /// <summary>
        /// Clear file list.
        /// </summary>
        private void ClearFileList()
        {
            IsDirectory.Clear();
            DirectoriesAndFiles.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="path">Path</param>
        private async Task DownloadFile(string path)
        {
            try
            {
                if (!Directory.Exists(pathToSaveFiles))
                {
                    Directory.CreateDirectory(pathToSaveFiles);
                }
                await dispatcher.BeginInvoke(() => DownloadingFiles.Add(path));
                var fileStream = new MemoryStream();
                await client.GetAsync(path, fileStream);
                using var contentStreamReader = new StreamReader(fileStream);
                var content = await contentStreamReader.ReadToEndAsync();
                var currentPath = new DirectoryInfo(path).Name;
                using var textFile = new StreamWriter(pathToSaveFiles + @"\" + currentPath);
                textFile.WriteLine(content);
                await dispatcher.BeginInvoke(() => DownloadingFiles.Remove(path));
                await dispatcher.BeginInvoke(() => DownloadedFiles.Add(path));
            }
            catch (SocketException)
            {
                MessageBox.Show("You are not connected to the server");
            }
        }

        /// <summary>
        /// Download all files in folder.
        /// </summary>
        private async Task DownloadAllFilesInFolderAsync()
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
                    tasks.Add(Task.Run(async () => await DownloadFile(DirectoriesAndFiles[localIndex])));
                }
            }
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// Delete downloaded files.
        /// </summary>
        private async Task DeleteDownloadedFilesAsync()
        {
            if (!Directory.Exists(pathToSaveFiles))
            {
                return;
            }
            await dispatcher.BeginInvoke(() => DownloadedFiles.Clear());
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