/* 
    Author : LimerBoy
    Github : github.com/LimerBoy/StormKitty
*/

using System;

namespace Anubis
{
    internal sealed class cli
    {
        public static string GetBoolValue(string text)
        {
            
            string result = Console.ReadLine();
            return result.ToUpper() == "Y" ? "1" : "0";
        }

    


    }
}
