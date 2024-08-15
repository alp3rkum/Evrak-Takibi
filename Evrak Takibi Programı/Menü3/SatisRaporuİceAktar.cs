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
using Excel = OfficeOpenXml;

namespace Evrak_Takibi_Programı
{
    public partial class SatisRaporuİceAktar : Form
    {
        internal FileInfo? satisRaporu;
        public SatisRaporuİceAktar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            satisRaporuDialog.Filter = "Excel dosyası|*.xlsx";
            if (satisRaporuDialog.ShowDialog() == DialogResult.OK)
            {
                satisRaporu = new FileInfo(satisRaporuDialog.FileName);
                text_filepath.Text = satisRaporuDialog.FileName;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                {
                    using (ExcelPackage package = new ExcelPackage(satisRaporu))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        text_alisSatis.Text = (worksheet.Dimension.Rows - 1).ToString();
                        List<string> customers = new List<string>();
                        int toplamSatis = 0;
                        for (int i = 2; i <= worksheet.Dimension.Rows; i++)
                        {
                            if (!customers.Contains(worksheet.Cells[i, 11].Value))
                            {
                                if (worksheet.Cells[i, 11].Value != null)
                                    customers.Add(worksheet.Cells[i, 11].Value.ToString());
                                else
                                {
                                    text_filepath.Text = "";
                                    text_alisSatis.Text = "";
                                    MessageBox.Show("İçe alınan dosya desteklenen yapıda değil.", "Satış Raporu İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            toplamSatis += Convert.ToInt32(worksheet.Cells[i, 6].Value);
                        }
                        text_musterisayi.Text = customers.Count.ToString();
                        text_toplamsatis.Text = toplamSatis.ToString();

                    }
                    MessageBox.Show("Satış raporu dosyası başarıyla alındı!", "Satış Raporu İçe Aktar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.satisRaporu = satisRaporu;
                MessageBox.Show("Satış raporu dosyası başarıyla kaydedildi!", "Satış Raporu Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SatisRaporuİceAktar_Load(object sender, EventArgs e)
        {

        }
    }
}