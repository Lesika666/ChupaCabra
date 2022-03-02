using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Saruman.Utilies
{
    class screen
    {
        public static void get_scr(string string_0)
        {
            try
            {
                
                int width = Screen.PrimaryScreen.Bounds.Width;
                int height = Screen.PrimaryScreen.Bounds.Height;
                Bitmap bitmap = new Bitmap(width, height);
                Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                bitmap.Save(string_0 + "\\screen.jpeg", ImageFormat.Jpeg);
            }
            catch (Exception item)
            {

            }
        }
    }
}
