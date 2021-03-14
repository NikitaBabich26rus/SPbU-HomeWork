using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using FTP;


namespace HomeWork6
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Client client;
        private Server server;

        public string serverPath;

        private string currentServerPath;

        private Stack<string> openFolder = new Stack<string>();

        public ObservableCollection<string> DirectoriesAndFiles { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<bool> IsDirectory { get; set; } = new ObservableCollection<bool>();

        private bool connectButtonIsEnabled = true;

        public bool ConnectButtonIsEnabled
        {
            get => connectButtonIsEnabled;
            set
            {
                connectButtonIsEnabled = value;
                OnPropertyChanged("ConnectButtonIsEnabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Connection(string host, string port)
        {
            try
            {
                server = new Server("127.0.0.1", 8888);
                client = new Client("127.0.0.1", 8888, this);
                server.Start();
            }
            catch (Exception)
            {
                MessageBox.Show($"Не удалось подключиться к серверу {host}:{port}");
            }
            ShowCurrentFoldersAndFilesAsync(serverPath);
            MessageBox.Show($"Вы подключились к серверу {host}:{port}");
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

        private void ClearFileList() => DirectoriesAndFiles.Clear();

        public void EditListBox(string path)
        {
            ShowCurrentFoldersAndFilesAsync(path);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public void DownloadFile(string path)
        {

        }
    }
}
