using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı.Menü4
{
    public partial class MusteriBilgileriDısaAktar : Form
    {
        private List<int> donems = new List<int>();
        private int musteriKod = 0;
        private string musteriAd = "";
        private string musteriTur = "";
        public MusteriBilgileriDısaAktar()
        {
            InitializeComponent();
        }

        private void MusteriBilgileriDısaAktar_Load(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> columnNames = new List<string> { "musteri_kodu", "ad_soyad", "referans", "telefon_no", "eposta_adres", "is_baslangic_tarih", "son_islem_tarihi", "musteri_tur" };
                List<string> columnHeaders = new List<string> { "Müşteri Kodu", "Ad Soyad", "Referans", "Telefon Numarası", "Eposta Adresi", "İş Başlangıç Tarihi", "Son İşlem Tarihi", "Müşteri Türü" };
                List<Type> columnTypes = new List<Type> { typeof(int), typeof(string), typeof(int), typeof(string), typeof(string), typeof(DateTime), typeof(DateTime), typeof(string) };
                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = columnHeaders[i];
                    column.ValueType = columnTypes[i];
                    dataGridView1.Columns.Add(column);
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi, donem FROM dbo.TuzelKisi";
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
                                if (i < reader.FieldCount - 1)
                                    row_1.Cells[i].Value = reader.GetValue(i);
                                else
                                    donems.Add(reader.GetInt32(i));
                            }
                            row_1.Cells[7].Value = "Tüzel Kişi";
                            dataGridView1.Rows.Add(row_1);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi, donem FROM dbo.GercekKisi";
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
                                if (i < reader.FieldCount - 1)
                                    row_2.Cells[i].Value = reader.GetValue(i);
                                else
                                    donems.Add(reader.GetInt32(i));
                            }
                            row_2.Cells[7].Value = "Gerçek Kişi";
                            dataGridView1.Rows.Add(row_2);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi, donem FROM dbo.Sahis";
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
                                if (i < reader.FieldCount - 1)
                                    row_3.Cells[i].Value = reader.GetValue(i);
                                else
                                    donems.Add(reader.GetInt32(i));
                            }
                            row_3.Cells[7].Value = "Şahıs";
                            dataGridView1.Rows.Add(row_3);
                        }
                    }
                }
                query = $"SELECT musteri_kodu, ad_soyad, referans, telefon_no, eposta_adres, is_baslangic_tarih, son_islem_tarihi, donem FROM dbo.AdiOrtaklik";
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
                                if (i < reader.FieldCount - 1)
                                    row_4.Cells[i].Value = reader.GetValue(i);
                                else
                                    donems.Add(reader.GetInt32(i));
                            }
                            row_4.Cells[7].Value = "Adi Ortaklık";
                            dataGridView1.Rows.Add(row_4);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            musteriKod = Convert.ToInt32(row.Cells[0].Value);
            musteriAd = row.Cells[1].Value.ToString();
            musteriTur = row.Cells[7].Value.ToString();
            text_custname.Text = musteriAd;
            button_export.Enabled = true;
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            DialogResult result = MessageBox.Show("Seçili müşterinin bilgilerini dışarı aktarmak istiyor musunuz?", "Müşteri Bilgileri Dışarı Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string table = "";
                    connection.Open();
                    switch(musteriTur)
                    {
                        case "Tüzel Kişi": table = "dbo.TuzelKisi"; break;
                        case "Gerçek Kişi": table = "dbo.GercekKisi"; break;
                        case "Şahıs": table = "dbo.Sahis"; break;
                        case "Adi Ortaklık": table = "dbo.AdiOrtaklik"; break;
                    }
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("MusteriBilgileri");
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if( (reader.GetName(i).Contains("_imza")) || (reader.GetName(i).Contains("_fotograf") ) || (reader.GetName(i).Contains("1imza")) || (reader.GetName(i).Contains("1fotograf")) || (reader.GetName(i).Contains("2imza")) || (reader.GetName(i).Contains("2fotograf")))
                                    {
                                        worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                        worksheet.Cells[1, i + 1].AutoFitColumns();
                                        worksheet.Cells[2, i+1].Value = reader.GetValue(i);
                                    }
                                }
                                string filePath = $"raporlar\\{musteriAd}.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Müşteri bilgileri başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    connection.Close();
                }
            }
        }
    }
}
