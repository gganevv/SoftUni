namespace _04.CurrencyConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.bgnEur = new System.Windows.Forms.RadioButton();
            this.eurBgn = new System.Windows.Forms.RadioButton();
            this.amount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amount)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(306, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResult.Location = new System.Drawing.Point(80, 94);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.MinimumSize = new System.Drawing.Size(257, 34);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(257, 34);
            this.lblResult.TabIndex = 2;
            // 
            // bgnEur
            // 
            this.bgnEur.AutoSize = true;
            this.bgnEur.Checked = true;
            this.bgnEur.Location = new System.Drawing.Point(186, 17);
            this.bgnEur.Margin = new System.Windows.Forms.Padding(4);
            this.bgnEur.Name = "bgnEur";
            this.bgnEur.Size = new System.Drawing.Size(111, 25);
            this.bgnEur.TabIndex = 3;
            this.bgnEur.TabStop = true;
            this.bgnEur.Text = "BGN to EUR";
            this.bgnEur.UseVisualStyleBackColor = true;
            // 
            // eurBgn
            // 
            this.eurBgn.AutoSize = true;
            this.eurBgn.Location = new System.Drawing.Point(186, 46);
            this.eurBgn.Margin = new System.Windows.Forms.Padding(4);
            this.eurBgn.Name = "eurBgn";
            this.eurBgn.Size = new System.Drawing.Size(111, 25);
            this.eurBgn.TabIndex = 4;
            this.eurBgn.Text = "EUR to BGN";
            this.eurBgn.UseVisualStyleBackColor = true;
            // 
            // amount
            // 
            this.amount.DecimalPlaces = 2;
            this.amount.Location = new System.Drawing.Point(15, 39);
            this.amount.Margin = new System.Windows.Forms.Padding(4);
            this.amount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(154, 29);
            this.amount.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 169);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.eurBgn);
            this.Controls.Add(this.bgnEur);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Currency Converter";
            this.Text = "Currency Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.amount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.RadioButton bgnEur;
        private System.Windows.Forms.RadioButton eurBgn;
        private System.Windows.Forms.NumericUpDown amount;
    }
}
