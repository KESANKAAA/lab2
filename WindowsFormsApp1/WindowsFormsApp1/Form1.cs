using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
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
        Pen p1 = new Pen(Color.Blue, 3);
        Pen p2 = new Pen(Color.HotPink, 2);
        Pen p3 = new Pen(Color.White, 3);
        public float ug1, ug2;

        public List<List<(float, float)>> list = new List<List<(float, float)>>();
        public List<Rectangle> rectangles = new List<Rectangle>();



        private void button1_Click(object sender, EventArgs e)
        {

        }



        //метод описывающий движение по кругу в следующую ячейку (с правого края по часовой)

        private Stack<Ya> stack = new Stack<Ya>();

        public void lab((int n, int y) c1)
        {
            int a, b, c, d;
            a = 1;
            b = 1;
            c = 1;
            d = 1;
            (int c1, int c2) cor = c1;
            (int c1, int c2) cor2 = c1;
            Stack<(int, int)> st = new Stack<(int, int)>();
            Random rnd = new Random();

            st.Push(cor);

            while (st.Count != 0)

            {
                int s = rnd.Next(0, 4);

                //if (s == 0 && )
                //{

                //}
                if (a == 0 && b == 0 && c == 0 && d == 0)
                {
                    a = 1;
                    b = 1;
                    c = 1;
                    d = 1;
                    listBox1.Items.Add("Откат");
                    cor = st.Pop();
                }

                else
                {
                    switch (s)
                    {
                        case 0:
                            {
                                listBox1.Items.Add(s + " " + " по кругу");
                                cor = dvpokr(cor.c1, cor.c2);
                                if (cor != (-1, -1))
                                {
                                    cor2 = cor;
                                    st.Push(cor2);
                                    a = 1;
                                    break;
                                }

                                else
                                {
                                    cor = cor2;
                                    a = 0;
                                    Console.WriteLine("asdasdasdasdasd");
                                    break;
                                }

                            }
                        case 1:
                            {
                                listBox1.Items.Add(s + " " + " против круга");
                                cor = dvpprotivkr(cor.c1, cor.c2);
                                if (cor != (-1, -1))
                                {
                                    cor2 = cor;
                                    st.Push(cor2);
                                    b = 1;
                                    break;
                                }
                                else
                                {
                                    cor = cor2;

                                    b = 0;
                                    Console.WriteLine("asdasdasdasdasd");

                                    break;
                                }
                            }
                        case 2:
                            {
                                listBox1.Items.Add(s + " " + " внутрь круга");
                                cor = dvvnutrb(cor.c1, cor.c2);
                                if (cor != (-1, -1))
                                {
                                    cor2 = cor;
                                    st.Push(cor2);
                                    c = 1;
                                    break;
                                }
                                else
                                {
                                    cor = cor2;

                                    c = 0;
                                    Console.WriteLine("asdasdasdasdasd");

                                    break;
                                }
                            }
                        case 3:
                            {
                                listBox1.Items.Add(s + " " + " внешний круг");
                                cor = dvvovn(cor.c1, cor.c2);
                                if (cor != (-1, -1))
                                {
                                    cor2 = cor;
                                    st.Push(cor2);
                                    d = 1;
                                    break;
                                }
                                else
                                {
                                    cor = cor2;

                                    d = 0;
                                    Console.WriteLine("asdasdasdasdasd");

                                    break;
                                }
                            }
                    }
                }
            }
        }

        public void del()
        {
            for (int i = 0; i < obj.Count; i++)
            {

                for (int j = 0; j < obj[i].Count; j++)
                {

                    dvpokr(i, j);
                    break;

                }
            }
        }

        public void vxod()
        {
            Random rnd = new Random();
            int k = rnd.Next(obj[0].Count - 1);
            plato.DrawArc(p3, rectangles[0], obj[0][k].ug.Item1, obj[0][k].ug.Item2);
            plato.DrawArc(p3, rectangles[obj.Count], obj[obj.Count - 1][k].ug.Item1, obj[obj.Count - 1][k].ug.Item2);
        }


        public (int, int) dvpokr(int i, int j)
        {

            if (j == obj[i].Count - 1)
            {
                j = 0;
                Console.WriteLine(obj[i]);
            }
            else
            {
                j += 1;
            }

            if (obj[i][j].Toggle == true)
            {
                plato.DrawLine(p3, obj[i][j].st11.Item1, obj[i][j].st11.Item2, obj[i][j].st12.Item1, obj[i][j].st12.Item2);
                obj[i][j].Toggle = false;
                return (i, j);
            }
            else
            {
                return (-1, -1);
            }
        }

        public (int, int) cors(int i,int j) 
        {
            return (i, j);
        }
       

        //Метод описывающий движение по кругу в обратном направлении 


        public (int,int) dvpprotivkr(int i, int j)
        {
            if (j == 0)
            {
                j = obj[i].Count - 1;
            }
            else
            {
                j -= 1;
            }

            if (obj[i][j].Toggle == true)
            {
                plato.DrawLine(p3, obj[i][j].st21.Item1, obj[i][j].st21.Item2, obj[i][j].st22.Item1, obj[i][j].st22.Item2);
                obj[i][j].Toggle = false;
                return (i, j);
            }
            else
            {
                return (-1, -1);
            }
                                   
        }

            //метод описывающий движение в следующий круг, то есть к центру из текущего

        public (int,int) dvvnutrb(int i,int j)
        {
            int r = j;

            if (i == 0)
            {
                return (-1, -1);
            }
            
            if (obj[i].Count != obj[i - 1].Count)
            {
                r = j / 2;
            }

            if (obj[i-1][r].Toggle == true )
            {
                plato.DrawArc(p3, rectangles[i], obj[i][j].ug.Item1, obj[i][j].ug.Item2);
                i -= 1;
                j = r;
                obj[i][j].Toggle = false;
                return (i, j);
            }
            else
            {
                return (-1,-1);  
            }
        }
        

        //метод описывающий движение в предыдущий круг

        public (int,int) dvvovn(int i,int j) 
        {
            int r = j;

            if (i == obj.Count - 1)
            {
                return(-1,-1);    
            }

            if (obj[i].Count != obj[i + 1].Count)
            {
                r = j * 2 + new Random().Next(2);
            }
            
            
            if (obj[i + 1][r].Toggle == true)
            {
                i += 1;
                j = r;
                obj[i][j].Toggle = false;
                plato.DrawArc(p3, rectangles[i], obj[i][j].ug.Item1, obj[i][j].ug.Item2);
                return (i, j);
            }
            else
            {
                return (-1, -1);
            }
        }
     

        private List<List<Ya>> obj = new List<List<Ya>>(); 
        public void zapis()
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                List<Ya> objects = new List<Ya>();

                //for (int j = 0,s = 0; j < list[i].Count - 2; s += 2,j++)
                //{
                //    if (list[i].Count == list[i+1].Count)
                //    {
                //        objects.Add(new Ya(list[i][j], list[i + 1][j], list[i][j + 1], list[i + 1][j + 1], ugl[i][j + 1]));
                //    }
                //    else
                //    {
                //        objects.Add(new Ya(list[i][j], list[i + 1][s], list[i][j + 1], list[i + 1][s + 2], ugl[i][j + 1]));
                //    }

                //}

                if (list[i].Count == list[i+1].Count)
                {
                    for (int j = 0; j < list[i].Count - 1;j++) 
                    {
                        objects.Add(new Ya(list[i][j], list[i + 1][j], list[i][j + 1], list[i + 1][j + 1], ugl[i][j]));
                    }

                    objects.Add(new Ya(list[i][list[i].Count - 1], list[i + 1][list[i + 1].Count - 1], list[i][0], list[i + 1][0], ugl[i][list[i].Count - 1]));
                }
                else
                {
                    for (int j = 0,s = 0; j < list[i].Count - 1; s += 2,j++)
                    {
                        objects.Add(new Ya(list[i][j], list[i + 1][s], list[i][j + 1], list[i + 1][s + 2], ugl[i][j]));
                    }

                    objects.Add(new Ya(list[i][list[i].Count - 1], list[i + 1][list[i + 1].Count - 2], list[i][0], list[i + 1][0], ugl[i][list[i].Count - 1]));


                }


                obj.Add(objects);
            }
        }

        public List<List<(float, float)>> ugl = new List<List<(float, float)>>();
        public void postr(Pen p, float gr1, float gr2,int k,int size1,int size2)
        {
            Rectangle r = new Rectangle();
            r.Size = new Size(size1, size2);
            r.X = pictureBox1.Width / 2 - r.Size.Width / 2;
            r.Y = pictureBox1.Height / 2 - r.Size.Height / 2;
            rectangles.Add(r);
            List<(float, float)> abc = new List<(float, float)>();
            List<(float, float)> ugls = new List<(float, float)>();

            for (int i = 0; i < k; i++)
            {        
                plato.DrawArc(p1, r, gr1, gr2);
                double a, b;
                a = (pictureBox1.Width / 2) + r.Size.Width / 2 * Math.Cos((gr1 * Math.PI) / 180);
                b = (pictureBox1.Height / 2) + r.Size.Height / 2 * Math.Sin((gr1 * Math.PI) / 180);
                abc.Add(((float)a, (float)b));

                ugls.Add((gr1,gr2));
                gr1 += gr2;

            }
            ugl.Add(ugls);
            list.Add(abc);
        }

          
        public void ris()
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i].Count == list[i + 1].Count)
                {
                    for (int j = 0; j < list[i].Count; j++)
                    {
                        plato.DrawLine(p1, list[i][j].Item1, list[i][j].Item2, list[i + 1][j].Item1, list[i + 1][j].Item2);
                    }
                }
                else 
                {
                    for (int j = 0,k = 0; j < list[i].Count; j++,k+=2)
                    {
                        plato.DrawLine(p1, list[i][j].Item1, list[i][j].Item2, list[i + 1][k].Item1, list[i + 1][k].Item2);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plato.Clear(Color.White);
            rectangles.Clear();
            list.Clear();
            ugl.Clear();
            obj.Clear();

            int sw = 0;

            try
            {
                sw = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception) { }
            int s1 = 50;
            int s2 = 50;
            float ug = 40;
            int k = 9;
            int r = 2;
            int l = 3;

            for (int i = 0; i < sw; i++)
            {
                if (i == r)
                {
                    k *= 2;
                    ug /= 2;
                    r += l;
                    l++;
                }
                postr(p1, 0, ug, k, s1, s2);
                s1 = s1 + 50;
                s2 = s2 + 50;
                k = Convert.ToInt32(360 / ug);
            }

            zapis();
            Console.WriteLine(obj.Count.ToString() + "asdasdasdasd");
            ris();

            lab((0,0));
            del();
            vxod();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plato = pictureBox1.CreateGraphics();
          
        }
    } 
}
