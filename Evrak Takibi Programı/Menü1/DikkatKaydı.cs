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
using static Evrak_Takibi_Programı.YeniTuzel;

namespace Evrak_Takibi_Programı
{
    public partial class DikkatKaydı : Form
    {
        public DikkatKaydı()
        {
            InitializeComponent();
        }

        private void DikkatKayitlariYukle()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT Id, MusteriNo, MusteriAdi,Referans,KayitTarih,IslemTarih,IslemAmac FROM dbo.DikkatKaydi WHERE Durum = 0";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dataGrid_takip.DataSource = dataTable;
                }
                query = $"SELECT Id, MusteriNo, MusteriAdi,Referans,KayitTarih,IslemTarih,IslemAmac FROM dbo.DikkatKaydi WHERE Durum = 1";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    dataGrid_tamam.DataSource = dataTable;
                }
                connection.Close();
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int musteriNo, referans;
            string musteriAd, islemAmac;
            DateTime recdate, opdate;
            try
            {
                musteriNo = Convert.ToInt32(text_custno.Text);
                musteriAd = text_custname.Text;
                referans = Convert.ToInt32(text_custref.Text);
                recdate = Convert.ToDateTime(text_recdate.Text); /*DateTime.Now;*/
                opdate = Convert.ToDateTime(text_opdate.Text);
                islemAmac = text_reason.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gerekli bilgilerde en az bir eksik var. İşleme devam edilemiyor.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"INSERT INTO dbo.DikkatKaydi(MusteriNo,MusteriAdi,Referans,KayitTarih,IslemTarih,IslemAmac,Durum) VALUES (@MusteriNo,@MusteriAdi,@Referans,@KayitTarih,@IslemTarih,@IslemAmac,0)";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriNo", musteriNo);
                    command.Parameters.AddWithValue("@MusteriAdi", musteriAd);
                    command.Parameters.AddWithValue("@Referans", referans);
                    command.Parameters.AddWithValue("@KayitTarih", recdate);
                    command.Parameters.AddWithValue("@IslemTarih", opdate);
                    command.Parameters.AddWithValue("@IslemAmac", islemAmac);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {

                        MessageBox.Show($"Dikkat kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Dikkat kaydı gerçekleştirilemedi", "Kayıt Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dataGrid_takip_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dataGrid_takip.Rows[e.RowIndex];
            //text_custno.Text = row.Cells[0].Value.ToString();
            //text_custname.Text = row.Cells[1].Value.ToString();
            //text_custref.Text = row.Cells[2].Value.ToString();
            //text_recdate.Text = row.Cells[3].Value.ToString();
            //text_opdate.Text = row.Cells[4].Value.ToString();
            //text_reason.Text = row.Cells[5].Value.ToString();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int musteriNo, referans;
            string musteriAd, islemAmac;
            DateTime recdate, opdate;
            try
            {
                musteriNo = Convert.ToInt32(text_custno.Text);
                musteriAd = text_custname.Text;
                referans = Convert.ToInt32(text_custref.Text);
                recdate = Convert.ToDateTime(text_recdate.Text); /*DateTime.Now;*/
                opdate = Convert.ToDateTime(text_opdate.Text);
                islemAmac = text_reason.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gerekli bilgilerde en az bir eksik var. İşleme devam edilemiyor.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE dbo.DikkatKaydi SET KayitTarihi = @KayitTarihi, İslemTarihi = @IslemTarihi, IslemAmac = @IslemAmac WHERE MusteriNo = @MusteriNo AND MusteriAdi = @MusteriAdi";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriNo", musteriNo);
                    command.Parameters.AddWithValue("@MusteriAdi", musteriAd);
                    command.Parameters.AddWithValue("@KayitTarih", recdate);
                    command.Parameters.AddWithValue("@IslemTarih", opdate);
                    command.Parameters.AddWithValue("@IslemAmac", islemAmac);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {

                        MessageBox.Show($"Dikkat kaydı güncellemesi başarıyla gerçekleştirildi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Dikkat kaydı güncellenemedi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dataGrid_takip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid_takip.Rows[e.RowIndex];
            text_custno.Text = row.Cells[0].Value.ToString();
            text_custname.Text = row.Cells[1].Value.ToString();
            text_custref.Text = row.Cells[2].Value.ToString();
            text_recdate.Text = row.Cells[3].Value.ToString();
            text_opdate.Text = row.Cells[4].Value.ToString();
            text_reason.Text = row.Cells[5].Value.ToString();
        }

        private void text_custno_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            int musteriNo = Convert.ToInt32(text_custno.Text);
            string musteriAdi = "";
            int referans = 0;
            DateTime kayitTarihi = new DateTime();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                query = "SELECT ad_soyad, referans, kayit_tarih FROM dbo.TuzelKisi WHERE musteri_kodu = @MusteriKodu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", musteriNo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                musteriAdi = reader["ad_soyad"].ToString();
                                referans = reader.GetInt32(reader.GetOrdinal("referans"));
                                kayitTarihi = reader.GetDateTime(reader.GetOrdinal("kayit_tarih"));
                                text_custname.Text = musteriAdi;
                                text_custref.Text = referans.ToString();
                                text_recdate.Text = kayitTarihi.ToString("dd.MM.yyyy");
                            }
                            return;
                        }
                        
                    }
                }
                query = "SELECT ad_soyad, referans, kayit_tarih FROM dbo.GercekKisi WHERE musteri_kodu = @MusteriKodu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", musteriNo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                musteriAdi = reader["ad_soyad"].ToString();
                                referans = reader.GetInt32(reader.GetOrdinal("referans"));
                                kayitTarihi = reader.GetDateTime(reader.GetOrdinal("kayit_tarih"));
                                text_custname.Text = musteriAdi;
                                text_custref.Text = referans.ToString();
                                text_recdate.Text = kayitTarihi.ToString("dd.MM.yyyy");
                            }
                            return;
                        }
                        
                    }
                }
                query = "SELECT ad_soyad, referans, kayit_tarih FROM dbo.Sahis WHERE musteri_kodu = @MusteriKodu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", musteriNo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                musteriAdi = reader["ad_soyad"].ToString();
                                referans = reader.GetInt32(reader.GetOrdinal("referans"));
                                kayitTarihi = reader.GetDateTime(reader.GetOrdinal("kayit_tarih"));
                                text_custname.Text = musteriAdi;
                                text_custref.Text = referans.ToString();
                                text_recdate.Text = kayitTarihi.ToString("dd.MM.yyyy");
                            }
                            return;
                        }

                    }
                }
                query = "SELECT ad_soyad, referans, kayit_tarih FROM dbo.AdiOrtaklik WHERE musteri_kodu = @MusteriKodu";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", musteriNo);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                musteriAdi = reader["ad_soyad"].ToString();
                                referans = reader.GetInt32(reader.GetOrdinal("referans"));
                                kayitTarihi = reader.GetDateTime(reader.GetOrdinal("kayit_tarih"));
                                text_custname.Text = musteriAdi;
                                text_custref.Text = referans.ToString();
                                text_recdate.Text = kayitTarihi.ToString("dd.MM.yyyy");
                            }
                            return;
                        }

                    }
                }
                connection.Close();
            }
        }
    }
}

