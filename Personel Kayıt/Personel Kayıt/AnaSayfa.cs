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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=DESKTOP-ATVNEGK;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");

        void temizle()
        {
            txtid.Clear();
            txtad.Clear();
            txtmeslek.Clear();
            txtsoyad.Clear();
            cmbsehir.Text = "";
            mskmaaş.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           // this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabanıDataSet.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(Perad,PerSoyad,PerSehir,PerMaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", bağlantı);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaaş.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);

            komut.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Personel Eklendi","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabanıDataSet.Tbl_Personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilen = dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[seçilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[seçilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[seçilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[seçilen].Cells[3].Value.ToString();
            mskmaaş.Text = dataGridView1.Rows[seçilen].Cells[4].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[seçilen].Cells[6].Value.ToString();
            label8.Text = dataGridView1.Rows[seçilen].Cells[5].Value.ToString();

         }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true ;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where Perid=@k1",bağlantı);
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Kayıt Silindi","Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            bağlantı.Open();
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Personel Set Perad=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a7 ", bağlantı);
            komutgüncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", mskmaaş.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", txtid.Text);
            komutgüncelle.ExecuteNonQuery();
            bağlantı.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            İstatistik fr = new İstatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            Grafikler fr = new Grafikler();
            fr.Show();
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
