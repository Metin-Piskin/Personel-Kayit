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
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-ATVNEGK;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");

        private void İstatistik_Load(object sender, EventArgs e)
        {
            //Toplam Personel Sayısı
            bağlantı.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", bağlantı);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            bağlantı.Close();

            //Evli Personel Sayısı
            bağlantı.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", bağlantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }
            bağlantı.Close();

            //Bekar Personel Sayısı
            bağlantı.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", bağlantı);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            bağlantı.Close();

            //Kaç Farklı Şehir Sayısı
            bağlantı.Open();
            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel", bağlantı);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayısı.Text = dr4[0].ToString();
            }
            bağlantı.Close();

            //Toplam Maaş
            bağlantı.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas)From Tbl_Personel", bağlantı);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaaş.Text = dr5[0].ToString();
            }
            bağlantı.Close();

            //Ortalama Maaş
            bağlantı.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas)From Tbl_Personel", bağlantı);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamaMaaş.Text = dr6[0].ToString();
            }
            bağlantı.Close();
        }
    }
}

