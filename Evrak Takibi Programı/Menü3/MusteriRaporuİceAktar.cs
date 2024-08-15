using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı.Menü3
{
    public partial class MusteriRaporuİceAktar : Form
    {
        internal FileInfo? musteriRaporu;
        public MusteriRaporuİceAktar()
        {
            InitializeComponent();
        }

        private void MusteriRaporuİceAktar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriRaporDialog.Filter = "Excel dosyası|*.xlsx";
            if (musteriRaporDialog.ShowDialog() == DialogResult.OK)
            {
                musteriRaporu = new FileInfo(musteriRaporDialog.FileName);
                text_filepath.Text = musteriRaporu.FullName;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(musteriRaporu))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    List<ExcelRangeRow> customers = new List<ExcelRangeRow>();
                    for (int i = 2; i <= worksheet.Rows.Count(); i++)
                    {
                        customers.Add(worksheet.Rows[i]);
                    }
                    text_musterisayi.Text = customers.Count.ToString();
                }
                MessageBox.Show("Müşteri raporu/dökümü başarıyla alındı!", "Müşteri Raporu İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.musteriRaporu = musteriRaporu;
                MessageBox.Show("Müşteri raporu dosyası başarıyla kaydedildi!", "Müşteri Raporu Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
