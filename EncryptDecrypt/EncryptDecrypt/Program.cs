using System.IO;

namespace EncryptDecrypt;

class Program
{
    static void Main(string[] args)
    {
        string key = args[0];

        string fileName = args[1];

        var sw = Path.GetExtension(fileName) == ".cry" ? new StreamWriter(Path.ChangeExtension(fileName, ".txt")) : new StreamWriter(Path.ChangeExtension(fileName, ".cry"));
        

        using (StreamReader sr = new StreamReader(fileName))
        {
            string linee;

            while ((linee = sr.ReadLine()) != null)
            {
                sw.WriteLine(Encrypt(linee, key));
            }
            sw.Close();
        }
    }

    static string Encrypt(string linee, string key)
    {
        string outString = "";

        int index = 0;

        char xoredChar;

        for (int i = 0; i < linee.Length; i++)
        {
            xoredChar = (char) (linee[i] ^ key[index]);
            outString += xoredChar;
        }

        return outString;
    }

}

