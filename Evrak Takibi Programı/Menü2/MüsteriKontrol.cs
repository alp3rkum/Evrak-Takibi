using Evrak_Takibi_Programı.Diğer;
using OfficeOpenXml;
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

namespace Evrak_Takibi_Programı.Menü2
{
    public partial class MüsteriKontrol : Form
    {
        private string musteriTipi;
        private string musteriAdi;
        private bool excelden;
        public MüsteriKontrol()
        {
            InitializeComponent();
        }

        private void MüsteriKontrol_Load(object sender, EventArgs e)
        {
            if (Form1.musteriRaporu == null)
            {
                button_report.Enabled = false;
            }

            //string query = "";
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "referans", "telefon_no", "eposta_adres", "is_baslangic_tarih", "son_islem_tarihi", "musteri_tur" };
            //    List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Referans", "telefon_no", "eposta_adres", "İş Başlangıç Tarihi", "Son İşlem Tarihi", "Müşteri Türü" };
            //    List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(string) };
            //    for (int i = 0; i < 8; i++)
            //    {
            //        DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //        column.Name = columnNames[i];
            //        column.HeaderText = columnHeaders[i];
            //        column.ValueType = columnTypes[i];
            //        dataGridView1.Columns.Add(column);
            //    }
            //    query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.TuzelKisi";
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                DataGridViewRow row_1 = new DataGridViewRow();
            //                row_1.CreateCells(dataGridView1);
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    row_1.Cells[i].Value = reader.GetValue(i);
            //                }
            //                row_1.Cells[7].Value = "Tüzel Kişi";
            //                dataGridView1.Rows.Add(row_1);
            //            }
            //        }
            //    }
            //    query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.GercekKisi";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                DataGridViewRow row_2 = new DataGridViewRow();
            //                row_2.CreateCells(dataGridView1);
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    row_2.Cells[i].Value = reader.GetValue(i);
            //                }
            //                row_2.Cells[7].Value = "Gerçek Kişi";
            //                dataGridView1.Rows.Add(row_2);
            //            }
            //        }
            //    }
            //    query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.Sahis";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                DataGridViewRow row_3 = new DataGridViewRow();
            //                row_3.CreateCells(dataGridView1);
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    row_3.Cells[i].Value = reader.GetValue(i);
            //                }
            //                row_3.Cells[7].Value = "Şahıs";
            //                dataGridView1.Rows.Add(row_3);
            //            }
            //        }
            //    }
            //    query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.AdiOrtaklik";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataReader reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                DataGridViewRow row_4 = new DataGridViewRow();
            //                row_4.CreateCells(dataGridView1);
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    row_4.Cells[i].Value = reader.GetValue(i);
            //                }
            //                row_4.Cells[7].Value = "Adi Ortaklık";
            //                dataGridView1.Rows.Add(row_4);
            //            }
            //        }
            //    }
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            musteriTipi = row.Cells[7].Value.ToString();
            musteriAdi = row.Cells[1].Value.ToString();
            text_custname.Text = musteriAdi;
        }

        private void button_getir_Click(object sender, EventArgs e)
        {
            if (text_custname.Text.Length > 0)
            {
                DosyaGoster dosyaGoster = new DosyaGoster(0, musteriAdi, musteriTipi, false);
                dosyaGoster.Show();
            }
            else
            {
                MessageBox.Show("Müşteri seçilmedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_db_Click(object sender, EventArgs e)
        {
            excelden = false;
            button_getir.Enabled = true;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "referans", "telefon_no", "eposta_adres", "is_baslangic_tarih", "son_islem_tarihi", "musteri_tur" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Referans", "telefon_no", "eposta_adres", "İş Başlangıç Tarihi", "Son İşlem Tarihi", "Müşteri Türü" };
                List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(string) };
                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGridView1.Columns.Add(column);
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.TuzelKisi";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_1 = new DataGridViewRow();
                            row_1.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_1.Cells[i].Value = reader.GetValue(i);
                            }
                            row_1.Cells[7].Value = "Tüzel Kişi";
                            dataGridView1.Rows.Add(row_1);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.GercekKisi";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_2 = new DataGridViewRow();
                            row_2.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_2.Cells[i].Value = reader.GetValue(i);
                            }
                            row_2.Cells[7].Value = "Gerçek Kişi";
                            dataGridView1.Rows.Add(row_2);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.Sahis";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_3 = new DataGridViewRow();
                            row_3.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_3.Cells[i].Value = reader.GetValue(i);
                            }
                            row_3.Cells[7].Value = "Şahıs";
                            dataGridView1.Rows.Add(row_3);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi FROM dbo.AdiOrtaklik";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row_4 = new DataGridViewRow();
                            row_4.CreateCells(dataGridView1);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row_4.Cells[i].Value = reader.GetValue(i);
                            }
                            row_4.Cells[7].Value = "Adi Ortaklık";
                            dataGridView1.Rows.Add(row_4);
                        }
                    }
                }
            }
        }

        private void button_report_Click(object sender, EventArgs e)
        {
            excelden = true;
            button_getir.Enabled = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "vergi_no", "telefon_no", "eposta_adres", "vergi_dairesi", "referans", "musteri_tur" };
            List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Vergi Numarası", "telefon_no", "eposta_adres", "Vergi Dairesi", "Referans", "Müşteri Türü" };
            List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(string), typeof(string), typeof(string) };
            for (int i = 0; i < 8; i++)
            {
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.Name = columnNames[i];
                column.HeaderText = columnHeaders[i];
                column.ValueType = columnTypes[i];
                dataGridView1.Columns.Add(column);
            }
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(Form1.musteriRaporu))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    DataGridViewRow row_data = new DataGridViewRow();
                    row_data.CreateCells(dataGridView1);
                    row_data.Cells[0].Value = worksheet.Cells[row, 16].Value;
                    row_data.Cells[1].Value = worksheet.Cells[row, 3].Value;
                    row_data.Cells[2].Value = worksheet.Cells[row, 2].Value;
                    row_data.Cells[3].Value = worksheet.Cells[row, 6].Value;
                    row_data.Cells[4].Value = worksheet.Cells[row, 20].Value;
                    row_data.Cells[5].Value = worksheet.Cells[row, 7].Value;
                    row_data.Cells[6].Value = worksheet.Cells[row, 13].Value;
                    row_data.Cells[7].Value = worksheet.Cells[row, 29].Value;
                    dataGridView1.Rows.Add(row_data);
                }
            }
        }
    }
}
