namespace _2._7._1
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonChangeSgn = new System.Windows.Forms.Button();
            this.buttonNumber0 = new System.Windows.Forms.Button();
            this.buttonNumber7 = new System.Windows.Forms.Button();
            this.buttonNumber8 = new System.Windows.Forms.Button();
            this.buttonComma = new System.Windows.Forms.Button();
            this.buttonNumber9 = new System.Windows.Forms.Button();
            this.buttonNumber4 = new System.Windows.Forms.Button();
            this.buttonNumber5 = new System.Windows.Forms.Button();
            this.buttonNumber6 = new System.Windows.Forms.Button();
            this.buttonNumber1 = new System.Windows.Forms.Button();
            this.buttonNumber2 = new System.Windows.Forms.Button();
            this.buttonNumber3 = new System.Windows.Forms.Button();
            this.buttonDivisionSign = new System.Windows.Forms.Button();
            this.buttonMultiplicationSign = new System.Windows.Forms.Button();
            this.buttonSubtractionSign = new System.Windows.Forms.Button();
            this.buttonAdditionSign = new System.Windows.Forms.Button();
            this.buttonEqualSign = new System.Windows.Forms.Button();
            this.buttonDeleteEntry = new System.Windows.Forms.Button();
            this.buttonDeleteAllExpression = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.currentExpression = new System.Windows.Forms.Label();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelCurrentExpression = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeSgn
            // 
            this.buttonChangeSgn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChangeSgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonChangeSgn.Location = new System.Drawing.Point(3, 495);
            this.buttonChangeSgn.Name = "buttonChangeSgn";
            this.buttonChangeSgn.Size = new System.Drawing.Size(161, 79);
            this.buttonChangeSgn.TabIndex = 0;
            this.buttonChangeSgn.Text = "+/-";
            this.buttonChangeSgn.UseVisualStyleBackColor = true;
            this.buttonChangeSgn.Click += new System.EventHandler(this.buttonChangeSgn_Click);
            this.buttonChangeSgn.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber0
            // 
            this.buttonNumber0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber0.Location = new System.Drawing.Point(170, 495);
            this.buttonNumber0.Name = "buttonNumber0";
            this.buttonNumber0.Size = new System.Drawing.Size(161, 79);
            this.buttonNumber0.TabIndex = 1;
            this.buttonNumber0.Text = "0";
            this.buttonNumber0.UseVisualStyleBackColor = true;
            this.buttonNumber0.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber0.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber7
            // 
            this.buttonNumber7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber7.Location = new System.Drawing.Point(3, 413);
            this.buttonNumber7.Name = "buttonNumber7";
            this.buttonNumber7.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber7.TabIndex = 2;
            this.buttonNumber7.Text = "7";
            this.buttonNumber7.UseVisualStyleBackColor = true;
            this.buttonNumber7.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber7.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber8
            // 
            this.buttonNumber8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber8.Location = new System.Drawing.Point(170, 413);
            this.buttonNumber8.Name = "buttonNumber8";
            this.buttonNumber8.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber8.TabIndex = 3;
            this.buttonNumber8.Text = "8";
            this.buttonNumber8.UseVisualStyleBackColor = true;
            this.buttonNumber8.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber8.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonComma
            // 
            this.buttonComma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonComma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonComma.Location = new System.Drawing.Point(337, 495);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(161, 79);
            this.buttonComma.TabIndex = 4;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = true;
            this.buttonComma.Click += new System.EventHandler(this.buttonComma_Click);
            this.buttonComma.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber9
            // 
            this.buttonNumber9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber9.Location = new System.Drawing.Point(337, 413);
            this.buttonNumber9.Name = "buttonNumber9";
            this.buttonNumber9.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber9.TabIndex = 5;
            this.buttonNumber9.Text = "9";
            this.buttonNumber9.UseVisualStyleBackColor = true;
            this.buttonNumber9.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber9.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber4
            // 
            this.buttonNumber4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber4.Location = new System.Drawing.Point(3, 331);
            this.buttonNumber4.Name = "buttonNumber4";
            this.buttonNumber4.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber4.TabIndex = 6;
            this.buttonNumber4.Text = "4";
            this.buttonNumber4.UseVisualStyleBackColor = true;
            this.buttonNumber4.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber4.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber5
            // 
            this.buttonNumber5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber5.Location = new System.Drawing.Point(170, 331);
            this.buttonNumber5.Name = "buttonNumber5";
            this.buttonNumber5.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber5.TabIndex = 7;
            this.buttonNumber5.Text = "5";
            this.buttonNumber5.UseVisualStyleBackColor = true;
            this.buttonNumber5.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber5.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber6
            // 
            this.buttonNumber6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber6.Location = new System.Drawing.Point(337, 331);
            this.buttonNumber6.Name = "buttonNumber6";
            this.buttonNumber6.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber6.TabIndex = 8;
            this.buttonNumber6.Text = "6";
            this.buttonNumber6.UseVisualStyleBackColor = true;
            this.buttonNumber6.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber6.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber1
            // 
            this.buttonNumber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber1.Location = new System.Drawing.Point(3, 249);
            this.buttonNumber1.Name = "buttonNumber1";
            this.buttonNumber1.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber1.TabIndex = 9;
            this.buttonNumber1.Text = "1";
            this.buttonNumber1.UseVisualStyleBackColor = true;
            this.buttonNumber1.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber1.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber2
            // 
            this.buttonNumber2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber2.Location = new System.Drawing.Point(170, 249);
            this.buttonNumber2.Name = "buttonNumber2";
            this.buttonNumber2.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber2.TabIndex = 10;
            this.buttonNumber2.Text = "2";
            this.buttonNumber2.UseVisualStyleBackColor = true;
            this.buttonNumber2.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber2.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber3
            // 
            this.buttonNumber3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNumber3.Location = new System.Drawing.Point(337, 249);
            this.buttonNumber3.Name = "buttonNumber3";
            this.buttonNumber3.Size = new System.Drawing.Size(161, 76);
            this.buttonNumber3.TabIndex = 11;
            this.buttonNumber3.Text = "3";
            this.buttonNumber3.UseVisualStyleBackColor = true;
            this.buttonNumber3.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber3.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDivisionSign
            // 
            this.buttonDivisionSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDivisionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonDivisionSign.Location = new System.Drawing.Point(504, 167);
            this.buttonDivisionSign.Name = "buttonDivisionSign";
            this.buttonDivisionSign.Size = new System.Drawing.Size(161, 76);
            this.buttonDivisionSign.TabIndex = 15;
            this.buttonDivisionSign.Text = "/";
            this.buttonDivisionSign.UseVisualStyleBackColor = true;
            this.buttonDivisionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonDivisionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonMultiplicationSign
            // 
            this.buttonMultiplicationSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMultiplicationSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonMultiplicationSign.Location = new System.Drawing.Point(504, 249);
            this.buttonMultiplicationSign.Name = "buttonMultiplicationSign";
            this.buttonMultiplicationSign.Size = new System.Drawing.Size(161, 76);
            this.buttonMultiplicationSign.TabIndex = 16;
            this.buttonMultiplicationSign.Text = "*";
            this.buttonMultiplicationSign.UseVisualStyleBackColor = true;
            this.buttonMultiplicationSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonMultiplicationSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonSubtractionSign
            // 
            this.buttonSubtractionSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubtractionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonSubtractionSign.Location = new System.Drawing.Point(504, 331);
            this.buttonSubtractionSign.Name = "buttonSubtractionSign";
            this.buttonSubtractionSign.Size = new System.Drawing.Size(161, 76);
            this.buttonSubtractionSign.TabIndex = 17;
            this.buttonSubtractionSign.Text = "-";
            this.buttonSubtractionSign.UseVisualStyleBackColor = true;
            this.buttonSubtractionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonSubtractionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonAdditionSign
            // 
            this.buttonAdditionSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdditionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonAdditionSign.Location = new System.Drawing.Point(504, 413);
            this.buttonAdditionSign.Name = "buttonAdditionSign";
            this.buttonAdditionSign.Size = new System.Drawing.Size(161, 76);
            this.buttonAdditionSign.TabIndex = 18;
            this.buttonAdditionSign.Text = "+";
            this.buttonAdditionSign.UseVisualStyleBackColor = true;
            this.buttonAdditionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonAdditionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonEqualSign
            // 
            this.buttonEqualSign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEqualSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonEqualSign.Location = new System.Drawing.Point(504, 495);
            this.buttonEqualSign.Name = "buttonEqualSign";
            this.buttonEqualSign.Size = new System.Drawing.Size(161, 79);
            this.buttonEqualSign.TabIndex = 19;
            this.buttonEqualSign.Text = "=";
            this.buttonEqualSign.UseVisualStyleBackColor = true;
            this.buttonEqualSign.Click += new System.EventHandler(this.buttonEqualSign_Click);
            this.buttonEqualSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDeleteEntry
            // 
            this.buttonDeleteEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonDeleteEntry.Location = new System.Drawing.Point(3, 167);
            this.buttonDeleteEntry.Name = "buttonDeleteEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(161, 76);
            this.buttonDeleteEntry.TabIndex = 21;
            this.buttonDeleteEntry.Text = "CE";
            this.buttonDeleteEntry.UseVisualStyleBackColor = true;
            this.buttonDeleteEntry.Click += new System.EventHandler(this.buttonDeleteEntry_Click);
            this.buttonDeleteEntry.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDeleteAllExpression
            // 
            this.buttonDeleteAllExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteAllExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonDeleteAllExpression.Location = new System.Drawing.Point(170, 167);
            this.buttonDeleteAllExpression.Name = "buttonDeleteAllExpression";
            this.buttonDeleteAllExpression.Size = new System.Drawing.Size(161, 76);
            this.buttonDeleteAllExpression.TabIndex = 22;
            this.buttonDeleteAllExpression.Text = "C";
            this.buttonDeleteAllExpression.UseVisualStyleBackColor = true;
            this.buttonDeleteAllExpression.Click += new System.EventHandler(this.buttonDeleteAllExpression_Click);
            this.buttonDeleteAllExpression.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonBackspace.Location = new System.Drawing.Point(337, 167);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(161, 76);
            this.buttonBackspace.TabIndex = 23;
            this.buttonBackspace.Text = "Delete";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.buttonBackspace_Click);
            this.buttonBackspace.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // currentExpression
            // 
            this.currentExpression.AutoSize = true;
            this.currentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.currentExpression.Location = new System.Drawing.Point(7, 40);
            this.currentExpression.Name = "currentExpression";
            this.currentExpression.Size = new System.Drawing.Size(0, 40);
            this.currentExpression.TabIndex = 24;
            // 
            // textBoxResult
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxResult, 4);
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxResult.Location = new System.Drawing.Point(3, 85);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(662, 76);
            this.textBoxResult.TabIndex = 25;
            this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCurrentExpression
            // 
            this.labelCurrentExpression.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelCurrentExpression, 4);
            this.labelCurrentExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelCurrentExpression.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCurrentExpression.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentExpression.Name = "labelCurrentExpression";
            this.labelCurrentExpression.Size = new System.Drawing.Size(662, 82);
            this.labelCurrentExpression.TabIndex = 27;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.textBoxResult, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDeleteEntry, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonDeleteAllExpression, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqualSign, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonComma, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivisionSign, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonChangeSgn, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonAdditionSign, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber9, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber5, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber8, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSubtractionSign, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplicationSign, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber3, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonNumber0, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelCurrentExpression, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(668, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.currentExpression);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonChangeSgn;
        private System.Windows.Forms.Button buttonNumber0;
        private System.Windows.Forms.Button buttonNumber7;
        private System.Windows.Forms.Button buttonNumber8;
        private System.Windows.Forms.Button buttonComma;
        private System.Windows.Forms.Button buttonNumber9;
        private System.Windows.Forms.Button buttonNumber4;
        private System.Windows.Forms.Button buttonNumber5;
        private System.Windows.Forms.Button buttonNumber6;
        private System.Windows.Forms.Button buttonNumber1;
        private System.Windows.Forms.Button buttonNumber2;
        private System.Windows.Forms.Button buttonNumber3;
        private System.Windows.Forms.Button buttonDivisionSign;
        private System.Windows.Forms.Button buttonMultiplicationSign;
        private System.Windows.Forms.Button buttonSubtractionSign;
        private System.Windows.Forms.Button buttonAdditionSign;
        private System.Windows.Forms.Button buttonEqualSign;
        private System.Windows.Forms.Button buttonDeleteEntry;
        private System.Windows.Forms.Button buttonDeleteAllExpression;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.Label currentExpression;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelCurrentExpression;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

