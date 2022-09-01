using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row, col].Size = new Size(175, 175);
                    buttons[row, col].Location = new Point(row * 175, col * 175);
                    buttons[row, col].FlatStyle = FlatStyle.Flat;
                    buttons[row, col].Font = new Font(DefaultFont.FontFamily, 80, FontStyle.Bold);

                    buttons[row, col].Click += new EventHandler(OnButtonClick);
                    this.buttonPanel.Controls.Add(buttons[row, col]);
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
            CheckIfGameEnds();
            if (this.playerButton.Text == "X")
            {
                this.playerButton.Text = "O";
            }
            else
            {
                this.playerButton.Text = "X";
            }
        }

        private void CheckIfGameEnds()
        {
            List<Button> winnerButtons = new List<Button>();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (buttons[row, col].Text != this.playerButton.Text)
                    {
                        break;
                    }

                    winnerButtons.Add(buttons[row, col]);
                    if (col == 2)
                    {
                        ShowWinner(winnerButtons);
                        return;
                    }
                }
            }

            winnerButtons.Clear();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (buttons[col, row].Text != this.playerButton.Text)
                    {
                        break;
                    }

                    winnerButtons.Add(buttons[col, row]);
                    if (col == 2)
                    {
                        ShowWinner(winnerButtons);
                        return;
                    }
                }
            }

            winnerButtons.Clear();
            for (int row = 0, col = 0; row < 3; row++, col++)
            {
                if (buttons[row, col].Text != this.playerButton.Text)
                {
                    break;
                }

                winnerButtons.Add(buttons[row, col]);
                if (col == 2)
                {
                    ShowWinner(winnerButtons);
                    return;
                }
            }

            winnerButtons.Clear();
            for (int row = 2, col = 0; col < 3; row--, col++)
            {
                if (buttons[row, col].Text != this.playerButton.Text)
                {
                    break;
                }

                winnerButtons.Add(buttons[row, col]);
                if (col == 2)
                {
                    ShowWinner(winnerButtons);
                    return;
                }
            }

            foreach (var button in buttons)
            {
                if (button.Text == "")
                {
                    return;
                }
            }

            MessageBox.Show("Game Draw");
            Application.Exit();
        }

        private void ShowWinner(List<Button> winnerButtons)
        {
            foreach (var button in winnerButtons)
            {
                button.BackColor = Color.LightGreen;
            }
            Application.Exit();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Button button in buttons)
            {
                button.Text = "";
            }
        }
    }
}
