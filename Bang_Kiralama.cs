using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangKiralama
{
    class Bang_Kiralama
    {                                                           //HOCAYA SOR! BURADA BİR ŞEY DEĞİŞTİRDİM YANLIŞLIKLA HATA VERDİ...!
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-AHL7I8U\\SQLEXPRESS;Initial Catalog=Bang_Kiralama;Integrated Security=True");
        DataTable tablo;
        public void ekle_sil_guncelle(SqlCommand komut, string sorgu)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = sorgu;
            komut.ExecuteNonQuery(); //İşlemi onaylama
            baglanti.Close();
        }
        public DataTable listele(SqlDataAdapter dtap, string sorgu)
        {
            tablo = new DataTable();
            dtap = new SqlDataAdapter(sorgu, baglanti);
            dtap.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
    }
}
