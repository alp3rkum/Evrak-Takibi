using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using Evrak_Takibi_Programı.Diğer;
using System.Runtime.CompilerServices;
using OfficeOpenXml;
using static Evrak_Takibi_Programı.YeniSahis;
using System.Security.Policy;

namespace Evrak_Takibi_Programı
{
    public partial class YeniTuzel : Form
    {

        List<DateTime> operationDates = new List<DateTime>();

        public TuzelKisi yeniTuzelKisi;
        public bool güncellemeModu = false;
        string oldMusteriKod = "";

        public void OnTuzelKisiChanged()
        {
            comboBox_donem.Text = yeniTuzelKisi.Properties[1].ToString();
            text_custcode.Text = yeniTuzelKisi.Properties[2].ToString();
            oldMusteriKod = text_custcode.Text;
            text_taxoffice.Text = yeniTuzelKisi.Properties[19].ToString();
            text_taxnum.Text = yeniTuzelKisi.Properties[3].ToString();
            text_namesurname.Text = yeniTuzelKisi.Properties[4].ToString();
            text_reference.Text = yeniTuzelKisi.Properties[5].ToString();
            text_phone.Text = yeniTuzelKisi.Properties[6].ToString();
            text_date.Text = yeniTuzelKisi.Properties[7].ToString();
            text_email.Text = yeniTuzelKisi.Properties[8].ToString();
            text_gerfayda.Text = yeniTuzelKisi.Properties[9].ToString();
            text_sermaye.Text = yeniTuzelKisi.Properties[10].ToString();
            txt_matrah.Text = yeniTuzelKisi.Properties[11].ToString();
            text_tahakkuk.Text = yeniTuzelKisi.Properties[12].ToString();
            text_sirkulertarih.Text = yeniTuzelKisi.Properties[13].ToString();
            text_lastoperation.Text = yeniTuzelKisi.Properties[14].ToString();
            switch (yeniTuzelKisi.Properties[17])
            {
                case 0: radio_none.Checked = true; break;
                case 1: radio_tim.Checked = true; break;
                case 2: radio_imib.Checked = true; break;
                case 3: radio_sanayi.Checked = true; break;
            }
            text_opreason.Text = yeniTuzelKisi.Properties[15].ToString();
            text_lastopcount.Text = yeniTuzelKisi.Properties[16].ToString();
            
            check_cerceve.Checked = (yeniTuzelKisi.Properties[21] != DBNull.Value) ? Convert.ToBoolean(yeniTuzelKisi.Properties[21]) : false;
            check_kimlik.Checked = (yeniTuzelKisi.Properties[22] != DBNull.Value) ? Convert.ToBoolean(yeniTuzelKisi.Properties[22]) : false;
            check_fayda.Checked = (yeniTuzelKisi.Properties[25] != DBNull.Value) ? Convert.ToBoolean(yeniTuzelKisi.Properties[25]) : false;
            text_ticaretsicil.Text = yeniTuzelKisi.Properties[24].ToString();
            text_faaliyet.Text = yeniTuzelKisi.Properties[23].ToString();
            text_fax.Text = yeniTuzelKisi.Properties[20].ToString();

            string directoryPath = Path.Combine("belgeler", comboBox_donem.Text, text_namesurname.Text);
            string imzaPath = Path.Combine(directoryPath, "imza.png");
            if (File.Exists(imzaPath))
            {
                yeniTuzelKisi.Imza = new Bitmap(imzaPath);
                picture_signature.Image = yeniTuzelKisi.Imza;
            }
            string fotoPath = Path.Combine(directoryPath, "fotograf.png");
            if (File.Exists(fotoPath))
            {
                yeniTuzelKisi.Fotograf = new Bitmap(fotoPath);
                picture_photo.Image = yeniTuzelKisi.Fotograf;
            }
            button_save.Text = "Müşteriyi Güncelle";
            button_update.Text = "Başka Müşteri Güncelle";
        }

        public class TuzelKisi
        {
            private int donem;
            private string musteriKodu;
            private string vergiNumarasi;
            private string adSoyad;
            private string referans;
            private string? telefon;
            private DateTime? isebaslama;
            private string? eposta;
            private string? gercekFaydalanici;
            private string? sermaye;
            private string? matrah;
            private string? tahakkuk;
            private DateTime? imzaSirkulerTarih;
            private DateTime? sonİslemTarihi;
            private int? timImibSanayi;
            private string? sonİslemAmac;
            private int? sonİslemSayi;
            private string? vergiDairesi;
            private string? vergiLevhasi;
            private bool? cerceveSozlesmesi;
            private bool? kimlikKarti;
            private DateTime? faaliyetBelgesi;
            private DateTime? ticaretSicilGazetesi;
            private bool? gercekFaydalaniciFormu;
            private Image? imza;
            private Image? fotograf;

            internal List<object> Properties = new List<object>();

            public int Donem { get => donem; set => donem = value; }
            public string MusteriKodu { get => musteriKodu; set => musteriKodu = value; }
            public string VergiNumarasi { get => vergiNumarasi; set => vergiNumarasi = value; }
            public string AdSoyad { get => adSoyad; set => adSoyad = value; }
            public string Referans { get => referans; set => referans = value; }
            public string? Telefon { get => telefon; set => telefon = value; }
            public DateTime? Isebaslama { get => isebaslama; set => isebaslama = value; }
            public string? Eposta { get => eposta; set => eposta = value; }
            public string? GercekFaydalanici { get => gercekFaydalanici; set => gercekFaydalanici = value; }
            public string? Sermaye { get => sermaye; set => sermaye = value; }
            public string? Matrah { get => matrah; set => matrah = value; }
            public string? Tahakkuk { get => tahakkuk; set => tahakkuk = value; }
            public DateTime? ImzaSirkulerTarih { get => imzaSirkulerTarih; set => imzaSirkulerTarih = value; }
            public DateTime? SonİslemTarihi { get => sonİslemTarihi; set => sonİslemTarihi = value; }
            public int? TimImibSanayi { get => timImibSanayi; set => timImibSanayi = value; }
            public string? SonİslemAmac { get => sonİslemAmac; set => sonİslemAmac = value; }
            public int? SonİslemSayi { get => sonİslemSayi; set => sonİslemSayi = value; }
            public string? VergiDairesi { get => vergiDairesi; set => vergiDairesi = value; }
            public string? VergiLevhasi { get => vergiLevhasi; set => vergiLevhasi = value; }
            public bool? CerceveSozlesmesi { get => cerceveSozlesmesi; set => cerceveSozlesmesi = value; }
            public bool? KimlikKarti { get => kimlikKarti; set => kimlikKarti = value; }
            public DateTime? FaaliyetBelgesi { get => faaliyetBelgesi; set => faaliyetBelgesi = value; }
            public DateTime? TicaretSicilGazetesi { get => ticaretSicilGazetesi; set => ticaretSicilGazetesi = value; }
            public bool? GercekFaydalaniciFormu { get => gercekFaydalaniciFormu; set => gercekFaydalaniciFormu = value; }
            public Image? Imza { get => imza; set => imza = value; }
            public Image? Fotograf { get => fotograf; set => fotograf = value; }

            public TuzelKisi()
            {
                for (int i = 0; i < typeof(TuzelKisi).GetProperties().Length; i++)
                {
                    Properties.Add(typeof(TuzelKisi).GetProperties()[i]);
                }
            }

        }
        public YeniTuzel()
        {
            InitializeComponent();
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                //years.Append(i);
                comboBox_donem.Items.Add(i.ToString());
            }
        }

        private void YeniTuzel_Load(object sender, EventArgs e)
        {
            int year = comboBox_donem.Items.Count-1;
            comboBox_donem.SelectedIndex = year;

        }

        private void picture_signature_Click(object sender, EventArgs e)
        {
            fileDialog_imza.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_imza.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_imza.FileName;
                picture_signature.Image = new Bitmap(filename);
                checkInput(sender,e);
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
            foreach (Control control in panel2.Controls)
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
            foreach (Control control in panel2.Controls)
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
            foreach (Control control in panel2.Controls)
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

        private void comboBox_donem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //button_save.Enabled = YeterliGirdilerGirili() && isEmail();
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private void checkInput(object sender, EventArgs e)
        {
            //button_save.Enabled = YeterliGirdilerGirili() && isEmail();
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private bool isEmail()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text_email.Text);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if(CheckIfRecordExists() && güncellemeModu == false)
            {
                MessageBox.Show("Müşteri zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TuzelKisi tuzelKisi = new TuzelKisi();
            tuzelKisi.Donem = Convert.ToInt32(comboBox_donem.Text);
            tuzelKisi.MusteriKodu = text_custcode.Text;
            tuzelKisi.VergiDairesi = text_taxoffice.Text;
            tuzelKisi.VergiNumarasi = text_taxnum.Text;
            tuzelKisi.AdSoyad = text_namesurname.Text;
            tuzelKisi.Referans = text_reference.Text;
            tuzelKisi.Telefon = text_phone.Text;
            tuzelKisi.VergiLevhasi = text_fax.Text;
            DateTime date;
            if (DateTime.TryParse(text_date.Text, out date))
            {
                tuzelKisi.Isebaslama = Convert.ToDateTime(text_date.Text);
                if (tuzelKisi.Isebaslama > DateTime.Today)
                {
                    MessageBox.Show("İş başlangıç tarihi bugünden ileri.", "İş Başlangıç Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                tuzelKisi.Isebaslama = null;
            }

            if(text_email.Text.Length > 0 && isEmail())
                tuzelKisi.Eposta = text_email.Text;
            else
            {
                MessageBox.Show("Doğru tür bir eposta girdisi girilmedi", "Eposta girdisi yanlış", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(text_gerfayda.Text.Length > 0)
                tuzelKisi.GercekFaydalanici = text_gerfayda.Text;
            if(text_sermaye.Text.Length > 0)
                tuzelKisi.Sermaye = text_sermaye.Text;
            if(txt_matrah.Text.Length > 0)
                tuzelKisi.Matrah = txt_matrah.Text;
            if(text_tahakkuk.Text.Length > 0)
            tuzelKisi.Tahakkuk = text_tahakkuk.Text;
            if (DateTime.TryParse(text_sirkulertarih.Text, out date))
            {
                tuzelKisi.ImzaSirkulerTarih = Convert.ToDateTime(text_sirkulertarih.Text);
                if (tuzelKisi.ImzaSirkulerTarih > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                tuzelKisi.ImzaSirkulerTarih = null;
            }

            if (DateTime.TryParse(text_faaliyet.Text, out date))
            {
                tuzelKisi.FaaliyetBelgesi = Convert.ToDateTime(text_faaliyet.Text);
                if (tuzelKisi.FaaliyetBelgesi > DateTime.Today)
                {
                    MessageBox.Show("Faaliyet Belgesi tarihi bugünden ileri olamaz.", "Faaliyet Belgesi Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (DateTime.Today.DayOfYear - tuzelKisi.FaaliyetBelgesi?.DayOfYear > 60)
                {
                    MessageBox.Show("Faaliyet Belgesi dosyanız çok eski. Lütfen yeni bir Faaliyet Belgesi dosyası alın.", "Faaliyet Belgesi Eski", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                tuzelKisi.FaaliyetBelgesi = null;
            }

            if (DateTime.TryParse(text_ticaretsicil.Text, out date))
            {
                tuzelKisi.TicaretSicilGazetesi = Convert.ToDateTime(text_ticaretsicil.Text);
                if (tuzelKisi.TicaretSicilGazetesi > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                tuzelKisi.TicaretSicilGazetesi = null;
            }

            if (DateTime.TryParse(text_lastoperation.Text, out date))
            {
                tuzelKisi.SonİslemTarihi = Convert.ToDateTime(text_lastoperation.Text);
                if (tuzelKisi.SonİslemTarihi > DateTime.Today)
                {
                    MessageBox.Show("Son İşlem Tarihi bugünden ileri olamaz.", "Son İşlem Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                tuzelKisi.SonİslemTarihi = null;
            }


            if (radio_tim.Checked)
                tuzelKisi.TimImibSanayi = 1;
            else if (radio_imib.Checked)
                tuzelKisi.TimImibSanayi = 2;
            else if (radio_sanayi.Checked)
                tuzelKisi.TimImibSanayi = 3;
            else if (radio_none.Checked)
                tuzelKisi.TimImibSanayi = 0;
            else
            {
                MessageBox.Show("Gerekli seçim yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tuzelKisi.SonİslemAmac = text_opreason.Text;
            if(text_lastopcount.Text.Length > 0)
                tuzelKisi.SonİslemSayi = Convert.ToInt32(text_lastopcount.Text);
            //if (tuzelKisi.SonİslemSayi <= 0)
            //{
            //    MessageBox.Show("En az bir adet son işlem yapmış olmalısınız.", "Son İşlem Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            tuzelKisi.CerceveSozlesmesi = check_cerceve.Checked;
            tuzelKisi.KimlikKarti = check_kimlik.Checked;
            tuzelKisi.GercekFaydalaniciFormu = check_fayda.Checked;

            if (picture_signature.Image != null)
            {
                tuzelKisi.Imza = picture_signature.Image;
            }
            else
                tuzelKisi.Imza = null;
            tuzelKisi.Fotograf = picture_photo.Image;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                string formattedTelNo = tuzelKisi.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (güncellemeModu == false)
                {
                    query = "INSERT INTO dbo.TuzelKisi(donem, musteri_kodu, vergi_numarasi, ad_soyad, referans, telefon_no, is_baslangic_tarih, eposta_adres, gercek_faydalanici, sermaye, matrah, tahakkuk_vergi, imza_sirkuleri, son_islem_tarihi, son_islem_amaci, son_islem_sayisi, son_islem_tipi, kayit_tarih, vergi_dairesi, vergi_levhasi, dosya_cercevesozlesmesi, dosya_kimlik, dosya_faaliyetbelgesi, dosya_ticaretsicil, dosya_faydalaniciform, dosya_imza, dosya_fotograf) VALUES (@Donem, @MusteriKodu, @VergiNumarasi, @AdSoyad, @Referans, @Telefon, @Isebaslama, @Eposta, @GercekFaydalanici, @Sermaye, @Matrah, @Tahakkuk, @ImzaSirkulerTarih, @SonİslemTarihi, @SonİslemAmac, @SonİslemSayi, @TimImibSanayi, @KayitTarih, @VergiDairesi, @VergiLevhasi, @CerceveSozlesmesi, @KimlikKarti, @FaaliyetBelgesi, @TicaretSicil, @FaydalaniciForm, @Imza, @Fotograf);";
                }
                else if (güncellemeModu == true)
                {
                    query = "UPDATE dbo.TuzelKisi SET donem = @Donem, musteri_kodu = @MusteriKodu, vergi_dairesi = @VergiDairesi, vergi_numarasi = @VergiNumarasi, ad_soyad = @AdSoyad, referans = @Referans, telefon_no = @Telefon, is_baslangic_tarih = @Isebaslama, eposta_adres = @Eposta, gercek_faydalanici = @GercekFaydalanici, sermaye = @Sermaye, matrah = @Matrah, tahakkuk_vergi = @Tahakkuk, imza_sirkuleri = @ImzaSirkulerTarih, son_islem_tarihi = @SonİslemTarihi, son_islem_amaci = @SonİslemAmac, son_islem_sayisi = @SonİslemSayi, son_islem_tipi = @TimImibSanayi, dosya_cercevesozlesmesi = @CerceveSozlesmesi, dosya_kimlik = @KimlikKarti, dosya_faaliyetbelgesi = @FaaliyetBelgesi, dosya_ticaretsicil = @TicaretSicil, dosya_faydalaniciform = @FaydalaniciForm, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKodu2;";
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Donem", tuzelKisi.Donem);
                    command.Parameters.AddWithValue("@MusteriKodu", tuzelKisi.MusteriKodu);
                    command.Parameters.AddWithValue("@VergiDairesi", tuzelKisi.VergiDairesi);
                    command.Parameters.AddWithValue("@VergiNumarasi", tuzelKisi.VergiNumarasi);
                    command.Parameters.AddWithValue("@KayitTarih", DateTime.Today.Date);
                    command.Parameters.AddWithValue("@AdSoyad", tuzelKisi.AdSoyad);
                    if(güncellemeModu == true)
                        command.Parameters.AddWithValue("@MusteriKodu2", oldMusteriKod);
                    command.Parameters.AddWithValue("@Referans", tuzelKisi.Referans);
                    command.Parameters.AddWithValue("@Telefon", formattedTelNo != "" ? formattedTelNo : DBNull.Value);
                    command.Parameters.AddWithValue("@Isebaslama", tuzelKisi.Isebaslama != null ? tuzelKisi.Isebaslama : DBNull.Value);
                    command.Parameters.AddWithValue("@Eposta", tuzelKisi.Eposta != null ? tuzelKisi.Eposta : DBNull.Value);
                    command.Parameters.AddWithValue("@GercekFaydalanici", tuzelKisi.GercekFaydalanici != null ? tuzelKisi.GercekFaydalanici : DBNull.Value);
                    command.Parameters.AddWithValue("@Sermaye", tuzelKisi.Sermaye != null ? tuzelKisi.Sermaye : DBNull.Value);
                    command.Parameters.AddWithValue("@Matrah", tuzelKisi.Matrah != null ? tuzelKisi.Matrah : DBNull.Value);
                    command.Parameters.AddWithValue("@Tahakkuk", tuzelKisi.Tahakkuk != null ? tuzelKisi.Tahakkuk : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkulerTarih", tuzelKisi.ImzaSirkulerTarih != null ? tuzelKisi.ImzaSirkulerTarih : DBNull.Value);
                    command.Parameters.AddWithValue("@SonİslemTarihi", tuzelKisi.SonİslemTarihi != null ? tuzelKisi.SonİslemTarihi : DBNull.Value);
                    command.Parameters.AddWithValue("@SonİslemAmac", tuzelKisi.SonİslemAmac != null ? tuzelKisi.SonİslemAmac : DBNull.Value);
                    command.Parameters.AddWithValue("@SonİslemSayi", tuzelKisi.SonİslemSayi != null ? tuzelKisi.SonİslemSayi : DBNull.Value);
                    command.Parameters.AddWithValue("@TimImibSanayi", tuzelKisi.TimImibSanayi != null ? tuzelKisi.TimImibSanayi : DBNull.Value);
                    command.Parameters.AddWithValue("@CerceveSozlesmesi", tuzelKisi.CerceveSozlesmesi);
                    command.Parameters.AddWithValue("@KimlikKarti", tuzelKisi.KimlikKarti);
                    command.Parameters.AddWithValue("@VergiLevhasi", tuzelKisi.VergiLevhasi);
                    command.Parameters.AddWithValue("@FaaliyetBelgesi", tuzelKisi.FaaliyetBelgesi != null ? tuzelKisi.FaaliyetBelgesi : DBNull.Value);
                    command.Parameters.AddWithValue("@TicaretSicil", tuzelKisi.TicaretSicilGazetesi != null ? tuzelKisi.TicaretSicilGazetesi : DBNull.Value);
                    command.Parameters.AddWithValue("@FaydalaniciForm", tuzelKisi.GercekFaydalaniciFormu);

                    if (tuzelKisi.Imza != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            tuzelKisi.Imza.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();

                            command.Parameters.Add("@Imza", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Imza", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (tuzelKisi.Fotograf != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            tuzelKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();

                            command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = DBNull.Value;
                    }
                    string filePath = $"belgeler\\{tuzelKisi.Donem}\\{tuzelKisi.AdSoyad.Replace(".", "_").Replace(" ", "_")}";
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);

                    if (tuzelKisi.Imza != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            byte[] imageBytes;

                            tuzelKisi.Imza.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if(güncellemeModu == true)
                                tuzelKisi.Imza.Dispose();
                            string imzaPath = $"{filePath}\\imza.png";
                            File.WriteAllBytes(imzaPath, imageBytes);
                        }
                        
                    }
                    if (tuzelKisi.Fotograf != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            byte[] imageBytes;

                            tuzelKisi.Fotograf = picture_photo.Image;
                            tuzelKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if(güncellemeModu == true)
                                tuzelKisi.Fotograf.Dispose();
                            string fotoPath = $"{filePath}\\fotograf.png";
                            File.WriteAllBytes(fotoPath, imageBytes);
                        }  
                    }
                      
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        if (güncellemeModu == false)
                            MessageBox.Show($"{tuzelKisi.AdSoyad} isimli tüzel kişinin kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (güncellemeModu == true)
                                güncellemeModu = false;
                            button_save.Text = "Müşteriyi Kaydet";
                            button_update.Text = "Müşteri Güncelle";
                            MessageBox.Show($"{tuzelKisi.AdSoyad} isimli tüzel kişinin kaydı başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show($"{tuzelKisi.AdSoyad} isimli tüzel kişi zaten kayıtlı.", "Kayıt Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
        }

        private bool CheckIfRecordExists()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.TuzelKisi where musteri_kodu = @MusteriKod";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@MusteriKod", Convert.ToInt32(text_custcode.Text));
                    int result = (int)command.ExecuteScalar();
                    if(result > 0)
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
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            MüsteriGüncelle müsteriGüncelle = new MüsteriGüncelle(0);
            müsteriGüncelle.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MusteriSil müsteriSil = new MusteriSil(0);
            müsteriSil.Show();
        }

        private void text_custcode_TextChanged(object sender, EventArgs e)
        {
            checkInput(sender,e);
            if(Form1.satisRaporu != null)
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(Form1.satisRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    if(text_custcode.Text.Length > 0)
                    {
                        operationDates.Clear();
                        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                        {
                            if (Convert.ToInt32(worksheet.Cells[row, 58].Value) == Convert.ToInt32(text_custcode.Text))
                            {
                                text_namesurname.Text = worksheet.Cells[row, 11].Value != null ? worksheet.Cells[row, 11].Value.ToString() : null;
                                text_phone.Text = worksheet.Cells[row, 14].Value != null ? worksheet.Cells[row, 14].Value.ToString() : null;
                                text_taxnum.Text = worksheet.Cells[row, 40].Value != null ? worksheet.Cells[row, 40].Value.ToString() : null;
                                text_taxoffice.Text = worksheet.Cells[row, 17].Value != null ? worksheet.Cells[row, 17].Value.ToString() : null;
                                text_email.Text = worksheet.Cells[row, 45].Value != null ? worksheet.Cells[row, 45].Value?.ToString() : null;
                                try
                                {
                                    double dateValue = worksheet.Cells[row, 8].Value != null ? Convert.ToDouble(worksheet.Cells[row, 8].Value) : 0;
                                    MessageBox.Show(dateValue.ToString());
                                    DateTime date = DateTime.FromOADate(dateValue);
                                    operationDates.Add(date);
                                }
                                catch(System.InvalidCastException ex)
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
                            text_phone.Text = worksheet.Cells[row, 6].Value != null ? worksheet.Cells[row, 6].Value.ToString() : null;
                            text_taxoffice.Text = worksheet.Cells[row, 7].Value != null ? worksheet.Cells[row, 7].Value.ToString() : null;
                            text_reference.Text = worksheet.Cells[row, 13].Value != null ? worksheet.Cells[row,13].Value.ToString() : null;
                            text_email.Text = worksheet.Cells[row,20].Value != null ? worksheet.Cells[row, 20].Value.ToString() : null;
                            break;
                        }
                    }
                }
            }
        }
    }
}
