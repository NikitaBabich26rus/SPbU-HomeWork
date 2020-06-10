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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChangeSgn
            // 
            this.buttonChangeSgn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChangeSgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChangeSgn.Location = new System.Drawing.Point(3, 623);
            this.buttonChangeSgn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonChangeSgn.Name = "buttonChangeSgn";
            this.buttonChangeSgn.Size = new System.Drawing.Size(174, 102);
            this.buttonChangeSgn.TabIndex = 0;
            this.buttonChangeSgn.Text = "+/-";
            this.buttonChangeSgn.UseVisualStyleBackColor = true;
            this.buttonChangeSgn.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber0
            // 
            this.buttonNumber0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber0.Location = new System.Drawing.Point(183, 623);
            this.buttonNumber0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber0.Name = "buttonNumber0";
            this.buttonNumber0.Size = new System.Drawing.Size(177, 102);
            this.buttonNumber0.TabIndex = 1;
            this.buttonNumber0.Text = "0";
            this.buttonNumber0.UseVisualStyleBackColor = true;
            this.buttonNumber0.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber7
            // 
            this.buttonNumber7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber7.Location = new System.Drawing.Point(3, 515);
            this.buttonNumber7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber7.Name = "buttonNumber7";
            this.buttonNumber7.Size = new System.Drawing.Size(174, 100);
            this.buttonNumber7.TabIndex = 2;
            this.buttonNumber7.Text = "7";
            this.buttonNumber7.UseVisualStyleBackColor = true;
            this.buttonNumber7.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber8
            // 
            this.buttonNumber8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber8.Location = new System.Drawing.Point(183, 515);
            this.buttonNumber8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber8.Name = "buttonNumber8";
            this.buttonNumber8.Size = new System.Drawing.Size(177, 100);
            this.buttonNumber8.TabIndex = 3;
            this.buttonNumber8.Text = "8";
            this.buttonNumber8.UseVisualStyleBackColor = true;
            this.buttonNumber8.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonComma
            // 
            this.buttonComma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonComma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonComma.Location = new System.Drawing.Point(366, 623);
            this.buttonComma.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(170, 102);
            this.buttonComma.TabIndex = 4;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = true;
            this.buttonComma.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber9
            // 
            this.buttonNumber9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber9.Location = new System.Drawing.Point(366, 515);
            this.buttonNumber9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber9.Name = "buttonNumber9";
            this.buttonNumber9.Size = new System.Drawing.Size(170, 100);
            this.buttonNumber9.TabIndex = 5;
            this.buttonNumber9.Text = "9";
            this.buttonNumber9.UseVisualStyleBackColor = true;
            this.buttonNumber9.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber4
            // 
            this.buttonNumber4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber4.Location = new System.Drawing.Point(3, 400);
            this.buttonNumber4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber4.Name = "buttonNumber4";
            this.buttonNumber4.Size = new System.Drawing.Size(174, 107);
            this.buttonNumber4.TabIndex = 6;
            this.buttonNumber4.Text = "4";
            this.buttonNumber4.UseVisualStyleBackColor = true;
            this.buttonNumber4.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber5
            // 
            this.buttonNumber5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber5.Location = new System.Drawing.Point(183, 400);
            this.buttonNumber5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber5.Name = "buttonNumber5";
            this.buttonNumber5.Size = new System.Drawing.Size(177, 107);
            this.buttonNumber5.TabIndex = 7;
            this.buttonNumber5.Text = "5";
            this.buttonNumber5.UseVisualStyleBackColor = true;
            this.buttonNumber5.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber6
            // 
            this.buttonNumber6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber6.Location = new System.Drawing.Point(366, 400);
            this.buttonNumber6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber6.Name = "buttonNumber6";
            this.buttonNumber6.Size = new System.Drawing.Size(170, 107);
            this.buttonNumber6.TabIndex = 8;
            this.buttonNumber6.Text = "6";
            this.buttonNumber6.UseVisualStyleBackColor = true;
            this.buttonNumber6.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber1
            // 
            this.buttonNumber1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber1.Location = new System.Drawing.Point(3, 296);
            this.buttonNumber1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber1.Name = "buttonNumber1";
            this.buttonNumber1.Size = new System.Drawing.Size(174, 96);
            this.buttonNumber1.TabIndex = 9;
            this.buttonNumber1.Text = "1";
            this.buttonNumber1.UseVisualStyleBackColor = true;
            this.buttonNumber1.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber2
            // 
            this.buttonNumber2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber2.Location = new System.Drawing.Point(183, 296);
            this.buttonNumber2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber2.Name = "buttonNumber2";
            this.buttonNumber2.Size = new System.Drawing.Size(177, 96);
            this.buttonNumber2.TabIndex = 10;
            this.buttonNumber2.Text = "2";
            this.buttonNumber2.UseVisualStyleBackColor = true;
            this.buttonNumber2.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber3
            // 
            this.buttonNumber3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNumber3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonNumber3.Location = new System.Drawing.Point(366, 296);
            this.buttonNumber3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNumber3.Name = "buttonNumber3";
            this.buttonNumber3.Size = new System.Drawing.Size(170, 96);
            this.buttonNumber3.TabIndex = 11;
            this.buttonNumber3.Text = "3";
            this.buttonNumber3.UseVisualStyleBackColor = true;
            this.buttonNumber3.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDivisionSign
            // 
            this.buttonDivisionSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivisionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDivisionSign.Location = new System.Drawing.Point(542, 187);
            this.buttonDivisionSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDivisionSign.Name = "buttonDivisionSign";
            this.buttonDivisionSign.Size = new System.Drawing.Size(181, 101);
            this.buttonDivisionSign.TabIndex = 15;
            this.buttonDivisionSign.Text = "/";
            this.buttonDivisionSign.UseVisualStyleBackColor = true;
            this.buttonDivisionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonMultiplicationSign
            // 
            this.buttonMultiplicationSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplicationSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMultiplicationSign.Location = new System.Drawing.Point(542, 296);
            this.buttonMultiplicationSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonMultiplicationSign.Name = "buttonMultiplicationSign";
            this.buttonMultiplicationSign.Size = new System.Drawing.Size(181, 96);
            this.buttonMultiplicationSign.TabIndex = 16;
            this.buttonMultiplicationSign.Text = "*";
            this.buttonMultiplicationSign.UseVisualStyleBackColor = true;
            this.buttonMultiplicationSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonSubtractionSign
            // 
            this.buttonSubtractionSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSubtractionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSubtractionSign.Location = new System.Drawing.Point(542, 400);
            this.buttonSubtractionSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSubtractionSign.Name = "buttonSubtractionSign";
            this.buttonSubtractionSign.Size = new System.Drawing.Size(181, 107);
            this.buttonSubtractionSign.TabIndex = 17;
            this.buttonSubtractionSign.Text = "-";
            this.buttonSubtractionSign.UseVisualStyleBackColor = true;
            this.buttonSubtractionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonAdditionSign
            // 
            this.buttonAdditionSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdditionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdditionSign.Location = new System.Drawing.Point(542, 515);
            this.buttonAdditionSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAdditionSign.Name = "buttonAdditionSign";
            this.buttonAdditionSign.Size = new System.Drawing.Size(181, 100);
            this.buttonAdditionSign.TabIndex = 18;
            this.buttonAdditionSign.Text = "+";
            this.buttonAdditionSign.UseVisualStyleBackColor = true;
            this.buttonAdditionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonEqualSign
            // 
            this.buttonEqualSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqualSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEqualSign.Location = new System.Drawing.Point(542, 623);
            this.buttonEqualSign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonEqualSign.Name = "buttonEqualSign";
            this.buttonEqualSign.Size = new System.Drawing.Size(181, 102);
            this.buttonEqualSign.TabIndex = 19;
            this.buttonEqualSign.Text = "=";
            this.buttonEqualSign.UseVisualStyleBackColor = true;
            this.buttonEqualSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDeleteEntry
            // 
            this.buttonDeleteEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteEntry.Location = new System.Drawing.Point(3, 187);
            this.buttonDeleteEntry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteEntry.Name = "buttonDeleteEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(174, 101);
            this.buttonDeleteEntry.TabIndex = 21;
            this.buttonDeleteEntry.Text = "CE";
            this.buttonDeleteEntry.UseVisualStyleBackColor = true;
            this.buttonDeleteEntry.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDeleteAllExpression
            // 
            this.buttonDeleteAllExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteAllExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteAllExpression.Location = new System.Drawing.Point(183, 187);
            this.buttonDeleteAllExpression.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonDeleteAllExpression.Name = "buttonDeleteAllExpression";
            this.buttonDeleteAllExpression.Size = new System.Drawing.Size(177, 101);
            this.buttonDeleteAllExpression.TabIndex = 22;
            this.buttonDeleteAllExpression.Text = "C";
            this.buttonDeleteAllExpression.UseVisualStyleBackColor = true;
            this.buttonDeleteAllExpression.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBackspace.Location = new System.Drawing.Point(366, 187);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(170, 101);
            this.buttonBackspace.TabIndex = 23;
            this.buttonBackspace.Text = "Delete";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // currentExpression
            // 
            this.currentExpression.AutoSize = true;
            this.currentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentExpression.Location = new System.Drawing.Point(8, 50);
            this.currentExpression.Name = "currentExpression";
            this.currentExpression.Size = new System.Drawing.Size(0, 40);
            this.currentExpression.TabIndex = 24;
            // 
            // textBoxResult
            // 
            this.tableLayoutPanel.SetColumnSpan(this.textBoxResult, 4);
            this.textBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxResult.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxResult.Location = new System.Drawing.Point(3, 56);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(720, 123);
            this.textBoxResult.TabIndex = 25;
            this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCurrentExpression
            // 
            this.labelCurrentExpression.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.labelCurrentExpression, 4);
            this.labelCurrentExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCurrentExpression.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCurrentExpression.Location = new System.Drawing.Point(3, 0);
            this.labelCurrentExpression.Name = "labelCurrentExpression";
            this.labelCurrentExpression.Size = new System.Drawing.Size(720, 52);
            this.labelCurrentExpression.TabIndex = 27;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel.Controls.Add(this.textBoxResult, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.buttonDeleteEntry, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonDeleteAllExpression, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonBackspace, 2, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonEqualSign, 3, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonComma, 2, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonDivisionSign, 3, 2);
            this.tableLayoutPanel.Controls.Add(this.buttonChangeSgn, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.buttonAdditionSign, 3, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber9, 2, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber7, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber4, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber5, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber8, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber6, 2, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonSubtractionSign, 3, 4);
            this.tableLayoutPanel.Controls.Add(this.buttonMultiplicationSign, 3, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber3, 2, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber2, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber1, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.buttonNumber0, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.labelCurrentExpression, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 7;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(721, 729);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 729);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.currentExpression);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}

