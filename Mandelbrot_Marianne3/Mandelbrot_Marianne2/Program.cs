/* Practicumopgave 2 Modelleren en Programmeren KI
 * Mandelbrot
 * Marianne Noordzij en Shi Yi Butter
 */

using System.Windows.Forms;
using System.Drawing;
using System;

namespace Mandelbrot
{
    class InvoerForm : Form
    {
        Panel display = new Panel();
        private TextBox middenX;
        private TextBox middenY;
        private TextBox txtMax;
        private TextBox textboxMax;

        public InvoerForm()
        {
            // Layout window
            this.Text = "Mandelbrot";
            this.BackColor = Color.Gainsboro;
            this.Size = new Size(525, 650);

            // Laytout labelX;
            Label labelX = new Label();
            labelX.AutoSize = true;
            labelX.Text = "midden X:";
            labelX.Location = new Point(20, 15);

            // Laytout labelY
            Label labelY = new Label();
            labelY.AutoSize = true;
            labelY.Text = "midden Y:";
            labelY.Location = new Point(20, 40);

            // Laytout labelSchaal;
            Label labelSchaal = new Label();
            labelSchaal.AutoSize = true;
            labelSchaal.Text = "schaal:";
            labelSchaal.Location = new Point(200, 15);

            // Laytout labelMax
            Label labelMax = new Label();
            labelMax.AutoSize = true;
            labelMax.Text = "max:";
            labelMax.Location = new Point(200, 40);

            // Layout textbox midden X
            this.middenX = new TextBox();
            this.middenX.Name = "textboxX";
            this.middenX.AutoSize = true;
            this.middenX.Location = new Point(80, 13);

            // Layout textbox midden Y
            this.middenY = new TextBox();
            this.middenY.Name = "textboxY";
            this.middenY.AutoSize = true;
            this.middenY.Location = new Point(80, 38);

            // Layout textbox schaal
            TextBox txtSchaal = new TextBox();
            txtSchaal.Name = "textboxX";
            txtSchaal.AutoSize = true;
            txtSchaal.Location = new Point(248, 13);

            // Layout textbox max
            TextBox txtMax = new TextBox();
            txtMax.Name = "textboxY";
            txtMax.Size = new Size(45, 25);
            txtMax.Location = new Point(248, 38);

            // Layout button OK
            Button button = new Button();
            button.Name = "OK";
            button.Text = "OK";
            button.Size = new Size(45, 25);
            button.Location = new Point(304, 38);

            // Layout textbox max
            this.txtMax = new TextBox();
            this.txtMax.Name = "textboxMax";
            this.txtMax.Size = new Size(45, 25);
            this.txtMax.Location = new Point(248, 38);

            // Layout listbox
            ListBox listbox = new ListBox();
            listbox.Name = "listbox";
            //listbox.ItemHeight = 40;
            listbox.Size = new Size(60, 60);
            listbox.Location = new Point(370, 13);
            listbox.Items.Add("basis");
            listbox.Items.Add("zuilen");
            listbox.Items.Add("vuur");
            listbox.Items.Add("zigzag");

            // Draw Panel

            display.Location = new System.Drawing.Point(20, 80);
            display.Name = "Panel1";
            display.Size = new System.Drawing.Size(400, 400);
            display.TabIndex = 0;
            display.BackColor = Color.LightBlue;

            this.Controls.Add(labelX);
            this.Controls.Add(labelY);
            this.Controls.Add(labelSchaal);
            this.Controls.Add(labelMax);
            this.Controls.Add(this.middenX);
            this.Controls.Add(this.middenY);
            this.Controls.Add(txtSchaal);
            this.Controls.Add(textboxMax);
            this.Controls.Add(txtMax);
            this.Controls.Add(button);
            this.Controls.Add(listbox);
            this.Controls.Add(display);

            button.Click += Button_Click;
            display.Paint += drawingPoint;
        }

        public void drawingPoint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            for (float x = 0; x < display.Width; x++)
            {
                for (float y = 0; y < display.Height; y++)
                {

                    float MandelX = x / 100 - 2;
                    float MandelY = y / 100 * -1 + 2;

                    //int NewValueX = b0 + (b1 - b0) * ((x - a0) / (a1 - a0));
                    //int NewValueY = b0 + (b1 - b0) * ((y - a0) / (a1 - a0));
                    //int NewValueX = ((Inputx - InputLow) / (InputHigh - InputLow)) * (OutputHigh - OutputLow) + OutputLow;
                    //int NewValueY = ((Inputy - InputLow) / (InputHigh - InputLow)) * (OutputHigh - OutputLow) + OutputLow;




                    Console.WriteLine((x, y, MandelX, MandelY).ToString());

                    float PlotX = MandelX * 100 + 200;
                    float PlotY = MandelY * 100 / -1 + 200;

                    g.FillRectangle(Brushes.Black, PlotX, PlotY, 1, 1);
                }
            }
        }

        private int bereken(double x, double y)
        {

            double a = 0;
            double b = 0;
            int max = int.Parse(txtMax.Text);
            int i;
            for (i = 0; i < max; i++)
            {
                double uitkomstX = a * a - b * b + x;
                double uitkomstY = 2 * a * b + y;
                double afstand = Math.Sqrt(Math.Pow(uitkomstX, 2) + Math.Pow(uitkomstY, 2));
                x = uitkomstX;
                y = uitkomstY;
                a = x;
                b = y;
                if (afstand > 2)
                {
                    return i;
                }
            }
            return i;
        }

        void Button_Click(object sender, EventArgs e)
        {
            double x = double.Parse(middenX.Text);
            double y = double.Parse(middenY.Text);
            int result = bereken(x, y);
            Console.WriteLine(result.ToString());
        }

    }

    class Mandelbrot
    {
        static void Main()
        {
            InvoerForm scherm;
            scherm = new InvoerForm();
            Application.Run(scherm);
        }

    }
}
