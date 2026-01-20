using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class IconConverter
{
    static void Main()
    {
        string pngPath = @"d:\GitHub_Project\OneClickFullShutdown\WinFormsShutdown\power_button.png";
        string icoPath = @"d:\GitHub_Project\OneClickFullShutdown\WinFormsShutdown\app_icon.ico";

        using (var img = Image.FromFile(pngPath))
        using (var bmp = new Bitmap(img, new Size(256, 256)))
        {
            Icon icon = Icon.FromHandle(bmp.GetHicon());
            using (FileStream fs = new FileStream(icoPath, FileMode.Create))
            {
                icon.Save(fs);
            }
        }

        Console.WriteLine("Icon created successfully!");
    }
}
