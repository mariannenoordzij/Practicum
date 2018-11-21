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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            startButton = new Button();
            startButton.Size = new Size(80, 40);
            startButton.Text = "start";

            // startButton wordt in het midden van het scherm geplaatst
            int x = ClientSize.Width / 2 - startButton.Width / 2;
            int y = ClientSize.Height / 2 - startButton.Height / 2;
            startButton.Location = new Point(x, y);

            measureButton = new Button();
            measureButton.Location = new Point(100, 30);
            measureButton.Size = new Size(80, 80);
            measureButton.Text = "";
            measureButton.Hide();
            measureButton.BackColor = System.Drawing.Color.Red;

            this.Controls.Add(startButton);
            this.Controls.Add(measureButton);

            startButton.Click += StartButton_Click;
            measureButton.Click += MeasureButton_Click;

        }

        void MeasureButton_Click(object sender, EventArgs e)
        {
            // Ticks
            DateTime measureTime = DateTime.Now;
            Int64 mt = measureTime.Ticks;
            
            startButton.Show();
            measureButton.Hide();


            Random rndSize = new Random();
            measureButton.MinimumSize = new Size(25, 25);
            int MaxSize = 200;
            int rndMaxSize = rndSize.Next(MaxSize);
            Size sz = new Size(
                    int.Parse(rndMaxSize.ToString()),
                    int.Parse(rndMaxSize.ToString()));
            measureButton.Size = sz;

            Random rndPos = new Random();
            Point pt = new Point(
            int.Parse(rndPos.Next(ClientSize.Width - measureButton.Width).ToString()),
            int.Parse(rndPos.Next(ClientSize.Height - measureButton.Width).ToString())
            );
            measureButton.Location = pt;


            //// Krijg coordinaten measureButton
            int mb_xpoint = measureButton.Location.X;
            int mb_ypoint = measureButton.Location.Y;
            int sb_xpoint = startButton.Location.X;
            int sb_ypoint = startButton.Location.Y;
            int z1 = mb_xpoint - sb_xpoint;
            int z2 = mb_ypoint - sb_ypoint;

            // Berekening afstand
            double distance = (Math.Sqrt(Math.Pow(Math.Abs(mb_xpoint - sb_xpoint), 2) + Math.Pow(Math.Abs(mb_ypoint - sb_ypoint), 2) + Math.Pow(Math.Abs(z1 - z2), 2)));

            // WriteLines
            Console.WriteLine("Measuretijd: " + mt / 10000);
            Console.WriteLine("Width: " +  measureButton.Width);
            Console.WriteLine("X: " + mb_xpoint + ", Y: " + mb_ypoint);
            Console.WriteLine("Afstand = " + distance);
            Console.WriteLine("");



        }


        void StartButton_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            Int64 st = startTime.Ticks;

            Point startButtonLoc = startButton.FindForm().PointToClient(
            startButton.Parent.PointToScreen(startButton.Location));

            // WriteLines
            Console.WriteLine("Starttijd: " + st);
            Console.WriteLine("Locatie startButton: " + startButtonLoc);
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
