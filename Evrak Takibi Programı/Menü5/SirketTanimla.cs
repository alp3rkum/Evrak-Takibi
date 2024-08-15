using Evrak_Takibi_Programı.Diğer;
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
using static Evrak_Takibi_Programı.YeniTuzel;

namespace Evrak_Takibi_Programı.Menü5
{
    public partial class SirketTanimla : Form
    {
        public bool güncellemeModu = false;

        public Sirket yeniSirket;

        public void OnSirketChanged()
        {
            text_custcode.Text = yeniSirket.Properties[1].ToString();
            text_namesurname.Text = yeniSirket.Properties[2].ToString();
            text_tcid.Text = yeniSirket.Properties[3].ToString();
            text_unvan.Text = yeniSirket.Properties[4].ToString();
            text_phone.Text = yeniSirket.Properties[5].ToString();
            text_yetkili.Text = yeniSirket.Properties[6].ToString();
            text_taxoffice.Text = yeniSirket.Properties[7].ToString();
            text_taxnum.Text = yeniSirket.Properties[8].ToString();
            text_date.Text = yeniSirket.Properties[9].ToString().Replace("00:00:00", "");
            text_address.Text = yeniSirket.Properties[10].ToString();
            text_ilce.Text = yeniSirket.Properties[11].ToString();
            text_ilkod.Text = yeniSirket.Properties[12].ToString();
            check_kullanici.Checked = (bool)yeniSirket.Properties[13];
        }
        public class Sirket
        {
            private int musteriKodu;
            private string? musteriAdi;
            private string? tcKimlikNo;
            private string? unvan;
            private string? telefonNo;
            private string? yetkiliKisi;
            private string? vergiDairesi;
            private int? vergiNo;
            private DateTime? gelisTarihi;
            private string? adres;
            private string? ilce;
            private int? ilKodu;
            private bool kullanici = false;
            internal List<object> Properties = new List<object>();

            public int MusteriKodu { get => musteriKodu; set => musteriKodu = value; }
            public string? MusteriAdi { get => musteriAdi; set => musteriAdi = value; }
            public string? TcKimlikNo { get => tcKimlikNo; set => tcKimlikNo = value; }
            public string? Unvan { get => unvan; set => unvan = value; }
            public string? TelefonNo { get => telefonNo; set => telefonNo = value; }
            public string? YetkiliKisi { get => yetkiliKisi; set => yetkiliKisi = value; }
            public string? VergiDairesi { get => vergiDairesi; set => vergiDairesi = value; }
            public int? VergiNo { get => vergiNo; set => vergiNo = value; }
            public DateTime? GelisTarihi { get => gelisTarihi; set => gelisTarihi = value; }
            public string? Adres { get => adres; set => adres = value; }
            public string? Ilce { get => ilce; set => ilce = value; }
            public int? IlKodu { get => ilKodu; set => ilKodu = value; }
            public bool Kullanici { get => kullanici; set => kullanici = value; }

            public Sirket()
            {
                for (int i = 0; i < typeof(Sirket).GetProperties().Length; i++)
                {
                    Properties.Add(typeof(Sirket).GetProperties()[i]);
                }
            }

        }

        private bool YeterliGirdilerGirili()
        {
            bool gerekliGirdilerGirili = true;
            foreach (Control control in panel2.Controls)
            {
                if (control is MaskedTextBox maskedTextBox && string.IsNullOrEmpty(maskedTextBox.Text))
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
            foreach (Control control in panel2.Controls)
            {
                if (control is MaskedTextBox maskedTextBox && !string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    herhangiBir = true;
                    break;
                }
                else if (control is System.Windows.Forms.TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
                {
                    herhangiBir = true;
                    break;
                }
            }
            return herhangiBir;
        }

        private void BütünGirdileriTemizle()
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is MaskedTextBox maskedTextBox && !string.IsNullOrEmpty(maskedTextBox.Text))
                {
                    maskedTextBox.Clear();
                }
                else if (control is System.Windows.Forms.TextBox textBox && !string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Clear();
                }
            }
        }

        private void checkInput(object sender, EventArgs e)
        {
            //button_save.Enabled = YeterliGirdilerGirili();
            button_new.Enabled = HerhangiBirGirdiGirili();
        }

        public SirketTanimla()
        {
            InitializeComponent();
        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (HerhangiBirGirdiGirili())
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş girdileriniz var. Eğer devam ederseniz bu girdileri kaybedeceksiniz.\nYeni kişi girişi yapmak istiyor musunuz?", "Yeni Kişi Girişi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    BütünGirdileriTemizle();
                    button_new.Enabled = false;
                }
            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Sirket sirket = new Sirket();
            sirket.MusteriKodu = Convert.ToInt32(text_custcode.Text);
            if (text_namesurname.Text != null)
                sirket.MusteriAdi = text_namesurname.Text;
            if (text_tcid.Text != null)
                sirket.TcKimlikNo = text_tcid.Text;
            if (text_unvan.Text != null)
                sirket.Unvan = text_unvan.Text;
            if (text_taxnum.Text != null)
                sirket.VergiNo = Convert.ToInt32(text_taxnum.Text);
            if (text_date.Text != null)
                sirket.GelisTarihi = Convert.ToDateTime(text_date.Text);
            if (text_address.Text != null)
                sirket.Adres = text_address.Text;
            if (text_ilce.Text != null)
                sirket.Ilce = text_ilce.Text;
            if (text_ilkod.Text != null)
                sirket.IlKodu = Convert.ToInt32(text_ilkod.Text);
            if (text_taxoffice.Text != null)
                sirket.VergiDairesi = text_taxoffice.Text;
            sirket.TelefonNo = text_phone.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            sirket.Kullanici = check_kullanici.Checked;
            if (text_yetkili.Text != null)
                sirket.YetkiliKisi = text_yetkili.Text;

            string query = "";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (güncellemeModu == false)
                {
                    query = "INSERT INTO dbo.Sirket(musteri_kodu,musteri_adi,tc_kimlik,unvan,telefon_no,yetkili_kisi,vergi_dairesi,vergi_no,gelis_tarihi,adres,ilce,il_kodu,kullanici_sirket) VALUES (@MusteriKodu,@MusteriAdi,@TcKimlik,@Unvan,@Telefon,@Yetkili,@VergiDairesi,@VergiNo,@GelisTarihi,@Adres,@Ilce,@IlKodu,@Kullanici)";
                }
                else
                {
                    query = "UPDATE dbo.Sirket SET musteri_kodu = @MusteriKodu, musteri_adi = @MusteriAdi, telefon_no = @Telefon, yetkili_kisi = @Yetkili, tc_kimlik = @TcKimlik, unvan = @Unvan, vergi_dairesi = @VergiDairesi, vergi_no = @VergiNo, gelis_tarihi = @GelisTarihi, adres = @Adres, ilce = @Ilce, il_kodu = @IlKodu, kullanici_sirket = @Kullanici WHERE musteri_kodu = @MusteriKodu2";
                }
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MusteriKodu", sirket.MusteriKodu);
                    if (güncellemeModu == true)
                        command.Parameters.AddWithValue("@MusteriKodu2", yeniSirket.MusteriKodu);
                    command.Parameters.AddWithValue("@MusteriAdi", sirket.MusteriAdi);
                    command.Parameters.AddWithValue("@TcKimlik", sirket.TcKimlikNo);
                    command.Parameters.AddWithValue("@Unvan", sirket.Unvan);
                    command.Parameters.AddWithValue("@VergiNo", sirket.VergiNo);
                    command.Parameters.AddWithValue("@GelisTarihi", sirket.GelisTarihi);
                    command.Parameters.AddWithValue("@Adres", sirket.Adres);
                    command.Parameters.AddWithValue("@Ilce", sirket.Ilce);
                    command.Parameters.AddWithValue("@IlKodu", sirket.IlKodu);
                    command.Parameters.AddWithValue("@Telefon", sirket.TelefonNo);
                    command.Parameters.AddWithValue("@Yetkili", sirket.YetkiliKisi);
                    command.Parameters.AddWithValue("@VergiDairesi", sirket.VergiDairesi);
                    command.Parameters.AddWithValue("@Kullanici", sirket.Kullanici);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {

                        MessageBox.Show($"{sirket.MusteriAdi} isimli şirketin kaydı başarıyla gerçekleştirildi.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Kayıt esnasında hata oluştu.", "Kayıt Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            SirketGuncelle sirketGuncelle = new SirketGuncelle();
            sirketGuncelle.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            SirketSil sirketSil = new SirketSil();
            sirketSil.Show();
        }

        private async void SirketTanimla_Load(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM dbo.Sirket where kullanici_sirket = 1";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)await command.ExecuteScalarAsync();
                    if (count > 0)
                        check_kullanici.Enabled = false;
                }
            }
        }
    }
}
