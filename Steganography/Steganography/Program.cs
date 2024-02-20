using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Steganography
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToImage = args[0];
            //EncodeMessage(pathToImage, "adam je debil");
            string decodedMessage = DecodeMessage(pathToImage);
            Console.WriteLine("Decoded message: " + decodedMessage);
            Console.ReadKey();
        }

        static void EncodeMessage(string pathToImage, string text)
        {
            Bitmap newImage = null;
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
        }
        static string DecodeMessage(string pathToImage)
        {
            using (var image = new Bitmap(pathToImage))
            {
                StringBuilder message = new StringBuilder();
                int i = 0, j = 0;
                int direction = 1; // Start down-right

                while (true)
                {
                    Color c = image.GetPixel(j, i);
                    message.Append((char)c.B);

                    // Modify coordinates based on directionswitch (direction)
                    switch(direction)
                    {
                        case 1: // Down-right
                            j++;
                            i++;
                            break;
                        case 2: // Up-right
                            j--;
                            i++;
                            break;
                        case 3: // Down-left
                            j++;
                            i--;
                            break;
                        case 4: // Up-left
                            j--;
                            i--;
                            break;
                        }

                        // Change direction at boundariesif (j >= image.Width || j < 0 || i >= image.Height || i < 0)
                        {
                            direction++;
                            if (direction > 20) break; // Reached end
                        }
                    }

                    // Get message length from the last pixel
                    Color lastPixel = image.GetPixel(image.Width - 1, image.Height - 1);

                    return message.ToString();
                }
            }

        }

    }
