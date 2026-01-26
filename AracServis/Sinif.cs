using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AracServis
{
    internal class Sinif
    {
        public SqlConnection baglanti()
        {
            // Metodumuza bağlantıyı yazarak form dosyalarımızda bağlantı kodunu tekrardan yazmayı engellemiş oluyoruz.
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-QH0DUMM;Initial Catalog=AracServisOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
