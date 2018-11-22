/* Practicumopgaven 1 Modelleren en Programmeren KI
 * Marianne Noordzij en Shi Yi Butter
 */

using System.Windows.Forms;
using System.Drawing;
using System;

namespace FittsLaw
{
    class InvoerForm : Form
    {
        Button startButton;
        Button measureButton;

        Int64 mt;
        Int64 st;
        double distance;
        double reactie_ms;
        double ID;
        int width;

        public InvoerForm()
        {
            // layout window
            this.Text = "Fitt's Law";
            this.BackColor = Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            // layout startBsutton
            startButton = new Button();
            startButton.Size = new Size(80, 40);
            startButton.Text = "start";

            // startButton wordt in het midden van het scherm geplaatst
            int x = ClientSize.Width / 2 - startButton.Width / 2;
            int y = ClientSize.Height / 2 - startButton.Height / 2;
            startButton.Location = new Point(x, y);

            // layout measureButton
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
            startButton.Show();
            measureButton.Hide();

            //// Ticks
            DateTime measureTime = DateTime.Now;
            this.mt = measureTime.Ticks;

            // random size measureButton
            Random rndSize = new Random();
            measureButton.MinimumSize = new Size(25, 25);
            int MaxSize = 200;
            int rndMaxSize = rndSize.Next(MaxSize);
            Size sz = new Size(
                    int.Parse(rndMaxSize.ToString()),
                    int.Parse(rndMaxSize.ToString()));
            measureButton.Size = sz;
            this.width = measureButton.Width;

            // random positie 
            Random rndPos = new Random();
            Point pt = new Point(
            int.Parse(rndPos.Next(ClientSize.Width - width).ToString()),
            int.Parse(rndPos.Next(ClientSize.Height - width).ToString())
            );
            measureButton.Location = pt;

            //// Krijg coordinaten van het centrum van measureButton en startButton
            int mb_xpoint = measureButton.Location.X + (width / 2);
            int mb_ypoint = measureButton.Location.Y - (width / 2);
            int sb_xpoint = startButton.Location.X + (width / 2);
            int sb_ypoint = startButton.Location.Y - (width / 2);
            int z1 = mb_xpoint - sb_xpoint;
            int z2 = mb_ypoint - sb_ypoint;

            // Berekening afstand
            this.distance = (Math.Sqrt(Math.Pow(Math.Abs(mb_xpoint - sb_xpoint), 2) + Math.Pow(Math.Abs(mb_ypoint - sb_ypoint), 2) + Math.Pow(Math.Abs(z1 - z2), 2)));

            // Reactietijd in milliseconden
            double reactie = mt - st;
            this.reactie_ms = reactie / 10000;
            double dw = distance / width + 1;
            double grondgetal = 2;
            this.ID = Math.Log(dw, grondgetal);

            Console.WriteLine("Locatie startknop:" + "X: " + sb_xpoint + " Y: " + sb_ypoint);
            Console.WriteLine("Measuretijd: " + mt);
            Console.WriteLine("Width: " +  width);
            Console.WriteLine("Helft:" + width / 2);
            Console.WriteLine("X: " + mb_xpoint + ", Y: " + mb_ypoint);
            Console.WriteLine("Afstand = " + distance);
            Console.WriteLine("Reactietijd = " + reactie);
            Console.WriteLine("Reactietijd in ms = " + reactie_ms);
            Console.WriteLine("ID = " + ID);
            Console.WriteLine("");
        }
        
        void StartButton_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            this.st = startTime.Ticks;

            Point startButtonLoc = startButton.FindForm().PointToClient(
            startButton.Parent.PointToScreen(startButton.Location));

            double x_sb = startButton.Location.X;
            double y_sb = startButton.Location.Y;
            double w_sb = startButton.Width / 2;
            double h_sb = startButton.Width / 2;
            double xpos = x_sb + w_sb;
            double ypos = y_sb - h_sb;

            // WriteLines
            Console.WriteLine("Starttijd: " + st);
            Console.WriteLine("Locatie startButton: " + x_sb.ToString() + ", " + y_sb.ToString());
            Console.WriteLine("Centrum startButton: " + xpos.ToString() + ", " + ypos.ToString());
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
