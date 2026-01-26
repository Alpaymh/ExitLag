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
namespace AracServis
{
    public partial class YedekParcaGuncelle : Form
    {
        // SQL Adresini Sinif.cs adındaki sınıf ile metod yardımıyla çağırarak komutlarda kullanıldı.
        Sinif bgl = new Sinif();
        public YedekParcaGuncelle()
        {
            InitializeComponent();
        }

        private void YedekParcaGuncelle_Load(object sender, EventArgs e)
        {
            // Sutünların genişliklerini ayarlamak için kullanıldı.
            this.dataTable5TableAdapter.Fill(this.dataSet2.DataTable5);

        }

        private void BtnLi_Click(object sender, EventArgs e)
        {
            // Dataset bağlantısı kullanılarak , yedek parça tablosunu yenilemek İçin kullanıldı.
            DataSet2TableAdapters.DataTable5TableAdapter ds = new DataSet2TableAdapters.DataTable5TableAdapter();
            dataGridView1.DataSource = ds.yedekparca();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tabloya çift tıklandığında bilgileri textbox'lara yazılması için kullanıldı.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            parcakodu.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            kategoriadi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kategoriid.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            parcaid.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            parcaadi.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            parcamarka.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            parcafiyatı.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void BtnKa_Click(object sender, EventArgs e)
        {
            // ADO.NET bağlantısı kullanılarak , yedek parça tablosuna textbox'dan bilgi alınmasıyla kayıt güncellenmesi sağlandı.
            SqlCommand guncelle = new SqlCommand("Update Tbl_Kategoriler Set Kategori_Adi =@p1 where KategoriID=@p2 ",bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1",kategoriadi.Text);
            guncelle.Parameters.AddWithValue("@p2", kategoriid.Text);
            guncelle.ExecuteNonQuery();

            SqlCommand guncelle1 = new SqlCommand("Update Tbl_Parcalar Set Parca_Adi =@p2,Parca_Marka=@p3,Parca_Fiyat=@p4 where ParcaID=@p1 ", bgl.baglanti());
            guncelle1.Parameters.AddWithValue("@p1", parcaid.Text);
            guncelle1.Parameters.AddWithValue("@p2", parcaadi.Text);
            guncelle1.Parameters.AddWithValue("@p3", parcamarka.Text);
            guncelle1.Parameters.AddWithValue("@p4", parcafiyatı.Text);
            guncelle1.ExecuteNonQuery();
            MessageBox.Show("Yedek Parça Güncellendi.", "Yedek Parça Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void button1_Click(object sender, EventArgs e)
        {


        

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
