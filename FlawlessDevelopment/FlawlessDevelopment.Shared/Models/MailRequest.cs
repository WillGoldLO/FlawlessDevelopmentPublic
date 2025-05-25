using System.Net.Mail;
using Azure.Communication.Email;

namespace FlawlessDevelopment.Shared.Models
{
    public class MailRequest
    {
        public List<EmailAddress> To { get; set; }
        public MailRequestTemplate Template { get; set; }
    }
}
