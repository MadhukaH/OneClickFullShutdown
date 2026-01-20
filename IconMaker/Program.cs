using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string pngPath = @"D:\GitHub_Project\OneClickFullShutdown\WinFormsShutdown\power_button.png";
        string icoPath = @"D:\GitHub_Project\OneClickFullShutdown\WinFormsShutdown\app_icon.ico";

        // Load PNG
        using var originalImage = Image.FromFile(pngPath);
        
        // Create memory stream for ICO
        using var ms = new MemoryStream();
        using var bw = new BinaryWriter(ms);

        // ICO header
        bw.Write((short)0);  // Reserved
        bw.Write((short)1);  // Image type (1 = icon)
        bw.Write((short)4);  // Number of images

        // Sizes to include
        int[] sizes = { 16, 32, 48, 256 };
        long[] imageDataOffsets = new long[sizes.Length];
        byte[][] imageData = new byte[sizes.Length][];

        // Generate each size
        for (int i = 0; i < sizes.Length; i++)
        {
            int size = sizes[i];
            using var resized = new Bitmap(originalImage, size, size);
            using var pngStream = new MemoryStream();
            resized.Save(pngStream, ImageFormat.Png);
            imageData[i] = pngStream.ToArray();
        }

        // Write directory entries
        int offset = 6 + (16 * sizes.Length); // Header + directory entries
        for (int i = 0; i < sizes.Length; i++)
        {
            bw.Write((byte)(sizes[i] == 256 ? 0 : sizes[i])); // Width (0 means 256)
            bw.Write((byte)(sizes[i] == 256 ? 0 : sizes[i])); // Height
            bw.Write((byte)0);  // Color palette
            bw.Write((byte)0);  // Reserved
            bw.Write((short)1); // Color planes
            bw.Write((short)32); // Bits per pixel
            bw.Write(imageData[i].Length); // Size of image data
            bw.Write(offset); // Offset to image data
            offset += imageData[i].Length;
        }

        // Write image data
        foreach (var data in imageData)
        {
            bw.Write(data);
        }

        // Save to file
        File.WriteAllBytes(icoPath, ms.ToArray());
        
        Console.WriteLine($"✓ Icon created: {Path.GetFullPath(icoPath)}");
        Console.WriteLine($"  Size: {new FileInfo(icoPath).Length / 1024} KB");
    }
}
