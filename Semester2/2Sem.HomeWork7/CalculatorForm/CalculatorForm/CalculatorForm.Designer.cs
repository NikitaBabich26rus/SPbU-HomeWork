namespace CalculatorForm
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
            this.SuspendLayout();
            // 
            // buttonChangeSgn
            // 
            this.buttonChangeSgn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangeSgn.Location = new System.Drawing.Point(1, 488);
            this.buttonChangeSgn.Name = "buttonChangeSgn";
            this.buttonChangeSgn.Size = new System.Drawing.Size(119, 79);
            this.buttonChangeSgn.TabIndex = 0;
            this.buttonChangeSgn.Text = "+/-";
            this.buttonChangeSgn.UseVisualStyleBackColor = true;
            this.buttonChangeSgn.Click += new System.EventHandler(this.buttonChangeSgn_Click);
            this.buttonChangeSgn.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber0
            // 
            this.buttonNumber0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber0.Location = new System.Drawing.Point(117, 488);
            this.buttonNumber0.Name = "buttonNumber0";
            this.buttonNumber0.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber0.TabIndex = 1;
            this.buttonNumber0.Text = "0";
            this.buttonNumber0.UseVisualStyleBackColor = true;
            this.buttonNumber0.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber0.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber7
            // 
            this.buttonNumber7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber7.Location = new System.Drawing.Point(1, 412);
            this.buttonNumber7.Name = "buttonNumber7";
            this.buttonNumber7.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber7.TabIndex = 2;
            this.buttonNumber7.Text = "7";
            this.buttonNumber7.UseVisualStyleBackColor = true;
            this.buttonNumber7.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber7.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber8
            // 
            this.buttonNumber8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber8.Location = new System.Drawing.Point(117, 412);
            this.buttonNumber8.Name = "buttonNumber8";
            this.buttonNumber8.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber8.TabIndex = 3;
            this.buttonNumber8.Text = "8";
            this.buttonNumber8.UseVisualStyleBackColor = true;
            this.buttonNumber8.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber8.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonComma
            // 
            this.buttonComma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComma.Location = new System.Drawing.Point(232, 488);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.Size = new System.Drawing.Size(119, 79);
            this.buttonComma.TabIndex = 4;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = true;
            this.buttonComma.Click += new System.EventHandler(this.buttonComma_Click);
            this.buttonComma.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber9
            // 
            this.buttonNumber9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber9.Location = new System.Drawing.Point(232, 412);
            this.buttonNumber9.Name = "buttonNumber9";
            this.buttonNumber9.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber9.TabIndex = 5;
            this.buttonNumber9.Text = "9";
            this.buttonNumber9.UseVisualStyleBackColor = true;
            this.buttonNumber9.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber9.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber4
            // 
            this.buttonNumber4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber4.Location = new System.Drawing.Point(1, 337);
            this.buttonNumber4.Name = "buttonNumber4";
            this.buttonNumber4.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber4.TabIndex = 6;
            this.buttonNumber4.Text = "4";
            this.buttonNumber4.UseVisualStyleBackColor = true;
            this.buttonNumber4.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber4.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber5
            // 
            this.buttonNumber5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber5.Location = new System.Drawing.Point(117, 337);
            this.buttonNumber5.Name = "buttonNumber5";
            this.buttonNumber5.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber5.TabIndex = 7;
            this.buttonNumber5.Text = "5";
            this.buttonNumber5.UseVisualStyleBackColor = true;
            this.buttonNumber5.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber5.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber6
            // 
            this.buttonNumber6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber6.Location = new System.Drawing.Point(232, 337);
            this.buttonNumber6.Name = "buttonNumber6";
            this.buttonNumber6.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber6.TabIndex = 8;
            this.buttonNumber6.Text = "6";
            this.buttonNumber6.UseVisualStyleBackColor = true;
            this.buttonNumber6.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber6.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber1
            // 
            this.buttonNumber1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber1.Location = new System.Drawing.Point(1, 262);
            this.buttonNumber1.Name = "buttonNumber1";
            this.buttonNumber1.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber1.TabIndex = 9;
            this.buttonNumber1.Text = "1";
            this.buttonNumber1.UseVisualStyleBackColor = true;
            this.buttonNumber1.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber1.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber2
            // 
            this.buttonNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber2.Location = new System.Drawing.Point(117, 262);
            this.buttonNumber2.Name = "buttonNumber2";
            this.buttonNumber2.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber2.TabIndex = 10;
            this.buttonNumber2.Text = "2";
            this.buttonNumber2.UseVisualStyleBackColor = true;
            this.buttonNumber2.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber2.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonNumber3
            // 
            this.buttonNumber3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNumber3.Location = new System.Drawing.Point(232, 262);
            this.buttonNumber3.Name = "buttonNumber3";
            this.buttonNumber3.Size = new System.Drawing.Size(119, 79);
            this.buttonNumber3.TabIndex = 11;
            this.buttonNumber3.Text = "3";
            this.buttonNumber3.UseVisualStyleBackColor = true;
            this.buttonNumber3.Click += new System.EventHandler(this.buttonNumber_Click);
            this.buttonNumber3.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDivisionSign
            // 
            this.buttonDivisionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDivisionSign.Location = new System.Drawing.Point(348, 186);
            this.buttonDivisionSign.Name = "buttonDivisionSign";
            this.buttonDivisionSign.Size = new System.Drawing.Size(119, 79);
            this.buttonDivisionSign.TabIndex = 15;
            this.buttonDivisionSign.Text = "/";
            this.buttonDivisionSign.UseVisualStyleBackColor = true;
            this.buttonDivisionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonDivisionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonMultiplicationSign
            // 
            this.buttonMultiplicationSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMultiplicationSign.Location = new System.Drawing.Point(348, 262);
            this.buttonMultiplicationSign.Name = "buttonMultiplicationSign";
            this.buttonMultiplicationSign.Size = new System.Drawing.Size(119, 79);
            this.buttonMultiplicationSign.TabIndex = 16;
            this.buttonMultiplicationSign.Text = "*";
            this.buttonMultiplicationSign.UseVisualStyleBackColor = true;
            this.buttonMultiplicationSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonMultiplicationSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonSubtractionSign
            // 
            this.buttonSubtractionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSubtractionSign.Location = new System.Drawing.Point(348, 337);
            this.buttonSubtractionSign.Name = "buttonSubtractionSign";
            this.buttonSubtractionSign.Size = new System.Drawing.Size(119, 79);
            this.buttonSubtractionSign.TabIndex = 17;
            this.buttonSubtractionSign.Text = "-";
            this.buttonSubtractionSign.UseVisualStyleBackColor = true;
            this.buttonSubtractionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonSubtractionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonAdditionSign
            // 
            this.buttonAdditionSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdditionSign.Location = new System.Drawing.Point(348, 412);
            this.buttonAdditionSign.Name = "buttonAdditionSign";
            this.buttonAdditionSign.Size = new System.Drawing.Size(119, 79);
            this.buttonAdditionSign.TabIndex = 18;
            this.buttonAdditionSign.Text = "+";
            this.buttonAdditionSign.UseVisualStyleBackColor = true;
            this.buttonAdditionSign.Click += new System.EventHandler(this.buttonOperation_Click);
            this.buttonAdditionSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonEqualSign
            // 
            this.buttonEqualSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEqualSign.Location = new System.Drawing.Point(348, 488);
            this.buttonEqualSign.Name = "buttonEqualSign";
            this.buttonEqualSign.Size = new System.Drawing.Size(119, 79);
            this.buttonEqualSign.TabIndex = 19;
            this.buttonEqualSign.Text = "=";
            this.buttonEqualSign.UseVisualStyleBackColor = true;
            this.buttonEqualSign.Click += new System.EventHandler(this.buttonEqualSign_Click);
            this.buttonEqualSign.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonClearEntry
            // 
            this.buttonDeleteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteEntry.Location = new System.Drawing.Point(1, 186);
            this.buttonDeleteEntry.Name = "buttonClearEntry";
            this.buttonDeleteEntry.Size = new System.Drawing.Size(119, 79);
            this.buttonDeleteEntry.TabIndex = 21;
            this.buttonDeleteEntry.Text = "CE";
            this.buttonDeleteEntry.UseVisualStyleBackColor = true;
            this.buttonDeleteEntry.Click += new System.EventHandler(this.buttonDeleteEntry_Click);
            this.buttonDeleteEntry.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonDeleteAllExpression
            // 
            this.buttonDeleteAllExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteAllExpression.Location = new System.Drawing.Point(117, 186);
            this.buttonDeleteAllExpression.Name = "buttonDeleteAllExpression";
            this.buttonDeleteAllExpression.Size = new System.Drawing.Size(119, 79);
            this.buttonDeleteAllExpression.TabIndex = 22;
            this.buttonDeleteAllExpression.Text = "C";
            this.buttonDeleteAllExpression.UseVisualStyleBackColor = true;
            this.buttonDeleteAllExpression.Click += new System.EventHandler(this.buttonDeleteAllExpression_Click);
            this.buttonDeleteAllExpression.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackspace.Location = new System.Drawing.Point(232, 186);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(119, 79);
            this.buttonBackspace.TabIndex = 23;
            this.buttonBackspace.Text = "Delete";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.buttonBackspace_Click);
            this.buttonBackspace.Click += new System.EventHandler(this.RefreshLabelAndTextBox);
            // 
            // currentExpression
            // 
            this.currentExpression.AutoSize = true;
            this.currentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentExpression.Location = new System.Drawing.Point(7, 40);
            this.currentExpression.Name = "currentExpression";
            this.currentExpression.Size = new System.Drawing.Size(0, 40);
            this.currentExpression.TabIndex = 24;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxResult.Location = new System.Drawing.Point(1, 116);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(466, 64);
            this.textBoxResult.TabIndex = 25;
            this.textBoxResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCurrentExpression
            // 
            this.labelCurrentExpression.AutoSize = true;
            this.labelCurrentExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCurrentExpression.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCurrentExpression.Location = new System.Drawing.Point(13, 31);
            this.labelCurrentExpression.Name = "labelCurrentExpression";
            this.labelCurrentExpression.Size = new System.Drawing.Size(0, 37);
            this.labelCurrentExpression.TabIndex = 27;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 567);
            this.Controls.Add(this.labelCurrentExpression);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.currentExpression);
            this.Controls.Add(this.buttonBackspace);
            this.Controls.Add(this.buttonDeleteAllExpression);
            this.Controls.Add(this.buttonDeleteEntry);
            this.Controls.Add(this.buttonEqualSign);
            this.Controls.Add(this.buttonAdditionSign);
            this.Controls.Add(this.buttonSubtractionSign);
            this.Controls.Add(this.buttonMultiplicationSign);
            this.Controls.Add(this.buttonDivisionSign);
            this.Controls.Add(this.buttonNumber3);
            this.Controls.Add(this.buttonNumber2);
            this.Controls.Add(this.buttonNumber1);
            this.Controls.Add(this.buttonNumber6);
            this.Controls.Add(this.buttonNumber5);
            this.Controls.Add(this.buttonNumber4);
            this.Controls.Add(this.buttonNumber9);
            this.Controls.Add(this.buttonComma);
            this.Controls.Add(this.buttonNumber8);
            this.Controls.Add(this.buttonNumber7);
            this.Controls.Add(this.buttonNumber0);
            this.Controls.Add(this.buttonChangeSgn);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
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
    }
}

