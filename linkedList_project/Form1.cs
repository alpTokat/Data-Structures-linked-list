using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linkedList_project
{

    public partial class Form1 : Form
    {

        public class dugum
        {
            public int no;
            public string name;
            public int price;
            public dugum next;
            public dugum last;
        }
        dugum ilk = null;
        dugum son = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void listeyeYazdır(dugum ilk)
        {
            dataGridView1.Rows.Clear();
            while (ilk != null)
            {
                String[] data = new string[] { ilk.no.ToString(), ilk.name, ilk.price.ToString() };
                dataGridView1.Rows.Add(data);
                ilk = ilk.next;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null)
            {
                MessageBox.Show("Lütfen bütün metinleri doldurun");
            }
            else
            {
                int no = Convert.ToInt32(textBox1.Text);
                dugum yeni = new dugum();
                dugum gecici = new dugum();
                yeni.no = Convert.ToInt32(textBox1.Text);
                yeni.name = textBox2.Text;
                yeni.price = Convert.ToInt32(textBox3.Text);
                gecici = ilk;
                Boolean check = true;
                while (gecici != null)
                {
                    if (no == gecici.no)
                    {
                        check = false;
                    }
                    gecici = gecici.next;
                }
                if (check)
                {
                    if (ilk == null)
                    {
                        ilk = yeni;
                        son = ilk;
                        ilk.next = son;
                        son.next = null;

                    }
                    else
                    {
                        son.next = yeni;
                        yeni.last = son;
                        son = yeni;
                        son.next = null;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen farkı bir kod girin");
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listeyeYazdır(ilk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = null;
            textBox4.Text = null;
            dugum indis = new dugum();
            indis = ilk;
            int bulunacak = Convert.ToInt32(textBox6.Text);
            while (indis != null)
            {
                if (indis.no == bulunacak)
                {
                    textBox5.Text = indis.name;
                    textBox4.Text = indis.price.ToString();
                }
                indis = indis.next;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = null;
            textBox7.Text = null;
            dugum indis = new dugum();
            indis = ilk;
            int bulunacak = Convert.ToInt32(textBox9.Text);
            while (indis != null)
            {
                if (indis.no == bulunacak)
                {
                    textBox8.Text = indis.name;
                    textBox7.Text = indis.price.ToString();
                }
                indis = indis.next;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dugum silinecek = new dugum();
            dugum onceki = new dugum();
            int no = Convert.ToInt32(textBox6.Text);
            if (ilk.no == no)
            {
                ilk = ilk.next;

            }
            else
            {
                silinecek = ilk;
                while (silinecek.no != no)
                {
                    onceki = silinecek;
                    silinecek = silinecek.next;
                }
                if (silinecek.next == null)
                {
                    son = onceki;
                    son.next = null;
                }
                else
                {
                    onceki.next = silinecek.next;
                    silinecek.next.last = onceki.last;
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int newPrice = Convert.ToInt32(textBox7.Text);
            dugum gecici = new dugum();
            int no2 = Convert.ToInt32(textBox9.Text);
            gecici = ilk;
            if (ilk.no == no2)
            {
                ilk.price = newPrice;
            }
            else
            {
                while (gecici.no != no2)
                {
                    gecici = gecici.next;
                    if (gecici.no == no2)
                    {
                        gecici.price = newPrice;
                    }
                }
            }

        }
    }
}



