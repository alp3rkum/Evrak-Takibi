using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Data.SqlClient;

namespace Evrak_Takibi_Programı
{
    internal class LisansAnahtarı
    {
        private string isim;
        private string email;
        private string telefon;
        private string kurulus;

        public LisansAnahtarı(string isim, string email, string telefon, string kurulus)
        {
            this.isim = isim;
            this.email = email;
            this.telefon = telefon;
            this.kurulus = kurulus;
        }

        internal static int AnahtarSayisiGetir()
        {
            int anahtarSayi = 0;

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM dbo.LisansDurum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    anahtarSayi = (int)command.ExecuteScalar();
                }
            }

            return anahtarSayi;
        }

        internal string AnahtarOlustur()
        {
            string key = string.Join("", isim,email,telefon,kurulus,DateTime.Now.Year.ToString());
            string result = "";

            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                result = Convert.ToBase64String(hash);
            }

            result = Regex.Replace(result, "[^A-Z0-9]+", "").Substring(0, 20);

            return result;
        }
    }
}
