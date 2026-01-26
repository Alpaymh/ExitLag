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
    public partial class PersonelSil : Form
    {
        // SQL Adresini Sinif.cs adındaki sınıf ile metod yardımıyla çağırarak komutlarda kullanıldı.
        Sinif bgl = new Sinif();
        public PersonelSil()
        {
            InitializeComponent();
        }

        private void BtnKa_Click(object sender, EventArgs e)
        {
            // Dataset bağlantısı kullanılarak , personel tablosunu yenilemek İçin kullanıldı.
            DataSet2TableAdapters.Tbl_PersonelTableAdapter ds = new DataSet2TableAdapters.Tbl_PersonelTableAdapter();
            dataGridView1.DataSource = ds.PersonelListele();
        }

        private void PersonelSil_Load(object sender, EventArgs e)
        {
            // Sutünların genişliklerini ayarlamak için kullanıldı.
            this.tbl_PersonelTableAdapter.Fill(this.dataSet2.Tbl_Personel);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ADO.NET bağlantısı kullanılarak , personel tablosuna textbox'dan bilgi alınmasıyla kayıt silinmesi sağlandı.
            SqlCommand sil = new SqlCommand("Delete from Tbl_Personel where PersonelKullaniciAdi =@p1",bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            sil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi.", "Personel Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tabloya çift tıklandığında bilgileri textbox'lara yazılması için kullanıldı.
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtKullaniciAdi.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
