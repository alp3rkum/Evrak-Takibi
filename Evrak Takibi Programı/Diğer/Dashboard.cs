using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class Dashboard : Form
    {
        //iş parçacıkları
        Task[] tasks = new Task[5];

        HashSet<object> uniqueSatisValues = new HashSet<object>();
        HashSet<object> uniqueMusteriValues = new HashSet<object>();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                combobox_donem.Items.Add(i.ToString());
            }
            //combobox_donem.SelectedIndex = 0;
            combobox_donem.Text = "Yıl Seçiniz";

            if (Form1.satisRaporu != null)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int uniqueValueCount = 0;

                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        object cellValue = worksheet.Cells[row, 11].Value;
                        if (cellValue != null && !uniqueSatisValues.Contains(cellValue))
                        {
                            uniqueSatisValues.Add(cellValue);
                            uniqueValueCount++;
                        }
                        //check worksheet.Cells[row, 11].Value; of all rows, give the count of unique values
                    }
                    label_satis.Text = uniqueValueCount.ToString();
                }
            }
            if (Form1.musteriRaporu != null)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.musteriRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int uniqueValueCount = 0;
                    int columnIndex = -1;
                    int musteriAdColumn = 0;
                    for (int column = 1; column <= worksheet.Dimension.Columns; column++)
                    {
                        string? headerValue = worksheet.Cells[1, column].Value?.ToString();
                        if (headerValue.Equals("Müşteri Adı", StringComparison.OrdinalIgnoreCase) || headerValue.Equals("Müşteri İsim", StringComparison.OrdinalIgnoreCase) || headerValue.Equals("Ünvan", StringComparison.OrdinalIgnoreCase))
                        {
                            musteriAdColumn = column;
                            break;
                        }
                    }
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        object cellValue = worksheet.Cells[row, musteriAdColumn].Value;
                        if (cellValue != null && !uniqueMusteriValues.Contains(cellValue))
                        {
                            uniqueMusteriValues.Add(cellValue);
                            uniqueValueCount++;
                        }
                        //check worksheet.Cells[row, 11].Value; of all rows, give the count of unique values
                    }
                    label_musteri.Text = uniqueValueCount.ToString();
                }
            }
        }

        private async void combobox_donem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string donem = combobox_donem.Text;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";

            string[] cerceveSozlesmesiQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Sahis where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1cerceve = 0) OR (dosya_ortak2cerceve = 0) AND donem = @Donem" };
            string[] kimlikKartiQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_kimlik = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where dosya_kimlik = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Sahis where dosya_kimlik = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1kimlik = 0) OR (dosya_ortak2kimlik = 0) AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Yetkili where dosya_kimlikkarti = 0", "SELECT COUNT(*) FROM dbo.CerceveYetkili where dosya_kimlikkarti = 0" };
            string[] imzaSirkuleriQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Sahis where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1sirkuler IS NULL) OR (dosya_ortak2sirkuler IS NULL) AND donem = @Donem" };
            string[] vergiLevhasiQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where vergi_levhasi IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where vergi_levhasi IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1vergilevha IS NULL) OR (dosya_ortak2vergilevha IS NULL) AND donem = @Donem" };
            string[] faaliyetBelgesiQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_faaliyetbelgesi IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1faaliyetbelge IS NULL AND donem = @Donem) OR (dosya_ortak2faaliyetbelge IS NULL AND donem = @Donem)" };
            string[] ticaretSicilQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_ticaretsicil IS NULL AND donem = @Donem" };
            string[] ikametgahQueries = new string[] { "SELECT COUNT(*) FROM dbo.Sahis where dosya_ikametgah = 0 AND donem = @Donem" };
            string[] islakImzaQueries = new string[] { "SELECT COUNT(*) FROM dbo.Sahis where dosya_islakimza = 0 AND donem = @Donem" };
            string[] adiOrtaklikQueries = new string[] { "SELECT COUNT(*) FROM dbo.AdiOrtaklik where dosya_ortakliksozlesmesi = 0 AND donem = @Donem" };
            string[] tahakkukQueries = new string[] { "SELECT COUNT(*) FROM dbo.AdiOrtaklik where dosya_tahakkukfisi = 0 AND donem = @Donem" };
            string[] imzaQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_imza IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where dosya_imza IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Sahis where dosya_imza IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1imza IS NULL) OR (dosya_ortak2imza IS NULL) AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Yetkili where dosya_imza IS NULL", "SELECT COUNT(*) FROM dbo.CerceveYetkili where dosya_imza IS NULL" };
            string[] fotografQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi where dosya_fotograf IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.GercekKisi where dosya_fotograf IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Sahis where dosya_fotograf IS NULL AND donem = @Donem", "SELECT COUNT(*) FROM dbo.AdiOrtaklik where (dosya_ortak1fotograf IS NULL) OR (dosya_ortak2fotograf IS NULL) AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Yetkili where dosya_fotograf IS NULL", "SELECT COUNT(*) FROM dbo.CerceveYetkili where dosya_fotograf IS NULL" };

            string[] faaliyetBelgesiTarihQueries = new string[] { "SELECT dosya_faaliyetbelgesi FROM dbo.TuzelKisi WHERE donem = @Donem", "SELECT dosya_ortak1faaliyetbelge FROM dbo.AdiOrtaklik WHERE donem = @Donem", "SELECT dosya_ortak2faaliyetbelge FROM dbo.AdiOrtaklik WHERE donem = @Donem" };
            string faturaTakipQuery = "SELECT COUNT(*) FROM dbo.Fatura where takipte = 1 AND YEAR(tarih) = @Donem";
            string dikkatQuery = "SELECT COUNT(*) FROM dbo.DikkatKaydi WHERE Durum = 0 AND YEAR(IslemTarih) = @Donem";
            string[] gercekFaydalaniciQueries = new string[] { "SELECT COUNT(*) FROM dbo.TuzelKisi WHERE dosya_faydalaniciform = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Adiortaklik WHERE dosya_ortak1faydalanici = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Adiortaklik WHERE (dosya_ortak1faydalanici = 0 OR dosya_ortak2faydalanici = 0) AND donem = @Donem" };

            tasks[0] = Task.Run(async () =>
            {
                int eksikBelgeSayi = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in cerceveSozlesmesiQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_cerceve.Invoke(new Action(() => label_cerceve.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in kimlikKartiQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_kimlik.Invoke(new Action(() => label_kimlik.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in imzaSirkuleriQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_sirkuler.Invoke(new Action(() => label_sirkuler.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                    }

                }
            });
            tasks[1] = Task.Run(async () =>
            {
                int eksikBelgeSayi = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in vergiLevhasiQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_vergilevha.Invoke(new Action(() => label_vergilevha.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in faaliyetBelgesiQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_faaliyet.Invoke(new Action(() => label_faaliyet.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in ticaretSicilQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_ticaretsicil.Invoke(new Action(() => label_ticaretsicil.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                    }

                }
            });
            tasks[2] = Task.Run(async () =>
            {
                int eksikBelgeSayi = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in ikametgahQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_ikametgah.Invoke(new Action(() => label_ikametgah.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in islakImzaQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_islakimza.Invoke(new Action(() => label_islakimza.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in adiOrtaklikQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_adiortaklik.Invoke(new Action(() => label_adiortaklik.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                    }

                }
            });
            tasks[3] = Task.Run(async () =>
            {
                int eksikBelgeSayi = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in tahakkukQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_tahakkuk.Invoke(new Action(() => label_tahakkuk.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in imzaQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_imza.Invoke(new Action(() => label_imza.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                        foreach (string query in fotografQueries)
                        {
                            command.CommandText = query;
                            int result = (int)await command.ExecuteScalarAsync();
                            eksikBelgeSayi += result;
                        }
                        label_fotograf.Invoke(new Action(() => label_fotograf.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                    }

                }
            });
            tasks[4] = Task.Run(async () =>
            {
                int eksikBelgeSayi = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in faaliyetBelgesiTarihQueries)
                        {
                            command.CommandText = query;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    DateTime? faaliyetBelgesi = reader.GetValue(0) != DBNull.Value ? reader.GetDateTime(0) : null;
                                    if (faaliyetBelgesi == null)
                                        break;
                                    DateTime today = DateTime.Today;
                                    DateTime twoMonthsAgo = today.AddMonths(-2);
                                    if (faaliyetBelgesi.Value < twoMonthsAgo)
                                    {
                                        eksikBelgeSayi++;
                                    }
                                }
                            }
                        }
                        label_oldsirkuler.Invoke(new Action(() => label_oldsirkuler.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;

                        command.CommandText = faturaTakipQuery;
                        int faturaResult = (int)await command.ExecuteScalarAsync();
                        eksikBelgeSayi = faturaResult;
                        label_takip.Invoke(new Action(() => label_takip.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;

                        command.CommandText = dikkatQuery;
                        int dikkatResult = (int)await command.ExecuteScalarAsync();
                        eksikBelgeSayi = dikkatResult;
                        label_dikkat.Invoke(new Action(() => label_dikkat.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;

                        //command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in gercekFaydalaniciQueries)
                        {
                            command.CommandText = query;
                            eksikBelgeSayi += (int)await command.ExecuteScalarAsync();
                        }
                        label_faydalanici.Invoke(new Action(() => label_faydalanici.Text = eksikBelgeSayi.ToString()));
                        eksikBelgeSayi = 0;
                    }

                }
            });
            await Task.WhenAll(tasks);
        }

        private void label_cerceve_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(0, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(0, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(1, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(2, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(3, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(4, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(5, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(6, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(7, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(8, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(9, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel11_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(10, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(11, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void label_oldsirkuler_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(12, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void label_faydalanici_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(13, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(12, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Dikkat Kaydı sayfasından takipte olan işlemlere ulaşabilirsiniz.", "Takipte Olan İşlemler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Takipteki Faturalar sayfasından takipte olan faturalar ulaşabilirsiniz.", "Takipte Olan Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(13, Convert.ToInt32(combobox_donem.Text));
            eksikDokumanEkran.Show();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label_dikkat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dikkat Kaydı sayfasından takipte olan işlemlere ulaşabilirsiniz.", "Takipte Olan İşlemler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label_takip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Takipteki Faturalar sayfasından takipte olan faturalar ulaşabilirsiniz.", "Takipte Olan Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label_satis_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(14, uniqueSatisValues);
            eksikDokumanEkran.Show();
        }

        private void label_musteri_Click(object sender, EventArgs e)
        {
            EksikDokuman eksikDokumanEkran = new EksikDokuman(15, uniqueMusteriValues);
            eksikDokumanEkran.Show();
        }
    }
}
