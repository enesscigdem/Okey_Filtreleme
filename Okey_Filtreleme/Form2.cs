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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int Bahis; // Oyuncunun seçmiş olduğu bahis ve filtreler önceki ekrandan bu ekrana veri aktarımı gerçekleştirilir.
        public string secenek;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = "\r\n\r\n Masa Özellikleri" + "\r\n\r\n" + "Bahis Tutarı : "+ Bahis.ToString() + "$" + "\r\n\r\n" + "Filtre : " + secenek; // Bahis ve filtreler burada yazdırılır.
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
