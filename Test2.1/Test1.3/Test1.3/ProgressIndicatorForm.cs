using System;
using System.Windows.Forms;

namespace Test1._3
{
    /// <summary>
    /// Progress indicator class
    /// </summary>
    public partial class ProgressIndicatorForm : Form
    {
        /// <summary>
        /// Progress indicator constructor.
        /// </summary>
        public ProgressIndicatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize progress bar.
        /// </summary>
        public void ProgressBarInitialize()
        {
            this.progressBar.Step = 1;
            this.progressBar.Minimum = 1;
            this.progressBar.Maximum = 100;
        }

        /// <summary>
        /// Begins to fill the scale
        /// </summary>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.progressBar.Value == 100)
            {
                this.Close();
            }
            timer.Interval = 500;
            this.timer.Tick += new EventHandler(this.timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// Increases the scale of filling every half second
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.progressBar.Value == 100)
            {
                this.buttonStart.Text = "Close";
                return;
            }
            this.progressBar.PerformStep();
        }
    }
}
