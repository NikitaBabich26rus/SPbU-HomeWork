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

namespace Test3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Table table = new Table();
        private bool isFirstPlayer = true;
        private int movesAmount = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = table;
        }

        /// <summary>
        /// Cell click event.
        /// </summary>
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button) - 1;
            var value = isFirstPlayer ? "X" : "0";
            isFirstPlayer = !isFirstPlayer;
            table.ChangeTable(row, column, value);
            button.Content = value;

            if (table.IsGameOver() || movesAmount == 9)
            {
                Restart_Click(sender, e);
            }
        }

        /// <summary>
        /// Button restart event
        /// </summary>
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            table = new Table();
            Button11.Content = "";
            Button12.Content = "";
            Button13.Content = "";
            Button21.Content = "";
            Button22.Content = "";
            Button23.Content = "";
            Button31.Content = "";
            Button32.Content = "";
            Button33.Content = "";
            isFirstPlayer = true;
            movesAmount = 0;
        }
    }
}
