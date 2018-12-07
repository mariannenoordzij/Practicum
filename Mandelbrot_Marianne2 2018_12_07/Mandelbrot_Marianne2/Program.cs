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
        int max = 100;

        Panel display = new Panel();
        private TextBox middenX;
        private TextBox middenY;
        private TextBox txtSchaal;
        private TextBox txtMax;
        private Label Exceptions;
        ListBox listbox;

        public InvoerForm()
        {
            // Layout window
            Text = "Mandelbrot Viewer";
            BackColor = Color.Gainsboro;
            Size = new Size(525, 650);

            // Exceptions Label
            Exceptions = new Label();
            Exceptions.Location = new Point(20, 80);
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
            txtMax = new TextBox();
            txtMax.Name = "textboxMax";
            txtMax.Size = new Size(45, 25);
            txtMax.Location = new Point(248, 38);

            // Layout listbox
            listbox = new ListBox();
            listbox.Name = "listbox";
            listbox.Size = new Size(60, 60);
            listbox.Location = new Point(370, 13);
            listbox.Items.Add("start");
            listbox.Items.Add("smelten");
            listbox.Items.Add("microscoop");
            listbox.Items.Add("de rand");

            // Draw Panel
            display.Location = new System.Drawing.Point(20, 120);
            display.Name = "Panel1";
            display.Size = new System.Drawing.Size(400, 400);
            display.TabIndex = 0;
            display.BackColor = Color.Black;

            Controls.Add(labelX);
            Controls.Add(labelY);
            Controls.Add(labelSchaal);
            Controls.Add(labelMax);
            Controls.Add(middenX);
            Controls.Add(middenY);
            Controls.Add(txtSchaal);
            Controls.Add(txtMax);
            Controls.Add(button);
            Controls.Add(Exceptions);
            Controls.Add(listbox);
            Controls.Add(display);

            button.Click += Button_Click;
            display.Paint += drawingPoint;
            display.MouseClick += display_Click;
            listbox.MouseClick += listboxClick;
        }

        public void Button_Click(object sender, EventArgs e)
        {

            string messageError = null;

            try
            {
                verschuivingX = double.Parse(middenX.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = "Ongeldige invoer. Voer een getal in.";
            }
            try
            {
                verschuivingY = double.Parse(middenY.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = "Ongeldige invoer. Voer een getal in.";
            }
            try
            {
                zoom = double.Parse(txtSchaal.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = "Ongeldige invoer. Voer een getal in.";
            }
            try
            {
                max = int.Parse(txtMax.Text);
            }
            catch (FormatException)
            {
                Exceptions.Text = "Ongeldige invoer. Voer een getal in.";
            }
            if (string.IsNullOrEmpty(messageError))
            {
                display.Invalidate();
            }


        }

        public void listboxClick(object sender, MouseEventArgs e)
        {
            int keuze = listbox.SelectedIndex;
            Exceptions.Text = "";

            switch (keuze)
            {
                case 0:
                    verschuivingX = 0;
                    verschuivingY = 0;
                    zoom = 1;
                    max = 150;
                    display.Invalidate();
                    break;
                case 1:
                    verschuivingX = -1;
                    verschuivingY = -0.35;
                    zoom = 30;
                    max = 150;
                    display.Invalidate();
                    break;
                case 2:
                    verschuivingX = -1.245;
                    verschuivingY = -0.118;
                    zoom = 180;
                    max = 150;
                    display.Invalidate();
                    break;
                case 3:
                    verschuivingX = 0.4;
                    verschuivingY = -1;
                    zoom = 3;
                    max = 150;
                    display.Invalidate();
                    break;
            }
        }

        public void display_Click(object sender, MouseEventArgs e)
        {
            double pos_x = (double)e.X / 100 - 2;
            verschuivingX += pos_x;
            double pos_y = (double)e.Y / 100 * -1 + 2;
            verschuivingY += pos_y;
            zoom += 2;
            display.Invalidate();
        }

        public void drawingPoint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(display.Width, display.Height);

            // Dubbele for-loop zodat het programma elke pixel afgaat
            for (float x = 0; x < display.Width; x++)
            {
                for (float y = 0; y < display.Height; y++)
                {
                    float MandelX = (x / 100 - 2) / (float)zoom + (float)verschuivingX / (float)zoom;
                    float MandelY = (y / 100 * -1 + 2) / (float)zoom + (float)verschuivingY / (float)zoom;

                    float a = 0;
                    float b = 0;

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
                                bmp.SetPixel((int)x, (int)y, Color.FromArgb(i % 10 * 2, i % 32 * 7, i % 16 * 14));
                            }
                            else
                            {
                                bmp.SetPixel((int)x, (int)y, Color.FromArgb(i % 10 * 2, i % 32 * 7, i % 16 * 14));
                            }
                            break;
                        }

                        if (i % 2 == 0)
                        {
                            bmp.SetPixel((int)x, (int)y, Color.FromArgb(i % 10 * 2, i % 32 * 7, i % 16 * 14));
                        }
                        else
                        {
                            bmp.SetPixel((int)x, (int)y, Color.FromArgb(i % 10 * 2, i % 32 * 7, i % 16 * 14));
                        }
                    }
                }
                e.Graphics.DrawImage(bmp, 0, 0, display.Width, display.Height);
            }
            txtSchaal.Text = zoom.ToString();
            txtMax.Text = max.ToString();
            middenX.Text = verschuivingX.ToString();
            middenY.Text = verschuivingY.ToString();
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
