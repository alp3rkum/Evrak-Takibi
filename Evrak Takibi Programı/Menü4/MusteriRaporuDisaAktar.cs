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

namespace Evrak_Takibi_Programı.Menü4
{
    public partial class MusteriRaporuDisaAktar : Form
    {
        private List<List<object>> tuzelKisiler = new List<List<object>>();
        private List<List<object>> gercekKisiler = new List<List<object>>();
        private List<List<object>> sahisKisiler = new List<List<object>>();
        private List<List<object>> adiOrtakKisiler = new List<List<object>>();

        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
        public MusteriRaporuDisaAktar()
        {
            InitializeComponent();
        }

        private void button_tuzel_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.TuzelKisi";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı bütün tüzel kişileri dışa aktarmak istiyor musunuz?", "Tüzel Kişileri Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("TuzelKisi");
                                for (int i = 0; i < reader.FieldCount - 8; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }

                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount - 8; i++)
                                    {
                                        worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }

                                string filePath = "raporlar\\tuzel_kisiler.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Tüzel kişiler başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
            }
        }

        private void button_gercek_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.GercekKisi";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı bütün gerçek kişileri dışa aktarmak istiyor musunuz?", "Gerçek Kişileri Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("GercekKisi");
                                for (int i = 0; i < reader.FieldCount - 6; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }

                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount - 6; i++)
                                    {
                                        worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }

                                string filePath = "C:raporlar\\gercek_kisiler.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Gerçek kişiler başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
            }
        }

        private void button_sahis_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.Sahis";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı bütün şahısları dışa aktarmak istiyor musunuz?", "Şahıs Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sahis");
                                for (int i = 0; i < reader.FieldCount - 6; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }

                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount - 6; i++)
                                    {
                                        worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }

                                string filePath = "C:raporlar\\sahislar.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Şahıslar başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
            }
        }

        private void button_ortaklik_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            string query = "SELECT * FROM dbo.AdiOrtaklik";
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı bütün adi ortaklıkları dışa aktarmak istiyor musunuz?", "Adi Ortaklık Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            using (ExcelPackage package = new ExcelPackage())
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("AdiOrtaklık");
                                for (int i = 0; i < reader.FieldCount - 16; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    worksheet.Cells[1, i + 1].AutoFitColumns();
                                }

                                int rowIndex = 2;
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount - 16; i++)
                                    {
                                        worksheet.Cells[rowIndex, i + 1].Value = reader[i];
                                    }
                                    rowIndex++;
                                }

                                string filePath = "C:raporlar\\adi_ortakliklar.xlsx";
                                package.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Adi Ortaklıklar başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                }
            }
        }

        private void button_hepsi_Click(object sender, EventArgs e)
        {
            string query = "";
            List<string> columns = new List<string> {"Id","musteri_tipi","kayit_tarih","donem","musteri_kodu","sirket_tipi","ad_soyad","referans","telefon_no","is_baslangic_tarih","eposta_adres","sermaye","matrah","tahakkuk_vergi","imza_sirkuleri","son_islem_tarihi","son_islem_amaci","son_islem_sayisi","son_islem_tipi","vergi_dairesi","vergi_no1","vergi_no2","tc_kimlikno1","tc_kimlikno2","gercek_faydalanici1","gercek_faydalanici2" };
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            DialogResult result = MessageBox.Show("Veritabanında kayıtlı BÜTÜN MÜŞTERİLERİ dışa aktarmak istiyor musunuz?", "Bütün Müşterileri Dışa Aktar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                //veritabanından müşterileri al
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    query = "SELECT * FROM dbo.TuzelKisi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<object> tuzelKisi = new List<object>();
                                for (int i = 0; i < reader.FieldCount - 8; i++)
                                {
                                    tuzelKisi.Add(reader.GetValue(i));
                                }
                                gercekKisiler.Add(tuzelKisi);
                            }
                        }
                    }
                    query = "SELECT * FROM dbo.GercekKisi";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<object> gercekKisi = new List<object>();
                                for (int i = 0; i < reader.FieldCount - 6; i++)
                                {
                                    gercekKisi.Add(reader.GetValue(i));
                                }
                                gercekKisiler.Add(gercekKisi);
                            }
                            
                            
                        }
                    }
                    query = "SELECT * FROM dbo.Sahis";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<object> sahisKisi = new List<object>();
                                for (int i = 0; i < reader.FieldCount - 6; i++)
                                {
                                    sahisKisi.Add(reader.GetValue(i));
                                }
                                sahisKisiler.Add(sahisKisi);
                            }
                        }
                    }
                    query = "SELECT * FROM dbo.AdiOrtaklik";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                List<object> adiOrtakKisi = new List<object>();
                                for (int i = 0; i < reader.FieldCount - 6; i++)
                                {
                                    adiOrtakKisi.Add(reader.GetValue(i));
                                }
                                adiOrtakKisiler.Add(adiOrtakKisi);
                            }
                        }
                    }
                }
                //excel'e aktar
                using (ExcelPackage package = new ExcelPackage())
                {
                    int rowIndex = 2;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("TumMusteriler");
                    for (int i = 0; i < columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = columns[i];
                        worksheet.Cells[1, i + 1].AutoFitColumns();
                    }
                    foreach(List<object> tuzelKisi in tuzelKisiler)
                    {
                        worksheet.Cells[rowIndex, 1].Value = tuzelKisi[0].ToString();
                        worksheet.Cells[rowIndex, 2].Value = "Tüzel Kişi";
                        worksheet.Cells[rowIndex, 3].Value = tuzelKisi[18].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 4].Value = tuzelKisi[1].ToString();
                        worksheet.Cells[rowIndex, 5].Value = tuzelKisi[2].ToString();
                        worksheet.Cells[rowIndex, 6].Value = "";
                        worksheet.Cells[rowIndex, 7].Value = tuzelKisi[4].ToString();
                        worksheet.Cells[rowIndex, 8].Value = tuzelKisi[5].ToString();
                        worksheet.Cells[rowIndex, 9].Value = tuzelKisi[6].ToString();
                        worksheet.Cells[rowIndex, 10].Value = tuzelKisi[7].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 11].Value = tuzelKisi[8].ToString();
                        worksheet.Cells[rowIndex, 12].Value = tuzelKisi[10].ToString();
                        worksheet.Cells[rowIndex, 13].Value = tuzelKisi[11].ToString();
                        worksheet.Cells[rowIndex, 14].Value = tuzelKisi[12].ToString();
                        worksheet.Cells[rowIndex, 15].Value = tuzelKisi[13].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 16].Value = tuzelKisi[14].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 17].Value = tuzelKisi[15].ToString();
                        worksheet.Cells[rowIndex, 18].Value = tuzelKisi[16].ToString();
                        worksheet.Cells[rowIndex, 19].Value = tuzelKisi[17].ToString();
                        worksheet.Cells[rowIndex, 20].Value = tuzelKisi[19].ToString();
                        worksheet.Cells[rowIndex, 21].Value = tuzelKisi[3].ToString();
                        worksheet.Cells[rowIndex, 22].Value = "";
                        worksheet.Cells[rowIndex, 23].Value = tuzelKisi[4].ToString();
                        worksheet.Cells[rowIndex, 24].Value = "";
                        worksheet.Cells[rowIndex, 25].Value = tuzelKisi[9].ToString();
                        worksheet.Cells[rowIndex, 26].Value = "";
                    }
                    foreach (List<object> gercekKisi in gercekKisiler)
                    {
                        worksheet.Cells[rowIndex, 1].Value = gercekKisi[0].ToString();
                        worksheet.Cells[rowIndex, 2].Value = "Gerçek Kişi";
                        worksheet.Cells[rowIndex, 3].Value = gercekKisi[18].ToString().Replace("00:00:00","");
                        worksheet.Cells[rowIndex, 4].Value = gercekKisi[1].ToString();
                        worksheet.Cells[rowIndex, 5].Value = gercekKisi[2].ToString();
                        worksheet.Cells[rowIndex, 6].Value = gercekKisi[5].ToString();
                        worksheet.Cells[rowIndex, 7].Value = gercekKisi[6].ToString();
                        worksheet.Cells[rowIndex, 8].Value = gercekKisi[7].ToString();
                        worksheet.Cells[rowIndex, 9].Value = gercekKisi[8].ToString();
                        worksheet.Cells[rowIndex, 10].Value = gercekKisi[9].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 11].Value = gercekKisi[10].ToString();
                        worksheet.Cells[rowIndex, 12].Value = gercekKisi[11].ToString();
                        worksheet.Cells[rowIndex, 13].Value = gercekKisi[12].ToString();
                        worksheet.Cells[rowIndex, 14].Value = gercekKisi[13].ToString();
                        worksheet.Cells[rowIndex, 15].Value = gercekKisi[14].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 16].Value = gercekKisi[15].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 17].Value = gercekKisi[16].ToString();
                        worksheet.Cells[rowIndex, 18].Value = "";
                        worksheet.Cells[rowIndex, 19].Value = gercekKisi[17].ToString();
                        worksheet.Cells[rowIndex, 20].Value = gercekKisi[19].ToString();
                        worksheet.Cells[rowIndex, 21].Value = gercekKisi[3].ToString();
                        worksheet.Cells[rowIndex, 22].Value = "";
                        worksheet.Cells[rowIndex, 23].Value = gercekKisi[4].ToString();
                        worksheet.Cells[rowIndex, 24].Value = "";
                        worksheet.Cells[rowIndex, 25].Value = "";
                        worksheet.Cells[rowIndex, 26].Value = "";

                    }
                    foreach (List<object> sahisKisi in sahisKisiler)
                    {
                        worksheet.Cells[rowIndex, 1].Value = sahisKisi[0].ToString();
                        worksheet.Cells[rowIndex, 2].Value = "Şahıs";
                        worksheet.Cells[rowIndex, 3].Value = sahisKisi[18].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 4].Value = sahisKisi[1].ToString();
                        worksheet.Cells[rowIndex, 5].Value = sahisKisi[2].ToString();
                        worksheet.Cells[rowIndex, 6].Value = sahisKisi[5].ToString();
                        worksheet.Cells[rowIndex, 7].Value = sahisKisi[6].ToString();
                        worksheet.Cells[rowIndex, 8].Value = sahisKisi[7].ToString();
                        worksheet.Cells[rowIndex, 9].Value = sahisKisi[8].ToString();
                        worksheet.Cells[rowIndex, 10].Value = sahisKisi[9].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 11].Value = sahisKisi[10].ToString();
                        worksheet.Cells[rowIndex, 12].Value = sahisKisi[11].ToString();
                        worksheet.Cells[rowIndex, 13].Value = sahisKisi[12].ToString();
                        worksheet.Cells[rowIndex, 14].Value = sahisKisi[13].ToString();
                        worksheet.Cells[rowIndex, 15].Value = sahisKisi[14].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 16].Value = sahisKisi[15].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 17].Value = sahisKisi[16].ToString();
                        worksheet.Cells[rowIndex, 18].Value = "";
                        worksheet.Cells[rowIndex, 19].Value = sahisKisi[17].ToString();
                        worksheet.Cells[rowIndex, 20].Value = sahisKisi[19].ToString();
                        worksheet.Cells[rowIndex, 21].Value = sahisKisi[3].ToString();
                        worksheet.Cells[rowIndex, 22].Value = "";
                        worksheet.Cells[rowIndex, 23].Value = sahisKisi[4].ToString();
                        worksheet.Cells[rowIndex, 24].Value = "";
                        worksheet.Cells[rowIndex, 25].Value = "";
                        worksheet.Cells[rowIndex, 26].Value = "";
                    }
                    foreach (List<object> adiOrtakKisi in adiOrtakKisiler)
                    {
                        worksheet.Cells[rowIndex, 1].Value = adiOrtakKisi[0].ToString();
                        worksheet.Cells[rowIndex, 2].Value = "Adi Ortaklık";
                        worksheet.Cells[rowIndex, 3].Value = adiOrtakKisi[22].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 4].Value = "";
                        worksheet.Cells[rowIndex, 5].Value = adiOrtakKisi[2].ToString();
                        worksheet.Cells[rowIndex, 6].Value = adiOrtakKisi[3].ToString();
                        worksheet.Cells[rowIndex, 7].Value = adiOrtakKisi[4].ToString();
                        worksheet.Cells[rowIndex, 8].Value = adiOrtakKisi[5].ToString();
                        worksheet.Cells[rowIndex, 9].Value = adiOrtakKisi[6].ToString();
                        worksheet.Cells[rowIndex, 10].Value = adiOrtakKisi[7].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 11].Value = adiOrtakKisi[8].ToString();
                        worksheet.Cells[rowIndex, 12].Value = adiOrtakKisi[9].ToString();
                        worksheet.Cells[rowIndex, 13].Value = adiOrtakKisi[10].ToString();
                        worksheet.Cells[rowIndex, 14].Value = adiOrtakKisi[11].ToString();
                        worksheet.Cells[rowIndex, 15].Value = adiOrtakKisi[12].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 16].Value = adiOrtakKisi[13].ToString().Replace("00:00:00", "");
                        worksheet.Cells[rowIndex, 17].Value = adiOrtakKisi[14].ToString();
                        worksheet.Cells[rowIndex, 18].Value = "";
                        worksheet.Cells[rowIndex, 19].Value = adiOrtakKisi[15].ToString();
                        worksheet.Cells[rowIndex, 20].Value = adiOrtakKisi[23].ToString();
                        worksheet.Cells[rowIndex, 21].Value = adiOrtakKisi[17].ToString();
                        worksheet.Cells[rowIndex, 22].Value = adiOrtakKisi[20].ToString();
                        worksheet.Cells[rowIndex, 23].Value = adiOrtakKisi[18].ToString();
                        worksheet.Cells[rowIndex, 24].Value = adiOrtakKisi[21].ToString();
                        worksheet.Cells[rowIndex, 25].Value = adiOrtakKisi[19].ToString();
                        worksheet.Cells[rowIndex, 26].Value = adiOrtakKisi[22].ToString();
                    }
                    string filePath = "C:raporlar\\tum_musteriler.xlsx";
                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show("Tüm müşteriler başarıyla dışa aktarıldı.", "Dışa Aktarma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
