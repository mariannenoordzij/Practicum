using System.Windows.Forms;
using System.Drawing;
using System;

namespace FittsLaw
{
    class InvoerForm : Form
    {
        Button startButton;
        Button measureButton;

        public InvoerForm()
        {
            this.Text = "Fitt's Law";
            this.BackColor = Color.White;
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            startButton = new Button();
            startButton.Size = new Size(80, 20);
            startButton.Text = "start";

            int x = ClientSize.Width / 2 - startButton.Width / 2;
            int y = ClientSize.Height / 2 - startButton.Height / 2;
            startButton.Location = new Point(x, y);

            measureButton = new Button();
            measureButton.Location = new Point(100, 30);
            measureButton.Size = new Size(80, 20);
            measureButton.Text = "measure";
            measureButton.Hide();

            Random rndPos = new Random();

            this.Controls.Add(startButton);
            this.Controls.Add(measureButton);

            startButton.Click += StartButton_Click;
            measureButton.Click += MeasureButton_Click;
        }

        void MeasureButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hallo2");
            startButton.Show();
            measureButton.Hide();
        }


        void StartButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hallo");
            startButton.Hide();
            measureButton.Show();
        }
    }

   



    class FittsLaw
    {
        static void Main()
        {
            InvoerForm scherm;
            scherm = new InvoerForm();
            Application.Run(scherm);
        }
    }
}
