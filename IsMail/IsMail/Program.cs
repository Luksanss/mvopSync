using System.Text.RegularExpressions;

namespace IsMail;

class Program
{
    public static void Main(string[] args)
    {
        string userMail = "papariga.lu.2020@ssps.cz";

        Console.WriteLine(IsMail(userMail));

        string[] userMails = { "jan.novak@seznam.cz", "jannovak@mail.cz", "jan_novak111@centrum.cz", "@mail.cz", "ahoj.cz" };

        foreach (string mail in userMails)
        {
            Console.WriteLine(IsMail(mail));
        }

        // IsMail() -> no need for regex

        // Console.WriteLine("Hack");
        // 
        // try
        // {
        //     Console.WriteLine(IsMail(userMail));
        // }
        // catch
        // {
        //     Console.WriteLine("Not good");
        // }

    

        Console.ReadKey();
    }

    public static bool IsMail(string userMail)
    {
        Regex validatro = new Regex(@"^[\[\w\._-]+@[\w]+\.\w{1,18}$");

        return validatro.IsMatch(userMail);
    }


}