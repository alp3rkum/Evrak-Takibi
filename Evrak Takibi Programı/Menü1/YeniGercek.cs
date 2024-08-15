using Evrak_Takibi_Programı.Diğer;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Evrak_Takibi_Programı.YeniTuzel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evrak_Takibi_Programı
{
    public partial class YeniGercek : Form
    {
        List<DateTime> operationDates = new List<DateTime>();

        public GercekKisi yeniGercekKisi;
        public bool güncellemeModu;

        string gercekSozlesmeName = "";
        string kimlikName = "";
        string sirkulerName = "";
        string levhaName = "";
        string oldMusteriKod = "";

        public void OnGercekKisiChanged()
        {
            comboBox_donem.Text = yeniGercekKisi.Properties[1].ToString();
            text_custcode.Text = yeniGercekKisi.Properties[2].ToString();
            oldMusteriKod = text_custcode.Text;

            text_taxoffice.Text = yeniGercekKisi.Properties[19].ToString();
            text_taxnum.Text = yeniGercekKisi.Properties[3].ToString();
            text_tcid.Text = yeniGercekKisi.Properties[4].ToString();
            text_comptype.Text = yeniGercekKisi.Properties[5].ToString();
            text_namesurname.Text = yeniGercekKisi.Properties[6].ToString();
            text_reference.Text = yeniGercekKisi.Properties[7].ToString();
            text_phone.Text = yeniGercekKisi.Properties[8].ToString();
            text_date.Text = yeniGercekKisi.Properties[9].ToString();
            text_email.Text = yeniGercekKisi.Properties[10].ToString();
            text_sermaye.Text = yeniGercekKisi.Properties[11].ToString();
            txt_matrah.Text = yeniGercekKisi.Properties[12].ToString();
            text_tahakkuk.Text = yeniGercekKisi.Properties[13].ToString();
            text_sirkulertarih.Text = yeniGercekKisi.Properties[14].ToString();
            text_lastoperation.Text = yeniGercekKisi.Properties[15].ToString();
            switch (yeniGercekKisi.Properties[17])
            {
                case 0: radio_none.Checked = true; break;
                case 1: radio_tim.Checked = true; break;
                case 2: radio_imib.Checked = true; break;
                case 3: radio_sanayi.Checked = true; break;
            }
            text_opreason.Text = yeniGercekKisi.Properties[16].ToString();
            check_cerceve.Checked = (yeniGercekKisi.Properties[21] != DBNull.Value) ? Convert.ToBoolean(yeniGercekKisi.Properties[21]) : false;
            check_kimlik.Checked = (yeniGercekKisi.Properties[22] != DBNull.Value) ? Convert.ToBoolean(yeniGercekKisi.Properties[22]) : false;
            text_fax.Text = yeniGercekKisi.Properties[20].ToString();

            string directoryPath = Path.Combine("belgeler", comboBox_donem.Text, text_namesurname.Text);
            string? imzaPath = Path.Combine(directoryPath, "imza.png");
            if (File.Exists(imzaPath))
            {
                yeniGercekKisi.Imza = new Bitmap(imzaPath);
                pictureBox1.Image = yeniGercekKisi.Imza;
            }
            string? fotoPath = Path.Combine(directoryPath, "fotograf.png");
            if (File.Exists(fotoPath))
            {
                yeniGercekKisi.Fotograf = new Bitmap(fotoPath);
                pictureBox2.Image = yeniGercekKisi.Fotograf;
            }
            button_save.Text = "Müşteriyi Güncelle";
            button_update.Text = "Başka Müşteri Güncelle";
        }

        public class GercekKisi
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
            private string? vergiDairesi;
            private string? vergiLevhasi;
            private bool? cerceveSozlesmesi;
            private bool? kimlikKarti;
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
            public string? VergiDairesi { get => vergiDairesi; set => vergiDairesi = value; }
            public string? VergiLevhasi { get => vergiLevhasi; set => vergiLevhasi = value; }
            public bool? CerceveSozlesmesi { get => cerceveSozlesmesi; set => cerceveSozlesmesi = value; }
            public bool? KimlikKarti { get => kimlikKarti; set => kimlikKarti = value; }
            public Image? Imza { get => imza; set => imza = value; }
            public Image? Fotograf { get => fotograf; set => fotograf = value; }

            public GercekKisi()
            {
                var properties = typeof(GercekKisi).GetProperties();
                if (properties != null)
                {
                    for (int i = 0; i < typeof(GercekKisi).GetProperties().Length; i++)
                    {
                        Properties.Add(typeof(GercekKisi).GetProperties()[i]);
                    }
                }

            }


        }
        public YeniGercek()
        {
            InitializeComponent();
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                //years.Append(i);
                comboBox_donem.Items.Add(i.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fileDialog_imza.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_imza.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_imza.FileName;
                pictureBox1.Image = new Bitmap(filename);
                checkInput(sender, e);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fileDialog_picture.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_picture.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_picture.FileName;
                pictureBox2.Image = new Bitmap(filename);
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
            //button_save.Enabled = YeterliGirdilerGirili() && isEmail();
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private bool isEmail()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(text_email.Text);
        }

        private void comboBox_donem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //button_save.Enabled = YeterliGirdilerGirili() && isEmail();
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (HerhangiBirGirdiGirili())
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş girdileriniz var. Eğer devam ederseniz bu girdileri kaybedeceksiniz.\nYeni kişi girişi yapmak istiyor musunuz?", "Yeni Kişi Girişi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    BütünGirdileriTemizle();
                    pictureBox1.Image = null;
                    pictureBox2.Image = Properties.Resources.default_photo;
                    button_new.Enabled = false;
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (CheckIfRecordExists() && güncellemeModu == false)
            {
                MessageBox.Show("Müşteri zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GercekKisi gercekKisi = new GercekKisi();
            gercekKisi.Donem = Convert.ToInt32(comboBox_donem.Text);
            gercekKisi.MusteriKodu = text_custcode.Text;
            gercekKisi.VergiDairesi = text_taxoffice.Text;
            gercekKisi.VergiNumarasi = text_taxnum.Text;

            if (text_tcid.Text.Length == 11)
                gercekKisi.TcKimlik = text_tcid.Text;
            else
            {
                if(text_tcid.Text != "0")
                {
                    MessageBox.Show("TC Kimlik Numarası hatalı formatta.", "Girdi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    gercekKisi.TcKimlik = text_tcid.Text;
            }
            gercekKisi.SirketTipi = text_comptype.Text;
            gercekKisi.AdSoyad = text_namesurname.Text;
            gercekKisi.Referans = text_reference.Text;
            gercekKisi.Telefon = text_phone.Text;
            if (text_fax.Text != null)
                gercekKisi.VergiLevhasi = text_fax.Text;
            DateTime date;
            if (DateTime.TryParse(text_date.Text, out date))
            {
                gercekKisi.Isebaslama = Convert.ToDateTime(text_date.Text);
                if (gercekKisi.Isebaslama > DateTime.Today)
                {
                    MessageBox.Show("İş başlangıç tarihi bugünden ileri.", "İş Başlangıç Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                gercekKisi.Isebaslama = null;
            }
            if (text_email.Text.Length > 0 && isEmail())
                gercekKisi.Eposta = text_email.Text;
            else
            {
                MessageBox.Show("Doğru tür bir eposta girdisi girilmedi", "Eposta girdisi yanlış", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (text_sermaye.Text.Length > 0)
                gercekKisi.Sermaye = text_sermaye.Text;
            if (txt_matrah.Text.Length > 0)
                gercekKisi.Matrah = txt_matrah.Text;
            if (text_tahakkuk.Text.Length > 0)
                gercekKisi.Tahakkuk = text_tahakkuk.Text;
            if (DateTime.TryParse(text_sirkulertarih.Text, out date))
            {
                gercekKisi.ImzaSirkulerTarih = Convert.ToDateTime(text_sirkulertarih.Text);
                if (gercekKisi.ImzaSirkulerTarih > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                gercekKisi.ImzaSirkulerTarih = null;
            }

            if (DateTime.TryParse(text_lastoperation.Text, out date))
            {
                gercekKisi.SonİslemTarihi = Convert.ToDateTime(text_lastoperation.Text);
                if (gercekKisi.SonİslemTarihi > DateTime.Today)
                {
                    MessageBox.Show("Son İşlem Tarihi bugünden ileri olamaz.", "Son İşlem Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                gercekKisi.SonİslemTarihi = null;
            }

            if (radio_tim.Checked)
                gercekKisi.TimImibSanayi = 1;
            else if (radio_imib.Checked)
                gercekKisi.TimImibSanayi = 2;
            else if (radio_sanayi.Checked)
                gercekKisi.TimImibSanayi = 3;
            else if (radio_none.Checked)
                gercekKisi.TimImibSanayi = 0;
            else
            {
                MessageBox.Show("Gerekli seçim yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            gercekKisi.SonİslemAmac = text_opreason.Text;
            gercekKisi.CerceveSozlesmesi = check_cerceve.Checked;
            gercekKisi.KimlikKarti = check_kimlik.Checked;
            if (!(pictureBox1.Image == null))
            {
                gercekKisi.Imza = pictureBox1.Image;
            }
            gercekKisi.Fotograf = pictureBox2.Image;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                string formattedTelNo = gercekKisi.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (güncellemeModu == false)
                    query = "INSERT INTO dbo.GercekKisi(donem, musteri_kodu, vergi_numarasi, tc_kimlikno, sirket_tipi, ad_soyad, referans, telefon_no, is_baslangic_tarih, eposta_adres, sermaye, matrah, tahakkuk_vergi, imza_sirkuleri, son_islem_tarihi, son_islem_amaci, son_islem_tipi, kayit_tarih, vergi_dairesi, vergi_levhasi, dosya_cercevesozlesmesi, dosya_kimlik, dosya_imza, dosya_fotograf) VALUES (@Donem, @MusteriKodu, @VergiNumarasi, @TcKimlikNo, @SirketTipi, @AdSoyad, @Referans, @TelefonNo, @IsBaslangicTarih, @EpostaAdres, @Sermaye, @Matrah, @TahakkukVergi, @ImzaSirkuleri, @SonIslemTarihi, @SonIslemAmac, @SonIslemTipi, @KayitTarih, @VergiDairesi, @VergiLevhasi, @DosyaCerceveSozlesmesi, @DosyaKimlik, @DosyaImza, @DosyaFotograf);";
                else if (güncellemeModu == true)
                    query = "UPDATE dbo.GercekKisi SET donem = @Donem, musteri_kodu = @MusteriKodu, vergi_numarasi = @VergiNumarasi, tc_kimlikno = @TcKimlikNo, sirket_tipi = @SirketTipi, ad_soyad = @AdSoyad, referans = @Referans, telefon_no = @TelefonNo, is_baslangic_tarih = @IsBaslangicTarih, eposta_adres = @EpostaAdres, sermaye = @Sermaye, matrah = @Matrah, tahakkuk_vergi = @TahakkukVergi, imza_sirkuleri = @ImzaSirkuleri, son_islem_tarihi = @SonIslemTarihi, son_islem_amaci = @SonIslemAmac, son_islem_tipi = @SonIslemTipi, kayit_tarih = @KayitTarih, vergi_dairesi = @VergiDairesi, vergi_levhasi = @VergiLevhasi, dosya_cercevesozlesmesi = @DosyaCerceveSozlesmesi, dosya_kimlik = @DosyaKimlik, dosya_imza = @DosyaImza, dosya_fotograf = @DosyaFotograf WHERE musteri_kodu = @MusteriKodu2";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Donem", gercekKisi.Donem);
                    command.Parameters.AddWithValue("@MusteriKodu", gercekKisi.MusteriKodu);
                    if (güncellemeModu == true)
                    {
                        command.Parameters.AddWithValue("@MusteriKodu2", oldMusteriKod);
                    }
                        
                    command.Parameters.AddWithValue("@VergiNumarasi", gercekKisi.VergiNumarasi);
                    command.Parameters.AddWithValue("@TcKimlikNo", gercekKisi.TcKimlik);
                    command.Parameters.AddWithValue("@SirketTipi", gercekKisi.SirketTipi);
                    command.Parameters.AddWithValue("@AdSoyad", gercekKisi.AdSoyad);
                    command.Parameters.AddWithValue("@Referans", gercekKisi.Referans);
                    command.Parameters.AddWithValue("@TelefonNo", formattedTelNo != "" ? formattedTelNo : DBNull.Value);
                    command.Parameters.AddWithValue("@IsBaslangicTarih", gercekKisi.Isebaslama != null ? gercekKisi.Isebaslama : DBNull.Value);
                    command.Parameters.AddWithValue("@EpostaAdres", gercekKisi.Eposta != null ? gercekKisi.Eposta : DBNull.Value);
                    command.Parameters.AddWithValue("@Sermaye", gercekKisi.Sermaye != null ? gercekKisi.Sermaye : DBNull.Value);
                    command.Parameters.AddWithValue("@Matrah", gercekKisi.Matrah != null ? gercekKisi.Matrah : DBNull.Value);
                    command.Parameters.AddWithValue("@TahakkukVergi", gercekKisi.Tahakkuk != null ? gercekKisi.Tahakkuk : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkuleri", gercekKisi.ImzaSirkulerTarih != null ? gercekKisi.ImzaSirkulerTarih : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTarihi", gercekKisi.SonİslemTarihi != null ? gercekKisi.SonİslemTarihi : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemAmac", gercekKisi.SonİslemAmac != null ? gercekKisi.SonİslemAmac : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTipi", gercekKisi.TimImibSanayi);
                    command.Parameters.AddWithValue("@KayitTarih", DateTime.Today.Date);
                    command.Parameters.AddWithValue("@VergiDairesi", gercekKisi.VergiDairesi != null ? gercekKisi.VergiDairesi : DBNull.Value);
                    command.Parameters.AddWithValue("@VergiLevhasi", gercekKisi.VergiLevhasi != null ? gercekKisi.VergiLevhasi : DBNull.Value);
                    command.Parameters.AddWithValue("@DosyaCerceveSozlesmesi", gercekKisi.CerceveSozlesmesi != null ? gercekKisi.CerceveSozlesmesi : DBNull.Value);
                    command.Parameters.AddWithValue("@DosyaKimlik", gercekKisi.KimlikKarti);

                    if (gercekKisi.Imza != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            gercekKisi.Imza.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@DosyaImza", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@DosyaImza", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (gercekKisi.Fotograf != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            gercekKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@DosyaFotograf", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@DosyaFotograf", SqlDbType.Image).Value = DBNull.Value;
                    }
                    string filePath = $"belgeler\\{gercekKisi.Donem}\\{gercekKisi.AdSoyad.Replace(".", "_").Replace(" ", "_")}";
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        byte[] imageBytes;
                        if(gercekKisi.Imza != null)
                        {
                            gercekKisi.Imza.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if(güncellemeModu == true)
                                gercekKisi.Imza.Dispose();
                            string imzaPath = $"{filePath}\\imza.png";
                            File.WriteAllBytes(imzaPath, imageBytes);

                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }
                        
                        if(gercekKisi.Fotograf != null)
                        {
                            gercekKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                            imageBytes = memoryStream.ToArray();
                            if(güncellemeModu == true)
                                gercekKisi.Fotograf.Dispose();
                            string fotoPath = $"{filePath}\\fotograf.png";
                            File.WriteAllBytes(fotoPath, imageBytes);

                            memoryStream.Flush();
                        }
                        

                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        if (güncellemeModu == false)
                            MessageBox.Show($"{gercekKisi.AdSoyad} isimli gerçek kişinin kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (güncellemeModu == true)
                                güncellemeModu = false;
                            button_save.Text = "Müşteriyi Kaydet";
                            button_update.Text = "Müşteri Güncelle";
                            MessageBox.Show($"{gercekKisi.AdSoyad} isimli gerçek kişinin kaydı başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show($"{gercekKisi.AdSoyad} isimli gerçek kişi zaten kayıtlı.", "Kayıt Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
        }

        private bool CheckIfRecordExists()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.GercekKisi where musteri_kodu = @MusteriKod";
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
            MüsteriGüncelle müsteriGüncelle = new MüsteriGüncelle(1);
            müsteriGüncelle.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MusteriSil müsteriSil = new MusteriSil(1);
            müsteriSil.Show();
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
                            text_taxoffice.Text = worksheet.Cells[row, 7].Value != null ? worksheet.Cells[row, 7].Value.ToString() : null;
                            text_reference.Text = worksheet.Cells[row, 13].Value != null ? worksheet.Cells[row, 13].Value.ToString() : null;
                            text_email.Text = worksheet.Cells[row, 20].Value != null ? worksheet.Cells[row, 20].Value.ToString() : null;
                            break;
                        }
                    }
                }
            }
        }

        private void YeniGercek_Load(object sender, EventArgs e)
        {
            int year = comboBox_donem.Items.Count - 1;
            comboBox_donem.SelectedIndex = year;
        }
    }
}
