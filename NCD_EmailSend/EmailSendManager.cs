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
        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="body">email body</param>
        /// <param name="destination">destination email</param>
        /// <param name="subject">email subject</param>
        /// <param name="attachments">attachments for email</param>
        /// <returns></returns>
        public static async Task EmailSendAsync(string body, string destination, string subject, IEnumerable<Attachment> attachments = null)
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

        /// <summary>
        /// Validate email
        /// </summary>
        /// <param name="emailAddress">string email</param>
        /// <returns></returns>
        public static bool IsValidEmail(string emailAddress)
        {
            try
            {
                var email = new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
