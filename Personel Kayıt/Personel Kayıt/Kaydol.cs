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
    public partial class Kaydol : Form
    {
        public Kaydol()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-ATVNEGK;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");
        
        private void BtnKaydol_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand kk = new SqlCommand("insert into Tbl_Yonetici(KullaniciAd,Sifre) values (@p1,@p2)", bağlantı);
            kk.Parameters.AddWithValue("@p1", textBox1.Text);
            kk.Parameters.AddWithValue("@p2", textBox2.Text);
            kk.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Kayıt işlemi tamam", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Giriş gg = new Giriş();
            gg.Show();
            this.Hide();
        }

        

        private void BtnÇıkış_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
