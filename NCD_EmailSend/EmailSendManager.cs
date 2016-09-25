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
        public static async Task EmailSendAsync(string body, string destination, string subject, List<Attachment> attachments = null)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(destination));
                message.Subject = subject;
                message.Body = body;

                //add attachments
                if (attachments != null)
                    foreach (var item in attachments)
                        message.Attachments.Add(item);

                try
                {
                    //async send
                    using (var smtp = new SmtpClient())
                    {
                        await smtp.SendMailAsync(message);
                    }
                }
                finally
                {
                    //dispose all attachments
                    foreach (var item in message.Attachments)
                        item.Dispose();
                }
            }
        }
    }
}
