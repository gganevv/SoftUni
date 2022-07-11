using System;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class FormSummator : System.Windows.Forms.Form
    {
        public FormSummator()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            decimal firstNum = decimal.Parse(this.textBoxFirstNum.Text);
            decimal secondNum = decimal.Parse(this.textBoxSecondNum.Text);
            decimal sum = firstNum * secondNum;
            this.textBoxSum.Text = sum.ToString();
        }
    }
}
