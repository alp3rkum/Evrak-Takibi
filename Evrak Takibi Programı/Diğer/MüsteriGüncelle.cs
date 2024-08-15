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
using static Evrak_Takibi_Programı.YeniAdiOrtak;
using static Evrak_Takibi_Programı.YeniGercek;
using static Evrak_Takibi_Programı.YeniSahis;
using static Evrak_Takibi_Programı.YeniTuzel;
using static Evrak_Takibi_Programı.YeniYetkili;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class MüsteriGüncelle : Form
    {
        private int musteriTipi;
        private string musteriAd;
        private int musteriKod;

        private YeniTuzel? yeniTuzelForm;
        private YeniGercek? yeniGercekForm;
        private YeniSahis? yeniSahisForm;
        private YeniAdiOrtak? yeniAdiOrtakForm;
        private YeniYetkili? yeniYetkiliForm;
        private YeniCerceveYetkili? yeniCerceveYetkiliForm;

        public MüsteriGüncelle(int musteriTip = 0)
        {
            musteriTipi = musteriTip;
            InitializeComponent();
            yeniTuzelForm = Application.OpenForms.OfType<YeniTuzel>().FirstOrDefault();
            yeniGercekForm = Application.OpenForms.OfType<YeniGercek>().FirstOrDefault();
            yeniSahisForm = Application.OpenForms.OfType<YeniSahis>().FirstOrDefault();
            yeniAdiOrtakForm = Application.OpenForms.OfType<YeniAdiOrtak>().FirstOrDefault();
            yeniYetkiliForm = Application.OpenForms.OfType<YeniYetkili>().FirstOrDefault();
            yeniCerceveYetkiliForm = Application.OpenForms.OfType<YeniCerceveYetkili>().FirstOrDefault();
        }

        private void MüsteriGüncelle_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                switch (musteriTipi)
                {
                    case 0:
                        {
                            List<string> columnNames = new List<string> { "donem", "musteri_kodu", "vergi_dairesi", "vergi_numarasi", "ad_soyad", "referans", "telefon_no", "is_baslangic_tarih", "eposta_adres", "gercek_faydalanici", "sermaye", "matrah", "tahakkuk_vergi", "imza_sirkuleri", "son_islem_tarihi", "son_islem_amaci", "son_islem_sayisi", "son_islem_tipi" };
                            List<string> columnHeaders = new List<string> { "Dönem", "Müşteri Kodu", "Vergi Dairesi", "Vergi Numarası", "Ad Soyad", "Referans", "Telefon Numarası", "İş Başlangıç Tarihi", "Eposta Adresi", "Gerçek Faydalanıcı", "Sermaye", "Beyan Edilen Matrah", "Tahakkuk Vergisi", "İmza Sirküleri Tarihi", "Son İşlem Tarihi", "Son İşlem Amacı", "Son İşlem Sayısı", "Son İşlem Tipi" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(int), typeof(int), typeof(string), typeof(int), typeof(string), typeof(DateTime), typeof(string), typeof(string), typeof(double), typeof(double), typeof(double), typeof(DateTime), typeof(string), typeof(int), typeof(int), typeof(string) };
                            for (int i = 0; i < 17; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.TuzelKisi";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for(int i = 0; i < 17; i++)
                                        {
                                            data_row.Cells[i].Value = reader.GetValue(i+1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }

                                }
                            }
                            connection.Close();
                        }
                        break;
                    case 1:
                        {
                            List<string> columnNames = new List<string> { "donem", "musteri_kodu", "vergi_numarasi", "tc_kimlikno", "sirket_tipi", "ad_soyad", "referans", "telefon_no", "is_baslangic_tarih", "eposta_adres", "sermaye", "matrah", "tahakkuk_vergi", "imza_sirkuleri", "son_islem_tarihi", "son_islem_amaci", "son_islem_tipi", "vergi_dairesi" };
                            List<string> columnHeaders = new List<string> { "Dönem", "Müşteri Kodu", "Vergi Numarası", "TC Kimlik Numarası", "Şirket Tipi", "Ad Soyad", "Referans", "Telefon Numarası", "İş Başlangıç Tarihi", "Eposta Adresi", "Sermaye", "Beyan Edilen Matrah", "Tahakkuk Vergisi", "İmza Sirküleri Tarihi", "Son İşlem Tarihi", "Son İşlem Amacı", "Son İşlem Tipi", "Vergi Dairesi" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(int), typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(DateTime), typeof(string), typeof(double), typeof(double), typeof(double), typeof(DateTime), typeof(string), typeof(int), typeof(int), typeof(string) };
                            for (int i = 0; i < 18; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.GercekKisi";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for (int i = 0; i < 18; i++)
                                        {
                                            if (reader.GetValue(i + 1) == null)
                                                data_row.Cells[i].Value = null;
                                            else
                                                data_row.Cells[i].Value = reader.GetValue(i+1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }

                                }
                            }
                            connection.Close();
                        }
                        break;
                    case 2:
                        {
                            List<string> columnNames = new List<string> { "donem", "musteri_kodu", "vergi_numarasi", "tc_kimlikno", "sirket_tipi", "ad_soyad", "referans", "telefon_no", "is_baslangic_tarih", "eposta_adres", "sermaye", "matrah", "tahakkuk_vergi", "imza_sirkuleri", "son_islem_tarihi", "son_islem_amaci", "son_islem_tipi", "vergi_dairesi" };
                            List<string> columnHeaders = new List<string> { "Dönem", "Müşteri Kodu", "Vergi Numarası", "TC Kimlik Numarası", "Şirket Tipi", "Ad Soyad", "Referans", "Telefon Numarası", "İş Başlangıç Tarihi", "Eposta Adresi", "Sermaye", "Beyan Edilen Matrah", "Tahakkuk Vergisi", "İmza Sirküleri Tarihi", "Son İşlem Tarihi", "Son İşlem Amacı", "Son İşlem Tipi", "Vergi Dairesi" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(int), typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(DateTime), typeof(string), typeof(double), typeof(double), typeof(double), typeof(DateTime), typeof(string), typeof(int), typeof(int), typeof(string) };
                            for (int i = 0; i < 18; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.Sahis";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for (int i = 0; i < 18; i++)
                                        {
                                            if (reader.GetValue(i + 1) == null)
                                                data_row.Cells[i].Value = null;
                                            else
                                                data_row.Cells[i].Value = reader.GetValue(i + 1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }

                                }
                            }
                            connection.Close();
                        }
                        break;
                    case 3:
                        {
                            List<string> columnNames = new List<string> { "donem", "musteri_kodu", "sirket_tipi", "ad_soyad", "referans", "telefon_no", "is_baslangic_tarih", "eposta_adres", "sermaye", "matrah", "tahakkuk_vergi", "imza_sirkuleri", "son_islem_tarihi", "son_islem_amaci", "son_islem_tipi", "ortak1_vergino", "ortak1_tcno", "ortak1_faydalanici", "ortak2_vergino", "ortak2_tcno", "ortak2_faydalanici", "Vergi Dairesi" };
                            List<string> columnHeaders = new List<string> { "Dönem", "Müşteri Kodu", "Şirket Tipi", "Ad Soyad", "Referans", "Telefon No", "İş Başlangıç Tarih", "Eposta Adresi", "Sermaye", "Beyan Edilen Matrah", "Tahakkuk Edilen Vergi", "İmza Sirküleri Tarihi", "Son İşlem Tarihi", "Son İşlem Amacı", "Son İşlem Tipi", "Vergi Numarası (Ortak 1)", "TC Kimlik Numarası (Ortak 1)", "Gerçek Faydalanıcı (Ortak 1)", "Vergi Numarası (Ortak 2)", "TC Kimlik Numarası (Ortak 2)", "Gerçek Faydalanıcı (Ortak 2)", "Vergi Dairesi" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(DateTime), typeof(string), typeof(double), typeof(double), typeof(double), typeof(DateTime), typeof(DateTime), typeof(string), typeof(int), typeof(int), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(string) };
                            for (int i = 0; i < 22; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.AdiOrtaklik";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for (int j = 0; j < 22; j++)
                                        {
                                            if (reader.GetValue(j + 1) == null)
                                                data_row.Cells[j].Value = null;
                                            else
                                                data_row.Cells[j].Value = reader.GetValue(j + 1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            List<string> columnNames = new List<string> { "musteri_kodu", "tc_kimlikno", "ad_soyad", "telefon_no", "dogum_yili", "dogum_yeri1", "dogum_yeri2", "meslek", "gorev" };
                            List<string> columnHeaders = new List<string> { "Müşteri Kodu", "TC Kimlik Numarası", "Ad Soyad", "Telefon Numarası", "Doğum Yılı", "Doğum Yeri (Ülke)", "Doğum Yeri (Şehir)", "Meslek", "İş-Görev" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), typeof(string) };
                            for (int i = 0; i < 9; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.Yetkili";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for (int j = 0; j < 9; j++)
                                        {
                                            if (reader.GetValue(j + 1) == null)
                                                data_row.Cells[j].Value = null;
                                            else
                                                data_row.Cells[j].Value = reader.GetValue(j + 1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            List<string> columnNames = new List<string> { "musteri_kodu", "tc_kimlikno", "ad_soyad", "telefon_no", "dogum_yili", "dogum_yeri1", "dogum_yeri2", "meslek", "gorev" };
                            List<string> columnHeaders = new List<string> { "Müşteri Kodu", "TC Kimlik Numarası", "Ad Soyad", "Telefon Numarası", "Doğum Yılı", "Doğum Yeri (Ülke)", "Doğum Yeri (Şehir)", "Meslek", "İş-Görev" };
                            List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(string), typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), typeof(string) };
                            for (int i = 0; i < 9; i++)
                            {
                                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                                column.Name = columnNames[i];
                                column.HeaderText = columnHeaders[i];
                                column.ValueType = columnTypes[i];
                                dataGrid_customer.Columns.Add(column);
                            }
                            query = $"SELECT * FROM dbo.CerceveYetkili";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        DataGridViewRow data_row = new DataGridViewRow();
                                        data_row.CreateCells(dataGrid_customer);
                                        for (int j = 0; j < 9; j++)
                                        {
                                            if (reader.GetValue(j + 1) == null)
                                                data_row.Cells[j].Value = null;
                                            else
                                                data_row.Cells[j].Value = reader.GetValue(j + 1);
                                        }
                                        dataGrid_customer.Rows.Add(data_row);
                                    }
                                }
                            }
                        }
                        break;
                }
            }

        }

        private void dataGrid_customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGrid_customer.Rows[e.RowIndex];
            musteriKod = Convert.ToInt32(row.Cells[1].Value);
            switch (musteriTipi)
            {
                case 0:
                    {
                        musteriAd = row.Cells[3].Value.ToString();
                    }
                    break;
                case 1:
                    {
                        musteriAd = row.Cells[5].Value.ToString();
                    }
                    break;
                case 2:
                    {
                        musteriAd = row.Cells[5].Value.ToString();
                    }
                    break;
                case 3:
                    {
                        musteriAd = row.Cells[3].Value.ToString();
                    }
                    break;
            }
            text_musteri.Text = musteriAd;
        }

        private void button_sec_Click(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                switch(musteriTipi)
                {
                    case 0:
                    {
                        YeniTuzel.TuzelKisi tuzelKisi = new YeniTuzel.TuzelKisi();
                        int attributeCount = typeof(TuzelKisi).GetProperties().Length;
                        query = $"SELECT * FROM dbo.TuzelKisi WHERE musteri_kodu = @MusteriKodu";
                        connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount-2;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            tuzelKisi.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                                yeniTuzelForm.yeniTuzelKisi = tuzelKisi;
                                yeniTuzelForm.OnTuzelKisiChanged();
                                yeniTuzelForm.güncellemeModu = true;
                                this.Close();
                            }
                        }
                        break;
                    case 1:
                    {
                            YeniGercek.GercekKisi gercekKisi = new YeniGercek.GercekKisi();
                            int attributeCount = typeof(GercekKisi).GetProperties().Length;
                            query = $"SELECT * FROM dbo.GercekKisi WHERE musteri_kodu = @MusteriKodu";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount-2;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            gercekKisi.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                                yeniGercekForm.yeniGercekKisi = gercekKisi;
                                yeniGercekForm.OnGercekKisiChanged();
                                yeniGercekForm.güncellemeModu = true;
                                this.Close();
                            }
                    }
                        break;
                    case 2:
                        {
                            YeniSahis.Sahis sahis = new YeniSahis.Sahis();
                            int attributeCount = typeof(YeniSahis.Sahis).GetProperties().Length;
                            query = $"SELECT * FROM dbo.Sahis WHERE musteri_kodu = @MusteriKodu";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount-2;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            sahis.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                                yeniSahisForm.yeniSahisKisi = sahis;
                                yeniSahisForm.OnSahisKisiChanged();
                                yeniSahisForm.güncellemeModu = true;
                                this.Close();
                            }
                        }
                        break;
                    case 3:
                        {
                            YeniAdiOrtak.AdiOrtaklik adiOrtaklik = new YeniAdiOrtak.AdiOrtaklik();
                            query = $"SELECT * FROM dbo.AdiOrtaklik WHERE musteri_kodu = @MusteriKodu";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount-2;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            adiOrtaklik.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                                yeniAdiOrtakForm.yeniAdiOrtaklik = adiOrtaklik;
                                yeniAdiOrtakForm.OnAdiOrtaklikChanged();
                                yeniAdiOrtakForm.güncellemeModu = true;
                                this.Close();
                            }
                        }
                        break;
                    case 4:
                        {
                            YeniYetkili.YetkiliKisi yetkiliKisi = new YeniYetkili.YetkiliKisi();
                            query = $"SELECT * FROM dbo.Yetkili WHERE musteri_kodu = @MusteriKodu";
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            yetkiliKisi.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                            }
                            yeniYetkiliForm.yeniYetkiliKisi = yetkiliKisi;
                            yeniYetkiliForm.OnYetkiliKisiChanged();
                            yeniYetkiliForm.güncellemeModu = true;
                            this.Close();
                        }
                        break;
                    case 5:
                        {
                            YeniCerceveYetkili.CerceveYetkiliKisi cerceveYetkiliKisi = new YeniCerceveYetkili.CerceveYetkiliKisi();
                            query = $"SELECT * FROM dbo.CerceveYetkili WHERE musteri_kodu = @MusteriKodu";
                            connection.Open();
                            using(SqlCommand command = new SqlCommand(query,connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    int columnCount = reader.FieldCount;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < columnCount; i++)
                                        {
                                            cerceveYetkiliKisi.Properties[i] = reader.GetValue(i);
                                        }
                                    }
                                }
                            }
                            yeniCerceveYetkiliForm.yeniYetkiliKisi = cerceveYetkiliKisi;
                            yeniCerceveYetkiliForm.OnYetkiliKisiChanged();
                            yeniCerceveYetkiliForm.güncellemeModu = true;
                            this.Close();
                        }
                        break;
                }
            }
        }
    }
}
