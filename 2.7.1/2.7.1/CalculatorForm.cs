using System;
using System.Windows.Forms;

namespace _2._7._1
{
    public partial class CalculatorForm : Form
    {
        CalculatorLogic calculator = new CalculatorLogic();

        /// <summary>
        /// CalculatorForm constructor.
        /// </summary>
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click a number buttonю
        /// </summary>
        /// <param name="sender">Clicked button</param>
        private void buttonNumber_Click(object sender, EventArgs e)
        {
            calculator.AddNumber((string)((Button)sender).Text);
        }

        /// <summary>
        /// Click a comma button.
        /// </summary>
        private void buttonComma_Click(object sender, EventArgs e)
        {
            calculator.AddComma();
        }

        /// <summary>
        /// Click change sgn button.
        /// </summary>
        private void buttonChangeSgn_Click(object sender, EventArgs e)
        {
            calculator.ChangeSgn();
        }

        /// <summary>
        /// Click equal sign button.
        /// </summary>
        private void buttonEqualSign_Click(object sender, EventArgs e)
        {
            calculator.Counting();
        }

        /// <summary>
        /// Click operation button.
        /// </summary>
        private void buttonOperation_Click(object sender, EventArgs e)
        {
            calculator.AddOperation((string)((Button)sender).Text);
        }

        /// <summary>
        /// Click backspace button.
        /// </summary>
        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            calculator.Backspace();
        }

        /// <summary>
        /// Click delete entry button.
        /// </summary>
        private void buttonDeleteEntry_Click(object sender, EventArgs e)
        {
            calculator.ClearEntry();
        }

        /// <summary>
        /// Click delete all expression button.
        /// </summary>
        private void buttonDeleteAllExpression_Click(object sender, EventArgs e)
        {
            calculator.Clear();
        }

        /// <summary>
        /// Refresh calculator fields.
        /// </summary>
        private void RefreshLabelAndTextBox(object sender, EventArgs e)
        {
            this.labelCurrentExpression.Text = calculator.CurrentExpression;
            this.textBoxResult.Text = calculator.CurrentEntry;
        }
    }
}
