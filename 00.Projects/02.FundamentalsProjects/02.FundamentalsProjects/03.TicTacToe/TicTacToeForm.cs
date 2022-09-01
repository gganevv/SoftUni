using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03.TicTacToe
{
    public partial class TicTacToeForm : Form
    {
        public TicTacToeForm()
        {
            InitializeComponent();
            GenerateButtons();
        }

        Button[,] buttons = new Button[3, 3];

        private void GenerateButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(175, 175);
                    buttons[i, j].Location = new Point(i * 175, j * 175);
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].Font = new Font(DefaultFont.FontFamily, 80, FontStyle.Bold);

                    buttons[i, j].Click += new EventHandler(OnButtonClick);
                    this.buttonPanel.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text != "")
            {
                return;
            }

            button.Text = this.playerButton.Text;

            TogglePlayer();
        }

        private void TogglePlayer()
        {
            if (this.playerButton.Text == "X")
            {
                this.playerButton.Text = "O";
            }
            else
            {
                this.playerButton.Text = "X";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
