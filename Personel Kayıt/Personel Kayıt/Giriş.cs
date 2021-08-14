using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayıt
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-ATVNEGK;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");

        private void BtnGirişYap_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2", bağlantı);
            komut.Parameters.AddWithValue("@p1", TxtKullanıcıAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtŞifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AnaSayfa frm = new AnaSayfa();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            bağlantı.Close();
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void BtnKaydol_Click(object sender, EventArgs e)
        {
            Kaydol k = new Kaydol();
            k.Show();
            this.Hide();
        }
    }
}
