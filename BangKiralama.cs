using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BangKiralama
{
    public partial class BangKiralama : Form
    {
        public BangKiralama()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            MusteriEkle mekle = new MusteriEkle();
            mekle.Show();
        }

        private void BangKiralama_Load(object sender, EventArgs e)
        {

        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            MusteriListele mlistele = new MusteriListele();
            mlistele.Show();
        }
    }
}
