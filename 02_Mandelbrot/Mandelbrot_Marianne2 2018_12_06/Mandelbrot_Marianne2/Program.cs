/* Practicumopgave 2 Modelleren en Programmeren KI
 * Mandelbrot
 * Marianne Noordzij en Shi Yi Butter
 */

using System.Windows.Forms;
using System.Drawing;
using System;

namespace Mandelbrot
{
    public class InvoerForm : Form
    {
        double zoom = 1;
        double verschuivingX = 0;
        double verschuivingY = 0;

        Panel display = new Panel();
        private TextBox middenX;
        private TextBox middenY;
        private TextBox txtSchaal;
        private TextBox txtMax;
        private TextBox txtboxMax;
        private Label Exceptions;

        public InvoerForm()
        {
            // Layout window
            this.Text = "Mandelbrot";
            this.BackColor = Color.Gainsboro;
            this.Size = new Size(525, 650);

            // Exceptions Label
            Exceptions = new Label();
            Exceptions.Location = new Point(20, 70);
            Exceptions.AutoSize = true;
            Exceptions.Text = "";

            // Laytout labelX
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
            middenX = new TextBox();
            middenX.Name = "textboxX";
            middenX.AutoSize = true;
            middenX.Location = new Point(80, 13);

            // Layout textbox midden Y
            middenY = new TextBox();
            middenY.Name = "textboxY";
            middenY.AutoSize = true;
            middenY.Location = new Point(80, 38);

            // Layout textbox schaal
            txtSchaal = new TextBox();
            txtSchaal.Name = "textboxX";
            txtSchaal.AutoSize = true;
            txtSchaal.Location = new Point(248, 13);

            // Layout textbox max
            txtMax = new TextBox();
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

            display.Location = new System.Drawing.Point(20, 120);
            display.Name = "Panel1";
            display.Size = new System.Drawing.Size(400, 400);
            display.TabIndex = 0;
            display.BackColor = Color.Black;

            this.Controls.Add(labelX);
            this.Controls.Add(labelY);
            this.Controls.Add(labelSchaal);
            this.Controls.Add(labelMax);
            this.Controls.Add(middenX);
            this.Controls.Add(middenY);
            this.Controls.Add(txtSchaal);
            this.Controls.Add(txtMax);
            this.Controls.Add(txtMax);
            this.Controls.Add(button);
            this.Controls.Add(Exceptions);
            this.Controls.Add(listbox);
            this.Controls.Add(display);

            button.Click += Button_Click;
            display.Paint += drawingPoint;
            display.MouseClick += display_Click;
        }

        public void Button_Click(object sender, EventArgs e)
        {

            string messageError = null;

            try
            {
                verschuivingX = double.Parse(middenX.Text);
                Exceptions.Text = "";
            }
            catch (FormatException)
            {
                Exceptions.Text = (middenX.Text + " is geen getal");
            }
            try
            {
                verschuivingY = double.Parse(middenY.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = (middenY.Text + " is geen getal");
            }
            try
            {
                zoom = double.Parse(txtSchaal.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = (txtSchaal.Text + " is geen getal");
            }
            if (string.IsNullOrEmpty(messageError))
            {
                display.Invalidate();
            }
            else
            {

            }

        }


        public void drawingPoint(object sender, PaintEventArgs e)
        {
            //var g = e.Graphics;
            Bitmap bmp = new Bitmap(display.Width, display.Height);

            // Dubbele for-loop zodat het programma elke pixel afgaat
            for (float x = 0; x < display.Width; x++)
            {
                for (float y = 0; y < display.Height; y++)
                {
                    float MandelX = (x / 100 - 2) / (float)zoom + (float)verschuivingX;
                    float MandelY = (y / 100 * -1 + 2) / (float)zoom + (float)verschuivingY;

                    //Console.WriteLine((x, y, MandelX, MandelY).ToString());

                    float a = 0;
                    float b = 0;

                    //g.FillRectangle(Brushes.Black, PlotX, PlotY, 1, 1);

                    int max = 100;

                    // For-loop voor berekening het mandelgetal int i
                    int i;
                    for (i = 0; i < max; i++)
                    {
                        float uitkomstX = a * a - b * b + MandelX;
                        float uitkomstY = 2 * a * b + MandelY;


                        float afstand = (float)Math.Sqrt(Math.Pow(uitkomstX, 2) + Math.Pow(uitkomstY, 2));
                        a = uitkomstX;
                        b = uitkomstY;

                        if (afstand > 2)
                        {
                            if (i % 2 == 0)
                            {
                                //g.FillRectangle(Brushes.Black, x, y, 1, 1);
                                bmp.SetPixel((int)x, (int)y, Color.Black);
                            }
                            else
                            {
                                //g.FillRectangle(Brushes.White, x, y, 1, 1);
                                bmp.SetPixel((int)x, (int)y, Color.White);
                            }
                            break;
                        }

                        if (i % 2 == 0)
                        {
                            //g.FillRectangle(Brushes.White, x, y, 1, 1);
                            bmp.SetPixel((int)x, (int)y, Color.White);
                        }
                        else
                        {
                            //g.FillRectangle(Brushes.Black, x, y, 1, 1);
                            bmp.SetPixel((int)x, (int)y, Color.Black);
                        }
                    }
                }
                e.Graphics.DrawImage(bmp, 0, 0, display.Width, display.Height);
            }
        }

        public void display_Click(object sender, MouseEventArgs e)
        {
            double pos_x = (double)e.X / 100 - 2;
            verschuivingX += pos_x;
            double pos_y = (double)e.Y / 100 * -1 + 2;
            verschuivingY += pos_y;
            zoom = zoom * 2;
            display.Invalidate();
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
