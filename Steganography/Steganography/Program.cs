using System;
using System.Drawing;
using System.Collections.Generic;
using System.Xml.Schema;

namespace Steganography;

class Program
{
    public static void Main(string[] args)
    {
        string pathToImage = args[0];

        Bitmap newImage = null;

        string text = "ahoj stenografie";
        int n = 0;
        int j = 0;
        int i = 0;

        using (var image = new Bitmap(pathToImage))
        {
            newImage = new Bitmap(image);
            var fileInfo = new FileInfo(pathToImage).Length;

            while (true) 
            {
                Color c = image.GetPixel(j, i);
                Color setPix = Color.FromArgb(c.R, c.G, Convert.ToByte(text[n]));
                newImage.SetPixel(j, i, setPix);
                j++;
                i++;
                n++;
                if (n > text.Length - 1) break;
            }

        }
        Color cLast = newImage.GetPixel(newImage.Width - 1, newImage.Height - 1);
        Color setPixLast = Color.FromArgb(
           cLast.R, cLast.G, Convert.ToByte(text.Length));
        newImage.SetPixel(newImage.Width - 1, newImage.Height - 1, setPixLast);

        newImage.Save("newImg.bmp");
        Console.WriteLine("done running");

        Console.ReadKey();
    }

}