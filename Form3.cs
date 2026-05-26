using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace cafe_adisyon
{
    public partial class Siparis : Form
    {
        public Siparis(string masaNo)
        {
            InitializeComponent();

            masa_num.Text = masaNo;
        }

        int hesapp = 0;
        int siparis = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Siparis_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Latte"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Latte x" + adet;

                    siparis += 135;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Latte x1");
                siparis += 135;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void Siparis_FormClosed(object sender, FormClosedEventArgs e)
        {
            siparis = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Latte"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 135;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Latte x" + adet;

                    siparis -= 135;             
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                listBox2.Items.Add(item);
            }
            listBox1.Items.Clear();
            hesapp += siparis;
            siparis = 0;
            siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            hesaptxt.Text = ("HESAP: " + Convert.ToString(hesapp));
        }
    }
}
