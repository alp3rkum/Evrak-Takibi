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

namespace Evrak_Takibi_Programı.Menü5
{
    public partial class KullaniciTanimla : Form
    {
        public bool güncellemeModu = false;
        public bool keyFound = false;
        private string anahtar = "";
        private DateTime expireDate = new DateTime();
        public KullaniciTanimla()
        {
            InitializeComponent();
        }

        public void OnKeyFound()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "INSERT INTO dbo.LisansDurum(kullanici_ad, eposta, telefon, kurulus, lisans_anahtari, son_kullanim_tarihi) VALUES (@AdSoyad,@Eposta,@Telefon,@Kurulus,@LisansAnahtari,@SonKullanimTarihi)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AdSoyad", text_namesurname.Text);
                    command.Parameters.AddWithValue("@Eposta", text_email.Text);
                    command.Parameters.AddWithValue("@Telefon", text_telefon.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", ""));
                    command.Parameters.AddWithValue("@Kurulus", text_kurulus.Text);
                    command.Parameters.AddWithValue("@LisansAnahtari", anahtar);
                    command.Parameters.AddWithValue("@SonKullanimTarihi", expireDate);
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Kullanıcı kaydı başarıyla gerçekleştirildi!\nLisans anahtarınız {expireDate.ToString("dd.MM.yyyy")} gününe kadar geçerli.", "Kullanıcı Kaydı Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
            button_save.Enabled = YeterliGirdilerGirili();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            anahtar = new LisansAnahtarı(text_namesurname.Text, text_email.Text, text_telefon.Text, text_kurulus.Text).AnahtarOlustur();
            expireDate = DateTime.Now.AddYears(1);
            LisansAnahtari anahtarDiyalog = new LisansAnahtari(false, anahtar);
            anahtarDiyalog.Show();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            KullaniciGuncelle kullaniciGuncelle = new KullaniciGuncelle();
            kullaniciGuncelle.Show();
        }
    }
}
