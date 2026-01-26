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
    public partial class MusteriEkle : Form
    {
        // SQL Adresini Sinif.cs adındaki sınıf ile metod yardımıyla çağırarak komutlarda kullanıldı.
        Sinif bgl = new Sinif();
        public MusteriEkle()
        {
            InitializeComponent();
        }

        private void BtnKa_Click(object sender, EventArgs e)
        {
            // ADO.NET bağlantısı kullanılarak , müşteri tablosuna textbox'dan bilgi alınmasıyla kayıt eklenmesi sağlandı.
            string buyukyazi = aracplaka.Text;
            SqlCommand ekle = new SqlCommand("insert into Tbl_Musteriler (Musteri_Ad,Musteri_Soyad,Musteri_Tel,Musteri_Plaka) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
            ekle.Parameters.AddWithValue("@p1",TxtMusteriAdi.Text);
            ekle.Parameters.AddWithValue("@p2", TxtMusteriSoyad.Text);
            ekle.Parameters.AddWithValue("@p3", MusteriTel.Text);
            ekle.Parameters.AddWithValue("@p4", buyukyazi.ToUpper());
            ekle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Eklendi.", "Müşteri Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MusteriEkle_Load(object sender, EventArgs e)
        {
            // Sutünların genişliklerini ayarlamak için kullanıldı.
            this.tbl_Musteriler1TableAdapter.Fill(this.dataSet2.Tbl_Musteriler1);
            this.tbl_MusterilerTableAdapter.Fill(this.dataSet2.Tbl_Musteriler);

        }

        private void BtnLi_Click(object sender, EventArgs e)
        {
            // Dataset bağlantısı kullanılarak , müşteri tablosunu yenilemek İçin kullanıldı.
            DataSet2TableAdapters.Tbl_Musteriler1TableAdapter ds = new DataSet2TableAdapters.Tbl_Musteriler1TableAdapter();
            dataGridView1.DataSource = ds.GetData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tabloya çift tıklandığında bilgileri textbox'lara yazılması için kullanıldı.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtMusteriAdi.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtMusteriSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            MusteriTel.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            aracplaka.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
