using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vjesala
{
    public partial class Form1 : Form
    {
        private UnesenaRijec neka;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //neka = new UnesenaRijec();
        }

        int Stanje = -1;


        Point t1 = new Point();
        Point t2 = new Point();
        Point t3 = new Point();
        Point t4 = new Point();
        Point t5 = new Point();
        Point t6 = new Point();
        Point t7 = new Point();

        int x = 50;
        int y = 50;

        int sirinaGlave = 50;
        int visinaGlave = 25;

        Random brojevi = new Random();
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           



            Graphics obj = this.CreateGraphics();
            Pen olovka = new Pen(Color.Brown, 2);
            if (Stanje == 0)
            {
                Rectangle krug = new Rectangle(x, y, sirinaGlave, visinaGlave);
                obj.DrawEllipse(olovka, krug);
            }
            if (Stanje == 1)
            {
                t1 = new Point(x + (sirinaGlave / 2), y + visinaGlave);
                t2 = new Point(x + (sirinaGlave / 2), y + visinaGlave + 60);
                obj.DrawLine(olovka, t1, t2);
            }

            if (Stanje == 2)
            {

                t3 = new Point(x + (sirinaGlave / 2), y + visinaGlave + 10);
                t4 = new Point(x - 10, y + visinaGlave + 25);
                obj.DrawLine(olovka, t3, t4);
            }

            if (Stanje == 3)
            {
                t5 = new Point(x + sirinaGlave + 10, y + visinaGlave + 25);
                obj.DrawLine(olovka, t3, t5);
            }

            if (Stanje == 4)
            {
                t6 = new Point(t4.X, t4.Y + (t2.Y - t1.Y));
                obj.DrawLine(olovka, t2, t6);
            }

            if (Stanje == 5)
            {
                t7 = new Point(t5.X, t5.Y + (t2.Y - t1.Y));
                obj.DrawLine(olovka, t2, t7);
            }
        }

        

        string pojam = "";
        
        private void button2_Click(object sender, EventArgs e)
        {
            string[] rijeci = new string[]{ "ŽIRAFA", "JELEN", "SRNA", "KORNJAČA","PAS","MAČKA","KROKODIL"};
            Random odabir = new Random(DateTime.Now.Millisecond);

            int pos = odabir.Next(0, rijeci.Length - 1);

            pojam = rijeci.GetValue(pos).ToString();
            

            textBox1.Text = "";

            for (int i = 0; i < pojam.Length; i++)
            {
                textBox1.Text += "_ ";
            }

            Stanje = -1;
            ispucanaslova = "";

            Rezultat = new string[] { };

            Array.Resize(ref Rezultat, pojam.Length);
            for (int i = 0; i < Rezultat.Length; i++)
            {
                Rezultat[i] = "_ ";
            }
            
        }

        string ispucanaslova = "";

        string[] Rezultat;

        private void button4_Click(object sender, EventArgs e)
        {


            string slovo = textBox2.Text.ToUpper();
            if (slovo.Length == 0) return;

           

            string rijesenje = "";

            bool Pogodak = false;

            for (int i = 0; i < pojam.Length; i++)
			{
                if (pojam[i] == slovo[0])
                {
                    Rezultat[i] = slovo;
                    Pogodak = true;
                }
               
			}

            textBox1.Text = string.Join("",Rezultat);


            if (!Pogodak)
                Stanje++;

            if (Stanje == 5)
            {
                MessageBox.Show("Majmune jedan, glup si: " + pojam);
                return;
            }
            if (textBox1.Text.IndexOf("_") == -1)
            {
                MessageBox.Show("Bravo");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            neka = new UnesenaRijec();
            neka.ShowDialog();
            pojam = neka.lol;

           

            textBox1.Text = "";

            for (int i = 0; i < pojam.Length; i++)
            {
                textBox1.Text += "_ ";
            }

            Stanje = -1;
            ispucanaslova = "";

            Rezultat = new string[] { };

            Array.Resize(ref Rezultat, pojam.Length);
            for (int i = 0; i < Rezultat.Length; i++)
            {
                Rezultat[i] = "_ ";
            }
        }

        
    }
}
