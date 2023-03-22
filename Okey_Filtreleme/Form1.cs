using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okey_Filtreleme
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        bool hizli, teke_tek, rovans;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label13.Text = (trackBar1.Value * 100).ToString() + " $"; //TrackBar değeri label13'e yazdırılır.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Maximum = 50; //Trackbar minimum ve maksimum değerleri tanımlanmıştır, 100-100 artması ayarlanacağı için minimum 2 maximum 50 olarak tanımlanmış, yazdırılırken 100 
            trackBar1.Minimum = 2;  //ile çarpılmıştır

        }
        int btn_bahis_evet;
        private void button1_Click(object sender, EventArgs e)
        {
            btn_bahis_hayır = 0;
            hizli = true;
            button1.BackColor = Color.CornflowerBlue;   // butona bir kere basıldığı zaman rengi değişmektedir. Ardından tekrar basılması durumunda eski haline dönmektedir.
            button2.BackColor = Color.Transparent;
            if (btn_bahis_evet > 0)
            {
                button1.BackColor = Color.Transparent;
                hizli = false;
                btn_bahis_evet = 0;
            }
            else
                btn_bahis_evet++;
        }
        int btn_bahis_hayır;
        private void button2_Click(object sender, EventArgs e)
        {
            btn_bahis_evet = 0;
            hizli = false;
            button2.BackColor = Color.CornflowerBlue;
            button1.BackColor = Color.Transparent;
            if (btn_bahis_hayır > 0)
            {
                button2.BackColor = Color.Transparent;
                hizli = false;
                btn_bahis_hayır = 0;
            }
            else
                btn_bahis_hayır++;
        }
        int btn_teketek_evet;
        private void button4_Click(object sender, EventArgs e)
        {
            btn_teketek_hayır = 0;
            teke_tek = true;
            button4.BackColor = Color.CornflowerBlue;
            button3.BackColor = Color.Transparent;
            if (btn_teketek_evet > 0)
            {
                button4.BackColor = Color.Transparent;
                teke_tek = false;
                btn_teketek_evet = 0;
            }
            else
                btn_teketek_evet++;
        }
        int btn_teketek_hayır;
        private void button3_Click(object sender, EventArgs e)
        {
            btn_teketek_evet = 0;
            teke_tek = false;
            button3.BackColor = Color.CornflowerBlue;
            button4.BackColor = Color.Transparent;
            if (btn_teketek_hayır > 0)
            {
                button3.BackColor = Color.Transparent;
                teke_tek = false;
                btn_teketek_hayır = 0;
            }
            else
            {
                btn_teketek_hayır++;
            }
        }
        string secenek;
        private void button7_Click(object sender, EventArgs e)
        {
            //Aşağıdaki cümleye dayanarak, oyuncu sadece "Evet" seçeneğini işaretlediği takdirde masa bulunacaktır. Ayrıca aşağıdaki cümleye dayanarak programa yavaş, çiftli ve rövanşsız masa seçenekleri eklenmemiştir.
            //**** Oyuncu bu filtrede Evet olarak işaretlemediği masa tipteki masaları görüntülememelidir. ****


            //** MANUEL MASA VERİLERİ EKLEME **
            //Seçilen tüm bahis tutarına uyumluluk sağlayabilmek için BahisMin=200 BahisMax=5000 değerleri kullanılmıştır. Böylelikle oyuncu hangi bahis tutarını seçer ise kendi seçtiği bahis tutarında ilgili filtrelerdeki bahis tutarını bulabilecektir.
            var masaListesi = new List<Masa>()
            {
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = false, TekeTek = false, Rovans = true },      /*001 --> Rövanşlı Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = false, TekeTek = true, Rovans = false },      /*010 --> TekeTek Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = false, TekeTek = true, Rovans = true },       /*011 --> TekeTek + Rövanşlı Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = true, TekeTek = false, Rovans = false },      /*100 --> Hızlı Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = true, TekeTek = false, Rovans = true },       /*101 --> Hızlı + Rövanşlı Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = true, TekeTek = true, Rovans = false },       /*110 --> Hızlı + TekeTek Masa*/
            new Masa { BahisMin = 200, BahisMax=5000, Hizli = true, TekeTek = true, Rovans = true }         /*111 --> Hızlı + TekeTek + Rövanşlı Masa*/
            };
            int bahisAraligi = Convert.ToInt32(trackBar1.Value * 100);
            var filtrelenmisMasalar = Filtreleme.FiltreleMasa(masaListesi, bahisAraligi, hizli, teke_tek, rovans);
            secenek = "";
            if (hizli)
                secenek += "Hızlı ";
            if (teke_tek)
                secenek += "- TekeTek ";
            if (rovans)
                secenek += "- Rövanşlı";
            if (filtrelenmisMasalar.Count == 0)
            {
                //Masa bulunamadıysa uyarı mesajı verdirilir.
                MessageBox.Show("Filtrelenmiş özelliklere sahip bir masa bulunamadı.", "Masa Bulunamadı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (var masa in filtrelenmisMasalar)
            {
                //Burada ek olarak timer kullanılmıştır. Masa bulunduğu durumda bir uyarı ekrana gelmektedir. Kullanıcı tamam butonuna basmadığı takdirde 5 saniye sonra otomatik olarak bir sonraki sayfaya yönlendirilmektedir.
                timer1.Start();
                DialogResult result = MessageBox.Show($"5 saniye içinde masaya yönlendiriliyorsunuz. Hemen gitmek için Tamam'a basınız.", "Masa Bulundu.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Eğer kullanıcı "OK" düğmesine tıklarsa, Diğer sayfa otomatik olarak açılmaktadır.
                if (result == DialogResult.OK)
                {
                    timer1.Stop();
                    Form2 frm = new Form2();
                    frm.Bahis = trackBar1.Value * 100; // oyuncunun seçmiş olduğu bahis tutarı bir sonraki ekranda yazdırılır.
                    frm.secenek = secenek; // oyuncunun seçmiş olduğu filtreler bir sonraki ekranda yazdırılır.
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }
        int btn_rovans_evet;
        private void button6_Click(object sender, EventArgs e)
        {
            btn_rovans_hayır = 0;
            rovans = true;
            button6.BackColor = Color.CornflowerBlue;
            button5.BackColor = Color.Transparent;
            if (btn_rovans_evet > 0)
            {
                button6.BackColor = Color.Transparent;
                rovans = false;
                btn_rovans_evet = 0;
            }
            else
                btn_rovans_evet++;
        }
        int süre = 5;
        private void timer1_Tick(object sender, EventArgs e)
        {
            süre--;

            if (süre == 0)
            {
                timer1.Stop();
                Form2 frm = new Form2();
                frm.Bahis = trackBar1.Value * 100; 
                frm.secenek = secenek; 
                this.Hide();
                frm.ShowDialog();
            }
        }
        int btn_rovans_hayır;
        private void button5_Click(object sender, EventArgs e)
        {
            btn_rovans_evet = 0;
            rovans = false;
            button5.BackColor = Color.CornflowerBlue;
            button6.BackColor = Color.Transparent;
            if (btn_rovans_hayır > 0)
            {
                button5.BackColor = Color.Transparent;
                rovans = false;
                btn_rovans_hayır = 0;
            }
            else
                btn_rovans_hayır++;
        }
    }
}
