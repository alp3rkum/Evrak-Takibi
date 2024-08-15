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

namespace Evrak_Takibi_Programı.Diğer
{
    public partial class EksikDokuman : Form
    {
        int dokumanKodu = -1;
        int donem = 2018;
        List<string> queriesToWorkWith = new List<string>();
        HashSet<object> names = new HashSet<object>();

        public EksikDokuman(int dokumanKodu, int donem)
        {
            InitializeComponent();
            this.dokumanKodu = dokumanKodu;
            this.donem = donem;
        }
        public EksikDokuman(int dokumanKodu,HashSet<object> nameList)
        {
            InitializeComponent();
            this.dokumanKodu = dokumanKodu;
            this.names = nameList;
        }

        private void EksikDokuman_Load(object sender, EventArgs e)
        {
            string[] cerceveSozlesmesiQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.Sahis where dosya_cercevesozlesmesi = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1cerceve = 0) OR (dosya_ortak2cerceve = 0) AND donem = @Donem" };
            string[] kimlikKartiQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_kimlik = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where dosya_kimlik = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.Sahis where dosya_kimlik = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1kimlik = 0) OR (dosya_ortak2kimlik = 0) AND donem = @Donem", "SELECT ad_soyad FROM dbo.Yetkili where dosya_kimlikkarti = 0", "SELECT ad_soyad FROM dbo.CerceveYetkili where dosya_kimlikkarti = 0" };
            string[] imzaSirkuleriQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.Sahis where imza_sirkuleri IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1sirkuler IS NULL) OR (dosya_ortak2sirkuler IS NULL) AND donem = @Donem" };
            string[] vergiLevhasiQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where vergi_levhasi IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where vergi_levhasi IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1vergilevha IS NULL) OR (dosya_ortak2vergilevha IS NULL) AND donem = @Donem" };
            string[] faaliyetBelgesiQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_faaliyetbelgesi IS NULL", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1faaliyetbelge IS NULL) OR (dosya_ortak2faaliyetbelge IS NULL)" };
            string[] ticaretSicilQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_ticaretsicil IS NULL AND donem = @Donem" };
            string[] ikametgahQueries = new string[] { "SELECT ad_soyad FROM dbo.Sahis where dosya_ikametgah = 0 AND donem = @Donem" };
            string[] islakImzaQueries = new string[] { "SELECT ad_soyad FROM dbo.Sahis where dosya_islakimza = 0 AND donem = @Donem" };
            string[] adiOrtaklikQueries = new string[] { "SELECT ad_soyad FROM dbo.AdiOrtaklik where dosya_ortakliksozlesmesi = 0 AND donem = @Donem" };
            string[] tahakkukQueries = new string[] { "SELECT ad_soyad FROM dbo.AdiOrtaklik where dosya_tahakkukfisi = 0 AND donem = @Donem" };
            string[] imzaQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_imza IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where dosya_imza IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.Sahis where dosya_imza IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1imza IS NULL) OR (dosya_ortak2imza IS NULL) AND donem = @Donem", "SELECT ad_soyad FROM dbo.Yetkili where dosya_imza IS NULL", "SELECT ad_soyad FROM dbo.CerceveYetkili where dosya_imza IS NULL" };
            string[] fotografQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi where dosya_fotograf IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.GercekKisi where dosya_fotograf IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.Sahis where dosya_fotograf IS NULL AND donem = @Donem", "SELECT ad_soyad FROM dbo.AdiOrtaklik where (dosya_ortak1fotograf IS NULL) OR (dosya_ortak2fotograf IS NULL) AND donem = @Donem", "SELECT ad_soyad FROM dbo.Yetkili where dosya_fotograf IS NULL", "SELECT ad_soyad FROM dbo.CerceveYetkili where dosya_fotograf IS NULL" };

            string[] faaliyetBelgesiTarihQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi WHERE donem = @Donem AND DATEPART(DAYOFYEAR, dosya_faaliyetbelgesi) <= DATEPART(DAYOFYEAR, GETDATE())-1;", "SELECT ad_soyad FROM dbo.AdiOrtaklik WHERE donem = @Donem AND (DATEPART(DAYOFYEAR, dosya_ortak1faaliyetbelge) <= DATEPART(DAYOFYEAR, GETDATE())-1) OR (DATEPART(DAYOFYEAR, dosya_ortak2faaliyetbelge) <= DATEPART(DAYOFYEAR, GETDATE())-1);" };
            string[] gercekFaydalaniciQueries = new string[] { "SELECT ad_soyad FROM dbo.TuzelKisi WHERE dosya_faydalaniciform = 0 AND donem = @Donem", "SELECT COUNT(*) FROM dbo.Adiortaklik WHERE dosya_ortak1faydalanici = 0 AND donem = @Donem", "SELECT ad_soyad FROM dbo.Adiortaklik WHERE (dosya_ortak1faydalanici = 0 OR dosya_ortak2faydalanici = 0) AND donem = @Donem" };

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            switch (dokumanKodu)
            {
                case 0:
                    panel_left_title.BackColor = Color.Moccasin;
                    foreach (string query in cerceveSozlesmesiQueries)
                        queriesToWorkWith.Add(query);
                        break;
                case 1:
                    panel_left_title.BackColor = Color.LightSkyBlue;
                    foreach (string query in kimlikKartiQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 2:
                    panel_left_title.BackColor = Color.FromArgb(151, 251, 152);
                    foreach (string query in imzaSirkuleriQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 3:
                    panel_left_title.BackColor = Color.Coral;
                    foreach (string query in vergiLevhasiQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 4:
                    panel_left_title.BackColor = Color.FromArgb(153,180,209);
                    foreach (string query in faaliyetBelgesiQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 5:
                    panel_left_title.BackColor = Color.FromArgb(253, 192, 193);
                    foreach (string query in ticaretSicilQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 6:
                    panel_left_title.BackColor = Color.DarkKhaki;
                    foreach (string query in ikametgahQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 7:
                    panel_left_title.BackColor = Color.FromArgb(73, 209, 205);
                    foreach (string query in islakImzaQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 8:
                    panel_left_title.BackColor = Color.FromArgb(167, 135, 150);
                    foreach (string query in adiOrtaklikQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 9:
                    panel_left_title.BackColor = Color.FromArgb(227, 59, 216);
                    foreach (string query in tahakkukQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 10:
                    panel_left_title.BackColor = Color.FromArgb(196, 204, 254);
                    foreach (string query in imzaQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 11:
                    panel_left_title.BackColor = Color.FromArgb(251, 106, 126);
                    foreach (string query in fotografQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 12:
                    foreach (string query in faaliyetBelgesiTarihQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 13:
                    foreach (string query in gercekFaydalaniciQueries)
                        queriesToWorkWith.Add(query);
                    break;
                case 14 | 15:
                    StringBuilder sb = new StringBuilder();
                    foreach (var name in names)
                    {
                        sb.AppendLine(name.ToString());
                    }  
                    text_userlist.Text = sb.ToString();
                    break;
            }
            if(dokumanKodu < 14)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        StringBuilder sb = new StringBuilder();
                        command.Parameters.AddWithValue("@Donem", Convert.ToInt32(donem));
                        command.Connection = connection;
                        foreach (string query in queriesToWorkWith)
                        {
                            command.CommandText = query;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                while (reader.Read())
                                {
                                    string adSoyad = reader.GetString(reader.GetOrdinal("ad_soyad"));
                                    sb.AppendLine(adSoyad);
                                }

                            }
                        }
                        text_userlist.Text = sb.ToString();
                    }
                }
            }
            
        }
    }
}
