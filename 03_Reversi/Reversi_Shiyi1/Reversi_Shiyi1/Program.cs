/* Practicumopgave 2 Modelleren en Programmeren KI
 * Reversi 21 december 2018
 * Marianne Noordzij en Shi Yi Butter, werkgroep 07
 */

using System.Windows.Forms;
using System.Drawing;
using System;

namespace Reversi_Shiyi1
{
    class InvoerForm : Form
    {
        int[,] tabel = new int [6, 6];

        public InvoerForm()
        {
            Panel gameboard = new Panel();

            // Layout window
            Text = "Refersi";
            BackColor = Color.White;
            Size = new Size(700, 700);

            // Layout gameboard
            gameboard.Location = new Point(30, 120);
            gameboard.Size = new Size(301, 301);
            gameboard.BackColor = Color.Aquamarine;

            this.Controls.Add(gameboard);

            gameboard.Paint += drawGameboard;
        }

        public void drawGameboard(object sender, PaintEventArgs e)
        {
            for (int t = 0; t < 6; t++)
            {
                for (int i = 0; i < 6; i++)
                {
                    e.Graphics.DrawRectangle(Pens.Black, t * 50, i * 50, 50, 50);

                    if (i % 2 == 0)
                    {
                        e.Graphics.FillEllipse(Brushes.Red, tabel[t, i], i * 50, 50, 50);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(Brushes.Blue, t * 50, i * 50, 50, 50);
                    }
                }
            }
        }
    }

    class Reversi
    {
        static void Main()
        {
            InvoerForm scherm;
            scherm = new InvoerForm();
            Application.Run(scherm);
        }

    }
}
