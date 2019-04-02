using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        public string ContactFormMessage { get; set; }

        public void OnGet()
        {

        }

        public async Task OnPost(string name, string email)
        {
            ContactFormMessage =
                "Thank you for your interest in Simple Store. We will contact you as soon as possible. ";

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var toEmailAddress = Environment.GetEnvironmentVariable("TO_EMAIL_ADDRESS");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = "Simple Store email inquiry";
            var to = new EmailAddress(toEmailAddress);
            var plainTextContent = $"Email inquiry from {name} sent on {DateTime.UtcNow.AddHours(11):F}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, plainTextContent);
            await client.SendEmailAsync(msg);
        }
    }
}
