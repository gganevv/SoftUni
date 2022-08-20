using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04.CurrencyConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bgnEur.Checked)
            {
                lblResult.Text = $"{amount.Value / 1.95583M:F2}";
            }
            else if (eurBgn.Checked)
            {
                lblResult.Text = $"{amount.Value * 1.95583M:F2}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
