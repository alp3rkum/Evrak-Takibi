using Evrak_Takibi_Programı.Diğer;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Evrak_Takibi_Programı.YeniGercek;
using static Evrak_Takibi_Programı.YeniTuzel;

namespace Evrak_Takibi_Programı
{
    public partial class YeniSahis : Form
    {
        List<DateTime> operationDates = new List<DateTime>();

        internal FileInfo cerceveSozlesmesi;
        internal FileInfo kimlikKarti;
        internal FileInfo imzaSirkuleri;
        internal FileInfo ikametgah;
        internal FileInfo islakImza;

        public Sahis yeniSahisKisi;
        public bool güncellemeModu;
        string oldMusteriKod = "";

        public void OnSahisKisiChanged()
        {
            comboBox_donem.Text = yeniSahisKisi.Properties[1].ToString();
            text_custcode.Text = yeniSahisKisi.Properties[2].ToString();
            oldMusteriKod = text_custcode.Text;
            text_taxnum.Text = yeniSahisKisi.Properties[3].ToString();
            text_tcid.Text = yeniSahisKisi.Properties[4].ToString();
            text_comptype.Text = yeniSahisKisi.Properties[5].ToString();
            text_namesurname.Text = yeniSahisKisi.Properties[6].ToString();
            text_reference.Text = yeniSahisKisi.Properties[7].ToString();
            text_phone.Text = yeniSahisKisi.Properties[8].ToString();
            text_date.Text = yeniSahisKisi.Properties[9].ToString();
            text_email.Text = yeniSahisKisi.Properties[10].ToString();
            text_sermaye.Text = yeniSahisKisi.Properties[11].ToString();
            txt_matrah.Text = yeniSahisKisi.Properties[12].ToString();
            text_tahakkuk.Text = yeniSahisKisi.Properties[13].ToString();
            text_sirkulertarih.Text = yeniSahisKisi.Properties[14].ToString();
            text_lastoperation.Text = yeniSahisKisi.Properties[15].ToString();
            switch (yeniSahisKisi.Properties[17])
            {
                case 0: radio_none.Checked = true; break;
                case 1: radio_tim.Checked = true; break;
                case 2: radio_imib.Checked = true; break;
                case 3: radio_sanayi.Checked = true; break;
            }
            text_opreason.Text = yeniSahisKisi.Properties[16].ToString();

            check_cerceve.Checked = Convert.ToBoolean(yeniSahisKisi.Properties[19]);
            check_kimlik.Checked = Convert.ToBoolean(yeniSahisKisi.Properties[20]);
            check_ikamet.Checked = Convert.ToBoolean(yeniSahisKisi.Properties[21]);
            check_imza.Checked = Convert.ToBoolean(yeniSahisKisi.Properties[22]);
            string directoryPath = Path.Combine("belgeler", comboBox_donem.Text, text_namesurname.Text);
            string imzaPath = Path.Combine(directoryPath, "imza.png");
            if (File.Exists(imzaPath))
            {
                yeniSahisKisi.Imza = new Bitmap(imzaPath);
                picture_signature.Image = yeniSahisKisi.Imza;
            }
            string fotoPath = Path.Combine(directoryPath, "fotograf.png");
            if (File.Exists(fotoPath))
            {
                yeniSahisKisi.Fotograf = new Bitmap(fotoPath);
                picture_photo.Image = yeniSahisKisi.Fotograf;
            }
            button_save.Text = "Müşteriyi Güncelle";
            button_update.Text = "Başka Müşteri Güncelle";
        }

        public class Sahis
        {
            private int donem;
            private string musteriKodu;
            private string vergiNumarasi;
            private string tcKimlik;
            private string sirketTipi;
            private string adSoyad;
            private string referans;
            private string? telefon;
            private DateTime? isebaslama;
            private string? eposta;
            private string? sermaye;
            private string? matrah;
            private string? tahakkuk;
            private DateTime? imzaSirkulerTarih;
            private DateTime? sonİslemTarihi;
            private int? timImibSanayi;
            private string? sonİslemAmac;
            private int? sonİslemSayi;
            private bool? cerceveSozlesmesi;
            private bool? kimlikKarti;
            private bool? ikametgah;
            private bool? islakImza;
            private Image? imza;
            private Image? fotograf;

            internal List<object> Properties = new List<object>();

            public int Donem { get => donem; set => donem = value; }
            public string MusteriKodu { get => musteriKodu; set => musteriKodu = value; }
            public string VergiNumarasi { get => vergiNumarasi; set => vergiNumarasi = value; }
            public string TcKimlik { get => tcKimlik; set => tcKimlik = value; }
            public string SirketTipi { get => sirketTipi; set => sirketTipi = value; }
            public string AdSoyad { get => adSoyad; set => adSoyad = value; }
            public string Referans { get => referans; set => referans = value; }
            public string? Telefon { get => telefon; set => telefon = value; }
            public DateTime? Isebaslama { get => isebaslama; set => isebaslama = value; }
            public string? Eposta { get => eposta; set => eposta = value; }
            public string? Sermaye { get => sermaye; set => sermaye = value; }
            public string? Matrah { get => matrah; set => matrah = value; }
            public string? Tahakkuk { get => tahakkuk; set => tahakkuk = value; }
            public DateTime? ImzaSirkulerTarih { get => imzaSirkulerTarih; set => imzaSirkulerTarih = value; }
            public DateTime? SonİslemTarihi { get => sonİslemTarihi; set => sonİslemTarihi = value; }
            public int? TimImibSanayi { get => timImibSanayi; set => timImibSanayi = value; }
            public string? SonİslemAmac { get => sonİslemAmac; set => sonİslemAmac = value; }
            public int? SonİslemSayi { get => sonİslemSayi; set => sonİslemSayi = value; }
            public bool? CerceveSozlesmesi { get => cerceveSozlesmesi; set => cerceveSozlesmesi = value; }
            public bool? KimlikKarti { get => kimlikKarti; set => kimlikKarti = value; }
            public bool? Ikametgah { get => ikametgah; set => ikametgah = value; }
            public bool? IslakImza { get => islakImza; set => islakImza = value; }
            public Image? Imza { get => imza; set => imza = value; }
            public Image? Fotograf { get => fotograf; set => fotograf = value; }

            public Sahis()
            {
                var properties = typeof(Sahis).GetProperties();
                if (properties != null)
                {
                    for (int i = 0; i < typeof(Sahis).GetProperties().Length; i++)
                    {
                        Properties.Add(typeof(Sahis).GetProperties()[i]);
                    }
                }
            }


        }
        public YeniSahis()
        {
            InitializeComponent();
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                //years.Append(i);
                comboBox_donem.Items.Add(i.ToString());
            }
        }

        private void YeniSahis_Load(object sender, EventArgs e)
        {
            int year = comboBox_donem.Items.Count - 1;
            comboBox_donem.SelectedIndex = year;
        }

        private void picture_signature_Click(object sender, EventArgs e)
        {
            fileDialog_imza.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_imza.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_imza.FileName;
                picture_signature.Image = new Bitmap(filename);
                checkInput(sender, e);
            }
        }

        private void picture_photo_Click(object sender, EventArgs e)
        {
            fileDialog_picture.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_picture.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_picture.FileName;
                picture_photo.Image = new Bitmap(filename);
                checkInput(sender, e);
            }
        }

        private bool YeterliGirdilerGirili()
        {
            bool gerekliGirdilerGirili = true;
            bool radioButtonSelected = false;
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.ComboBox comboBox && string.IsNullOrEmpty(comboBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
                else if (control is MaskedTextBox maskedTextBox && string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
                else if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                        radioButtonSelected = true;
                }
                else if (control is System.Windows.Forms.TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
            }
            if (radioButtonSelected == false)
            {
                gerekliGirdilerGirili = false;
            }
            return gerekliGirdilerGirili;
        }

        private bool HerhangiBirGirdiGirili()
        {
            bool herhangiBir = false;
            bool radioButtonSelected = false;
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.ComboBox comboBox && !string.IsNullOrEmpty(comboBox.Text))
                {
                    herhangiBir = true;
                    break;
                }
                else if (control is MaskedTextBox maskedTextBox && !string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    herhangiBir = true;
                    break;
                }
                else if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                        radioButtonSelected = true;
                }
                else if (control is System.Windows.Forms.TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
                {
                    herhangiBir = true;
                    break;
                }
            }
            if (radioButtonSelected == false)
            {
                herhangiBir = true;
            }
            return herhangiBir;
        }

        private void BütünGirdileriTemizle()
        {
            foreach (Control control in panel1.Controls)
            {
                if (control is System.Windows.Forms.ComboBox comboBox && !string.IsNullOrEmpty(comboBox.Text))
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is MaskedTextBox maskedTextBox && !string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    maskedTextBox.Clear();
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is System.Windows.Forms.TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Clear();
                }
            }
        }

        private void checkInput(object sender, EventArgs e)
        {
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private bool isEmail()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text_email.Text);
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (HerhangiBirGirdiGirili())
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş girdileriniz var. Eğer devam ederseniz bu girdileri kaybedeceksiniz.\nYeni kişi girişi yapmak istiyor musunuz?", "Yeni Kişi Girişi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    BütünGirdileriTemizle();
                    picture_signature.Image = null;
                    picture_photo.Image = Properties.Resources.default_photo;
                    button_new.Enabled = false;
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (CheckIfRecordExists() && güncellemeModu == false)
            {
                MessageBox.Show(güncellemeModu.ToString());
                MessageBox.Show("Müşteri zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Sahis sahis = new Sahis();
            sahis.Donem = Convert.ToInt32(comboBox_donem.Text);
            sahis.MusteriKodu = text_custcode.Text;
            sahis.VergiNumarasi = text_taxnum.Text;
            if (text_tcid.Text.Length == 11)
                sahis.TcKimlik = text_tcid.Text;
            else
            {
                if (text_tcid.Text != "0")
                {
                    MessageBox.Show("TC Kimlik Numarası hatalı formatta.", "Girdi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    sahis.TcKimlik = text_tcid.Text;
            }
            sahis.SirketTipi = text_comptype.Text;
            sahis.AdSoyad = text_namesurname.Text;
            sahis.Referans = text_reference.Text;
            sahis.Telefon = text_phone.Text;
            DateTime date;
            if (DateTime.TryParse(text_date.Text, out date))
            {
                sahis.Isebaslama = Convert.ToDateTime(text_date.Text);
                if (sahis.Isebaslama > DateTime.Today)
                {
                    MessageBox.Show("İş başlangıç tarihi bugünden ileri.", "İş Başlangıç Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                sahis.Isebaslama = null;
            }
            if (text_email.Text.Length > 0 && isEmail())
                sahis.Eposta = text_email.Text;
            if (text_sermaye.Text.Length > 0)
                sahis.Sermaye = text_sermaye.Text;
            if (txt_matrah.Text.Length > 0)
                sahis.Matrah = txt_matrah.Text;
            if (text_tahakkuk.Text.Length > 0)
                sahis.Tahakkuk = text_tahakkuk.Text;
            if (DateTime.TryParse(text_sirkulertarih.Text, out date))
            {
                sahis.ImzaSirkulerTarih = Convert.ToDateTime(text_sirkulertarih.Text);
                if (sahis.ImzaSirkulerTarih > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                sahis.ImzaSirkulerTarih = null;
            }

            if (DateTime.TryParse(text_lastoperation.Text, out date))
            {
                sahis.SonİslemTarihi = Convert.ToDateTime(text_lastoperation.Text);
                if (sahis.SonİslemTarihi > DateTime.Today)
                {
                    MessageBox.Show("Son İşlem Tarihi bugünden ileri olamaz.", "Son İşlem Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                sahis.SonİslemTarihi = null;
            }

            if (radio_tim.Checked)
                sahis.TimImibSanayi = 1;
            else if (radio_imib.Checked)
                sahis.TimImibSanayi = 2;
            else if (radio_sanayi.Checked)
                sahis.TimImibSanayi = 3;
            else if (radio_none.Checked)
                sahis.TimImibSanayi = 0;
            else
            {
                MessageBox.Show("Gerekli seçim yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sahis.SonİslemAmac = text_opreason.Text;
            sahis.CerceveSozlesmesi = check_cerceve.Checked;
            sahis.KimlikKarti = check_kimlik.Checked;
            sahis.Ikametgah = check_ikamet.Checked;
            sahis.IslakImza = check_imza.Checked;
            if (!(picture_signature.Image == null))
            {
                sahis.Imza = picture_signature.Image;
            }
            sahis.Fotograf = picture_photo.Image;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                string formattedTelNo = sahis.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (güncellemeModu == false)
                    query = "INSERT INTO dbo.Sahis(donem,musteri_kodu,vergi_numarasi,tc_kimlikno,sirket_tipi,ad_soyad,referans,telefon_no,is_baslangic_tarih,eposta_adres,sermaye,matrah,tahakkuk_vergi,imza_sirkuleri,son_islem_tarihi,son_islem_amaci,son_islem_tipi,kayit_tarih,dosya_cercevesozlesmesi,dosya_kimlik,dosya_ikametgah,dosya_islakimza,dosya_imza,dosya_fotograf) VALUES (@Donem,@MusteriKodu,@VergiNumarasi,@TcKimlikNo,@SirketTipi,@AdSoyad,@Referans,@TelefonNo,@IsBaslangic,@Eposta,@Sermaye,@Matrah,@Tahakkuk,@ImzaSirkuleri,@SonIslemTarihi,@SonIslemAmaci,@SonIslemTipi,@KayitTarih,@DosyaCerceveSozlesmesi,@DosyaKimlik,@DosyaIkametgah,@DosyaIslakImza,@Imza,@Fotograf)";
                else
                    query = "UPDATE dbo.Sahis SET donem = @Donem, musteri_kodu = @MusteriKodu, vergi_numarasi = @VergiNumarasi, tc_kimlikno = @TcKimlikNo, sirket_tipi = @SirketTipi, ad_soyad = @AdSoyad, referans = @Referans, telefon_no = @TelefonNo, is_baslangic_tarih = @IsBaslangic, eposta_adres = @Eposta, sermaye = @Sermaye, matrah = @Matrah, tahakkuk_vergi = @Tahakkuk, imza_sirkuleri = @ImzaSirkuleri, son_islem_tarihi = @SonIslemTarihi, son_islem_amaci = @SonIslemAmaci, son_islem_tipi = @SonIslemTipi, dosya_cercevesozlesmesi = @DosyaCerceveSozlesmesi, dosya_kimlik = @DosyaKimlik, dosya_ikametgah = @DosyaIkametgah, dosya_islakimza = @DosyaIslakImza, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKod2;";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Donem", sahis.Donem);
                    command.Parameters.AddWithValue("@MusteriKodu", sahis.MusteriKodu);
                    if (güncellemeModu == true)
                        command.Parameters.AddWithValue("@MusteriKod2", oldMusteriKod);
                    command.Parameters.AddWithValue("@VergiNumarasi", sahis.VergiNumarasi);
                    command.Parameters.AddWithValue("@TcKimlikNo", sahis.TcKimlik);
                    command.Parameters.AddWithValue("@SirketTipi", sahis.SirketTipi);
                    command.Parameters.AddWithValue("@AdSoyad", sahis.AdSoyad);
                    command.Parameters.AddWithValue("@Referans", sahis.Referans);
                    command.Parameters.AddWithValue("@TelefonNo", formattedTelNo != "" ? formattedTelNo : DBNull.Value);
                    command.Parameters.AddWithValue("@IsBaslangic", sahis.Isebaslama != null ? sahis.Isebaslama : DBNull.Value);
                    command.Parameters.AddWithValue("@Eposta", sahis.Eposta != null ? sahis.Eposta : DBNull.Value);
                    command.Parameters.AddWithValue("@Sermaye", sahis.Sermaye != null ? sahis.Sermaye : DBNull.Value);
                    command.Parameters.AddWithValue("@Matrah", sahis.Matrah != null ? sahis.Matrah : DBNull.Value);
                    command.Parameters.AddWithValue("@Tahakkuk", sahis.Tahakkuk != null ? sahis.Tahakkuk : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkuleri", sahis.ImzaSirkulerTarih != null ? sahis.ImzaSirkulerTarih : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTarihi", sahis.SonİslemTarihi != null ? sahis.SonİslemTarihi : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemAmaci", sahis.SonİslemAmac != null ? sahis.SonİslemAmac : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTipi", sahis.TimImibSanayi != null ? sahis.TimImibSanayi : DBNull.Value);
                    command.Parameters.AddWithValue("@KayitTarih", DateTime.Today.Date);
                    command.Parameters.AddWithValue("@DosyaCerceveSozlesmesi", sahis.CerceveSozlesmesi != null ? sahis.CerceveSozlesmesi : DBNull.Value);
                    command.Parameters.AddWithValue("@DosyaKimlik", sahis.KimlikKarti != null ? sahis.KimlikKarti : DBNull.Value);
                    command.Parameters.AddWithValue("@DosyaIkametgah", sahis.Ikametgah != null ? sahis.Ikametgah : DBNull.Value);
                    command.Parameters.AddWithValue("@DosyaIslakImza", sahis.IslakImza != null ? sahis.IslakImza : DBNull.Value);
                    //command.Parameters.AddWithValue("@Imza", sahis.Imza);
                    //command.Parameters.AddWithValue("@Fotograf", sahis.Fotograf);

                    if (sahis.Imza != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            sahis.Imza.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Imza", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Imza", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (sahis.Fotograf != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            sahis.Fotograf.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = DBNull.Value;
                    }
                    string filePath = $"belgeler\\{sahis.Donem}\\{sahis.AdSoyad.Replace(".", "_").Replace(" ", "_")}";
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] imageBytes;

                        if (sahis.Imza != null)
                        {
                            sahis.Imza.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                sahis.Imza.Dispose();
                            string imzaPath = $"{filePath}\\imza.png";
                            File.WriteAllBytes(imzaPath, imageBytes);

                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }

                        if (sahis.Fotograf != null)
                        {
                            sahis.Fotograf.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                sahis.Fotograf.Dispose();
                            string fotoPath = $"{filePath}\\fotograf.png";
                            File.WriteAllBytes(fotoPath, imageBytes);

                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }


                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        if (güncellemeModu == false)
                            MessageBox.Show($"{sahis.AdSoyad} isimli şahısın kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (güncellemeModu == true)
                                güncellemeModu = false;
                            button_save.Text = "Müşteriyi Kaydet";
                            button_update.Text = "Müşteri Güncelle";
                            MessageBox.Show($"{sahis.AdSoyad} isimli şahısın kaydı başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }   
                    }
                    else
                    {
                        MessageBox.Show($"{sahis.AdSoyad} isimli şahıs zaten kayıtlı.", "Kayıt Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
        }

        private bool CheckIfRecordExists()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.Sahis where musteri_kodu = @MusteriKod";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKod", Convert.ToInt32(text_custcode.Text));
                    int result = (int)command.ExecuteScalar();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            MüsteriGüncelle müsteriGüncelle = new MüsteriGüncelle(2);
            müsteriGüncelle.Show();
        }

        private void text_custcode_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender, e);
            if (Form1.satisRaporu != null)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    if (text_custcode.Text.Length > 0)
                    {
                        operationDates.Clear();
                        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                        {
                            if (Convert.ToInt32(worksheet.Cells[row, 58].Value) == Convert.ToInt32(text_custcode.Text))
                            {
                                text_namesurname.Text = worksheet.Cells[row, 11].Value != null ? worksheet.Cells[row, 11].Value.ToString() : null;
                                text_phone.Text = worksheet.Cells[row, 14].Value != null ? worksheet.Cells[row, 14].Value.ToString() : null;
                                text_taxnum.Text = worksheet.Cells[row, 40].Value != null ? worksheet.Cells[row, 40].Value.ToString() : null;
                                text_email.Text = worksheet.Cells[row, 45].Value != null ? worksheet.Cells[row, 45].Value?.ToString() : null;
                                try
                                {
                                    double dateValue = worksheet.Cells[row, 8].Value != null ? Convert.ToDouble(worksheet.Cells[row, 8].Value) : 0;
                                    MessageBox.Show(dateValue.ToString());
                                    DateTime date = DateTime.FromOADate(dateValue);
                                    operationDates.Add(date);
                                }
                                catch (System.InvalidCastException ex)
                                {
                                    DateTime date = worksheet.Cells[row, 8].Value != null ? Convert.ToDateTime(worksheet.Cells[row, 8].Value) : DateTime.MinValue;
                                    operationDates.Add(date);
                                }
                            }
                        }
                        text_lastopcount.Text = operationDates.Count().ToString();
                        if (text_lastopcount.Text != "0")
                        {
                            text_lastoperation.Text = operationDates.Max().ToString("dd.MM.yyyy");
                        }
                    }
                    
                }
            }
            if (Form1.musteriRaporu != null)
            {

                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.musteriRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    
                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                    {
                        if (Convert.ToInt32(worksheet.Cells[row, 16].Value) == Convert.ToInt32(text_custcode.Text))
                        {
                            text_namesurname.Text = worksheet.Cells[row, 3].Value != null ? worksheet.Cells[row, 3].Value.ToString() : (worksheet.Cells[row, 4].Value != null ? worksheet.Cells[row, 4].Value.ToString() : null);
                            text_taxnum.Text = worksheet.Cells[row, 2].Value != null ? worksheet.Cells[row, 2].Value.ToString() : null;
                            text_tcid.Text = worksheet.Cells[row, 1].Value != null ? worksheet.Cells[row, 1].Value.ToString() : null;
                            text_phone.Text = worksheet.Cells[row, 6].Value != null ? worksheet.Cells[row, 6].Value.ToString() : null;
                            text_reference.Text = worksheet.Cells[row, 13].Value != null ? worksheet.Cells[row, 13].Value.ToString() : null;
                            text_email.Text = worksheet.Cells[row, 20].Value != null ? worksheet.Cells[row, 20].Value.ToString() : null;
                            break;
                        }
                    }
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MusteriSil müsteriSil = new MusteriSil(2);
            müsteriSil.Show();
        }
    }
}
