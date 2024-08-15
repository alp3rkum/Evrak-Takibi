using Evrak_Takibi_Programı.Diğer;
using Evrak_Takibi_Programı.Menü2;
using Evrak_Takibi_Programı.Menü3;
using Evrak_Takibi_Programı.Menü4;
using Evrak_Takibi_Programı.Menü5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evrak_Takibi_Programı
{
    public partial class Form1 : Form
    {
        //iş parçacıkları
        Thread thread1;

        //animasyon vb. için tutulan değerler
        internal int panelOpenWidth = 181;
        internal int panelCloseWidth = 38;
        internal int titleCloseWidth = 0;
        internal int titleOpenWidth = 0;
        internal int oldColorIndex = 0;
        internal int currentColorIndex = 0;
        internal int colorChangeSteps = 7;
        internal int currentColorStep = 0;
        internal int sub1Height = 396;
        internal int sub2Height = 396;
        internal int sub3Height = 136;
        internal int sub4Height = 180;
        internal int sub5Height = 136;

        /*renk değişikliği için tutulan renk dizileri listesi
         * index 0 = sidebar
         * index 1 = butonlar
         */
        internal List<Color[]> colors = new List<Color[]>();

        //responsive sayfalar için boolean değişkenleri
        internal bool menuOpen = true;
        internal bool notInMain = false;
        internal bool wasMenuOpen = false;
        internal bool sub1Open = false;
        internal bool sub2Open = false;
        internal bool sub3Open = false;
        internal bool sub4Open = false;
        internal bool sub5Open = false;

        //Timer animasyonları için tutulan özel değişkenler
        internal int panelTargetWidth = 0;
        internal int titleTargetWidth = 0;

        //altmenü butonlarının tutulduğu diziler
        internal Button[] submenu1_buttons;
        internal Button[] submenu2_buttons;
        internal Button[] submenu3_buttons;
        internal Button[] submenu4_buttons;
        internal Button[] submenu5_buttons;

        //panel_form'da gösterilerek form ögesi
        Form? formToShow;

        //Satış Raporu
        public static FileInfo? satisRaporu;
        public static FileInfo? musteriRaporu;
        public Form1()
        {
            InitializeComponent();
            Color[] defaultColors = new Color[] { Color.FromArgb(128, SystemColors.ControlDark), Color.FromArgb(128, SystemColors.ControlDarkDark) }; //index 0, başlangıç rengi
            Color[] blue = new Color[] { Color.FromArgb(128, 72, 106, 169), Color.FromArgb(128, 48, 80, 127) }; //index 1, yeni kayıt rengi
            Color[] red = new Color[] { Color.FromArgb(128, 169, 106, 72), Color.FromArgb(128, 127, 80, 48) }; //index 2, rapor rengi
            Color[] green = new Color[] { Color.FromArgb(128, 106, 169, 72), Color.FromArgb(128, 80, 127, 48) }; //index 3, içe aktar
            Color[] yellow = new Color[] { Color.FromArgb(128, 146, 169, 106), Color.FromArgb(128, 108, 127, 80) }; //index 4, dışa aktar
            Color[] silver = new Color[] { Color.FromArgb(128, 166, 169, 167), Color.FromArgb(128, 125, 127, 126) }; //index 5, bakım
            colors.Add(defaultColors);
            colors.Add(blue);
            colors.Add(red);
            colors.Add(green);
            colors.Add(yellow);
            colors.Add(silver);
            submenu1_buttons = new Button[] { button_sub11, button_sub12, button_sub13, button_sub14, button_sub15, button_sub16, button_sub17, button_sub18, button_sub19 };
            submenu2_buttons = new Button[] { button_sub21, button_sub22, button_sub23, button_sub24, button_sub25, button_sub26, button_sub27, button_sub28, button_sub29 };
            submenu3_buttons = new Button[] { button_sub31, button_sub32, button_sub33 };
            submenu4_buttons = new Button[] { button_sub41, button_sub42, button_sub43, button_sub44 };
            submenu5_buttons = new Button[] { button_sub51, button_sub52, button_sub53 };
            //formToShow.TopLevel = false;
            panel_form.Visible = false;
            label_title.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button_x.BringToFront();
            button_menu.BringToFront();
            SetUIColor(0);
            panel_title.Width = 0;
            panel_submenu1.BackColor = panel_submenu2.BackColor = panel_submenu3.BackColor = panel_submenu4.BackColor = panel_submenu5.BackColor = Color.Transparent;
            panel_submenu1.Height = panel_submenu2.Height = panel_submenu3.Height = panel_submenu4.Height = panel_submenu5.Height = 0;
            if (!Directory.Exists("belgeler"))
                Directory.CreateDirectory("belgeler");
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                if (!Directory.Exists(String.Format("belgeler\\{0}", i)))
                {
                    Directory.CreateDirectory(String.Format("belgeler\\{0}", i));
                }
            }
            if (!Directory.Exists("belgeler\\Yetkili Kişiler"))
                Directory.CreateDirectory("belgeler\\Yetkili Kişiler");
            if (!Directory.Exists("belgeler\\Çerçeve Sözleşmesinde Yetkilendirilen Kişiler"))
                Directory.CreateDirectory("belgeler\\Çerçeve Sözleşmesinde Yetkilendirilen Kişiler");
            if (!Directory.Exists("pdf"))
                Directory.CreateDirectory("pdf");
            DateTime bugün = DateTime.Today;
            DikkatKontrol(bugün);
            ShowDashboard();
        }

        private void DikkatKontrol(DateTime day)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=evraktakibi;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT MusteriAdi,IslemTarih,IslemAmac FROM dbo.DikkatKaydi WHERE Durum = 0";
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string musteriAdi = reader.GetString(0);
                            DateTime islemTarih = reader.GetDateTime(1);
                            string islemAmac = reader.GetString(2);
                            if (islemTarih.ToString("D").Equals(day.ToString("D")))
                                MessageBox.Show($"{musteriAdi} isimli müşterinizin aşağıda amacı belirtilen işlemi gerçekleştirmesi gerekmektedir:\n{islemAmac}", "Gerçekleştirilmesi Gereken Bir İşlem Var", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void SetUIColor(int colorIndex)
        {
            panel_sidebar.BackColor = colors[colorIndex][0];
            button_menu.BackColor = button_x.BackColor = colors[colorIndex][1];
            Button[] buttons = panel_sidebar.Controls.OfType<Button>().ToArray();

            foreach (Button button in buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
            foreach (Button button in submenu1_buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
            foreach (Button button in submenu2_buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
            foreach (Button button in submenu3_buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
            foreach (Button button in submenu4_buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
            foreach (Button button in submenu5_buttons)
            {
                button.BackColor = colors[colorIndex][1];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuOpen = !menuOpen;
            wasMenuOpen = !wasMenuOpen;
            if (menuOpen == false && notInMain == true)
            {
                titleTargetWidth = 0;
                timer_title.Start();
            }
            else
            {
                panelTargetWidth = menuOpen ? panelOpenWidth : panelCloseWidth;
                timer_menu.Start();
            }
            if (sub1Open == true)
            {
                sub1Open = false;
                timer_sub1.Start();
            }
            if (sub2Open == true)
            {
                sub2Open = false;
                timer_sub2.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false;
                timer_sub3.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false;
                timer_sub4.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false;
                timer_sub5.Start();
            }
        }

        private void timer_menu_Tick(object sender, EventArgs e)
        {
            //if (menuOpen == false && notInMain == true)
            //{
            //    titleTargetWidth = 0;
            //    timer_title.Start();
            //}
            panel_sidebar.Width += menuOpen ? 13 : -13;
            panel_button_menu.Width += menuOpen ? 13 : -13;
            if (panel_sidebar.Width == panelTargetWidth)
            {
                timer_menu.Stop();
                if (menuOpen == true && notInMain == true)
                {
                    titleTargetWidth = this.Width - panelTargetWidth;
                    timer_title.Start();
                }
            }

        }

        private void button_new_Click(object sender, EventArgs e)
        {
            if (sub2Open == true)
            {
                sub2Open = false; timer_sub2.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false; timer_sub3.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false; timer_sub4.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false; timer_sub5.Start();
            }
            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            if (sub1Open == false)
            {
                sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            }
            else
            {
                sub1Open = false; timer_sub1.Start(); currentColorIndex = 0;
            }
            timer_color.Start();

            if (notInMain == false)
            {
                notInMain = true;
                titleTargetWidth = this.Width - panelTargetWidth;
            }
            else
            {
                if (oldColorIndex == 1)
                {
                    if (wasMenuOpen == true)
                    {
                        wasMenuOpen = false;
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                    if (menuOpen == true)
                    {
                        notInMain = false;
                        titleTargetWidth = 0;
                    }

                }

            }
            timer_title.Start();
            if (panel_form.Visible)
            {
                if (notInMain == false)
                {
                    if (!(formToShow is Dashboard))
                        ShowDashboard();
                }
                else
                {
                    panel_form.Visible = false;
                    label_title.Text = "";
                }

            }
            else
            {
                if (notInMain == false)
                {
                    panel_form.Visible = true;
                    ShowDashboard();
                }
            }
        }

        private void button_report_Click(object sender, EventArgs e)
        {
            if (sub1Open == true)
            {
                sub1Open = false; timer_sub1.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false; timer_sub3.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false; timer_sub4.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false; timer_sub5.Start();
            }
            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            if (sub2Open == false)
            {
                sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            }
            else
            {
                sub2Open = false; timer_sub2.Start(); currentColorIndex = 0;
            }
            timer_color.Start();

            if (notInMain == false)
            {
                notInMain = true;
                titleTargetWidth = this.Width - panelTargetWidth;
            }
            else
            {
                if (oldColorIndex == 2)
                {
                    if (wasMenuOpen == true)
                    {
                        wasMenuOpen = false;
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                    if (menuOpen == true)
                    {
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                }

            }
            timer_title.Start();
            if (panel_form.Visible)
            {
                if (notInMain == false)
                {
                    if (!(formToShow is Dashboard))
                        ShowDashboard();
                }
                else
                {
                    panel_form.Visible = false;
                    label_title.Text = "";
                }

            }
            else
            {
                if (notInMain == false)
                {
                    panel_form.Visible = true;
                    ShowDashboard();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (sub1Open == true)
            {
                sub1Open = false; timer_sub1.Start();
            }
            if (sub2Open == true)
            {
                sub2Open = false; timer_sub2.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false; timer_sub4.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false; timer_sub5.Start();
            }
            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            if (sub3Open == false)
            {
                sub3Open = true; timer_sub3.Start(); currentColorIndex = 3;
            }
            else
            {
                sub3Open = false; timer_sub3.Start(); currentColorIndex = 0;
            }
            timer_color.Start();

            if (notInMain == false)
            {
                notInMain = true;
                titleTargetWidth = this.Width - panelTargetWidth;
            }
            else
            {
                if (oldColorIndex == 3)
                {
                    if (wasMenuOpen == true)
                    {
                        wasMenuOpen = false;
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                    if (menuOpen == true)
                    {
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                }

            }
            timer_title.Start();
            if (panel_form.Visible)
            {
                if (notInMain == false)
                {
                    if (!(formToShow is Dashboard))
                        ShowDashboard();
                }
                else
                {
                    panel_form.Visible = false;
                    label_title.Text = "";
                }

            }
            else
            {
                if (notInMain == false)
                {
                    panel_form.Visible = true;
                    ShowDashboard();
                }
            }
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            if (sub1Open == true)
            {
                sub1Open = false; timer_sub1.Start();
            }
            if (sub2Open == true)
            {
                sub2Open = false; timer_sub2.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false; timer_sub3.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false; timer_sub5.Start();
            }
            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            if (sub4Open == false)
            {
                sub4Open = true; timer_sub4.Start(); currentColorIndex = 4;
            }
            else
            {
                sub4Open = false; timer_sub4.Start(); currentColorIndex = 0;
            }
            timer_color.Start();

            if (notInMain == false)
            {
                notInMain = true;
                titleTargetWidth = this.Width - panelTargetWidth;
            }
            else
            {
                if (oldColorIndex == 4)
                {
                    if (wasMenuOpen == true)
                    {
                        wasMenuOpen = false;
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                    if (menuOpen == true)
                    {
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                }

            }
            timer_title.Start();
            if (panel_form.Visible)
            {
                if (notInMain == false)
                {
                    if (!(formToShow is Dashboard))
                        ShowDashboard();
                }
                else
                {
                    panel_form.Visible = false;
                    label_title.Text = "";
                }

            }
            else
            {
                if (notInMain == false)
                {
                    panel_form.Visible = true;
                    ShowDashboard();
                }
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (sub1Open == true)
            {
                sub1Open = false; timer_sub1.Start();
            }
            if (sub2Open == true)
            {
                sub2Open = false; timer_sub2.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false; timer_sub3.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false; timer_sub4.Start();
            }
            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            if (sub5Open == false)
            {
                sub5Open = true; timer_sub5.Start(); currentColorIndex = 5;
            }
            else
            {
                sub5Open = false; timer_sub5.Start(); currentColorIndex = 0;
            }
            timer_color.Start();

            if (notInMain == false)
            {
                notInMain = true;
                titleTargetWidth = this.Width - panelTargetWidth;
            }
            else
            {
                if (oldColorIndex == 5)
                {
                    if (wasMenuOpen == true)
                    {
                        wasMenuOpen = false;
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                    if (menuOpen == true)
                    {
                        notInMain = false;
                        titleTargetWidth = 0;
                    }
                }

            }
            timer_title.Start();
            if (panel_form.Visible)
            {
                if (notInMain == false)
                {
                    if (!(formToShow is Dashboard))
                        ShowDashboard();
                }
                else
                {
                    panel_form.Visible = false;
                    label_title.Text = "";
                }

            }
            else
            {
                if (notInMain == false)
                {
                    panel_form.Visible = true;
                    ShowDashboard();
                }
            }
        }

        private void timer_color_Tick(object sender, EventArgs e)
        {
            if (currentColorStep <= colorChangeSteps)
            {
                double currentRatio = (double)currentColorStep / colorChangeSteps;
                int red_panel = (int)(colors[oldColorIndex][0].R + (colors[currentColorIndex][0].R - colors[oldColorIndex][0].R) * currentRatio);
                int green_panel = (int)(colors[oldColorIndex][0].G + (colors[currentColorIndex][0].G - colors[oldColorIndex][0].G) * currentRatio);
                int blue_panel = (int)(colors[oldColorIndex][0].B + (colors[currentColorIndex][0].B - colors[oldColorIndex][0].B) * currentRatio);
                panel_sidebar.BackColor = panel_title.BackColor = Color.FromArgb(128, red_panel, green_panel, blue_panel);

                int red_button = (int)(colors[oldColorIndex][1].R + (colors[currentColorIndex][1].R - colors[oldColorIndex][1].R) * currentRatio);
                int green_button = (int)(colors[oldColorIndex][1].G + (colors[currentColorIndex][1].G - colors[oldColorIndex][1].G) * currentRatio);
                int blue_button = (int)(colors[oldColorIndex][1].B + (colors[currentColorIndex][1].B - colors[oldColorIndex][1].B) * currentRatio);
                button_menu.BackColor = button_x.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                Button[] buttons = panel_sidebar.Controls.OfType<Button>().ToArray();
                foreach (Button button in buttons)
                {
                    button.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                }
                foreach (Button button in submenu1_buttons)
                {
                    button.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                }
                foreach (Button button in submenu2_buttons)
                {
                    button.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                }
                foreach (Button button in submenu3_buttons)
                {
                    button.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                }
                foreach (Button button in submenu4_buttons)
                {
                    button.BackColor = Color.FromArgb(128, red_button, green_button, blue_button);
                }
                currentColorStep++;
            }
            else
            {
                timer_color.Stop();
            }
        }

        private void timer_title_Tick(object sender, EventArgs e)
        {
            if (menuOpen == true)
            {
                if (notInMain == true)
                {
                    panel_title.Width += 50 * (this.Width / 640);
                    if (panel_title.Width >= titleTargetWidth)
                    {
                        panel_title.Width = titleTargetWidth;
                        timer_title.Stop();
                    }
                }
                else
                {
                    panel_title.Width -= 50 * (this.Width / 640);
                    if (panel_title.Width <= titleTargetWidth)
                    {
                        panel_title.Width = titleTargetWidth;
                        timer_title.Stop();
                    }
                }
            }
            else
            {
                panel_title.Width -= 50 * (this.Width / 640);
                if (panel_title.Width <= titleTargetWidth)
                {
                    panel_title.Width = titleTargetWidth;
                    timer_title.Stop();
                    panelTargetWidth = panelCloseWidth;
                    timer_menu.Start();

                    //titleTimerEvent.Set();
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if (form.WindowState == FormWindowState.Maximized)
            {
                if (notInMain == false)
                {
                    panel_title.Width = 0;
                }
                if (menuOpen == false)
                {
                    panel_title.Width = 0;
                }
            }
            label_title.Location = new Point((panel_title.Width / 2) - 143, label_title.Location.Y);
        }

        private void button_x_Click(object sender, EventArgs e)
        {
            ShowDashboard();
            notInMain = false;
            oldColorIndex = currentColorIndex;
            currentColorIndex = 0;
            currentColorStep = 0;
            timer_color.Start();
            titleTargetWidth = 0;
            timer_title.Start();
            if (sub1Open == true)
            {
                sub1Open = false;
                timer_sub1.Start();
            }
            if (sub2Open == true)
            {
                sub2Open = false;
                timer_sub2.Start();
            }
            if (sub3Open == true)
            {
                sub3Open = false;
                timer_sub3.Start();
            }
            if (sub4Open == true)
            {
                sub4Open = false;
                timer_sub4.Start();
            }
            if (sub5Open == true)
            {
                sub5Open = false;
                timer_sub5.Start();
            }
            if (panel_form.Visible)
            {
                label_title.Text = "";
            }
        }

        private void timer_sub1_Tick(object sender, EventArgs e)
        {
            if (sub1Open == true)
            {
                if (panel_submenu1.Height < 396)
                {
                    panel_submenu1.Height += 36;
                }
                else
                {
                    timer_sub1.Stop();
                }
            }
            else
            {
                if (panel_submenu1.Height > 0)
                {
                    panel_submenu1.Height -= 36;
                }
                else
                {
                    timer_sub1.Stop();
                }

            }
        }

        private void timer_sub2_Tick(object sender, EventArgs e)
        {
            if (sub2Open == true)
            {
                if (panel_submenu2.Height < 396)
                {
                    panel_submenu2.Height += 36;
                }
                else
                {
                    timer_sub2.Stop();
                }
            }
            else
            {
                if (panel_submenu2.Height > 0)
                {
                    panel_submenu2.Height -= 36;
                }
                else
                {
                    timer_sub2.Stop();
                }

            }
        }

        private void timer_sub3_Tick(object sender, EventArgs e)
        {
            if (sub3Open == true)
            {
                if (panel_submenu3.Height < 136)
                {
                    panel_submenu3.Height += 8;
                }
                else
                {
                    timer_sub3.Stop();
                }
            }
            else
            {
                if (panel_submenu3.Height > 0)
                {
                    panel_submenu3.Height -= 8;
                }
                else
                {
                    timer_sub3.Stop();
                }

            }
        }

        private void timer_sub4_Tick(object sender, EventArgs e)
        {
            if (sub4Open == true)
            {
                if (panel_submenu4.Height < 178)
                {
                    panel_submenu4.Height += 9;
                }
                else
                {
                    panel_submenu4.Height = 178;
                    timer_sub4.Stop();
                }
            }
            else
            {
                if (panel_submenu4.Height > 0)
                {
                    panel_submenu4.Height -= 9;
                }
                else
                {
                    timer_sub4.Stop();
                }

            }
        }

        private void timer_sub5_Tick(object sender, EventArgs e)
        {
            if (sub5Open == true)
            {
                if (panel_submenu5.Height < 136)
                {
                    panel_submenu5.Height += 8;
                }
                else
                {
                    timer_sub5.Stop();
                }
            }
            else
            {
                if (panel_submenu5.Height > 0)
                {
                    panel_submenu5.Height -= 8;
                }
                else
                {
                    timer_sub5.Stop();
                }

            }
        }

        private void button_sub11_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniTuzel();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = button_sub11.Text;

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub12_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniGercek();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = button_sub12.Text;

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub13_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniSahis();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = button_sub13.Text;

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub14_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniAdiOrtak();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = button_sub14.Text;

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub15_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniYetkili();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = button_sub15.Text;

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub16_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YeniCerceveYetkili();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Çerçeve Sözleşmesi İle Yetkilendirilen Kişi";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub17_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new GelenFatura();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Gelen Fatura";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub18_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new GidenFatura();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Giden Fatura";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub19_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new DikkatKaydı();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Dikkat Kaydı";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub1Open = true; timer_sub1.Start(); currentColorIndex = 1;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub21_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MüsteriKontrol();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Kontrol";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub22_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new GuvenlikKontrolRapor();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Güvenlik Kontrol Raporu";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub23_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new KapakOlustur();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Kapak Oluşturma Ekranı";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub24_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MusteriListesi();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Listesi";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub25_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YetkiliListesi();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Yetkili Kişi Listesi";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub26_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new EksikEvrakRaporu();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Eksik Evrak Listesi";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub27_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new TakiptekiFaturalar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Takipteki Faturalar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub28_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new TopluMutabakat();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Toplu Mutabakat";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub29_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new TeslimTesellum();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Location = new Point(0, 0);
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Teslim Tesellüm";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub2Open = true; timer_sub2.Start(); currentColorIndex = 2;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub31_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MusteriRaporuİceAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Raporu İçe Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub3Open = true; timer_sub3.Start(); currentColorIndex = 3;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub32_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MusteriBelgeİceriAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Belgesi İçe Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub3Open = true; timer_sub3.Start(); currentColorIndex = 3;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub33_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new SatisRaporuİceAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Satış Raporu İçe Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub3Open = true; timer_sub3.Start(); currentColorIndex = 3;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();

        }

        private void button_sub41_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MusteriRaporuDisaAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Raporu Dışa Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub4Open = true; timer_sub4.Start(); currentColorIndex = 4;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub42_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new MusteriBilgileriDısaAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Müşteri Bilgisi Dışarı Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub4Open = true; timer_sub4.Start(); currentColorIndex = 4;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub43_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new SatisRaporuDisaAktar();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Satış Raporu Dışa Aktar";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub4Open = true; timer_sub4.Start(); currentColorIndex = 4;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub44_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new SozlesmeYazdir();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Sözleşme Yazdır";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub4Open = true; timer_sub4.Start(); currentColorIndex = 4;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub51_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new YedekAl();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Veritabanı Yedekle";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub5Open = true; timer_sub5.Start(); currentColorIndex = 5;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub52_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new SirketTanimla();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Şirket Tanımla";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub5Open = true; timer_sub5.Start(); currentColorIndex = 5;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private void button_sub53_Click(object sender, EventArgs e)
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }
            formToShow = new KullaniciTanimla();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "Kullanıcı Tanımla";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            sub5Open = true; timer_sub5.Start(); currentColorIndex = 5;
            currentColorStep = 0;
            timer_color.Start();
            notInMain = true;
            titleTargetWidth = this.Width - panelTargetWidth;
            timer_title.Start();
        }

        private async void ShowDashboard()
        {
            if (panel_form.Controls.Contains(formToShow))
            {
                panel_form.Controls.Remove(formToShow);
            }

            formToShow = new Dashboard();
            formToShow.TopLevel = false;
            formToShow.AutoScroll = true;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel_form.Controls.Add(formToShow);
            formToShow.Show();
            panel_form.Visible = true;
            label_title.Text = "";
            label_title.Text = "";

            oldColorIndex = currentColorIndex;
            currentColorStep = 0;
            if (menuOpen == false)
            {
                menuOpen = true;
                wasMenuOpen = false;
                panelTargetWidth = panelOpenWidth;
                timer_menu.Start();
            }
            currentColorIndex = 0;
            currentColorStep = 0;
            timer_color.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}