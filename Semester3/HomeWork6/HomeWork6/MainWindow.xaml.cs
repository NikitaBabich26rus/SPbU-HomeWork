using System;
using System.Windows;
using System.Windows.Controls;

namespace HomeWork6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new ViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            viewModel.serverPath = this.DownloadPath.Text;
            viewModel.Connection(this.textBoxIP.Text, this.textBoxPort.Text);
        }

        private void ShowFilesAndFolderslistBox_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (((ListBox)sender).SelectedItem.ToString() == "..")
            {
                viewModel.EditListBox("..");
                return;
            }

            if (viewModel.IsDirectory[((ListBox)sender).SelectedIndex])
            {
                viewModel.EditListBox(((ListBox)sender).SelectedItem.ToString());
            }
            else
            {
                _ = viewModel.DownloadFile(((ListBox)sender).SelectedItem.ToString());
            }
        }

        private void DownloadAllInFolderButton_Click(object sender, RoutedEventArgs e) => viewModel.DownloadAllFilesInFolderAsync();

        private void DeleteDownloadedFilesButton_Click(object sender, RoutedEventArgs e) => viewModel.DeleteDownloadedFiles();
    }
}
