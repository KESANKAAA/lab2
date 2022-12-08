using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public Graphics plato;
        Pen p1 = new Pen(Color.Blue,3);
        Pen p2 = new Pen(Color.Red, 2);
        Brush br = new SolidBrush(Color.Red);
        public float ug1, ug2;

        public List<List<(float, float)>> list = new List<List<(float, float)>>();

        public List<(float, float)> lst = new List<(float, float)>();
        public List<(float, float)> lst1 = new List<(float, float)>();
        public List<(float, float)> lst2 = new List<(float, float)>();
        public List<(float, float)> lst3 = new List<(float, float)>();

        public int sw;

        private void button1_Click(object sender, EventArgs e)
        {
            plato.Clear(Color.White);
            lst.Clear();
            lst1.Clear();
            lst2.Clear();
            lst3.Clear();

            switch (sw)
            {
                case 3:
                    kr3();
                    break;

                case 6:
                    kr6();
                    break;

                case 9:
                    kr9();
                    break;

                case 12:
                    kr12();
                    break;
            }


        }
        public void postr(Pen p, float gr1, float gr2,int k,int size1,int size2)
        {
            for (int i = 0; i < k; i++)
            {
                Rectangle r = new Rectangle();
                r.Size = new Size(size1,size2);
                r.X = pictureBox1.Width / 2 - r.Size.Width / 2;
                r.Y = pictureBox1.Height / 2 - r.Size.Height / 2;
                plato.DrawArc(p1, r, gr1, gr2);

                //Рисование точек
                double a, b;
                a = (pictureBox1.Width / 2) + r.Size.Width / 2 * Math.Cos((gr1 * Math.PI) / 180);
                b = (pictureBox1.Height / 2) + r.Size.Height / 2 * Math.Sin((gr1 * Math.PI) / 180);
                plato.DrawEllipse(p2, (float)a - 2, (float)b - 2, 4, 4);
                lst.Add(((float)a,(float)b));
                gr1 += gr2;
            }
        }

        

        public void kr3()
        {     
            postr(p1, 0,30,12,200,200);
            postr(p1,0,30,12,150,150);
            postr(p1, 0, 60, 6, 100, 100);
            zapis();
            ris();
        }

        public void kr6() 
        {
            postr(p1, 0, 7.5F, 48, 300, 300);
            postr(p1, 0, 7.5F, 48, 250, 250);
            postr(p1, 0, 15, 24, 200, 200);
            postr(p1, 0, 15, 24, 150, 150);
            postr(p1, 0, 60, 12, 100, 100);
            postr(p1, 0, 60, 12, 50, 50);
        }
        public void kr9()
        {
            postr(p1, 0, 7.5F, 48, 450, 450);
            postr(p1, 0, 7.5F, 48, 400, 400);
            postr(p1, 0, 7.5F, 48, 350, 350);

            postr(p1, 0, 15, 24, 300, 300);
            postr(p1, 0, 15, 24, 250, 250);
            postr(p1, 0, 15, 24, 200, 200);

            postr(p1, 0, 60, 12, 150, 150);
            postr(p1, 0, 60, 12, 100, 100);
            postr(p1, 0, 60, 12, 50, 50);
        }
        public void kr12()
        {
            postr(p1, 0, 7.5F, 48, 420, 420);
            postr(p1, 0, 7.5F, 48, 385, 385);
            postr(p1, 0, 7.5F, 48, 350, 350);
            postr(p1, 0, 7.5F, 48, 315, 315);

            postr(p1, 0, 15, 24, 280, 280);
            postr(p1, 0, 15, 24, 245, 245);
            postr(p1, 0, 15, 24, 210, 210);
            postr(p1, 0, 15, 24, 175,175);

            postr(p1, 0, 60, 12, 140, 140);
            postr(p1, 0, 60, 12, 105, 105);
            postr(p1, 0, 60, 12, 70, 70);
            postr(p1, 0, 60, 12, 35, 35);
        }

        public void zapis() 
        {
            List<(float,float)> obs = new List<(float,float)> ();

            switch (lst.Count)
            {
                case 30:
                  
                    for (int i = 0; i < 12; i++)
                    {
                        obs.Add(lst[i]);
                        Console.WriteLine(lst3[i]);
                    }
                    list.Add(obs);
                    obs.Clear();    
                    Console.WriteLine("");

                    for (int i = 12; i < 24; i++)
                    {
                        lst2.Add(lst[i]);
                        Console.WriteLine(lst2[i - 12]);
                    }
                    Console.WriteLine("");

                    for (int i = 24; i < 30; i++)
                    {
                        lst1.Add(lst[i]);
                        Console.WriteLine(lst1[i - 24]);
                    }
                    break;

                case 168:
                    for (int i = 0; i < 48; i++)
                    {
                        lst3.Add(lst[i]);
                        Console.WriteLine(lst3[i]);
                    }
                    break;
            }                   
        }
        //lst1 - 6
        //lst1 - 12
        //lst1 - 12
        public void ris()
        {
            int j = 0;
            switch (lst.Count)
            {
                case 30:
                    for (int i = 0; i < 6; i++)
                    {
                        plato.DrawLine(p1, lst2[j].Item1, lst2[j].Item2, lst1[i].Item1, lst1[i].Item2);
                        j += 2;
                    }

                    for (int i = 0; i < 12; i++)
                    {
                        plato.DrawLine(p1, lst2[i].Item1, lst2[i].Item2, lst3[i].Item1, lst3[i].Item2);
                    }
                    break;
                    
            }
           
                
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            sw = 3;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            sw = 6;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            sw = 9;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            sw = 12;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plato = pictureBox1.CreateGraphics();
        }
    } 
}
