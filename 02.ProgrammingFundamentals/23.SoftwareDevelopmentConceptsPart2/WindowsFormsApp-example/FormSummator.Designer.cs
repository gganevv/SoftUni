namespace WindowsFormsApp
{
    partial class FormSummator : System.Windows.Forms.Form
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
            this.textBoxFirstNum = new System.Windows.Forms.TextBox();
            this.labelPlus = new System.Windows.Forms.Label();
            this.labelEqual = new System.Windows.Forms.Label();
            this.textBoxSecondNum = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFirstNum
            // 
            this.textBoxFirstNum.Location = new System.Drawing.Point(13, 14);
            this.textBoxFirstNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFirstNum.Name = "textBoxFirstNum";
            this.textBoxFirstNum.Size = new System.Drawing.Size(100, 26);
            this.textBoxFirstNum.TabIndex = 0;
            // 
            // labelPlus
            // 
            this.labelPlus.AutoSize = true;
            this.labelPlus.Location = new System.Drawing.Point(120, 17);
            this.labelPlus.Name = "labelPlus";
            this.labelPlus.Size = new System.Drawing.Size(18, 20);
            this.labelPlus.TabIndex = 1;
            this.labelPlus.Text = "*";
            // 
            // labelEqual
            // 
            this.labelEqual.AutoSize = true;
            this.labelEqual.Location = new System.Drawing.Point(258, 17);
            this.labelEqual.Name = "labelEqual";
            this.labelEqual.Size = new System.Drawing.Size(18, 20);
            this.labelEqual.TabIndex = 3;
            this.labelEqual.Text = "=";
            // 
            // textBoxSecondNum
            // 
            this.textBoxSecondNum.Location = new System.Drawing.Point(151, 14);
            this.textBoxSecondNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSecondNum.Name = "textBoxSecondNum";
            this.textBoxSecondNum.Size = new System.Drawing.Size(100, 26);
            this.textBoxSecondNum.TabIndex = 2;
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(289, 14);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(100, 26);
            this.textBoxSum.TabIndex = 4;
            // 
            // buttonCalc
            // 
            this.buttonCalc.Location = new System.Drawing.Point(13, 61);
            this.buttonCalc.Name = "buttonCalc";
            this.buttonCalc.Size = new System.Drawing.Size(376, 43);
            this.buttonCalc.TabIndex = 5;
            this.buttonCalc.Text = "Calculate Sum";
            this.buttonCalc.UseVisualStyleBackColor = true;
            this.buttonCalc.Click += new System.EventHandler(this.buttonCalc_Click);
            // 
            // FormSummator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 117);
            this.Controls.Add(this.buttonCalc);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelEqual);
            this.Controls.Add(this.textBoxSecondNum);
            this.Controls.Add(this.labelPlus);
            this.Controls.Add(this.textBoxFirstNum);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormSummator";
            this.Text = "Summator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFirstNum;
        private System.Windows.Forms.Label labelPlus;
        private System.Windows.Forms.Label labelEqual;
        private System.Windows.Forms.TextBox textBoxSecondNum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonCalc;
    }
}

