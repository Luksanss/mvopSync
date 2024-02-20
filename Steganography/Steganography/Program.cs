using System;
using System.Drawing;
using System.Collections.Generic;

namespace Steganography;

class Program
{
    public static void Main(string[] args)
    {
        string pathToImage = args[0];

        Bitmap newImage = null;
        using (var image = new Bitmap(pathToImage))
        {
            newImage = new Bitmap(image);

        }


    }

}