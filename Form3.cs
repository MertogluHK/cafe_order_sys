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

        private void button8_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Cappuccino"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Cappuccino x" + adet;

                    siparis += 125;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Cappuccino x1");
                siparis += 125;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Mocha"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Mocha x" + adet;

                    siparis += 145;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Mocha x1");
                siparis += 145;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Americano"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Americano x" + adet;

                    siparis += 130;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Americano x1");
                siparis += 130;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sıcak Çikolata"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Sıcak Çikolata x" + adet;

                    siparis += 110;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Sıcak Çikolata x1");
                siparis += 110;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Filtre Kahve"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Filtre Kahve x" + adet;

                    siparis += 140;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Filtre Kahve x1");
                siparis += 140;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Türk Kahvesi"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Türk Kahvesi x" + adet;

                    siparis += 120;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Türk Kahvesi x1");
                siparis += 120;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çay"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Çay x" + adet;

                    siparis += 20;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Çay x1");
                siparis += 20;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sahlep"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Sahlep x" + adet;

                    siparis += 100;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Sahlep x1");
                siparis += 100;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Cappuccino"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 125;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Cappuccino x" + adet;

                    siparis -= 125;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Mocha"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 145;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Mocha x" + adet;

                    siparis -= 145;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Americano"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 130;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Americano x" + adet;

                    siparis -= 130;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sıcak Çikolata"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 110;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Sıcak Çikolata x" + adet;

                    siparis -= 110;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Filtre Kahve"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 140;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Filtre Kahve x" + adet;

                    siparis -= 140;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Türk Kahvesi"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 120;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Türk Kahvesi x" + adet;

                    siparis -= 120;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çay"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 20;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Çay x" + adet;

                    siparis -= 20;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sahlep"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 100;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Sahlep x" + adet;

                    siparis -= 100;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Latte"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Iced Latte x" + adet;

                    siparis += 135;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Iced Latte x1");
                siparis += 135;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button52_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Latte"))
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

                    listBox1.Items[i] = "Iced Latte x" + adet;

                    siparis -= 135;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Cappuccino"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Iced Cappuccino x" + adet;

                    siparis += 125;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Iced Cappuccino x1");
                siparis += 125;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button50_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Cappuccino"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 125;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Iced Cappuccino x" + adet;

                    siparis -= 125;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Mocha"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Iced Mocha x" + adet;

                    siparis += 145;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Iced Mocha x1");
                siparis += 145;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Mocha"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 145;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Iced Mocha x" + adet;

                    siparis -= 145;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button47_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Americano"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Iced Americano x" + adet;

                    siparis += 130;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Iced Americano x1");
                siparis += 130;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Iced Americano"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 130;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Iced Americano x" + adet;

                    siparis -= 130;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Cool Lime Mango"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Cool Lime Mango x" + adet;

                    siparis += 115;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Cool Lime Mango x1");
                siparis += 115;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Cool Lime Mango"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 115;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Cool Lime Mango x" + adet;

                    siparis -= 115;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Buzlu Filtre Kahve"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Buzlu Filtre Kahve x" + adet;

                    siparis += 140;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Buzlu Filtre Kahve x1");
                siparis += 140;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Buzlu Filtre Kahve"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 140;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Buzlu Filtre Kahve x" + adet;

                    siparis -= 140;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Limonata"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Limonata x" + adet;

                    siparis += 80;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Limonata x1");
                siparis += 80;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Limonata"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 80;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Limonata x" + adet;

                    siparis -= 80;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button76_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Limonlu Cheesecake"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Limonlu Cheesecake x" + adet;

                    siparis += 160;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Limonlu Cheesecake x1");
                siparis += 160;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button75_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Limonlu Cheesecake"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 160;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Limonlu Cheesecake x" + adet;

                    siparis -= 160;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button74_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Mozaik Pasta"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Mozaik Pasta x" + adet;

                    siparis += 150;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Mozaik Pasta x1");
                siparis += 150;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button73_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Mozaik Pasta"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 150;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Mozaik Pasta x" + adet;

                    siparis -= 150;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button72_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sufle"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Sufle x" + adet;

                    siparis += 170;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Sufle x1");
                siparis += 170;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button71_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Sufle"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 170;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Sufle x" + adet;

                    siparis -= 170;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button70_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Tiramisu"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Tiramisu x" + adet;

                    siparis += 165;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Tiramisu x1");
                siparis += 165;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button69_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Tiramisu"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 165;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Tiramisu x" + adet;

                    siparis -= 165;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button68_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çikolatalı Puding"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Çikolatalı Puding x" + adet;

                    siparis += 140;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Çikolatalı Puding x1");
                siparis += 140;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button67_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çikolatalı Puding"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 140;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Çikolatalı Puding x" + adet;

                    siparis -= 140;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button66_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Muffin"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Muffin x" + adet;

                    siparis += 55;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Muffin x1");
                siparis += 55;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button65_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Muffin"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 55;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Muffin x" + adet;

                    siparis -= 55;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button64_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Islak Kek"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Islak Kek x" + adet;

                    siparis += 85;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Islak Kek x1");
                siparis += 85;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button63_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Islak Kek"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 85;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Islak Kek x" + adet;

                    siparis -= 85;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }

        private void button62_Click(object sender, EventArgs e)
        {
            bool bulundu = false;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çikolatalı Kurabiye"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    adet++;

                    listBox1.Items[i] = "Çikolatalı Kurabiye x" + adet;

                    siparis += 35;

                    bulundu = true;

                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }

            if (!bulundu)
            {
                listBox1.Items.Add("Çikolatalı Kurabiye x1");
                siparis += 35;
                siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString()!;

                if (item.StartsWith("Çikolatalı Kurabiye"))
                {
                    string[] parca = item.Split('x');

                    int adet = Convert.ToInt32(parca[1]);

                    if (adet == 1)
                    {
                        adet--;
                        siparis -= 35;
                        siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                        listBox1.Items.RemoveAt(i);
                        break;
                    }

                    adet--;

                    listBox1.Items[i] = "Çikolatalı Kurabiye x" + adet;

                    siparis -= 35;
                    siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
                    break;
                }
            }
        }
    }
}
