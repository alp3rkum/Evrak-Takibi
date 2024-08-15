using Evrak_Takibi_Programı.Diğer;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Diagnostics;
using System.Linq;

namespace Evrak_Takibi_Programı
{
    internal static class Program
    {
        public static bool userClosed = false;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Process currentProcess = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processes.Length > 1)
            {
                MessageBox.Show("Uygulama zaten açık!");
                Application.Exit();
            }
            else
            {
                ApplicationConfiguration.Initialize();
                DBKontrol.DatabaseCheck();
                if (LisansAnahtarı.AnahtarSayisiGetir() == 0)
                {
                    Application.Run(new İlkKullanici());
                }
                else
                {
                    Application.Run(new Diğer.LisansAnahtari(true));
                    if (userClosed == true)
                    {
                        Application.Exit();
                    }

                }
            }
        }
    }
}