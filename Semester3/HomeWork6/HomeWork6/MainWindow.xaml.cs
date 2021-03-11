using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void listBox_MouseDoubleClick(object sender, RoutedEventArgs e)
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
                viewModel.DownloadFile(((ListBox)sender).SelectedItem.ToString());
            }
        }
    }
}
