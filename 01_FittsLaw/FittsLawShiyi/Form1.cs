using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FittsLaw
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            int a, b, T, D, W;

            string box1 = textBox1.Text + button1.Location.X.ToString();

            int button1_xPt = int.Parse(button1.Location.X.ToString());
            int button1_yPt = int.Parse(button1.Location.Y.ToString());

            int button2_xPt = int.Parse(button2.Location.X.ToString());
            int button2_yPt = int.Parse(button2.Location.Y.ToString());

            
            //int button1Pt = int.Parse(button1.Location.ToString());
            //int button2Pt = int.Parse(button2.Location.ToString());
            //D = Point.Subtract(button1Pt, button2Pt);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verdwijnenen van button1 en verschijnen van button2 
            button2.Show();
            button1.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verdwijnen van button2 en verschijnen button1;
            button2.Hide();
            button1.Show();

            int i;
            Random rndPos = new Random();
            
            // for-loop voorkomt dat button2 buiten het scherm verschijnt
            for (i = 0; i < 10; i++)
            {
                Point pt = new Point(
                    int.Parse(rndPos.Next(ClientSize.Width - button2.Width).ToString()),
                    int.Parse(rndPos.Next(ClientSize.Height - button2.Width).ToString())
                    );
                button2.Location = pt;

                Random rndSize = new Random();
                button2.MinimumSize = new Size(25, 25);
                int MaxSize = 200;
                int rndMaxSize = rndSize.Next(MaxSize);
                Size sz = new Size(
                        int.Parse(rndMaxSize.ToString()),
                        int.Parse(rndMaxSize.ToString()));
                button2.Size = sz;
            }

            // for-loop voor verandering x en y coordinaten van button 2
            int k;
            int button2_xPt = button2.Location.X;
            int button2_yPt = button2.Location.Y;
            int button1_xPt = button1.Location.X;
            int button1_yPt = button1.Location.Y; 
            for (k = 0; k < 10; k++)
            {
                // coordinaten button2
                textBox1.Text = button2_xPt.ToString();
                textBox2.Text = button2_yPt.ToString();

                // coordinaten buttons
                double x2 = int.Parse(button2_xPt.ToString());
                double y2 = int.Parse(button2_xPt.ToString());
                double x1 = int.Parse(button1.Location.X.ToString());
                double y1 = int.Parse(button1.Location.Y.ToString());

                // berekent afstand tussen de buttons
                double x_squared = Math.Pow(x1 - x2, 2);
                double y_squared = Math.Pow(y1 - y2, 2);
                double diagonal = x_squared + y_squared;
                double distance = Math.Sqrt(diagonal);
                textBox3.Text = distance.ToString();
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
