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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Evrak_Takibi_Programı.YeniGercek;
using static Evrak_Takibi_Programı.YeniSahis;
using static Evrak_Takibi_Programı.YeniTuzel;

namespace Evrak_Takibi_Programı
{
    public partial class YeniAdiOrtak : Form
    {
        internal FileInfo? ortaklikSozlesmesi;
        internal FileInfo? tahakkukFisi;
        internal FileInfo? cerceveSozlesmesi1;
        internal FileInfo? kimlikKarti1;
        internal FileInfo? imzaSirkuleri1;
        internal FileInfo? vergiLevhasi1;
        internal FileInfo? faaliyetBelgesi1;
        internal FileInfo? cerceveSozlesmesi2;
        internal FileInfo? kimlikKarti2;
        internal FileInfo? imzaSirkuleri2;
        internal FileInfo? vergiLevhasi2;
        internal FileInfo? faaliyetBelgesi2;
        internal FileInfo? adiOrtaklikSozlesmesi;
        internal FileInfo? tahakkukSozlesmesi;

        public AdiOrtaklik yeniAdiOrtaklik;
        public bool güncellemeModu;
        string oldMusteriKod = "";

        List<DateTime> operationDates = new List<DateTime>();

        public void OnAdiOrtaklikChanged()
        {
            comboBox_donem.Text = yeniAdiOrtaklik.Properties[1].ToString();
            text_custcode.Text = yeniAdiOrtaklik.Properties[2].ToString();
            oldMusteriKod = text_custcode.Text;
            text_taxoffice.Text = yeniAdiOrtaklik.Properties[23].ToString();
            text_comptype.Text = yeniAdiOrtaklik.Properties[3].ToString();
            text_namesurname.Text = yeniAdiOrtaklik.Properties[4].ToString();
            text_reference.Text = yeniAdiOrtaklik.Properties[5].ToString();
            text_phone.Text = yeniAdiOrtaklik.Properties[6].ToString();
            text_date.Text = yeniAdiOrtaklik.Properties[7].ToString();
            text_email.Text = yeniAdiOrtaklik.Properties[8].ToString();
            text_sermaye.Text = yeniAdiOrtaklik.Properties[9].ToString();
            txt_matrah.Text = yeniAdiOrtaklik.Properties[10].ToString();
            text_tahakkuk.Text = yeniAdiOrtaklik.Properties[11].ToString();
            text_sirkulertarih.Text = yeniAdiOrtaklik.Properties[12].ToString();
            text_lastoperation.Text = yeniAdiOrtaklik.Properties[13].ToString();
            text_opreason.Text = yeniAdiOrtaklik.Properties[14].ToString();
            switch (yeniAdiOrtaklik.Properties[15])
            {
                case 0: radio_none.Checked = true; break;
                case 1: radio_tim.Checked = true; break;
                case 2: radio_imib.Checked = true; break;
                case 3: radio_sanayi.Checked = true; break;
            }
            text_taxnum1.Text = yeniAdiOrtaklik.Properties[16].ToString();
            text_tcid1.Text = yeniAdiOrtaklik.Properties[17].ToString();
            text_gerfayda.Text = yeniAdiOrtaklik.Properties[18].ToString();
            textBox1.Text = yeniAdiOrtaklik.Properties[19].ToString();
            textBox2.Text = yeniAdiOrtaklik.Properties[20].ToString();
            textBox3.Text = yeniAdiOrtaklik.Properties[21].ToString();

            check_ortaklik.Checked = (yeniAdiOrtaklik.Properties[24] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[24]) : false;
            check_tahakkuk.Checked = (yeniAdiOrtaklik.Properties[25] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[25]) : false;

            check_cerceve1.Checked = (yeniAdiOrtaklik.Properties[26] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[26]) : false;
            check_cerceve2.Checked = (yeniAdiOrtaklik.Properties[34] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[34]) : false;
            check_kimlik1.Checked = (yeniAdiOrtaklik.Properties[27] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[27]) : false;
            check_kimlik2.Checked = (yeniAdiOrtaklik.Properties[35] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[35]) : false;
            check_fayda1.Checked = (yeniAdiOrtaklik.Properties[31] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[31]) : false;
            check_fayda2.Checked = (yeniAdiOrtaklik.Properties[39] != DBNull.Value) ? Convert.ToBoolean(yeniAdiOrtaklik.Properties[39]) : false;
            text_sirkuler1.Text = yeniAdiOrtaklik.Properties[28].ToString();
            text_sirkuler2.Text = yeniAdiOrtaklik.Properties[36].ToString();
            text_vergilevha1.Text = yeniAdiOrtaklik.Properties[29].ToString();
            text_vergilevha2.Text = yeniAdiOrtaklik.Properties[37].ToString();
            text_faaliyet1.Text = yeniAdiOrtaklik.Properties[30].ToString();
            text_faaliyet2.Text = yeniAdiOrtaklik.Properties[38].ToString();
            string directoryPath = Path.Combine("belgeler", comboBox_donem.Text, text_namesurname.Text);
            string imza1Path = Path.Combine(directoryPath, "ortak1_imza.png");
            if (File.Exists(imza1Path))
            {
                yeniAdiOrtaklik.Imza_Ortak1 = new Bitmap(imza1Path);
                picture_signature.Image = yeniAdiOrtaklik.Imza_Ortak1;
            }
            string foto1Path = Path.Combine(directoryPath, "ortak1_fotograf.png");
            if (File.Exists(foto1Path))
            {
                yeniAdiOrtaklik.Fotograf_Ortak1 = new Bitmap(foto1Path);
                picture_photo.Image = yeniAdiOrtaklik.Fotograf_Ortak1;
            }
            string imza2Path = Path.Combine(directoryPath, "ortak2_imza.png");
            if (File.Exists(imza2Path))
            {
                yeniAdiOrtaklik.Imza_Ortak2 = new Bitmap(imza1Path);
                pictureBox1.Image = yeniAdiOrtaklik.Imza_Ortak2;
            }
            string foto2Path = Path.Combine(directoryPath, "ortak2_fotograf.png");
            if (File.Exists(foto2Path))
            {
                yeniAdiOrtaklik.Fotograf_Ortak2 = new Bitmap(foto1Path);
                pictureBox2.Image = yeniAdiOrtaklik.Fotograf_Ortak2;
            }
            button_save.Text = "Müşteriyi Güncelle";
            button_update.Text = "Başka Müşteri Güncelle";
        }

        public class AdiOrtaklik
        {
            private int donem;
            private string musteriKodu;
            private string vergiDairesi;
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

            private int? vergiNo_Ortak1;
            private string? tcno_Ortak1;
            private string? faydalanici_Ortak1;
            private int? vergiNo_Ortak2;
            private string? tcno_Ortak2;
            private string? faydalanici_Ortak2;

            private bool? ortaklikSozlesmesi;
            private bool? tahakkukFisi;

            private bool? cerceveSozlesmesi_Ortak1;
            private bool? kimlikKarti_Ortak1;
            private DateTime? imzaSirkuleri_Ortak1;
            private string? vergiLevhasi_Ortak1;
            private DateTime? faaliyetBelgesi_Ortak1;
            private bool faydalaniciForm_Ortak1;
            private Image? imza_Ortak1;
            private Image? fotograf_Ortak1;

            private bool? cerceveSozlesmesi_Ortak2;
            private bool? kimlikKarti_Ortak2;
            private DateTime? imzaSirkuleri_Ortak2;
            private string? vergiLevhasi_Ortak2;
            private DateTime? faaliyetBelgesi_Ortak2;
            private bool faydalaniciForm_Ortak2;
            private Image? imza_Ortak2;
            private Image? fotograf_Ortak2;

            internal List<object> Properties = new List<object>();

            public int Donem { get => donem; set => donem = value; }
            public string MusteriKodu { get => musteriKodu; set => musteriKodu = value; }
            public string VergiDairesi { get => vergiDairesi; set => vergiDairesi = value; }
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
            public int? VergiNo_Ortak1 { get => vergiNo_Ortak1; set => vergiNo_Ortak1 = value; }
            public string? Tcno_Ortak1 { get => tcno_Ortak1; set => tcno_Ortak1 = value; }
            public string? Faydalanici_Ortak1 { get => faydalanici_Ortak1; set => faydalanici_Ortak1 = value; }
            public int? VergiNo_Ortak2 { get => vergiNo_Ortak2; set => vergiNo_Ortak2 = value; }
            public string? Tcno_Ortak2 { get => tcno_Ortak2; set => tcno_Ortak2 = value; }
            public string? Faydalanici_Ortak2 { get => faydalanici_Ortak2; set => faydalanici_Ortak2 = value; }
            public bool? OrtaklikSozlesmesi { get => ortaklikSozlesmesi; set => ortaklikSozlesmesi = value; }
            public bool? TahakkukFisi { get => tahakkukFisi; set => tahakkukFisi = value; }
            public bool? CerceveSozlesmesi_Ortak1 { get => cerceveSozlesmesi_Ortak1; set => cerceveSozlesmesi_Ortak1 = value; }
            public bool? KimlikKarti_Ortak1 { get => kimlikKarti_Ortak1; set => kimlikKarti_Ortak1 = value; }
            public DateTime? ImzaSirkuleri_Ortak1 { get => imzaSirkuleri_Ortak1; set => imzaSirkuleri_Ortak1 = value; }
            public string? VergiLevhasi_Ortak1 { get => vergiLevhasi_Ortak1; set => vergiLevhasi_Ortak1 = value; }
            public DateTime? FaaliyetBelgesi_Ortak1 { get => faaliyetBelgesi_Ortak1; set => faaliyetBelgesi_Ortak1 = value; }
            public Image? Imza_Ortak1 { get => imza_Ortak1; set => imza_Ortak1 = value; }
            public Image? Fotograf_Ortak1 { get => fotograf_Ortak1; set => fotograf_Ortak1 = value; }
            public bool? CerceveSozlesmesi_Ortak2 { get => cerceveSozlesmesi_Ortak2; set => cerceveSozlesmesi_Ortak2 = value; }
            public bool? KimlikKarti_Ortak2 { get => kimlikKarti_Ortak2; set => kimlikKarti_Ortak2 = value; }
            public DateTime? ImzaSirkuleri_Ortak2 { get => imzaSirkuleri_Ortak2; set => imzaSirkuleri_Ortak2 = value; }
            public string? VergiLevhasi_Ortak2 { get => vergiLevhasi_Ortak2; set => vergiLevhasi_Ortak2 = value; }
            public DateTime? FaaliyetBelgesi_Ortak2 { get => faaliyetBelgesi_Ortak2; set => faaliyetBelgesi_Ortak2 = value; }
            public Image? Imza_Ortak2 { get => imza_Ortak2; set => imza_Ortak2 = value; }
            public Image? Fotograf_Ortak2 { get => fotograf_Ortak2; set => fotograf_Ortak2 = value; }
            public bool FaydalaniciForm_Ortak1 { get => faydalaniciForm_Ortak1; set => faydalaniciForm_Ortak1 = value; }
            public bool FaydalaniciForm_Ortak2 { get => faydalaniciForm_Ortak2; set => faydalaniciForm_Ortak2 = value; }

            public AdiOrtaklik()
            {
                var properties = typeof(AdiOrtaklik).GetProperties();
                if (properties != null)
                {
                    for (int i = 0; i < typeof(AdiOrtaklik).GetProperties().Length; i++)
                    {
                        Properties.Add(typeof(AdiOrtaklik).GetProperties()[i]);
                    }
                }
            }


        }
        public YeniAdiOrtak()
        {
            InitializeComponent();
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                //years.Append(i);
                comboBox_donem.Items.Add(i.ToString());
            }
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
            fileDialog_imza.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_imza.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_imza.FileName;
                picture_photo.Image = new Bitmap(filename);
                checkInput(sender, e);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fileDialog_document.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp|PDF Dosyası|*.pdf";
            if (fileDialog_document.ShowDialog() == DialogResult.OK)
            {
                faaliyetBelgesi2 = new FileInfo(fileDialog_document.FileName);
                MessageBox.Show("2. Ortak Faaliyet Belgesi dosyası başarıyla alındı!", "2. Ortak Faaliyet Belgesi İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button_new_Click(object sender, EventArgs e)
        {
            if (HerhangiBirGirdiGirili())
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş girdileriniz var. Eğer devam ederseniz bu girdileri kaybedeceksiniz.\nYeni kişi girişi yapmak istiyor musunuz?", "Yeni Kişi Girişi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    BütünGirdileriTemizle();
                    cerceveSozlesmesi1 = kimlikKarti1 = imzaSirkuleri1 = vergiLevhasi1 = faaliyetBelgesi1 = null;
                    cerceveSozlesmesi2 = kimlikKarti2 = imzaSirkuleri2 = vergiLevhasi2 = faaliyetBelgesi2 = null;
                    adiOrtaklikSozlesmesi = null;
                    tahakkukSozlesmesi = null;
                    picture_signature.Image = pictureBox1.Image = null;
                    picture_photo.Image = pictureBox2.Image = Properties.Resources.default_photo;
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
            AdiOrtaklik adiOrtaklik = new AdiOrtaklik();
            adiOrtaklik.Donem = Convert.ToInt32(comboBox_donem.Text);
            adiOrtaklik.MusteriKodu = text_custcode.Text;
            adiOrtaklik.VergiDairesi = text_taxoffice.Text;
            adiOrtaklik.SirketTipi = text_comptype.Text;
            adiOrtaklik.AdSoyad = text_namesurname.Text;
            adiOrtaklik.Referans = text_reference.Text;
            adiOrtaklik.Telefon = text_phone.Text;

            adiOrtaklik.Faydalanici_Ortak1 = text_gerfayda.Text;
            adiOrtaklik.Faydalanici_Ortak2 = textBox3.Text;
            //if (text_fax.Text != null || text_fax.Text.Length > 0)
            //    adiOrtaklik.Faks = text_fax.Text;
            DateTime date;
            if (DateTime.TryParse(text_date.Text, out date))
            {
                adiOrtaklik.Isebaslama = Convert.ToDateTime(text_date.Text);
                if (adiOrtaklik.Isebaslama > DateTime.Today)
                {
                    MessageBox.Show("İş başlangıç tarihi bugünden ileri.", "İş Başlangıç Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.Isebaslama = null;
            }

            if (text_email.Text.Length > 0 && isEmail())
                adiOrtaklik.Eposta = text_email.Text;
            if (text_sermaye.Text.Length > 0)
                adiOrtaklik.Sermaye = text_sermaye.Text;
            if (txt_matrah.Text.Length > 0)
                adiOrtaklik.Matrah = txt_matrah.Text;
            if (text_tahakkuk.Text.Length > 0)
                adiOrtaklik.Tahakkuk = text_tahakkuk.Text;
            if (DateTime.TryParse(text_sirkulertarih.Text, out date))
            {
                adiOrtaklik.ImzaSirkulerTarih = Convert.ToDateTime(text_sirkulertarih.Text);
                if (adiOrtaklik.ImzaSirkulerTarih > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (DateTime.TryParse(text_lastoperation.Text, out date))
            {
                adiOrtaklik.SonİslemTarihi = Convert.ToDateTime(text_lastoperation.Text);
                if (adiOrtaklik.SonİslemTarihi > DateTime.Today)
                {
                    MessageBox.Show("Son İşlem Tarihi bugünden ileri olamaz.", "Son İşlem Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.SonİslemTarihi = null;
            }

            if (radio_tim.Checked)
                adiOrtaklik.TimImibSanayi = 1;
            else if (radio_imib.Checked)
                adiOrtaklik.TimImibSanayi = 2;
            else if (radio_sanayi.Checked)
                adiOrtaklik.TimImibSanayi = 3;
            else if (radio_none.Checked)
                adiOrtaklik.TimImibSanayi = 0;
            else
            {
                MessageBox.Show("Gerekli seçim yapılmadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            adiOrtaklik.SonİslemAmac = text_opreason.Text;
            adiOrtaklik.OrtaklikSozlesmesi = check_ortaklik.Checked;
            adiOrtaklik.TahakkukFisi = check_tahakkuk.Checked;
            adiOrtaklik.CerceveSozlesmesi_Ortak1 = check_cerceve1.Checked;
            adiOrtaklik.CerceveSozlesmesi_Ortak2 = check_cerceve2.Checked;
            adiOrtaklik.KimlikKarti_Ortak1 = check_kimlik1.Checked;
            adiOrtaklik.KimlikKarti_Ortak2 = check_kimlik2.Checked;
            adiOrtaklik.Tcno_Ortak1 = text_tcid1.Text;
            adiOrtaklik.Tcno_Ortak2 = textBox2.Text;

            if (DateTime.TryParse(text_sirkuler1.Text, out date))
            {
                adiOrtaklik.ImzaSirkuleri_Ortak1 = Convert.ToDateTime(text_sirkuler1.Text);
                if(adiOrtaklik.ImzaSirkuleri_Ortak1 > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.ImzaSirkuleri_Ortak1 = null;
            }
            
            if (DateTime.TryParse(text_sirkuler1.Text, out date))
            {
                adiOrtaklik.ImzaSirkuleri_Ortak2 = Convert.ToDateTime(text_sirkuler2.Text);
                if (adiOrtaklik.ImzaSirkuleri_Ortak2 > DateTime.Today)
                {
                    MessageBox.Show("İmza Sirküleri tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.ImzaSirkuleri_Ortak2 = null;
            }
            int parseVal;
            if (int.TryParse(text_taxnum1.Text,out parseVal))
                adiOrtaklik.VergiNo_Ortak1 = Convert.ToInt32(text_taxnum1.Text);
            else
                adiOrtaklik.VergiNo_Ortak1 = null;

            if (int.TryParse(textBox1.Text, out parseVal))
                adiOrtaklik.VergiNo_Ortak2 = Convert.ToInt32(textBox1.Text);
            else
                adiOrtaklik.VergiNo_Ortak2 = null;

            if(int.TryParse(text_vergilevha1.Text, out parseVal))
                adiOrtaklik.VergiLevhasi_Ortak1 = text_vergilevha1.Text;
            else
                adiOrtaklik.VergiLevhasi_Ortak1 = null;

            if(int.TryParse(text_vergilevha2.Text, out parseVal))
                adiOrtaklik.VergiLevhasi_Ortak2 = text_vergilevha2.Text;
            else
                adiOrtaklik.VergiLevhasi_Ortak2 = null;

            if (DateTime.TryParse(text_faaliyet1.Text, out date))
            {
                adiOrtaklik.FaaliyetBelgesi_Ortak1 = Convert.ToDateTime(text_faaliyet1.Text);
                if (adiOrtaklik.FaaliyetBelgesi_Ortak1 > DateTime.Today)
                {
                    MessageBox.Show("Faaliyet Belgesi tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.FaaliyetBelgesi_Ortak1 = null;
            }
                
            
            if (DateTime.TryParse(text_faaliyet1.Text, out date))
            {
                adiOrtaklik.FaaliyetBelgesi_Ortak2 = Convert.ToDateTime(text_faaliyet2.Text);
                if (adiOrtaklik.FaaliyetBelgesi_Ortak2 > DateTime.Today)
                {
                    MessageBox.Show("Faaliyet Belgesi tarihi bugünden ileri olamaz.", "İmza Sirküleri Tarihi Çok İleri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                adiOrtaklik.FaaliyetBelgesi_Ortak2 = null;
            }

            adiOrtaklik.FaydalaniciForm_Ortak1 = check_fayda1.Checked;
            adiOrtaklik.FaydalaniciForm_Ortak2 = check_fayda2.Checked;

            if (!(picture_signature.Image == null))
            {
                adiOrtaklik.Imza_Ortak1 = picture_signature.Image;
            }
            adiOrtaklik.Fotograf_Ortak1 = picture_photo.Image;

            if (!(pictureBox1.Image == null))
            {
                adiOrtaklik.Imza_Ortak2 = pictureBox1.Image;
            }
            adiOrtaklik.Fotograf_Ortak2 = pictureBox2.Image;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                string formattedTelNo = adiOrtaklik.Telefon.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (güncellemeModu == false)
                    query = $"INSERT INTO dbo.AdiOrtaklik(donem,musteri_kodu,sirket_tipi,ad_soyad,referans,telefon_no,is_baslangic_tarih,eposta_adres,sermaye,matrah,tahakkuk_vergi,imza_sirkuleri,son_islem_tarihi,son_islem_amaci,son_islem_tipi,ortak1_vergino,ortak1_tcno,ortak1_faydalanici,ortak2_vergino,ortak2_tcno,ortak2_faydalanici,vergi_dairesi,dosya_ortakliksozlesmesi,dosya_tahakkukfisi,dosya_ortak1cerceve,dosya_ortak1kimlik,dosya_ortak1sirkuler,dosya_ortak1vergilevha,dosya_ortak1faaliyetbelge,dosya_ortak1faydalanici,dosya_ortak1imza,dosya_ortak1fotograf,dosya_ortak2cerceve,dosya_ortak2kimlik,dosya_ortak2sirkuler,dosya_ortak2vergilevha,dosya_ortak2faaliyetbelge,dosya_ortak2faydalanici,dosya_ortak2imza,dosya_ortak2fotograf, kayit_tarih) VALUES (@Donem,@MusteriKodu,@SirketTipi,@AdSoyad,@Referans,@TelefonNo,@IsBaslangicTarih,@Eposta,@Sermaye,@Matrah,@Tahakkuk,@ImzaSirkuleri,@SonIslemTarihi,@SonIslemAmaci,@SonIslemTipi,@VergiNo1,@TCNO1,@Faydalanici1,@VergiNo2,@TCNO2,@Faydalanici2,@VergiDairesi,@OrtaklikSozlesmesi,@TahakkukFisi,@CerceveSozlesmesi1,@KimlikKarti1,@ImzaSirkuleri1,@VergiLevhasi1,@FaaliyetBelgesi1,@FaydalaniciForm1,@Imza1,@Fotograf1,@CerceveSozlesmesi2,@KimlikKarti2,@ImzaSirkuleri2,@VergiLevhasi2,@FaaliyetBelgesi2,@FaydalaniciForm2,@Imza2,@Fotograf2,@KayitTarih)";
                else
                    query = $"UPDATE dbo.AdiOrtaklik SET donem = @Donem, musteri_kodu = @MusteriKodu, vergi_dairesi = @VergiDairesi, sirket_tipi = @SirketTipi, referans = @Referans, telefon_no = @TelefonNo, is_baslangic_tarih = @IsBaslangicTarih, eposta_adres = @Eposta, sermaye = @Sermaye, matrah = @Matrah, tahakkuk_vergi = @Tahakkuk, imza_sirkuleri = @ImzaSirkuleri, son_islem_tarihi = @SonIslemTarihi, son_islem_amaci = @SonIslemAmaci, son_islem_tipi = @SonIslemTipi, ortak1_vergino = @VergiNo1, ortak1_tcno = @TCNO1, ortak1_faydalanici = @Faydalanici1, ortak2_vergino = @VergiNo2, ortak2_tcno = @TCNO2, ortak2_faydalanici = @Faydalanici2, dosya_ortakliksozlesmesi = @OrtaklikSozlesmesi, dosya_tahakkukfisi = @TahakkukFisi, dosya_ortak1cerceve = @CerceveSozlesmesi1, dosya_ortak1kimlik = @KimlikKarti1, dosya_ortak1sirkuler = @ImzaSirkuleri1, dosya_ortak1vergilevha = @VergiLevhasi1, dosya_ortak1faaliyetbelge = @FaaliyetBelgesi1, dosya_ortak1imza = @Imza1, dosya_ortak1fotograf = @Fotograf1, dosya_ortak2cerceve = @CerceveSozlesmesi2, dosya_ortak2kimlik = @KimlikKarti2, dosya_ortak2sirkuler = @ImzaSirkuleri2, dosya_ortak2vergilevha = @VergiLevhasi2, dosya_ortak2faaliyetbelge = @FaaliyetBelgesi2, dosya_ortak2imza = @Imza2, dosya_ortak2fotograf = @Fotograf2 WHERE musteri_kodu = @MusteriKodu2";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Donem", adiOrtaklik.Donem);
                    command.Parameters.AddWithValue("@MusteriKodu", adiOrtaklik.MusteriKodu);
                    command.Parameters.AddWithValue("@VergiDairesi", adiOrtaklik.VergiDairesi);
                    command.Parameters.AddWithValue("@SirketTipi", adiOrtaklik.SirketTipi);
                    if (güncellemeModu == false)
                    {
                        command.Parameters.AddWithValue("@KayitTarih", DateTime.Today.Date);
                        command.Parameters.AddWithValue("@AdSoyad", adiOrtaklik.AdSoyad);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MusteriKodu2", oldMusteriKod);
                        command.Parameters.AddWithValue("@AdSoyad", adiOrtaklik.AdSoyad);
                    }
                    command.Parameters.AddWithValue("@Referans", adiOrtaklik.Referans);
                    command.Parameters.AddWithValue("@TelefonNo", formattedTelNo != "" ? formattedTelNo : DBNull.Value);
                    command.Parameters.AddWithValue("@IsBaslangicTarih", adiOrtaklik.Isebaslama != null ? adiOrtaklik.Isebaslama : DBNull.Value);
                    command.Parameters.AddWithValue("@Eposta", adiOrtaklik.Eposta != null ? adiOrtaklik.Eposta : DBNull.Value);
                    command.Parameters.AddWithValue("@Sermaye", adiOrtaklik.Sermaye != null ? adiOrtaklik.Sermaye : DBNull.Value);
                    command.Parameters.AddWithValue("@Matrah", adiOrtaklik.Matrah != null ? adiOrtaklik.Matrah : DBNull.Value);
                    command.Parameters.AddWithValue("@Tahakkuk", adiOrtaklik.Tahakkuk != null ? adiOrtaklik.Tahakkuk : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkuleri", adiOrtaklik.ImzaSirkulerTarih != null ? adiOrtaklik.ImzaSirkulerTarih : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTarihi", adiOrtaklik.SonİslemTarihi != null ? adiOrtaklik.SonİslemTarihi : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemAmaci", adiOrtaklik.SonİslemAmac != null ? adiOrtaklik.SonİslemAmac : DBNull.Value);
                    command.Parameters.AddWithValue("@SonIslemTipi", adiOrtaklik.TimImibSanayi != null ? adiOrtaklik.TimImibSanayi : DBNull.Value);
                    command.Parameters.AddWithValue("@VergiNo1", adiOrtaklik.VergiNo_Ortak1 != null ? adiOrtaklik.VergiNo_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@TCNO1", adiOrtaklik.Tcno_Ortak1 != null ? adiOrtaklik.Tcno_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@Faydalanici1", adiOrtaklik.Faydalanici_Ortak1 != null ? adiOrtaklik.Faydalanici_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@VergiNo2", adiOrtaklik.VergiNo_Ortak2 != null ? adiOrtaklik.VergiNo_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@TCNO2", adiOrtaklik.Tcno_Ortak2 != null ? adiOrtaklik.Tcno_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@Faydalanici2", adiOrtaklik.Faydalanici_Ortak2 != null ? adiOrtaklik.Faydalanici_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@OrtaklikSozlesmesi", adiOrtaklik.OrtaklikSozlesmesi != null ? adiOrtaklik.OrtaklikSozlesmesi : DBNull.Value);
                    command.Parameters.AddWithValue("@TahakkukFisi", adiOrtaklik.TahakkukFisi != null ? adiOrtaklik.TahakkukFisi : DBNull.Value);
                    command.Parameters.AddWithValue("@CerceveSozlesmesi1", adiOrtaklik.CerceveSozlesmesi_Ortak1 != null ? adiOrtaklik.CerceveSozlesmesi_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@KimlikKarti1", adiOrtaklik.KimlikKarti_Ortak1 != null ? adiOrtaklik.KimlikKarti_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkuleri1", adiOrtaklik.ImzaSirkuleri_Ortak1 != null ? adiOrtaklik.ImzaSirkuleri_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@VergiLevhasi1", adiOrtaklik.VergiLevhasi_Ortak1 != null ? adiOrtaklik.VergiLevhasi_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@FaaliyetBelgesi1", adiOrtaklik.FaaliyetBelgesi_Ortak1 != null ? adiOrtaklik.FaaliyetBelgesi_Ortak1 : DBNull.Value);
                    command.Parameters.AddWithValue("@FaydalaniciForm1", adiOrtaklik.FaydalaniciForm_Ortak1);
                    command.Parameters.AddWithValue("@CerceveSozlesmesi2", adiOrtaklik.CerceveSozlesmesi_Ortak2 != null ? adiOrtaklik.CerceveSozlesmesi_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@KimlikKarti2", adiOrtaklik.KimlikKarti_Ortak2 != null ? adiOrtaklik.KimlikKarti_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@ImzaSirkuleri2", adiOrtaklik.ImzaSirkuleri_Ortak2 != null ? adiOrtaklik.ImzaSirkuleri_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@VergiLevhasi2", adiOrtaklik.VergiLevhasi_Ortak2 != null ? adiOrtaklik.VergiLevhasi_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@FaaliyetBelgesi2", adiOrtaklik.FaaliyetBelgesi_Ortak2 != null ? adiOrtaklik.FaaliyetBelgesi_Ortak2 : DBNull.Value);
                    command.Parameters.AddWithValue("@FaydalaniciForm2", adiOrtaklik.FaydalaniciForm_Ortak2);
                    if (adiOrtaklik.Imza_Ortak1 != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            adiOrtaklik.Imza_Ortak1.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Imza1", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Imza1", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (adiOrtaklik.Fotograf_Ortak1 != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            adiOrtaklik.Fotograf_Ortak1.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Fotograf1", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Fotograf1", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (adiOrtaklik.Imza_Ortak2 != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            adiOrtaklik.Imza_Ortak2.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Imza2", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Imza2", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (adiOrtaklik.Fotograf_Ortak2 != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            adiOrtaklik.Fotograf_Ortak2.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Fotograf2", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Fotograf2", SqlDbType.Image).Value = DBNull.Value;
                    }
                    string filePath = $"belgeler\\{adiOrtaklik.Donem}\\{adiOrtaklik.AdSoyad.Replace(".", "_").Replace(" ", "_")}";
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {

                        if (adiOrtaklik.Imza_Ortak1 != null)
                        {
                            adiOrtaklik.Imza_Ortak1.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                adiOrtaklik.Imza_Ortak1.Dispose();
                            string imzaPath = $"{filePath}\\ortak1_imza.png";
                            File.WriteAllBytes(imzaPath, imageBytes);
                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }
                        if (adiOrtaklik.Fotograf_Ortak1 != null)
                        {
                            adiOrtaklik.Fotograf_Ortak1.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                adiOrtaklik.Fotograf_Ortak1.Dispose();
                            string fotoPath = $"{filePath}\\ortak1_fotograf.png";
                            File.WriteAllBytes(fotoPath, imageBytes);
                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }

                        if (adiOrtaklik.Imza_Ortak2 != null)
                        {
                            adiOrtaklik.Imza_Ortak2.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                adiOrtaklik.Imza_Ortak2.Dispose();
                            string imzaPath = $"{filePath}\\ortak2_imza.png";
                            File.WriteAllBytes(imzaPath, imageBytes);
                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }
                        if (adiOrtaklik.Fotograf_Ortak2 != null)
                        {
                            adiOrtaklik.Fotograf_Ortak2.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            if (güncellemeModu == true)
                                adiOrtaklik.Fotograf_Ortak2.Dispose();
                            string fotoPath = $"{filePath}\\ortak2_fotograf.png";
                            File.WriteAllBytes(fotoPath, imageBytes);
                            memoryStream.Flush();
                            memoryStream.SetLength(0);
                        }
                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        if (güncellemeModu == false)
                            MessageBox.Show($"{adiOrtaklik.AdSoyad} isimli adi ortaklığın kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            if (güncellemeModu == true)
                                güncellemeModu = false;
                            button_save.Text = "Müşteriyi Kaydet";
                            button_update.Text = "Müşteri Güncelle";
                            MessageBox.Show($"{adiOrtaklik.AdSoyad} isimli adi ortaklığın kaydı başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show($"{adiOrtaklik.AdSoyad} isimli adi ortaklık zaten kayıtlı.", "Kayıt Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
            }
        }

        private bool CheckIfRecordExists()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.AdiOrtaklik where musteri_kodu = @MusteriKod";
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
            MüsteriGüncelle müsteriGüncelle = new MüsteriGüncelle(3);
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
                                text_email.Text = worksheet.Cells[row, 45].Value != null ? worksheet.Cells[row, 45].Value?.ToString() : null;
                                double dateValue = worksheet.Cells[row, 8].Value != null ? Convert.ToDouble(worksheet.Cells[row, 8].Value) : 0.0;
                                DateTime date = DateTime.FromOADate(dateValue);
                                operationDates.Add(date);
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
                            text_phone.Text = worksheet.Cells[row, 6].Value != null ? worksheet.Cells[row, 6].Value.ToString() : null;
                            text_reference.Text = worksheet.Cells[row, 13].Value != null ? worksheet.Cells[row, 13].Value.ToString() : null;
                            text_email.Text = worksheet.Cells[row, 20].Value != null ? worksheet.Cells[row, 20].Value.ToString() : null;
                            break;
                        }
                    }
                }
            }
        }

        private void YeniAdiOrtak_Load(object sender, EventArgs e)
        {
            int year = comboBox_donem.Items.Count - 1;
            comboBox_donem.SelectedIndex = year;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MusteriSil müsteriSil = new MusteriSil(3);
            müsteriSil.Show();
        }
    }
}

