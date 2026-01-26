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
    public partial class MusteriSil : Form
    {
        // SQL Adresini Sinif.cs adındaki sınıf ile metod yardımıyla çağırarak komutlarda kullanıldı.
        Sinif bgl = new Sinif();
        public MusteriSil()
        {
            InitializeComponent();
        }

        private void MusteriSil_Load(object sender, EventArgs e)
        {
            // Sutünların genişliklerini ayarlamak için kullanıldı.
            this.tbl_MusterilerTableAdapter.Fill(this.dataSet2.Tbl_Musteriler);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tabloya çift tıklandığında bilgileri textbox'lara yazılması için kullanıldı.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();


        }

        private void BtnKa_Click(object sender, EventArgs e)
        {
            // Dataset bağlantısı kullanılarak , müşteri tablosunu yenilemek İçin kullanıldı.
            DataSet2TableAdapters.Tbl_MusterilerTableAdapter ds = new DataSet2TableAdapters.Tbl_MusterilerTableAdapter();
            dataGridView1.DataSource = ds.MusteriGetir();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ADO.NET bağlantısı kullanılarak , müşteri tablosuna textbox'dan bilgi alınmasıyla kayıt silinmesi sağlandı.
            SqlCommand komut = new SqlCommand("Delete from Tbl_Musteriler Where MusteriID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Silindi.", "Müşteri Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
