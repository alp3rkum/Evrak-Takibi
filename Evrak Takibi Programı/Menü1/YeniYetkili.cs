using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Excel = OfficeOpenXml;
using System.Text.RegularExpressions;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using static iText.Kernel.Font.PdfFontFactory;
using iText.IO.Font;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Layout.Font;
using iText.IO.Font.Constants;
using static System.Net.Mime.MediaTypeNames;
using static Evrak_Takibi_Programı.YeniSahis;
using System.Data.SqlClient;
using static Evrak_Takibi_Programı.YeniAdiOrtak;
using System.Drawing.Imaging;
using static Evrak_Takibi_Programı.YeniGercek;
using static Evrak_Takibi_Programı.YeniTuzel;
using Evrak_Takibi_Programı.Diğer;

namespace Evrak_Takibi_Programı
{
    public partial class YeniYetkili : Form
    {
        internal bool passedSdn;
        internal bool passedEU;
        internal bool passedUK;
        internal bool passedSWIT;
        internal bool passedUN;
        internal bool masak1;
        internal bool masak2;
        internal bool masak3;
        internal bool masak4;
        internal bool teror;

        internal bool taramaBitti;

        internal Label[] taramaLabels = new Label[12];
        internal TextBox[] sonucTexts = new TextBox[12];

        internal Dictionary<string, string> ülkeler = new Dictionary<string, string>();

        public YetkiliKisi yeniYetkiliKisi;
        public bool güncellemeModu;
        string oldMusteriKodu = "";
        int eslesmeSayisi = 0;

        public void OnYetkiliKisiChanged()
        {
            text_custcode.Text = yeniYetkiliKisi.Properties[1].ToString();
            oldMusteriKodu = text_custcode.Text;
            text_tcid.Text = yeniYetkiliKisi.Properties[2].ToString();
            text_namesurname.Text = yeniYetkiliKisi.Properties[3].ToString();
            text_phone.Text = yeniYetkiliKisi.Properties[4].ToString();
            text_birthyear.Text = yeniYetkiliKisi.Properties[5].ToString();
            combo_country.Text = yeniYetkiliKisi.Properties[6].ToString();
            text_birth2.Text = yeniYetkiliKisi.Properties[7].ToString();
            textBox2.Text = yeniYetkiliKisi.Properties[8].ToString();
            textBox1.Text = yeniYetkiliKisi.Properties[9].ToString();


            check_kimlik.Checked = (yeniYetkiliKisi.Properties[12] != DBNull.Value) ? Convert.ToBoolean(yeniYetkiliKisi.Properties[12]) : false;

            string directoryPath = Path.Combine("belgeler", "Yetkili Kişiler", text_namesurname.Text);
            string imzaPath = Path.Combine(directoryPath, "imza.png");
            if (File.Exists(imzaPath))
            {
                yeniYetkiliKisi.Imza = new Bitmap(imzaPath);
                picture_signature.Image = yeniYetkiliKisi.Imza;
            }
            string fotoPath = Path.Combine(directoryPath, "fotograf.png");
            if (File.Exists(fotoPath))
            {
                yeniYetkiliKisi.Fotograf = new Bitmap(fotoPath);
                picture_photo.Image = yeniYetkiliKisi.Fotograf;
            }
            button_save.Text = "Yetkiliyi Güncelle";
            button_update.Text = "Başka Yetkili Güncelle";
        }

        public class YetkiliKisi
        {
            private string musteriKodu;
            private string tcKimlikNo;
            private string adSoyad;
            private string telefonNo;
            private int? dogumYili;
            private string? dogumUlke;
            private string? dogumSehir;
            private string? meslek;
            private string? gorev;
            private bool? kimlikKarti;
            private System.Drawing.Image? imza;
            private System.Drawing.Image? fotograf;

            internal List<object> Properties = new List<object>();

            public string MusteriKodu { get => musteriKodu; set => musteriKodu = value; }
            public string TcKimlikNo { get => tcKimlikNo; set => tcKimlikNo = value; }
            public string AdSoyad { get => adSoyad; set => adSoyad = value; }
            public string TelefonNo { get => telefonNo; set => telefonNo = value; }
            public int? DogumYili { get => dogumYili; set => dogumYili = value; }
            public string? DogumUlke { get => dogumUlke; set => dogumUlke = value; }
            public string? DogumSehir { get => dogumSehir; set => dogumSehir = value; }
            public string? Meslek { get => meslek; set => meslek = value; }
            public string? Gorev { get => gorev; set => gorev = value; }
            public bool? KimlikKarti { get => kimlikKarti; set => kimlikKarti = value; }
            public System.Drawing.Image? Imza { get => imza; set => imza = value; }
            public System.Drawing.Image? Fotograf { get => fotograf; set => fotograf = value; }

            public YetkiliKisi()
            {
                var properties = typeof(YetkiliKisi).GetProperties();
                if (properties != null)
                {
                    for (int i = 0; i < typeof(YetkiliKisi).GetProperties().Length; i++)
                    {
                        Properties.Add(typeof(YetkiliKisi).GetProperties()[i]);
                    }
                }
            }
        }
        public YeniYetkili()
        {
            InitializeComponent();
            taramaLabels[0] = label9; taramaLabels[1] = label13; taramaLabels[2] = label14; taramaLabels[3] = label18; taramaLabels[4] = label19; taramaLabels[5] = label28; taramaLabels[6] = label20; taramaLabels[7] = label22; taramaLabels[8] = label23; taramaLabels[9] = label24; taramaLabels[10] = label21; taramaLabels[11] = label30;
            sonucTexts[0] = text_tckimlik; sonucTexts[1] = text_sdn; sonucTexts[2] = text_eu; sonucTexts[3] = text_uk; sonucTexts[4] = text_swt; sonucTexts[5] = text_un; sonucTexts[6] = text_masak1; sonucTexts[7] = text_masak2; sonucTexts[8] = text_masak3; sonucTexts[9] = text_masak4; sonucTexts[10] = text_terror; sonucTexts[11] = text_spk1;
            ülkeler.Add("Afganistan", "Afghanistan");
            ülkeler.Add("Almanya", "Germany");
            ülkeler.Add("Amerika Birleşik Devletleri", "United States of America");
            ülkeler.Add("Andorra", "Andorra");
            ülkeler.Add("Angola", "Angola");
            ülkeler.Add("Antigua ve Barbuda", "Antigua and Barbuda");
            ülkeler.Add("Arjantin", "Argentina");
            ülkeler.Add("Arnavutluk", "Albania");
            ülkeler.Add("Avustralya", "Australia");
            ülkeler.Add("Avusturya", "Austria");
            ülkeler.Add("Azerbaycan", "Azerbaijan");
            ülkeler.Add("Bahama Adaları", "Bahamas");
            ülkeler.Add("Bahreyn", "Bahrain");
            ülkeler.Add("Bangladeş", "Bangladesh");
            ülkeler.Add("Barbados", "Barbados");
            ülkeler.Add("Belçika", "Belgium");
            ülkeler.Add("Belize", "Belize");
            ülkeler.Add("Benin", "Benin");
            ülkeler.Add("Beyaz Rusya", "Belarus");
            ülkeler.Add("Birleşik Arap Emrilikleri", "United Arab Emirates");
            ülkeler.Add("Bolivya", "Bolivia");
            ülkeler.Add("Bosna Hersek", "Bosna Herzegovina");
            ülkeler.Add("Botsvana", "Botswana");
            ülkeler.Add("Brezilya", "Brazil");
            ülkeler.Add("Brunei", "Brunei");
            ülkeler.Add("Bulgaristan", "Bulgaria");
            ülkeler.Add("Burkina Faso", "Burkina Faso");
            ülkeler.Add("Burundi", "Burundi");
            ülkeler.Add("Butan", "Bhutan");
            ülkeler.Add("Cezayir", "Algeria");
            ülkeler.Add("Cibuti", "Djibouti");
            ülkeler.Add("Çad", "Chad");
            ülkeler.Add("Çek Cumhuriyeti", "Czech Republic");
            ülkeler.Add("Çin", "China");
            ülkeler.Add("Danimarka", "Denmark");
            ülkeler.Add("Demokratik Kongo Cumhuriyeti", "Democratic Republic of the Congo");
            ülkeler.Add("Doğu Timor", "East Timor");
            ülkeler.Add("Dominik Cumhuriyeti", "Dominician Republic");
            ülkeler.Add("Dominika", "Dominica");
            ülkeler.Add("Ekvador", "Ecuador");
            ülkeler.Add("Ekvator Ginesi", "Equatorial Guinea");
            ülkeler.Add("El Salvador", "El Salvador");
            ülkeler.Add("Endonezya", "Endonezya");
            ülkeler.Add("Eritre", "Eritrea");
            ülkeler.Add("Ermenistan", "Armenia");
            ülkeler.Add("Estonya", "Estonia");
            ülkeler.Add("Etiyopya", "Ethiopia");
            ülkeler.Add("Fas", "Morocco");
            ülkeler.Add("Fiji", "Fiji");
            ülkeler.Add("Fildişi Sahili", "Côte d’lvoire");
            ülkeler.Add("Filipinler", "Philippines");
            ülkeler.Add("Filistin", "Palestine");
            ülkeler.Add("Finlandiya", "Finlandiya");
            ülkeler.Add("Fransa", "France");
            ülkeler.Add("Gabon", "Gabon");
            ülkeler.Add("Gambiya", "Gambia");
            ülkeler.Add("Gana", "Ghana");
            ülkeler.Add("Gine", "Guinea");
            ülkeler.Add("Gine Bissau", "Guinea Bissau");
            ülkeler.Add("Grenada", "Grenada");
            ülkeler.Add("Guatemala", "Guatemala");
            ülkeler.Add("Guyana", "Guyana");
            ülkeler.Add("Güney Afrika", "South Africa");
            ülkeler.Add("Güney Kore", "Republic of Korea");
            ülkeler.Add("Güney Sudan", "South Sudan");
            ülkeler.Add("Gürcistan", "Georgia");
            ülkeler.Add("Haiti", "Haiti");
            ülkeler.Add("Hırvatistan", "Croatia");
            ülkeler.Add("Hindistan", "India");
            ülkeler.Add("Hollanda", "Netherlands");
            ülkeler.Add("Honduras", "Honduras");
            ülkeler.Add("Irak", "Iraq");
            ülkeler.Add("İngiltere", "United Kingdom");
            ülkeler.Add("İran", "Iran");
            ülkeler.Add("İrlanda", "Ireland");
            ülkeler.Add("İspanya", "Spain");
            ülkeler.Add("İsrail", "Israel");
            ülkeler.Add("İsveç", "Sweden");
            ülkeler.Add("İsviçre", "Switzerland");
            ülkeler.Add("İtalya", "Italy");
            ülkeler.Add("İzlanda", "Iceland");
            ülkeler.Add("Jamaika", "Jamaica");
            ülkeler.Add("Japonya", "Japan");
            ülkeler.Add("Kamboçya", "Cambodia");
            ülkeler.Add("Kamerun", "Cameroon");
            ülkeler.Add("Kanada", "Canada");
            ülkeler.Add("Karadağ", "Montenegro");
            ülkeler.Add("Katar", "Qatar");
            ülkeler.Add("Kazakistan", "Kazakhstan");
            ülkeler.Add("Kenya", "Kenya");
            ülkeler.Add("Kırgızistan", "Kyrgyzstan");
            ülkeler.Add("Kiribati", "Kiribati");
            ülkeler.Add("Kolombiya", "Colombia");
            ülkeler.Add("Komorlar Birliği", "Comoros");
            ülkeler.Add("Kongo", "Congo");
            ülkeler.Add("Kosova", "Kosovo");
            ülkeler.Add("Kosta Rika", "Costa Rica");
            ülkeler.Add("Kuveyt", "Kuwait");
            ülkeler.Add("Kuzey Kıbrıs Türk Cumhuriyeti", "Northern Cyprus");
            ülkeler.Add("Kuzey Kore", "Democratic People's Republic of Korea");
            ülkeler.Add("Laos", "Laos");
            ülkeler.Add("Lesotho", "Lesotho");
            ülkeler.Add("Letonya", "Latvia");
            ülkeler.Add("Liberya", "Liberia");
            ülkeler.Add("Libya", "Libya");
            ülkeler.Add("Lihtenştayn", "Liechtenstein");
            ülkeler.Add("Litvanya", "Lithuania");
            ülkeler.Add("Lübnan", "Lebanon");
            ülkeler.Add("Lüksemburg", "Luxembourg");
            ülkeler.Add("Macaristan", "Hungary");
            ülkeler.Add("Madagaskar", "Madagascar");
            ülkeler.Add("Makedonya", "Macedonia");
            ülkeler.Add("Malavi", "Malawi");
            ülkeler.Add("Maldivler", "Maldives");
            ülkeler.Add("Malezya", "Malaysia");
            ülkeler.Add("Mali", "Mali");
            ülkeler.Add("Malta", "Malta");
            ülkeler.Add("Marshall Adaları", "Marshall Islands");
            ülkeler.Add("Meksika", "Mexico");
            ülkeler.Add("Mikronezya Federal Devletleri", "Federated States of Micronesia");
            ülkeler.Add("Mısır", "Egypt");
            ülkeler.Add("Moldova", "Moldova");
            ülkeler.Add("Monako", "Monako");
            ülkeler.Add("Moğolistan", "Mongolia");
            ülkeler.Add("Montenegro", "Montenegro");
            ülkeler.Add("Moritanya", "Mauritania");
            ülkeler.Add("Moritus", "Mauritius");
            ülkeler.Add("Mozambik", "Mozambique");
            ülkeler.Add("Myanmar", "Myanmar");
            ülkeler.Add("Namibya", "Namibia");
            ülkeler.Add("Nauru", "Nauru");
            ülkeler.Add("Nepal", "Nepal");
            ülkeler.Add("Nijer", "Niger");
            ülkeler.Add("Nijerya", "Nigeria");
            ülkeler.Add("Nikaragua", "Nicaragua");
            ülkeler.Add("Norveç", "Norway");
            ülkeler.Add("Orta Afrika Cumhuriyeti", "Central African Republic");
            ülkeler.Add("Özbekistan", "Uzbekistan");
            ülkeler.Add("Pakistan", "Pakistan");
            ülkeler.Add("Palau", "Palau");
            ülkeler.Add("Panama", "Panama");
            ülkeler.Add("Papua Yeni Gine", "Papua New Guinea");
            ülkeler.Add("Paraguay", "Paraguay");
            ülkeler.Add("Peru", "Peru");
            ülkeler.Add("Polonya", "Poland");
            ülkeler.Add("Portekiz", "Portugal");
            ülkeler.Add("Romanya", "Romania");
            ülkeler.Add("Ruanda", "Rwanda");
            ülkeler.Add("Rusya", "Rusya");
            ülkeler.Add("Saint Kitts ve Nevis", "Saint Kitts and Nevis");
            ülkeler.Add("Saint Lucia", "Saint Lucia");
            ülkeler.Add("Saint Vincent ve Grenadinler", "Saint Vincent and the Grenadines");
            ülkeler.Add("Samoa", "Samoa");
            ülkeler.Add("San Marino", "San Marino");
            ülkeler.Add("Sao Tome ve Principe", "Sao Tome and Principe");
            ülkeler.Add("Senegal", "Senegal");
            ülkeler.Add("Seyşeller", "Seychelles");
            ülkeler.Add("Sırbistan", "Serbia");
            ülkeler.Add("Sierra Leone", "Sierra Leone");
            ülkeler.Add("Singapur", "Singapore");
            ülkeler.Add("Slovakya", "Slovakia");
            ülkeler.Add("Slovenya", "Slovenya");
            ülkeler.Add("Solomon Adaları", "Solomon Islands");
            ülkeler.Add("Somali", "Somalia");
            ülkeler.Add("Sri Lanka", "Sri Lanka");
            ülkeler.Add("Sudan", "Sudan");
            ülkeler.Add("Surinam", "Suriname");
            ülkeler.Add("Suriye", "Syria");
            ülkeler.Add("Suudi Arabistan", "Saudi Arabia");
            ülkeler.Add("Svaziland", "Swaziland");
            ülkeler.Add("Şili", "Chile");
            ülkeler.Add("Tacikistan", "Tajikistan");
            ülkeler.Add("Tanzanya", "Tanzania");
            ülkeler.Add("Tayland", "Thailand");
            ülkeler.Add("Togo", "Togo");
            ülkeler.Add("Tonga", "Tonga");
            ülkeler.Add("Trinidad ve Tobago", "Trinidad and Tobago");
            ülkeler.Add("Tunus", "Tunisia");
            ülkeler.Add("Tuvalu", "Tuvalu");
            ülkeler.Add("Türkiye", "Turkey");
            ülkeler.Add("Türkmenistan", "Turkmenistan");
            ülkeler.Add("Uganda", "Uganda");
            ülkeler.Add("Ukrayna", "Ukraine");
            ülkeler.Add("Umman", "Oman");
            ülkeler.Add("Uruguay", "Uruguay");
            ülkeler.Add("Ürgün", "Jordan");
            ülkeler.Add("Vanatu", "Vanatu");
            ülkeler.Add("Vatikan", "Vatican City");
            ülkeler.Add("Venezuela", "Venezuela");
            ülkeler.Add("Vietnam", "Vietnam");
            ülkeler.Add("Yemen", "Yemen");
            ülkeler.Add("Yeni Zelanda", "New Zealand");
            ülkeler.Add("Yeşil Burun Adaları", "Cape Verde");
            ülkeler.Add("Yunanistan", "Greece");
            ülkeler.Add("Zambiya", "Zambia");
            ülkeler.Add("Zimbabve", "Zimbabwe");
        }
        private bool YeterliGirdilerGirili()
        {
            bool gerekliGirdilerGirili = true;
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
                else if (control is System.Windows.Forms.TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    gerekliGirdilerGirili = false;
                    break;
                }
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
            button_save.Enabled = YeterliGirdilerGirili() /*&& isEmail()*/;
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private void checkInput()
        {
            button_save.Enabled = YeterliGirdilerGirili() /*&& isEmail()*/;
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void picture_signature_Click(object sender, EventArgs e)
        {
            fileDialog_imza.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_imza.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_imza.FileName;
                picture_signature.Image = new Bitmap(filename);
            }
        }

        private void picture_photo_Click(object sender, EventArgs e)
        {
            fileDialog_picture.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (fileDialog_picture.ShowDialog() == DialogResult.OK)
            {
                string filename = fileDialog_picture.FileName;
                picture_photo.Image = new Bitmap(filename);
            }
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {

        }

        private void YeniYetkili_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label9, "TC Kimlik Numarasının doğru ve kayıtlı olup olmadığının kontrolü");
            toolTip1.SetToolTip(label13, "OFACT (Amerika Hazine Bakanlığı) Yaptırımlılar/Yasaklılar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label14, "Avrupa Birliği Yaptırımlı Şahıslar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label18, "Birleşik Krallık Yaptırımlı Şahıslar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label19, "İsviçre Yaptırımlı Şahıslar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label28, "Birleşmiş Milletler Yaptırımlı Kişiler listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label20, "Birleşmiş Milletler Güvenlik Konseyi Kararına İstinaden Malvarlıkları Dondurulanlar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label22, "Yabancı Ülke Taleplerine İstinaden Malvarlıkları Dondurulanlar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label23, "İç Dondurma Kararı İle Malvarlıkları Dondurulanlar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label24, "Kitle İmha Silahlarının Yayılmasının Finansmanının Önlenmesi Kapsamında Malvarlıkları Dondurulanlar listesinde olup olmadığının kontrolü\nBilgileri verilen kişi listede yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label21, "İçişleri Bakanlığı Terörden Arananlar listesinde olup olmadığının kontrolü\nKırmızı, Mavi, Turuncu, Yeşil ve Gri olmak üzere beş farklı listeden kontrol yapılır\nBilgileri verilen kişi listelerin herhangi birinde yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            toolTip1.SetToolTip(label30, "Sermaye Piyasası Kurulu'nun idari para cezası ve/veya işlem yasağı koyduğu kişiler listesinde olup olmadığının kontrolü\nBilgileri verilen kişi bu listelerin herhangi birinde yoksa \"OLUMLU\", var ise \"OLUMSUZ\" döner");
            foreach (var ülke in ülkeler)
            {
                combo_country.Items.Add(ülke.Key);
            }
        }

        private void button_scan_Click(object sender, EventArgs e)
        {
            int percentage = 0;
            if (radio_30.Checked)
                percentage = 30;
            else if (radio_50.Checked)
                percentage = 50;
            else if (radio_70.Checked)
                percentage = 70;
            else if (radio_100.Checked)
                percentage = 100;
            if (percentage == 0)
            {
                MessageBox.Show("Eşleşme oranı seçmediniz. Tarama başlatılamadı.", "Güvenlik Taraması", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string countryName, countryEnglish = "";
                countryName = combo_country.Text;
                countryEnglish = ülkeler.GetValueOrDefault(countryName);
                if (countryName == "")
                {
                    MessageBox.Show("Ülke bilgisini girmediniz. Tarama başlatılamadı.", "Güvenlik Taraması", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string[] isim_kelimeler = text_namesurname.Text.Split(' ');
                Task<string> tcKimlikNoResponse = /*GüvenlikTaramaİstekleri.NullTask();*/ GüvenlikTaramaİstekleri.TCKimlikKontrolu(Convert.ToInt64(text_tcid.Text), string.Join(" ", isim_kelimeler.Take(isim_kelimeler.Length - 1)), isim_kelimeler[isim_kelimeler.Length - 1], Convert.ToInt32(text_birthyear.Text));
                tcKimlikNoResponse.ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        string responseString = task.Result;
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(responseString);

                        XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                        nsManager.AddNamespace("ns", "http://tckimlik.nvi.gov.tr/WS");

                        XmlNode resultNode = doc.SelectSingleNode("/soap:Envelope/soap:Body/ns:TCKimlikNoDogrulaResponse/ns:TCKimlikNoDogrulaResult", nsManager);
                        if (resultNode.InnerText == "false"/*false*/)
                        {
                            MessageBox.Show("Bu bilgilere sahip kullanıcı bulunamadı. Tarama durduruluyor.", "Güvenlik Taraması", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            text_tckimlik.Invoke((MethodInvoker)delegate
                            {
                                text_tckimlik.BackColor = text_tckimlik.BackColor;
                                text_tckimlik.ForeColor = Color.Red;
                                text_tckimlik.Text = "OLUMSUZ";
                            });
                            taramaBitti = false;
                        }
                        else
                        {
                            text_tckimlik.Invoke((MethodInvoker)delegate
                            {
                                text_tckimlik.BackColor = text_tckimlik.BackColor;
                                text_tckimlik.ForeColor = Color.Green;
                                text_tckimlik.Text = "OLUMLU";
                            });
                            passedSdn = true;
                            string sdn_xml_path = "xml\\SDN_ENHANCED.XML";
                            XmlDocument doc2 = new XmlDocument();
                            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(doc2.NameTable);
                            namespaceManager.AddNamespace("ns", "https://sanctionslistservice.ofac.treas.gov/api/PublicationPreview/exports/ENHANCED_XML");
                            doc2.Load(sdn_xml_path);

                            XmlNodeList entityNodes = doc2.SelectNodes("//*[local-name()='entity']");
                            foreach (XmlNode entityNode in entityNodes)
                            {
                                bool namesMatch = true;
                                string firstName = string.Join(" ", isim_kelimeler.Take(isim_kelimeler.Length - 1));
                                string lastName = isim_kelimeler[isim_kelimeler.Length - 1];
                                XmlNodeList entityNameNodes = entityNode.SelectNodes("./*[local-name()='names']/*[local-name()='name']");
                                foreach (XmlNode entityNameNode in entityNameNodes)
                                {
                                    XmlNode fullNameNode = entityNameNode.SelectSingleNode("./*[local-name()='translations']/*[local-name()='translation']/*[local-name()='formattedFullName']");
                                    if (fullNameNode.InnerText.Contains(","))
                                    {
                                        if (fullNameNode.InnerText.Equals($"{lastName}, {firstName}", StringComparison.OrdinalIgnoreCase))
                                        {
                                            namesMatch = true;
                                            if (percentage < 50)
                                            {
                                                passedSdn = false;
                                                break;
                                            }

                                        }

                                    }
                                    else
                                    {
                                        if (fullNameNode.InnerText.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                        {
                                            namesMatch = true;
                                            if (percentage < 50)
                                            {
                                                passedSdn = false;
                                                break;
                                            }
                                        }
                                    }

                                }
                                if (percentage >= 50)
                                {
                                    bool countriesMatch = false;
                                    XmlNodeList entityAddressNodes = entityNode.SelectNodes("./*[local-name()='addresses']/*[local-name()='address']");
                                    foreach (XmlNode entityAddressNode in entityAddressNodes)
                                    {
                                        XmlNode entityCountryNode = entityAddressNode.SelectSingleNode("//ns:country", namespaceManager);
                                        //MessageBox.Show(entityCountryNode.InnerText);
                                        if (entityCountryNode.InnerText.Equals(countryEnglish, StringComparison.OrdinalIgnoreCase))
                                        {
                                            countriesMatch = true;
                                            if (percentage == 50)
                                            {
                                                passedSdn = !(namesMatch && countriesMatch);
                                                if (passedSdn == false)
                                                    break;
                                            }
                                            else
                                            {
                                                bool citiesMatch = false;
                                                XmlNodeList addressPartsNodes = entityAddressNode.SelectNodes(".//*[local-name()='addressPart']");
                                                foreach (XmlNode addressPartNode in addressPartsNodes)
                                                {
                                                    if (addressPartNode.SelectSingleNode(".//*[local-name()='type']").InnerText == "CITY")
                                                    {
                                                        XmlNode addressCity = addressPartNode.SelectSingleNode(".//*[local-name()='value']");
                                                        if (addressCity.InnerText.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase))
                                                        {
                                                            citiesMatch = true;
                                                            passedSdn = !(namesMatch && countriesMatch && citiesMatch);
                                                            if (passedSdn == false)
                                                                break;
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                            if (passedSdn == true)
                            {
                                text_sdn.Invoke((MethodInvoker)delegate
                                {
                                    text_sdn.BackColor = text_sdn.BackColor;
                                    text_sdn.ForeColor = Color.Green;
                                    text_sdn.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_sdn.Invoke((MethodInvoker)delegate
                                {
                                    text_sdn.BackColor = text_sdn.BackColor;
                                    text_sdn.ForeColor = Color.Red;
                                    text_sdn.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            string eu_xsd_path = "xml\\EUXSD.xml";
                            XmlDocument doc3 = new XmlDocument();
                            doc3.Load(eu_xsd_path);
                            passedEU = true;

                            XmlNodeList sanctionEntityNodes = doc3.SelectNodes("//*[local-name()='sanctionEntity']");
                            foreach (XmlNode sanctionEntity in sanctionEntityNodes)
                            {
                                bool nameMatch = false;
                                bool yearMatch = false;
                                XmlNodeList nameAliasNodes = sanctionEntity.SelectNodes(".//*[local-name()='nameAlias']");
                                foreach (XmlNode nameAliasNode in nameAliasNodes)
                                {
                                    XmlElement nameAliasElement = (XmlElement)nameAliasNode;
                                    string wholeName = nameAliasElement.GetAttribute("wholeName");
                                    if (wholeName.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                    {
                                        nameMatch = true;
                                    }
                                }
                                XmlNodeList birthdateNodes = sanctionEntity.SelectNodes(".//*[local-name()='birthdate']");
                                foreach (XmlNode birthdateNode in birthdateNodes)
                                {
                                    XmlElement birthdateElement = (XmlElement)birthdateNode;
                                    string year = birthdateElement.GetAttribute("year");
                                    if (year.Equals(text_birthyear.Text))
                                    {
                                        yearMatch = true;
                                    }
                                    if (percentage >= 50 && (nameMatch && yearMatch) == true)
                                    {
                                        bool countriesMatch = false;
                                        string birthCountry = birthdateElement.GetAttribute("countryDescription");
                                        if (birthCountry.Equals(countryEnglish, StringComparison.OrdinalIgnoreCase))
                                        {
                                            countriesMatch = true;
                                            passedEU = !(nameMatch && yearMatch && countriesMatch);
                                        }
                                        if (percentage >= 70)
                                        {
                                            bool citiesMatch = false;
                                            string birthCity = birthdateElement.GetAttribute("city");
                                            if (birthCity.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || birthCity.Contains(text_birth2.Text, StringComparison.OrdinalIgnoreCase))
                                            {
                                                citiesMatch = true;
                                                passedEU = !(nameMatch && yearMatch && countriesMatch && citiesMatch);
                                            }
                                        }
                                    }
                                }
                                if (percentage < 50)
                                {
                                    passedEU = !(nameMatch && yearMatch);
                                }
                                if (passedEU == false)
                                {
                                    break;
                                }
                            }
                            if (passedEU == true)
                            {
                                text_eu.Invoke((MethodInvoker)delegate
                                {
                                    text_eu.BackColor = text_eu.BackColor;
                                    text_eu.ForeColor = Color.Green;
                                    text_eu.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_eu.Invoke((MethodInvoker)delegate
                                {
                                    text_eu.BackColor = text_eu.BackColor;
                                    text_eu.ForeColor = Color.Red;
                                    text_eu.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }

                            passedUK = true;
                            string uk_xml_path = "xml\\UK_Sanctions_List.xml";
                            XmlDocument doc4 = new XmlDocument();
                            doc4.Load(uk_xml_path);

                            XmlNodeList designationNodes = doc4.SelectNodes("//*[local-name()='Designation']");
                            foreach (XmlNode designation in designationNodes)
                            {
                                bool nameMatch = false;
                                bool placeMatch = false;
                                XmlNodeList names = designation.SelectNodes("Names/Name");
                                foreach (XmlNode name in names)
                                {
                                    string isimKontrol = "";
                                    XmlNode name1 = name.SelectSingleNode("Name1");
                                    XmlNode name2 = name.SelectSingleNode("Name2");
                                    XmlNode name6 = name.SelectSingleNode("Name6");
                                    if (name1 != null)
                                        isimKontrol += name1.InnerText;
                                    if (name2 != null)
                                        isimKontrol += name2.InnerText;
                                    if (name6 != null)
                                        isimKontrol += name6.InnerText;
                                    if (text_namesurname.Text.Equals(isimKontrol, StringComparison.OrdinalIgnoreCase))
                                    {
                                        nameMatch = true;
                                        //passedUK = false;
                                        //break;
                                    }
                                }
                                XmlNodeList addresses = designation.SelectNodes("Addresses/Address");
                                foreach (XmlNode address in addresses)
                                {
                                    XmlNode province = address.SelectSingleNode("Address6");
                                    XmlNode country = address.SelectSingleNode("AddressCountry");
                                    if (province != null)
                                    {
                                        if (province.InnerText.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || country.InnerText.Equals(countryEnglish, StringComparison.OrdinalIgnoreCase))
                                        {
                                            placeMatch = true;
                                        }
                                    }
                                }

                                if (percentage < 50)
                                    passedUK = !(nameMatch);
                                else if (percentage >= 50 && percentage < 100)
                                    passedUK = !(nameMatch && placeMatch);
                                else
                                {
                                    bool phonesMatch = false;
                                    XmlNodeList phoneNumbers = designation.SelectNodes("PhoneNumbers/PhoneNumber");
                                    if (phoneNumbers != null && phoneNumbers.Count > 0)
                                    {
                                        foreach (XmlNode phoneNumber in phoneNumbers)
                                        {
                                            if (phoneNumber.InnerText == text_phone.Text)
                                            {
                                                phonesMatch = true; break;
                                            }
                                        }
                                        passedUK = !(nameMatch && placeMatch && phonesMatch);
                                    }
                                }
                                if (passedUK == false)
                                    break;
                            }

                            if (passedUK == true)
                            {
                                text_uk.Invoke((MethodInvoker)delegate
                                {
                                    text_uk.BackColor = text_uk.BackColor;
                                    text_uk.ForeColor = Color.Green;
                                    text_uk.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_uk.Invoke((MethodInvoker)delegate
                                {
                                    text_uk.BackColor = text_uk.BackColor;
                                    text_uk.ForeColor = Color.Red;
                                    text_uk.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            passedSWIT = true;
                            string swit_xml_path = "xml\\switzerland_consolidated.xml";
                            XmlDocument doc5 = new XmlDocument();
                            doc5.Load(swit_xml_path);

                            XmlNodeList nameNodes = doc5.SelectNodes("//*[local-name()='name']");

                            foreach (XmlNode nameNode in nameNodes)
                            {
                                string isimKontrol = "";
                                XmlNodeList namePartNodes = nameNode.SelectNodes("name-part");
                                foreach (XmlNode namePartNode in namePartNodes)
                                {
                                    switch (namePartNode.Attributes["name-part-type"].Value)
                                    {
                                        case "family-name": isimKontrol = namePartNode.SelectNodes("value")[0].InnerText.Trim(); break;
                                        case "given-name": isimKontrol = namePartNode.SelectNodes("value")[0].InnerText.Trim() + " " + isimKontrol; break;
                                        case "whole-name": isimKontrol = namePartNode.SelectNodes("value")[0].InnerText.Trim(); break;
                                    }
                                }
                                if (isimKontrol.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                {
                                    passedSWIT = false;
                                    break;
                                }
                            }
                            if (passedSWIT == true)
                            {
                                text_swt.Invoke((MethodInvoker)delegate
                                {
                                    text_swt.BackColor = text_swt.BackColor;
                                    text_swt.ForeColor = Color.Green;
                                    text_swt.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_swt.Invoke((MethodInvoker)delegate
                                {
                                    text_swt.BackColor = text_swt.BackColor;
                                    text_swt.ForeColor = Color.Red;
                                    text_swt.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            passedUN = true;
                            string un_xml_path = "xml\\un_consolidated.xml";
                            XmlDocument doc6 = new XmlDocument();
                            doc6.Load(un_xml_path);

                            XmlNodeList individualNodes = doc6.SelectNodes("//*[local-name()='INDIVIDUAL']");
                            foreach (XmlNode individualNode in individualNodes)
                            {
                                string individual_name = "";
                                XmlNode individual_firstName = individualNode.SelectSingleNode("FIRST_NAME");
                                XmlNode individual_secondName = individualNode.SelectSingleNode("SECOND_NAME");
                                XmlNode individual_thirdName = individualNode.SelectSingleNode("THIRD_NAME");
                                XmlNode individual_fourthName = individualNode.SelectSingleNode("FOURTH_NAME");
                                XmlNode individual_dateOfBirth = individualNode.SelectSingleNode("INDIVIDUAL_DATE_OF_BIRTH/YEAR");
                                XmlNode individual_placeOfBirth = individualNode.SelectSingleNode("INDIVIDUAL_PLACE_OF_BIRTH/CITY");
                                if (individual_firstName != null)
                                    individual_name += individual_firstName.InnerText;
                                if (individual_secondName != null)
                                    individual_name += " " + individual_secondName.InnerText;
                                if (individual_thirdName != null)
                                    individual_name += " " + individual_thirdName.InnerText;
                                if (individual_fourthName != null)
                                    individual_name += " " + individual_fourthName.InnerText;
                                switch (percentage)
                                {
                                    case 30 | 50:
                                        if (individual_dateOfBirth != null)
                                        {
                                            if (individual_name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && individual_dateOfBirth.InnerText == text_birthyear.Text)
                                            {
                                                passedUN = false;
                                            }
                                        }
                                        else
                                        {
                                            if (individual_name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                            {
                                                passedUN = false;
                                            }
                                        }
                                        break;
                                    default:
                                        if (individual_dateOfBirth != null)
                                        {
                                            if (individual_placeOfBirth != null)
                                            {
                                                if (individual_name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && individual_dateOfBirth.InnerText == text_birthyear.Text && individual_placeOfBirth.InnerText.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    passedUN = false;
                                                }
                                            }
                                            else
                                            {
                                                if (individual_name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && individual_dateOfBirth.InnerText == text_birthyear.Text)
                                                {
                                                    passedUN = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (individual_name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                            {
                                                passedUN = false;
                                            }
                                        }
                                        break;
                                }
                            }
                            if (passedUN == true)
                            {
                                text_un.Invoke((MethodInvoker)delegate
                                {
                                    text_un.BackColor = text_un.BackColor;
                                    text_un.ForeColor = Color.Green;
                                    text_un.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_un.Invoke((MethodInvoker)delegate
                                {
                                    text_un.BackColor = text_un.BackColor;
                                    text_un.ForeColor = Color.Red;
                                    text_un.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }

                            masak1 = masak2 = masak3 = masak4 = true;
                            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                            FileInfo masak_dosya1 = new FileInfo("excel\\A-BIRLESMIS-MILLETLER-GUVENLIK-KONSEYI-KARARINA-ISTINADEN-MALVARLIKLARI-DONDURULANLAR-6415-SAYILI-KANUN-5.-MADDE.xlsx");
                            using (ExcelPackage package = new ExcelPackage(masak_dosya1))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                                {
                                    string name = $"{worksheet.Cells[row, 2].Value}";
                                    string otherNames = $"{worksheet.Cells[row, 5].Value}";
                                    string tckn = $"{worksheet.Cells[row, 3].Value}";
                                    string birthdate = $"{worksheet.Cells[row, 11].Value}";
                                    string birthplace = $"{worksheet.Cells[row, 12].Value}";
                                    switch (percentage)
                                    {
                                        case 30:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text))
                                            {
                                                MessageBox.Show($"Birleşmiş Milletler Güvenlik Konseyi Kararları Kapsamında Mal Varlığınız Dondurulmuştur", "Birleşmiş Milletler Güvenlik Konseyi Kararları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak2 = false;
                                                break;
                                            }
                                            break;
                                        default:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text) && (birthplace.Equals(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(text_birth2.Text, StringComparison.OrdinalIgnoreCase)))
                                            {
                                                MessageBox.Show($"Birleşmiş Milletler Güvenlik Konseyi Kararları Kapsamında Mal Varlığınız Dondurulmuştur", "Birleşmiş Milletler Güvenlik Konseyi Kararları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak2 = false;
                                                break;
                                            }
                                            break;
                                    }
                                }
                            }
                            if (masak1 == true)
                            {
                                text_masak1.Invoke((MethodInvoker)delegate
                                {
                                    text_masak1.BackColor = text_masak1.BackColor;
                                    text_masak1.ForeColor = Color.Green;
                                    text_masak1.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_masak1.Invoke((MethodInvoker)delegate
                                {
                                    text_masak1.BackColor = text_masak1.BackColor;
                                    text_masak1.ForeColor = Color.Red;
                                    text_masak1.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            FileInfo masak_dosya2 = new FileInfo("excel\\B-YABANCI-ULKE-TALEPLERINE-ISTINADEN-MALVARLIKLARI-DONDURULANLAR-6415-SAYILI-KANUN-6.-MADDE.xlsx");
                            using (ExcelPackage package = new ExcelPackage(masak_dosya2))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                                {
                                    string name = $"{worksheet.Cells[row, 2].Value}";
                                    string otherNames = $"{worksheet.Cells[row, 11].Value}";
                                    string tckn = $"{worksheet.Cells[row, 3].Value}";
                                    string birthdate = $"{worksheet.Cells[row, 8].Value}";
                                    string birthplace = $"{worksheet.Cells[row, 9].Value}";
                                    switch (percentage)
                                    {
                                        case 30:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text))
                                            {
                                                MessageBox.Show($"Yabancı Ülke Talepleri Kapsamında Mal Varlığınız Dondurulmuştur", "Yabancı Ülke Talepleri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak2 = false;
                                                break;
                                            }
                                            break;
                                        default:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text) && (birthplace.Equals(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(text_birth2.Text, StringComparison.OrdinalIgnoreCase)))
                                            {
                                                MessageBox.Show($"Yabancı Ülke Talepleri Kapsamında Mal Varlığınız Dondurulmuştur", "Yabancı Ülke Talepleri", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak2 = false;
                                                break;
                                            }
                                            break;
                                    }
                                }
                            }
                            if (masak2 == true)
                            {
                                text_masak2.Invoke((MethodInvoker)delegate
                                {
                                    text_masak2.BackColor = text_masak2.BackColor;
                                    text_masak2.ForeColor = Color.Green;
                                    text_masak2.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_masak2.Invoke((MethodInvoker)delegate
                                {
                                    text_masak2.BackColor = text_masak2.BackColor;
                                    text_masak2.ForeColor = Color.Red;
                                    text_masak2.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            FileInfo masak_dosya3 = new FileInfo("excel\\C-IC-DONDURMA-KARARI-ILE-MALVARLIKLARI-DONDURULANLAR-6415-SAYILI-KANUN-7.-MADDE.xlsx");
                            using (ExcelPackage package = new ExcelPackage(masak_dosya3))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                                {
                                    string name = $"{worksheet.Cells[row, 2].Value}";
                                    string otherNames = $"{worksheet.Cells[row, 3].Value}";
                                    string tckn = $"{worksheet.Cells[row, 4].Value}";
                                    string birthdate = $"{worksheet.Cells[row, 9].Value}";
                                    string birthplace = $"{worksheet.Cells[row, 10].Value}";
                                    switch (percentage)
                                    {
                                        case 30:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text))
                                            {
                                                MessageBox.Show($"İç Dondurma Kararları Kapsamında Mal Varlığınız Dondurulmuştur", "İç Dondurma Kararları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak3 = false;
                                                break;
                                            }
                                            break;
                                        default:
                                            if (tckn == text_tcid.Text && name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text) && (birthplace.Equals(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(text_birth2.Text, StringComparison.OrdinalIgnoreCase)))
                                            {
                                                MessageBox.Show($"İç Dondurma Kararları Kapsamında Mal Varlığınız Dondurulmuştur", "İç Dondurma Kararları", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak3 = false;
                                                break;
                                            }
                                            break;
                                    }
                                }
                            }
                            if (masak3 == true)
                            {
                                text_masak3.Invoke((MethodInvoker)delegate
                                {
                                    text_masak3.BackColor = text_masak3.BackColor;
                                    text_masak3.ForeColor = Color.Green;
                                    text_masak3.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_masak3.Invoke((MethodInvoker)delegate
                                {
                                    text_masak3.BackColor = text_masak3.BackColor;
                                    text_masak3.ForeColor = Color.Red;
                                    text_masak3.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            FileInfo masak_dosya4 = new FileInfo("excel\\D-KITLE-IMHA-SILAHLARININ-YAYILMASININ-FINANSMANININ-ONLENMESI-KAPSAMINDA-MALVARLIKLARI-DONDURULANLAR-7262-SAYILI-KANUN-3.A-VE-3.B-MADDELERI.xlsx");
                            using (ExcelPackage package = new ExcelPackage(masak_dosya4))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                                {
                                    string name = $"{worksheet.Cells[row, 2].Value}";
                                    string otherNames = $"{worksheet.Cells[row, 5].Value}";
                                    string birthdate = $"{worksheet.Cells[row, 14].Value}";
                                    string birthplace = $"{worksheet.Cells[row, 9].Value}";
                                    string gorev = $"{worksheet.Cells[row, 7].Value}";
                                    switch (percentage)
                                    {
                                        case 30:
                                            if (name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text))
                                            {
                                                MessageBox.Show($"Kitle İmha Silahlarının Yayılmasının Finansmanının Önlenmesi Kapsamında Mal Varlığınız Dondurulmuştur", "Kitle İmha Silahlarının Yayılmasının Finansmanının Önlenmesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak4 = false;
                                                break;
                                            }
                                            break;
                                        default:
                                            if (name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthdate.Contains(text_birthyear.Text) && (birthplace.Equals(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(countryName, StringComparison.OrdinalIgnoreCase) || birthplace.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase) || birthplace.Contains(text_birth2.Text, StringComparison.OrdinalIgnoreCase)) && gorev.Equals(textBox1.Text, StringComparison.OrdinalIgnoreCase) && otherNames.Contains(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                            {
                                                MessageBox.Show($"Kitle İmha Silahlarının Yayılmasının Finansmanının Önlenmesi Kapsamında Mal Varlığınız Dondurulmuştur", "Kitle İmha Silahlarının Yayılmasının Finansmanının Önlenmesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                masak4 = false;
                                                break;
                                            }
                                            break;
                                    }
                                }
                            }
                            if (masak4 == true)
                            {
                                text_masak4.Invoke((MethodInvoker)delegate
                                {
                                    text_masak4.BackColor = text_masak4.BackColor;
                                    text_masak4.ForeColor = Color.Green;
                                    text_masak4.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_masak4.Invoke((MethodInvoker)delegate
                                {
                                    text_masak4.BackColor = text_masak4.BackColor;
                                    text_masak4.ForeColor = Color.Red;
                                    text_masak4.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            teror = true;
                            FileInfo[] terorListesi = new FileInfo[5];
                            terorListesi[0] = new FileInfo("excel\\GriListe.xlsx");
                            terorListesi[1] = new FileInfo("excel\\KirmiziListe.xlsx");
                            terorListesi[2] = new FileInfo("excel\\MaviListe.xlsx");
                            terorListesi[3] = new FileInfo("excel\\TuruncuListe.xlsx");
                            terorListesi[4] = new FileInfo("excel\\YesilListe.xlsx");
                            foreach (var liste in terorListesi)
                            {
                                string listName = Regex.Replace(liste.Name.Replace(".xlsx", ""), "(\\B[A-Z])", " $1");
                                using (ExcelPackage package = new ExcelPackage(liste))
                                {
                                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                                    for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                                    {
                                        string name = $"{worksheet.Cells[row, 2].Value} {worksheet.Cells[row, 3].Value}";
                                        string birthplace = $"{worksheet.Cells[row, 4].Value}";
                                        string birthyear = $"{worksheet.Cells[row, 5].Value}";
                                        switch (percentage)
                                        {
                                            case 30:
                                                if (name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthyear == text_birthyear.Text)
                                                {
                                                    MessageBox.Show($"İsminiz İçişleri Bakanlığı Terörden Arananlar Listeleri içerisinden {listName}'de çıktı.", "İçişleri Bakanlığı Terörden Arananlar Listesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    teror = false;
                                                }
                                                break;
                                            default:
                                                if (name.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase) && birthyear == text_birthyear.Text && (birthplace.Equals(countryName, StringComparison.OrdinalIgnoreCase) || (birthplace.Equals(text_birth2.Text, StringComparison.OrdinalIgnoreCase))))
                                                {
                                                    MessageBox.Show($"İsminiz İçişleri Bakanlığı Terörden Arananlar Listeleri içerisinden {listName}'de çıktı.", "İçişleri Bakanlığı Terörden Arananlar Listesi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    teror = false;
                                                }
                                                break;
                                        }
                                        if (teror == false)
                                            break;
                                    }
                                }
                            }
                            if (teror == true)
                            {
                                text_terror.Invoke((MethodInvoker)delegate
                                {
                                    text_terror.BackColor = text_terror.BackColor;
                                    text_terror.ForeColor = Color.Green;
                                    text_terror.Text = "OLUMLU";
                                });
                            }
                            else
                            {
                                text_terror.Invoke((MethodInvoker)delegate
                                {
                                    text_terror.BackColor = text_terror.BackColor;
                                    text_terror.ForeColor = Color.Red;
                                    text_terror.Text = "OLUMSUZ";
                                    eslesmeSayisi += 1;
                                });
                            }
                            bool passedSPK1 = true;
                            bool passedSPK2 = true;
                            string reason = "";
                            Task<GüvenlikTaramaİstekleri.IResponse> spkParaCezaliResponse = GüvenlikTaramaİstekleri.SPK(1);

                            spkParaCezaliResponse.ContinueWith(spk_task1 =>
                            {
                                if (spk_task1.IsCompletedSuccessfully)
                                {
                                    GüvenlikTaramaİstekleri.IResponse response = spk_task1.GetAwaiter().GetResult();
                                    if (response is GüvenlikTaramaİstekleri.ListResponse)
                                    {
                                        List<GüvenlikTaramaİstekleri.IdariParaCezasi> idariParaCezalari = ((GüvenlikTaramaİstekleri.ListResponse)response).Items;
                                        //MessageBox.Show(idariParaCezalari.Count.ToString());
                                        foreach (var idariParaCezasi in idariParaCezalari)
                                        {
                                            if (idariParaCezasi.unvan.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                            {
                                                passedSPK1 = false;
                                                reason = "İdari Para Cezası";
                                                eslesmeSayisi += 1;
                                                break;
                                            }
                                        }
                                    }
                                    Task<GüvenlikTaramaİstekleri.IResponse> spkIslemYasagiResponse = GüvenlikTaramaİstekleri.SPK(2, text_tcid.Text);
                                    spkIslemYasagiResponse.ContinueWith(spk_task2 =>
                                    {
                                        if (spk_task2.IsCompletedSuccessfully)
                                        {
                                            GüvenlikTaramaİstekleri.IResponse response = spk_task2.GetAwaiter().GetResult();
                                            if (response is GüvenlikTaramaİstekleri.SingleResponse)
                                            {
                                                GüvenlikTaramaİstekleri.TekilİdariParaCezasi idariParaCezasi = ((GüvenlikTaramaİstekleri.SingleResponse)response).Item;
                                                if (idariParaCezasi.Unvan.Equals(text_namesurname.Text, StringComparison.OrdinalIgnoreCase))
                                                {
                                                    passedSPK2 = false;
                                                    reason = "İşlem yasağı";
                                                    eslesmeSayisi += 1;
                                                }
                                            }
                                        }
                                        if (passedSPK1 == true && passedSPK2 == true)
                                        {
                                            text_spk1.Invoke((MethodInvoker)delegate
                                            {
                                                text_spk1.BackColor = text_spk1.BackColor;
                                                text_spk1.ForeColor = Color.Green;
                                                text_spk1.Text = "OLUMLU";
                                            });
                                        }
                                        else
                                        {
                                            text_spk1.Invoke((MethodInvoker)delegate
                                            {
                                                text_spk1.BackColor = text_spk1.BackColor;
                                                text_spk1.ForeColor = Color.Red;
                                                text_spk1.Text = "OLUMSUZ";
                                            });
                                        }
                                    });


                                }
                                label26.Invoke((MethodInvoker)delegate
                                {
                                    label26.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                                });

                                if (text_tckimlik.Text == "OLUMSUZ")
                                {
                                    label26.Invoke((MethodInvoker)delegate
                                    {
                                        label26.ForeColor = Color.Red;
                                        label26.Text = "TC Kimlik Numarası Doğrulanmadı";
                                    });
                                }
                                else
                                {
                                    label26.Invoke((MethodInvoker)delegate
                                    {
                                        label26.ForeColor = Color.Green;
                                        label26.Text = "Tüm kontrollerden başarıyla geçtiniz!";
                                        taramaBitti = true;
                                        if (passedSdn == false || passedEU == false || passedUK == false || passedSWIT == false)
                                        {
                                            label26.ForeColor = Color.Orange;
                                            label26.Text = "Yurtdışı Kısıtı";
                                        }
                                        if (masak1 == false || masak2 == false || masak3 == false || masak4 == false)
                                        {
                                            label26.ForeColor = Color.Red;
                                            label26.Text = "MASAK Kararları Kapsamında Mal Varlığınız Dondurulmuştur";
                                        }
                                        if (teror == false)
                                        {
                                            label26.ForeColor = Color.Red;
                                            label26.Text = "Terörden Aranıyorsunuz";
                                            taramaBitti = false;
                                        }
                                        if (passedSPK1 == false)
                                        {
                                            label26.ForeColor = Color.Orange;
                                            label26.Text = "SPK'dan İdari Para Cezası Almışsınız";
                                        }
                                        if (taramaBitti == true)
                                        {
                                            if (passedSdn == true && passedEU == true && passedUK == true && passedSWIT == true && passedUN == true && masak1 == true && masak2 == true && masak3 == true && masak4 == true && teror == true)
                                            {
                                                MessageBox.Show("Taramada gerekli olan tüm kriterleri sağladınız!", "Güvenlik Taraması Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                button_save.Enabled = true;
                                                checkInput();
                                            }
                                        }
                                        List<object> yetkili_info = new List<object> { text_custcode.Text, text_namesurname.Text, eslesmeSayisi, percentage.ToString()};
                                        DosyaGoster sonucGoster = new DosyaGoster(1, text_namesurname.Text, "Yetkili", true, yetkili_info);
                                        sonucGoster.Show();
                                    });
                                }
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: " + task.Exception.Message + "\n" + task.Exception.InnerExceptions);
                    }

                });
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
                    radio_30.Checked = radio_50.Checked = radio_70.Checked = radio_100.Checked = false;
                    foreach (var sonucText in sonucTexts)
                    {
                        sonucText.Clear();
                    }
                    label26.Font = new System.Drawing.Font("Segoe UI", 9);
                    label26.Text = "Tarama yapılmadı";
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
                MessageBox.Show("Müşteri zaten kayıtlı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (taramaBitti != true)
            {
                MessageBox.Show("Güvenlik taramasından geçemediniz veya güvenlik taraması yapmadınız.", "Güvenlik Taramasından Geçmediniz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            YetkiliKisi yetkiliKisi = new YetkiliKisi();
            yetkiliKisi.MusteriKodu = text_custcode.Text;
            yetkiliKisi.TcKimlikNo = text_tcid.Text;
            yetkiliKisi.AdSoyad = text_namesurname.Text;
            yetkiliKisi.TelefonNo = text_phone.Text;
            yetkiliKisi.DogumYili = Convert.ToInt32(text_birthyear.Text);
            yetkiliKisi.DogumUlke = combo_country.Text;
            yetkiliKisi.DogumSehir = text_birth2.Text;
            yetkiliKisi.Meslek = textBox2.Text;
            yetkiliKisi.Gorev = textBox1.Text;
            yetkiliKisi.KimlikKarti = check_kimlik.Checked;
            if (!(picture_signature.Image == null))
            {
                yetkiliKisi.Imza = picture_signature.Image;
            }
            yetkiliKisi.Fotograf = picture_photo.Image;
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "";
                string formattedTelNo = yetkiliKisi.TelefonNo.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
                if (güncellemeModu == false)
                    query = $"INSERT INTO dbo.Yetkili(musteri_kodu,tc_kimlikno,ad_soyad,telefon_no,dogum_yili,dogum_yeri1,dogum_yeri2,meslek,gorev,dosya_kimlikkarti,dosya_imza,dosya_fotograf, kayit_tarih) VALUES (@MusteriKodu,@TCNO,@AdSoyad,@Telefon,@DogumYili,@DogumUlke,@DogumSehir,@Meslek,@Gorev,@KimlikKarti,@Imza,@Fotograf,@KayitTarih)";
                else
                    query = $"UPDATE dbo.Yetkili SET musteri_kodu = @MusteriKodu, tc_kimlikno = @TCNO, ad_soyad = @AdSoyad, telefon_no = @Telefon, dogum_yili = @DogumYili, dogum_yeri1 = @DogumUlke, dogum_yeri2 = @DogumSehir, meslek = @Meslek, gorev = @Gorev, dosya_kimlikkarti = @KimlikKarti, dosya_imza = @Imza, dosya_fotograf = @Fotograf WHERE musteri_kodu = @MusteriKodu2";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", yetkiliKisi.MusteriKodu);
                    command.Parameters.AddWithValue("@TCNO", yetkiliKisi.TcKimlikNo);
                    if (güncellemeModu == false)
                    {
                        command.Parameters.AddWithValue("@KayitTarih", DateTime.Today.Date);
                        command.Parameters.AddWithValue("@AdSoyad", yetkiliKisi.AdSoyad);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@MusteriKodu2", oldMusteriKodu);
                        command.Parameters.AddWithValue("@AdSoyad", yetkiliKisi.AdSoyad);
                    }
                    command.Parameters.AddWithValue("@Telefon", formattedTelNo != "" ? formattedTelNo : DBNull.Value);
                    command.Parameters.AddWithValue("@DogumYili", yetkiliKisi.DogumYili != null ? yetkiliKisi.DogumYili : DBNull.Value);
                    command.Parameters.AddWithValue("@DogumUlke", yetkiliKisi.DogumUlke != null ? yetkiliKisi.DogumUlke : DBNull.Value);
                    command.Parameters.AddWithValue("@DogumSehir", yetkiliKisi.DogumSehir != null ? yetkiliKisi.DogumSehir : DBNull.Value);
                    command.Parameters.AddWithValue("@Meslek", yetkiliKisi.Meslek != null ? yetkiliKisi.Meslek : DBNull.Value);
                    command.Parameters.AddWithValue("@Gorev", yetkiliKisi.Gorev != null ? yetkiliKisi.Gorev : DBNull.Value);
                    command.Parameters.AddWithValue("@KimlikKarti", yetkiliKisi.KimlikKarti);
                    if (yetkiliKisi.Imza != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            yetkiliKisi.Imza.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Imza", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Imza", SqlDbType.Image).Value = DBNull.Value;
                    }
                    if (yetkiliKisi.Fotograf != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            yetkiliKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                            byte[] imageBytes = memoryStream.ToArray();
                            command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = imageBytes;
                        }
                    }
                    else
                    {
                        command.Parameters.Add("@Fotograf", SqlDbType.Image).Value = DBNull.Value;
                    }
                    string filePath = $"belgeler\\Yetkili Kişiler\\{yetkiliKisi.AdSoyad.Replace(".", "_").Replace(" ", "_")}";
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        yetkiliKisi.Imza.Save(memoryStream, ImageFormat.Png);
                        byte[] imageBytes = memoryStream.ToArray();
                        string imzaPath = $"{filePath}\\imza.png";
                        File.WriteAllBytes(imzaPath, imageBytes);

                        memoryStream.Flush();
                        memoryStream.SetLength(0);

                        yetkiliKisi.Fotograf.Save(memoryStream, ImageFormat.Png);
                        imageBytes = memoryStream.ToArray();
                        string fotoPath = $"{filePath}\\fotograf.png";
                        File.WriteAllBytes(fotoPath, imageBytes);

                        memoryStream.Flush();
                        memoryStream.SetLength(0);
                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        if (güncellemeModu == false)
                            MessageBox.Show($"{yetkiliKisi.AdSoyad} isimli yetkili kişinin kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            MessageBox.Show($"{yetkiliKisi.AdSoyad} isimli yetkili kişinin kaydı başarıyla güncellendi.", "Güncelleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button_save.Text = "Müşteriyi Kaydet";
                            button_update.Text = "Müşteri Güncelle";
                            güncellemeModu = false;
                        }
                            
                    }
                    else
                    {
                        MessageBox.Show($"{yetkiliKisi.AdSoyad} isimli yetkili kişi zaten kayıtlı.", "Kayıt Zaten Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private bool CheckIfRecordExists()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.Yetkili where musteri_kodu = @MusteriKod";
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
            MüsteriGüncelle müsteriGüncelle = new MüsteriGüncelle(4);
            müsteriGüncelle.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            MusteriSil müsteriSil = new MusteriSil(4);
            müsteriSil.Show();
        }
    }
}
