using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace WebAPI.Mail
{
    public static class Email
    {

        public static EmailMessage CreateEmailMessage(string sender, string reciver,string subject, string body)
        {
            EmailMessage email = new EmailMessage();
            email.Sender = new MailboxAddress("Fitnes centar",sender);
            email.Reciever = new MailboxAddress(reciver,reciver);
            email.Subject = subject;
            email.Content = body;
            return email;
        }

        public static MimeMessage CreateMimeMessage(EmailMessage email)
        {
            var mimeMessaage = new MimeMessage();
            mimeMessaage.From.Add(email.Sender);
            mimeMessaage.To.Add(email.Reciever);
            mimeMessaage.Subject = "Login information";
            mimeMessaage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = email.Content };
            return mimeMessaage;
        }
        public static void Send(MimeMessage message,MailData mailData)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(mailData.SmtpServer, mailData.Port, true);
                    smtpClient.Authenticate(mailData.UserName, mailData.Password);
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);

                }
            }
            catch { }
        }
    }
}
