using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BangKiralama
{
    public partial class MusteriListele : Form
    {
        Bang_Kiralama kiralama = new Bang_Kiralama();

        public MusteriListele()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MusteriListele_Load(object sender, EventArgs e)
        {
            ListeleYenile();
        }

        private void ListeleYenile()
        {
            string cumle = "select * from musteri";
            SqlDataAdapter dtap2 = new SqlDataAdapter();
            dataGridView1.Columns[0].HeaderText = "T.C.";
            dataGridView1.Columns[1].HeaderText = "Ad Soyad";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Adres";
            dataGridView1.Columns[4].HeaderText = "Email";
            dataGridView1.DataSource = kiralama.listele(dtap2, cumle);
        }

        private void txtTCAra_TextChanged(object sender, EventArgs e)
        {
            string cumle = "select * from musteri where tc like '%"+txtTCAra.Text+"%'";
            SqlDataAdapter dtap2 = new SqlDataAdapter();
            dataGridView1.DataSource = kiralama.listele(dtap2, cumle);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtTC.Text = satir.Cells[0].Value.ToString();
            txtAdSoyad.Text = satir.Cells[1].Value.ToString();  //DataGridView ın satırlarının isimleri
            txtTelefon.Text = satir.Cells[2].Value.ToString();
            txtAdres.Text = satir.Cells[3].Value.ToString();
            txtEmail.Text = satir.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string cumle = "update musterş set adsoyad=@adsoyad, telefon=@telefon, adres=@adres, email=@email where tc=@tc";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTC.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut2.Parameters.AddWithValue("@email", txtEmail.Text);
            kiralama.ekle_sil_guncelle(komut2, cumle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = ""; //TextBox ları temizlemek için.
            ListeleYenile();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            string cumle = "delete from musteri where tc='"+satir.Cells["tc"].Value.ToString()+"'";
            SqlCommand komut2 = new SqlCommand();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            ListeleYenile();
        }
    }
}
