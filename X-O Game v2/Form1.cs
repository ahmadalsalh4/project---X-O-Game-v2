using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using X_O_Game_v2.Properties;

namespace X_O_Game_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enPlayers { Player1, Player2 };

        enum enstatus { InProgress, Ended };

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen BPen = new Pen(Color.White);

            BPen.Width = 10;

            BPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            BPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(BPen, 400, 150, 400, 600);
            e.Graphics.DrawLine(BPen, 550, 150, 550, 600);
            e.Graphics.DrawLine(BPen, 700, 150, 700, 600);
            e.Graphics.DrawLine(BPen, 850, 150, 850, 600);


            e.Graphics.DrawLine(BPen, 400, 150, 850, 150);
            e.Graphics.DrawLine(BPen, 400, 300, 850, 300);
            e.Graphics.DrawLine(BPen, 400, 450, 850, 450);
            e.Graphics.DrawLine(BPen, 400, 600, 850, 600);

        }

        enPlayers Player = enPlayers.Player1;

        enstatus State = enstatus.InProgress;

        short UsedBoxeCounter = 0;

        short Player1TotalWin = 0;
        short Player2TotalWin = 0;


        bool Check3Buttun(Button button1, Button button2, Button button3)
        {
            if (Convert.ToString(button1.Tag) == "?" ||
                    Convert.ToString(button2.Tag) == "?" ||
                    Convert.ToString(button3.Tag) == "?")
            {
                return false;
            }
            else
            {
                if (Convert.ToString(button1.Tag) == "x" &&
                    Convert.ToString(button2.Tag) == "x" &&
                    Convert.ToString(button3.Tag) == "x")
                {
                    State = enstatus.Ended;
                    LbTurn.Text = "Ended";
                    LbWinner.Text = "X";
                    Player1TotalWin++;
                    LbxtotalWin.Text = Convert.ToString(Player1TotalWin);

                    button1.BackColor = Color.Yellow;
                    button2.BackColor = Color.Yellow;
                    button3.BackColor = Color.Yellow;

                    MessageBox.Show("X Winned", "warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
                else if (Convert.ToString(button1.Tag) == "o" &&
                    Convert.ToString(button2.Tag) == "o" &&
                    Convert.ToString(button3.Tag) == "o")
                {
                    State = enstatus.Ended;
                    LbTurn.Text = "Ended";
                    LbWinner.Text = "O";
                    Player2TotalWin++;
                    LbOtotalWin.Text = Convert.ToString(Player2TotalWin);

                    button1.BackColor = Color.Yellow;
                    button2.BackColor = Color.Yellow;
                    button3.BackColor = Color.Yellow;

                    MessageBox.Show("O Winned", "warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
                return false;
            }

        }

        void CheckWinner()
        {
            if(UsedBoxeCounter == 9)
            {
                State = enstatus.Ended;
                LbTurn.Text = "Ended";
                LbWinner.Text = "Draw";
                MessageBox.Show("Draw", "warning",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (Check3Buttun(Btn1, Btn2, Btn3))
                    return;
                if (Check3Buttun(Btn4, Btn5, Btn6))
                    return;
                if (Check3Buttun(Btn7, Btn8, Btn9))
                    return;
                if (Check3Buttun(Btn1, Btn4, Btn7))
                    return;
                if (Check3Buttun(Btn2, Btn5, Btn8))
                    return;
                if (Check3Buttun(Btn3, Btn6, Btn9))
                    return;
                if (Check3Buttun(Btn1, Btn5, Btn9))
                    return;
                if (Check3Buttun(Btn3, Btn5, Btn7))
                    return;
            }
        }

        void AllInOne(Button button)
        {
            if(State != enstatus.InProgress)
            {
                MessageBox.Show("Game ended,Please restart the game", "warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (Convert.ToString(button.Tag) != "?")
                {
                    MessageBox.Show("this box alredy selected", "warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Player == enPlayers.Player1)
                    {
                        button.Image = Resources.X_Letter;
                        button.Tag = "x";
                        Player = enPlayers.Player2;
                        LbTurn.Text = "O";
                        
                    }
                    else
                    {
                        button.Image = Resources.O_Letter;
                        button.Tag = "o";
                        Player = enPlayers.Player1;
                        LbTurn.Text = "X";

                    }
                    UsedBoxeCounter++;
                    CheckWinner();
                }
            }
        }

        void ResetButtun(Button button)
        {
            button.Tag = "?";
            button.Image = Resources.Quastion_Mark;
            button.BackColor = Color.Transparent;
        }

        void ResettheGame()
        {
            Player = enPlayers.Player1;
            LbTurn.Text = "X";
            State = enstatus.InProgress;
            LbWinner.Text = "InProgress";
            UsedBoxeCounter = 0;
            

            ResetButtun(Btn1);
            ResetButtun(Btn2);
            ResetButtun(Btn3);
            ResetButtun(Btn4);
            ResetButtun(Btn5);
            ResetButtun(Btn6);
            ResetButtun(Btn7);
            ResetButtun(Btn8);
            ResetButtun(Btn9);

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            AllInOne((Button)sender);
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            ResettheGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player1TotalWin = 0;
            LbxtotalWin.Text = Convert.ToString(Player1TotalWin);

            Player2TotalWin = 0;
            LbOtotalWin.Text = Convert.ToString(Player2TotalWin);

        }
    }
}
