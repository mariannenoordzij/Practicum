using System.Windows.Forms;
using System.Drawing;
using System;

namespace Mandelbrot
{
    class GUI : Form
    {
       
        public GUI()
        {
            this.Text = "Mandelbrot Figure";
            this.BackColor = Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            Label label_co_X = new Label();
            Label label_co_Y = new Label();
            Label label_schaal = new Label();
            Label label_max = new Label();

            label_co_X.Location = new Point(20, 20);
            label_co_X.Size = new Size(50, 20);
            label_co_X.Text = "X-coord";

            label_co_Y.Location = new Point(20, 60);
            label_co_Y.Size = new Size(50, 20);
            label_co_Y.Text = "Y-coord";

            Controls.Add(label_co_X);
            Controls.Add(label_co_Y);
        }
    }

    class Mandelbrot
    {
        static void Main()
        {
            GUI scherm;
            scherm = new GUI();
            Application.Run(scherm);
        }
    }
}

