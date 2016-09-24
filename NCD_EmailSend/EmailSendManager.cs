using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NCD_EmailSend
{
    public static class EmailSendManager
    {
        public static async Task EmailSendAsync(string body, string destination, string subject)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(destination));
            message.Subject = subject;
            message.Body = body;
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
