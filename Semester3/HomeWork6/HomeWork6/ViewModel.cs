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
    /// <summary>
    /// ViewModel class for MVVM pattern;
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Client client;

        private string serverPath;

        private string currentServerPath;

        private const string defaultPathToDownload = "../../../../FTP/Data";

        private const string pathToSaveFiles = "../../../DirectoryForDownload";

        private const string defaultIp = "127.0.0.1";

        private const string defaultPort = "8888";

        private Stack<string> openFolder = new Stack<string>();

        /// <summary>
        /// List for downloading files.
        /// </summary>
        public ObservableCollection<string> DownloadingFiles { get; } = new ObservableCollection<string>();

        /// <summary>
        /// List for downloaded files.
        /// </summary>
        public ObservableCollection<string> DownloadedFiles { get; } = new ObservableCollection<string>();

        /// <summary>
        /// Current directories and files.
        /// </summary>
        public ObservableCollection<string> DirectoriesAndFiles { get; } = new ObservableCollection<string>();

        /// <summary>
        /// Checks if the path is a directory.
        /// </summary>
        private ObservableCollection<bool> IsDirectory { get; } = new ObservableCollection<bool>();

        private string ip = defaultIp;

        /// <summary>
        /// Ip to connect.
        /// </summary>
        public string Ip
        {
            get => ip;
            set
            {
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
                pathToDownload = value;
                OnPropertyChanged("PathToDownload");
            }
        }

        private CommandAsync connectCommand;

        public ViewModel()
        {

        }

        /// <summary>
        /// Command for connection.
        /// </summary>
        public CommandAsync ConnectCommand
        {
            get
            {
                return
                  new CommandAsync((object parameter) =>
                  {
                      return
                      Task.Run(async () =>
                      {
                          try
                          {
                              await Connect();
                          }
                          catch (SocketException e)
                          {
                              MessageBox.Show(e.Message);
                          }
                      });
                  });
            }
        }

        /// <summary>
        /// Command for download all files in folder.
        /// </summary>
        public CommandAsync DownloadAllInFolderCommand
        {
            get
            {
                return
                new CommandAsync(async (object parameter) =>
                {
                    await DownloadAllFilesInFolderAsync();
                });
            }
        }

        /// <summary>
        /// Command for delete downloaded files.
        /// </summary>
        public CommandAsync DeleteDownloadedFilesCommand
        {
            get
            {
                return
                new CommandAsync(async (object parameter) =>
                {
                    await DeleteDownloadedFilesAsync();
                });
            }
        }

        /// <summary>
        /// Command for download file or go to folder.
        /// </summary>
        public CommandAsync DownloadFileOrGoToAnotherFolderCommand
        {
            get
            {
                return
                  new CommandAsync(async (object parameter) =>
                  {
                      var index = Convert.ToInt32(parameter);
                      if (IsDirectory[index])
                      {
                          await ShowCurrentFoldersAndFilesAsync(DirectoriesAndFiles[index]);
                          return;
                      }
                      await DownloadFile(DirectoriesAndFiles[index]);
                  });
            }
        }

        /// <summary>
        /// Connection to server.
        /// </summary>
        private async Task Connect()
        {
            try
            {
                if (InputValidation.IpValidation(this.ip) && InputValidation.PortValidation(this.port))
                {
                    MessageBox.Show("Incorrect port or ip.");
                    return;
                }
                client = new Client(this.ip, int.Parse(this.port));
            }
            catch (Exception)
            {
                MessageBox.Show($"Failed to connect to server {this.ip}:{this.port}");
                return;
            }
            serverPath = pathToDownload;
            await ShowCurrentFoldersAndFilesAsync(serverPath);
        }

        /// <summary>
        /// Show current folder.
        /// </summary>
        /// <param name="path">Path</param>
        private async Task ShowCurrentFoldersAndFilesAsync(string path)
        {
            ClearFileList();
            if (path == "..")
            {
                await ShowCurrentFoldersAndFilesAsync(openFolder.Pop());
                return;
            }
            var foldersAndFiles = await client.ListAsync(path);
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
                DownloadingFiles.Add(path);
                var fileStream = new MemoryStream();
                await client.GetAsync(path, fileStream);
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

        /// <summary>
        /// Download all files in folder.
        /// </summary>
        private Task DownloadAllFilesInFolderAsync()
        {
            if (client == null)
            {
                MessageBox.Show("You are not connected to the server");
                return Task.CompletedTask;
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
            return Task.CompletedTask;
        }

        /// <summary>
        /// Delete downloaded files.
        /// </summary>
        private Task DeleteDownloadedFilesAsync()
        {
            if (!Directory.Exists(pathToSaveFiles))
            {
                return Task.CompletedTask;
            }
            DownloadedFiles.Clear();
            var directory = new DirectoryInfo(pathToSaveFiles);
            var files = directory.GetFiles();
            foreach (var file in files)
            {
                file.Delete();
            }
            Directory.Delete(pathToSaveFiles);
            return Task.CompletedTask;
        }
    }
}