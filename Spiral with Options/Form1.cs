using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spiral_with_Options
{
    struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public partial class Form1 : Form
    {
        Graphics g;
        Random rnd = new Random();
        Pen dlugopis;
        int kat = 0;
        int wybor = 0;
        Vector2 poczatek;
        float wielkosc = 1;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            int poziom = Screen.PrimaryScreen.Bounds.Width - this.PreferredSize.Width;
            int pion = Screen.PrimaryScreen.Bounds.Height - this.PreferredSize.Height;
            
            this.Location = new Point(poziom / 2, pion / 2);
            
            this.BackColor = Color.White;
            g = this.CreateGraphics();
            dlugopis = new Pen(Brushes.IndianRed);
        }

        private void button1_Click(object sender, EventArgs e) //start kołem
        {
            wybor = 1;

            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e) //start kwadratem
        {
            wybor = 2;
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e) //PAUZA
        {
            timer1.Stop();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 6;
            double rownekolo = kat * Math.PI / 180;

            double r = i * rownekolo;  //wzor
            poczatek=new Vector2(200, 400);
            float y = (float)(poczatek.x + r * Math.Sin(kat * Math.PI / 180));
            float x = (float)(poczatek.y + r * Math.Cos(kat * Math.PI / 180));
            try
            {

                wielkosc = int.Parse(textBox2.Text); //pobiera grubość


            }
            catch
            {
                wielkosc = 7;

            }
            try
            {
                timer1.Interval = int.Parse(textBox3.Text); //pobieranie interwału
            }
            catch
            {
                timer1.Interval = 20;
            }

            if (wybor == 1) //rysowanie kolem
            {
                
                g.DrawEllipse(dlugopis, x, y, wielkosc, wielkosc);
            }
            if (wybor == 2) //rysowanie kwadratem
            {
                
                g.DrawRectangle(dlugopis, x, y, wielkosc, wielkosc);
            }
            if (wybor == 3)
            {

            }
            if (wybor == 4)
            {
                wielkosc = 1;
                rownekolo = 0;
                kat = 0;
                x = 0;
                y = 0;
                r = 0;

            }
            if (wybor == 6)
            {
                dlugopis.Dispose();
                wybor = 1;
            }


            kat += 1;

            if (kat % 25 == 0)
            {
                wielkosc += 0.3f;
            }

        }

        private void button4_Click(object sender, EventArgs e) //STOP
        {

            g.Clear(Color.White);
            wybor = 4;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //wzowienie
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Random kolor= new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            dlugopis = new Pen(randomColor);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dlugopis = new Pen(Brushes.IndianRed);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dlugopis = new Pen(Brushes.ForestGreen);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dlugopis = new Pen(Brushes.RoyalBlue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dlugopis = new Pen(Brushes.Chocolate);
        }
    }
}