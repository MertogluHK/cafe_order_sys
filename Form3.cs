using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cafe_adisyon
{
    public partial class Siparis : Form
    {
        public Siparis(string masaNo)
        {
            InitializeComponent();

            masa_num.Text = masaNo;
        }

        int hesappp = 0;
        int hesapp = 0;
        int siparis = 0;

        private string DosyaYoluHesaplar()
        {
            string klasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Adisyonlar", "Hesaplar");
            Directory.CreateDirectory(klasor);
            string masaAdi = masa_num.Text.Replace(" ", "");
            return Path.Combine(klasor, $"{masaAdi}.txt");
        }

        private string DosyaYoluSiparisler()
        {
            string klasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Adisyonlar", "Siparisler");
            Directory.CreateDirectory(klasor);
            string masaAdi = masa_num.Text.Replace(" ", "");
            return Path.Combine(klasor, $"{masaAdi}.txt");
        }

        private void TxtGuncelle()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"=== {masa_num.Text} ===");
            sb.AppendLine($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("--- Hesap ---");

            foreach (var item in listBox2.Items)
                sb.AppendLine(item.ToString());

            sb.AppendLine($"TOPLAM: {hesapp}");
            sb.AppendLine("[AÇIK ADİSYON]");

            File.WriteAllText(DosyaYoluHesaplar(), sb.ToString(), Encoding.UTF8);
        }

        private void TxtKapatHesaplar()
        {
            string hesaplarDosya = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Adisyonlar", "Hesaplar", "Hesaplar.txt");

            string dosya = DosyaYoluHesaplar();
            string[] satirlar = File.ReadAllLines(dosya, Encoding.UTF8);
            foreach (string satir in satirlar)
            {
                if (satir.StartsWith("TOPLAM:"))
                {
                    string[] parca = satir.Split(' ');
                    hesappp = Convert.ToInt32(parca[1]);
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine($"=== {masa_num.Text} ===");
            sb.AppendLine($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("--- Hesap ---");

            foreach (var item in listBox2.Items)
                sb.AppendLine(item.ToString());

            sb.AppendLine($"TOPLAM: {hesappp}");
            sb.AppendLine("✔ ÖDEME ALINDI");
            sb.AppendLine(new string('-', 30));

            File.AppendAllText(hesaplarDosya, "\n" + sb.ToString(), Encoding.UTF8);

            // 2. Aktif masanın TXT dosyasını temizle
            File.WriteAllText(DosyaYoluHesaplar(), string.Empty, Encoding.UTF8);
        }
        private void TxtKapatSiparisler()
        {
            string hesaplarDosya = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Adisyonlar", "Hesaplar.txt");

            string dosya = DosyaYoluHesaplar();
            string[] satirlar = File.ReadAllLines(dosya, Encoding.UTF8);
            foreach (string satir in satirlar)
            {
                if (satir.StartsWith("TOPLAM:"))
                {
                    string[] parca = satir.Split(' ');
                    hesappp = Convert.ToInt32(parca[1]);
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine($"=== {masa_num.Text} ===");
            sb.AppendLine($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}");
            sb.AppendLine("--- Hesap ---");

            foreach (var item in listBox2.Items)
                sb.AppendLine(item.ToString());

            sb.AppendLine($"TOPLAM: {hesappp}");
            sb.AppendLine("✔ ÖDEME ALINDI");
            sb.AppendLine(new string('-', 30));

            File.AppendAllText(hesaplarDosya, "\n" + sb.ToString(), Encoding.UTF8);

            // 2. Aktif masanın TXT dosyasını temizle
            File.WriteAllText(DosyaYoluHesaplar(), string.Empty, Encoding.UTF8);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Siparis_Load(object sender, EventArgs e)
        {
            TxtdenYukle();
        }

        private void TxtdenYukle()
        {
            string dosya = DosyaYoluHesaplar();

            if (!File.Exists(dosya)) return; // Dosya yoksa (yeni masa) bir şey yapma

            string[] satirlar = File.ReadAllLines(dosya, Encoding.UTF8);

            listBox2.Items.Clear();

            bool hesapBasladi = false;

            foreach (string satir in satirlar)
            {
                if (satir == "--- Hesap ---")
                {
                    hesapBasladi = true;
                    continue;
                }
                if (satir.StartsWith("TOPLAM:"))
                {
                    string[] parca = satir.Split(' ');

                    hesappp = Convert.ToInt32(parca[1]);
                }
                hesaptxt.Text = ("HESAP: " + Convert.ToString(hesappp));
                if (satir.StartsWith("TOPLAM:") ||
                    satir.StartsWith("[AÇIK") ||
                    satir.StartsWith("✔") ||
                    satir.StartsWith("==="))
                {
                    hesapBasladi = false;
                }

                if (hesapBasladi && !string.IsNullOrWhiteSpace(satir))
                    listBox2.Items.Add(satir);
            }
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
            hesapp = hesappp + siparis;
            siparis = 0;
            siparistxt.Text = ("SİPARİŞ: " + Convert.ToString(siparis));
            hesaptxt.Text = ("HESAP: " + Convert.ToString(hesapp));

            // TXT'ye yaz
            TxtGuncelle();
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

        private void button3_Click(object sender, EventArgs e)
        {
            TxtKapatHesaplar();

            // UI sıfırla
            hesaptxt.Text = "HESAP: ";
            listBox2.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            siparistxt.Text = "SİPARİŞ: ";
        }
    }
}
