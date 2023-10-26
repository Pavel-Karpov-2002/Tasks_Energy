using System;
using System.Net;
using System.Net.Mail;
using Task_2_API;

namespace Task_2
{
    class Program
    {
        private const string Path = @"..\Resources\test.json";

        private const string Host = "smtp.mail.ru";
        private const int Port = 25;

        private const string FromName = "Pavel";
        private const string FromMail = "pavel_karpov_02@mail.ru";
        private const string FromPassword = "BgpFMi2FEqxtWimU7Utw";

        private const string MailHeader = "Affected areas";

        static void Main(string[] args)
        {
            try
            {
                string file = JsonParse.GetJson(Path).Result;
                Breakage breakage = JsonParse.GetObject<Breakage>(file);
                Console.WriteLine("Enter the sending email address: ");
                string toMail = Console.ReadLine();
                SendMessage(breakage.ToString(), toMail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static void SendMessage(string message, string toMail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = Host;
            client.Port = Port;
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;

            NetworkCredential networkCredential = new NetworkCredential(FromMail, FromPassword);
            client.Credentials = networkCredential;

            MailAddress from = new MailAddress(FromMail, FromName);
            MailAddress to = new MailAddress(toMail, MailHeader);

            MailMessage mailMessage = new MailMessage(from, to);

            mailMessage.Subject = MailHeader;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = message;

            client.Send(mailMessage);
            Console.WriteLine("Message sent");
        }
    }
}
