using Azure.Communication.Email;
using FlawlessDevelopment.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FlawlessDevelopment.API.Endpoints
{
    public class SendMail(ILogger<SendMail> logger)
    {
        private readonly ILogger<SendMail> _logger = logger;

        [Function("SendMail")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            _logger.LogInformation("SendMail triggered.");
            try
            {
                var requestBody = new StreamReader(req.Body).ReadToEnd();

                var mailRequest = JsonConvert.DeserializeObject<MailRequest>(requestBody) ?? throw new ArgumentException("Request body could not be deserialized.");

                // RBAC validation, based on template chosen, load the template


                var template = GenerateTemplate(mailRequest.Template);

                var emailContent = new EmailContent(template.Body);

                // Send the email using API
                string connectionString = "<your ACS connection string>";
                var emailClient = new EmailClient(connectionString);

                var senderAddress = "you@yourverifieddomain.com";

                var emailRecipients = new EmailRecipients(mailRequest.To);

                var emailMessage = new EmailMessage(senderAddress, emailRecipients, emailContent);

                var result = await emailClient.SendAsync(Azure.WaitUntil.Completed, emailMessage);

                if (result.Value.Status != EmailSendStatus.Succeeded)
                {
                    return new BadRequestObjectResult(new InvalidOperationException($"Failed to send email. ID={result.Id}"));
                }

                return new OkObjectResult("Email(s) sent!");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error sending email: {message}", ex.Message);
                return new BadRequestObjectResult("Error sending email.");
            }
        }

        private MailTemplate GenerateTemplate(MailRequestTemplate templateChoice)
        {
            var builder = new MailTemplate()
            {
                Subject = templateChoice.ToString().Replace("_", " "),
                Body = GetBody(templateChoice)
            };

            return builder;
        }

        private static string GetBody(MailRequestTemplate templateChoice)
        {
            return templateChoice switch
            {
                MailRequestTemplate.Welcome => "Welcome to our service!",
                MailRequestTemplate.Password_Reset => "Click here to reset your password.",
                MailRequestTemplate.Order_Confirmation => "Your order has been confirmed!",
                _ => throw new ArgumentException("Invalid template choice", nameof(templateChoice)),
            };
        }

        private class MailTemplate()
        {
            public string? Subject { get; set; }

            public string? Body { get; set; }
        }
    }
}
