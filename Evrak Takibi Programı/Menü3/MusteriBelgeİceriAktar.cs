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
using static Evrak_Takibi_Programı.YeniSahis;

namespace Evrak_Takibi_Programı.Menü3
{
    public partial class MusteriBelgeİceriAktar : Form
    {
        private int musteriKod;
        private string musteriAd;
        private string musteriTipi;
        private List<int> donems = new List<int>();
        private int currentDonem;

        internal FileInfo imza;
        internal FileInfo fotograf;
        internal FileInfo imza2;
        internal FileInfo fotograf2;
        public MusteriBelgeİceriAktar()
        {
            InitializeComponent();
        }

        private void MusteriBelgeİceriAktar_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            text_custname.Text = row.Cells[1].Value.ToString();
            musteriAd = text_custname.Text;
            musteriTipi = row.Cells[7].Value.ToString();
            musteriKod = Convert.ToInt32(row.Cells[0].Value);
            currentDonem = donems[e.RowIndex];

            button11.Enabled = true;
            button12.Enabled = true;
            switch(musteriTipi)
            {
                case "Tüzel Kişi":
                    {
                        check_cerceve1.Enabled = true;
                        check_cerceve2.Enabled = false;
                        check_kimlik1.Enabled = true;
                        check_kimlik2.Enabled = false;
                        check_ikametgah.Enabled = false;
                        text_sirkulertarih1.Enabled = true;
                        text_sirkulertarih2.Enabled = false;
                        text_vergilevha1.Enabled = true;
                        text_vergilevha2.Enabled = false;
                        check_imza.Enabled = false;
                        text_faaliyet1.Enabled = true;
                        text_faaliyet2.Enabled = false;
                        text_ticaretsicil.Enabled = true;
                        check_fayda1.Enabled = true;
                        check_fayda2.Enabled = false;
                        check_ortaklik.Enabled = false;
                        check_tahakkuk.Enabled = false;
                    }
                    break;
                case "Gerçek Kişi":
                    {
                        check_cerceve1.Enabled = true;
                        check_cerceve2.Enabled = false;
                        check_kimlik1.Enabled = true;
                        check_kimlik2.Enabled = false;
                        check_ikametgah.Enabled = false;
                        text_sirkulertarih1.Enabled = true;
                        text_sirkulertarih2.Enabled = false;
                        text_vergilevha1.Enabled = true;
                        text_vergilevha2.Enabled = false;
                        check_imza.Enabled = false;
                        text_faaliyet1.Enabled = false;
                        text_faaliyet2.Enabled = false;
                        text_ticaretsicil.Enabled = false;
                        check_fayda1.Enabled = false;
                        check_fayda2.Enabled = false;
                        check_ortaklik.Enabled = false;
                        check_tahakkuk.Enabled = false;
                    }
                    break;
                case "Şahıs":
                    {
                        check_cerceve1.Enabled = true;
                        check_cerceve2.Enabled = false;
                        check_kimlik1.Enabled = true;
                        check_kimlik2.Enabled = false;
                        check_ikametgah.Enabled = true;
                        text_sirkulertarih1.Enabled = true;
                        text_sirkulertarih2.Enabled = false;
                        text_vergilevha1.Enabled = true;
                        text_vergilevha2.Enabled = false;
                        check_imza.Enabled = true;
                        text_faaliyet1.Enabled = false;
                        text_faaliyet2.Enabled = false;
                        text_ticaretsicil.Enabled = false;
                        check_fayda1.Enabled = false;
                        check_fayda2.Enabled = false;
                        check_ortaklik.Enabled = false;
                        check_tahakkuk.Enabled = false;
                    }
                    break;
                case "Adi Ortaklık":
                    {
                        check_cerceve1.Enabled = true;
                        check_cerceve2.Enabled = true;
                        check_kimlik1.Enabled = true;
                        check_kimlik2.Enabled = true;
                        check_ikametgah.Enabled = false;
                        text_sirkulertarih1.Enabled = true;
                        text_sirkulertarih2.Enabled = true;
                        text_vergilevha1.Enabled = true;
                        text_vergilevha2.Enabled = true;
                        check_imza.Enabled = false;
                        text_faaliyet1.Enabled = true;
                        text_faaliyet2.Enabled = true;
                        text_ticaretsicil.Enabled = false;
                        check_fayda1.Enabled = true;
                        check_fayda2.Enabled = true;
                        check_ortaklik.Enabled = true;
                        check_tahakkuk.Enabled = true;
                    }
                    break;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (musteriTipi != "Adi Ortaklık")
            {
                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    imza = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\imza.png";
                    imza.CopyTo(filePath, true);
                    MessageBox.Show("İmza dosyası başarıyla alındı!", "İmza İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                filedialog_import.Title = "Ortak 1 İmza";
                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    imza2 = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\ortak1_imza.png";
                    imza.CopyTo(filePath, true);
                    MessageBox.Show("İmza dosyası başarıyla alındı!", "İmza İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                filedialog_import.Title = "Ortak 2 İmza";
                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    imza2 = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\ortak2_imza.png";
                    imza.CopyTo(filePath, true);
                    MessageBox.Show("İmza dosyası başarıyla alındı!", "İmza İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (musteriTipi != "Adi Ortaklık")
            {

                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    fotograf = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\fotograf.png";
                    fotograf.CopyTo(filePath, true);
                    MessageBox.Show("Fotoğraf dosyası başarıyla alındı!", "Fotoğraf İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                filedialog_import.Title = "Ortak 1 Fotoğraf";
                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    fotograf = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\ortak1_fotograf.png";
                    fotograf.CopyTo(filePath, true);
                    MessageBox.Show("İmza dosyası başarıyla alındı!", "İmza İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                filedialog_import.Title = "Ortak 2 Fotoğraf";
                filedialog_import.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
                if (filedialog_import.ShowDialog() == DialogResult.OK)
                {
                    fotograf2 = new FileInfo(filedialog_import.FileName);
                    string filePath = $"belgeler\\{currentDonem}\\{musteriAd}\\ortak2_fotograf.png";
                    fotograf2.CopyTo(filePath, true);
                    MessageBox.Show("Fotoğraf dosyası başarıyla alındı!", "Fotoğraf İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                switch(musteriTipi)
                {
                    case "Tüzel Kişi":
                        {
                            query = "UPDATE dbo.TuzelKisi SET dosya_cercevesozlesmesi = @Cerceve, dosya_kimlik = @Kimlik, imza_sirkuleri = @Sirkuler, vergi_levhasi = @VergiLevha, dosya_faaliyetbelgesi = @Faaliyet, dosya_ticaretsicil = @Ticaret, dosta_faydalaniciform = @Faydalanici, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKodu";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                command.Parameters.AddWithValue("@Cerceve", check_cerceve1.Checked);
                                command.Parameters.AddWithValue("@Kimlik", check_kimlik1.Checked);
                                command.Parameters.AddWithValue("@Sirkuler", Convert.ToDateTime(text_sirkulertarih1.Text));
                                command.Parameters.AddWithValue("@VergiLevha", text_vergilevha1.Text);
                                command.Parameters.AddWithValue("@Faaliyet", Convert.ToDateTime(text_faaliyet1.Text));
                                command.Parameters.AddWithValue("@Ticaret", Convert.ToDateTime(text_ticaretsicil.Text));
                                command.Parameters.AddWithValue("@Faydalanici", check_fayda1.Checked);
                                command.Parameters.AddWithValue("@Imza", imza);
                                command.Parameters.AddWithValue("@Fotograf", fotograf);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected == 1)
                                {
                                    MessageBox.Show($"{musteriAd} isimli müşterinin belge güncellemesi başarıyla gerçekleştirildi.", "Belge Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Belge Güncellemesi Yapılamadı.", "Belge Güncelleme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        break;
                    case "Gerçek Kişi":
                        {
                            query = "UPDATE dbo.GercekKisi SET dosya_cercevesozlesmesi = @Cerceve, dosya_kimlik = @Kimlik, imza_sirkuleri = @Sirkuler, vergi_levhasi = @VergiLevha, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKodu";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                command.Parameters.AddWithValue("@Cerceve", check_cerceve1.Checked);
                                command.Parameters.AddWithValue("@Kimlik", check_kimlik1.Checked);
                                command.Parameters.AddWithValue("@Sirkuler", Convert.ToDateTime(text_sirkulertarih1.Text));
                                command.Parameters.AddWithValue("@VergiLevha", text_vergilevha1.Text);
                                command.Parameters.AddWithValue("@Imza", imza);
                                command.Parameters.AddWithValue("@Fotograf", fotograf);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected == 1)
                                {
                                    MessageBox.Show($"{musteriAd} isimli müşterinin belge güncellemesi başarıyla gerçekleştirildi.", "Belge Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Belge Güncellemesi Yapılamadı.", "Belge Güncelleme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        break;
                    case "Şahıs":
                        {
                            query = "UPDATE dbo.Sahis SET dosya_cercevesozlesmesi = @Cerceve, dosya_kimlik = @Kimlik, imza_sirkuleri = @Sirkuler, ikametgah = @Ikametgah, islak_imza = @IslakImza, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKodu";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                command.Parameters.AddWithValue("@Cerceve", check_cerceve1.Checked);
                                command.Parameters.AddWithValue("@Kimlik", check_kimlik1.Checked);
                                command.Parameters.AddWithValue("@Sirkuler", Convert.ToDateTime(text_sirkulertarih1.Text));
                                command.Parameters.AddWithValue("@Ikametgah", check_ikametgah.Checked);
                                command.Parameters.AddWithValue("@IslakImza", check_imza.Checked);
                                command.Parameters.AddWithValue("@Imza", imza);
                                command.Parameters.AddWithValue("@Fotograf", fotograf);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected == 1)
                                {
                                    MessageBox.Show($"{musteriAd} isimli müşterinin belge güncellemesi başarıyla gerçekleştirildi.", "Belge Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Belge Güncellemesi Yapılamadı.", "Belge Güncelleme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        break;
                    case "Adi Ortaklık":
                        {
                            query = "UPDATE dbo.AdiOrtaklik SET dosya_ortakliksozlesmesi = @Ortaklik, dosya_tahakkukfisi = @Tahakkuk, dosya_ortak1cerceve = @Cerceve1, dosya_ortak2cerceve = @Cerceve2, dosya_ortak1kimlik = @Kimlik1, dosya_ortak2kimlik = @Kimlik2, dosya_ortak1sirkuler = @Sirkuler1, dosya_ortak2sirkuler = @Sirkuler2, dosya_ortak1vergilevha = @Levha1, dosya_ortak2vergilevha = @Levha2, dosya_ortak1faaliyetbelge = @Faaliyet1, dosya_ortak2faaliyetbelge = @Faaliyet2, dosya_ortak1faydalanici = @Fayda1, dosya_ortak2faydalanici = @Fayda2, dosya_ortak1imza = @Imza1, dosya_ortak2imza = @Imza2, dosya_ortak1fotograf = @Fotograf1, dosya_ortak2fotograf = @Fotograf2 WHERE musteri_kodu = @MusteriKodu";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@MusteriKodu", musteriKod);
                                command.Parameters.AddWithValue("@Ortaklik", check_ortaklik.Checked);
                                command.Parameters.AddWithValue("@Tahakkuk", check_tahakkuk.Checked);
                                command.Parameters.AddWithValue("@Cerceve1", check_cerceve1.Checked);
                                command.Parameters.AddWithValue("@Cerceve2", check_cerceve2.Checked);
                                command.Parameters.AddWithValue("@Kimlik1", check_kimlik1.Checked);
                                command.Parameters.AddWithValue("@Kimlik2", check_kimlik2.Checked);
                                command.Parameters.AddWithValue("@Sirkuler1", Convert.ToDateTime(text_sirkulertarih1.Text));
                                command.Parameters.AddWithValue("@Sirkuler2", Convert.ToDateTime(text_sirkulertarih2.Text));
                                command.Parameters.AddWithValue("@Levha1", text_vergilevha1.Text);
                                command.Parameters.AddWithValue("@Levha2", text_vergilevha2.Text);
                                command.Parameters.AddWithValue("@Faaliyet1", Convert.ToDateTime(text_faaliyet1.Text));
                                command.Parameters.AddWithValue("@Faaliyet2", Convert.ToDateTime(text_faaliyet2.Text));
                                command.Parameters.AddWithValue("@Fayda1", check_fayda1.Checked);
                                command.Parameters.AddWithValue("@Fayda2", check_fayda2.Checked);

                                command.Parameters.AddWithValue("@Imza1", imza);
                                command.Parameters.AddWithValue("@Imza2", imza2);
                                command.Parameters.AddWithValue("@Fotograf1", fotograf);
                                command.Parameters.AddWithValue("@Fotograf2", fotograf2);

                                int rowsAffected = command.ExecuteNonQuery();
                                if (rowsAffected == 1)
                                {
                                    MessageBox.Show($"{musteriAd} isimli müşterinin belge güncellemesi başarıyla gerçekleştirildi.", "Belge Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show($"Belge Güncellemesi Yapılamadı.", "Belge Güncelleme Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}