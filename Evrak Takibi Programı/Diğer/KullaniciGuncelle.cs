using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class KullaniciGuncelle : Form
    {
        string kullaniciAd = "";
        string eposta = "";
        string telefon = "";
        string kurulus = "";
        string anahtar = "";
        DateTime sonTarih = new DateTime();
        public KullaniciGuncelle()
        {
            InitializeComponent();
        }

        public void OnKeyFound()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "INSERT INTO dbo.LisansDurum(kullanici_ad, eposta, telefon, kurulus, lisans_anahtari, son_kullanim_tarihi) VALUES (@AdSoyad,@Eposta,@Telefon,@Kurulus,@LisansAnahtari,@SonKullanimTarihi)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdSoyad", kullaniciAd);
                    command.Parameters.AddWithValue("@Eposta", eposta);
                    command.Parameters.AddWithValue("@Telefon", telefon);
                    command.Parameters.AddWithValue("@Kurulus", kurulus);
                    command.Parameters.AddWithValue("@LisansAnahtari", anahtar);
                    command.Parameters.AddWithValue("@SonKullanimTarihi", sonTarih);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Abonelik güncellemesi başarıyla gerçekleştirildi!\nLisans anahtarınız {sonTarih.ToString("dd.MM.yyyy")} gününe kadar geçerli.", "Lisans Güncellemesi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void KullaniciGuncelle_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "kullanici_adi", "email", "telefon", "kurulus", "anahtar", "son_kullanim" };
                List<string> columnHeaders = new List<string> { "Ad Soyad", "Eposta", "Telefon", "Kuruluş", "Lisans Anahtarı", "Son Kullanım Tarihi" };
                List<Type> columnTypes = new List<Type> { typeof(string), typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTime) };
                for (int i = 0; i < 6; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGrid_customer.Columns.Add(column);
                }
                query = "SELECT * FROM dbo.LisansDurum";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow data_row = new DataGridViewRow();
                            data_row.CreateCells(dataGrid_customer);
                            for (int i = 0; i < columnNames.Count; i++)
                            {
                                data_row.Cells[i].Value = reader.GetValue(i + 1);
                            }
                            dataGrid_customer.Rows.Add(data_row);
                        }
                    }
                    connection.Close();
                }
            }
        }

        private void dataGrid_customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid_customer.Rows[e.RowIndex];
            kullaniciAd = row.Cells[0].Value.ToString();
            eposta = row.Cells[1].Value.ToString();
            telefon = row.Cells[2].Value.ToString().Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            kurulus = row.Cells[3].Value.ToString();
            sonTarih = Convert.ToDateTime(row.Cells[5].Value);
            text_musteri.Text = kullaniciAd;
            if(DateTime.Now < sonTarih)
            {
                MessageBox.Show("Lisansınız hala geçerli.","Lisans Geçerli",MessageBoxButtons.OK, MessageBoxIcon.Information);
                button_sec.Enabled = false;
            }
            else if(DateTime.Now == sonTarih)
            {
                MessageBox.Show("Bugün lisansınızın son günü. Lütfen lisansınızı güncelleyin.", "Lisansınızı Güncelleyin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button_sec.Enabled = true;
            }
            else
            {
                button_sec.Enabled = true;
            }
        }

        private void button_sec_Click(object sender, EventArgs e)
        {
            string newKey = new LisansAnahtarı(kullaniciAd, eposta, telefon, kurulus).AnahtarOlustur();
            anahtar = newKey;
            LisansAnahtari lisansAnahtarFormu = new LisansAnahtari(false,newKey);
            lisansAnahtarFormu.Show();
        }
    }
}
