using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PostmarkDotNet;
using Raven.Client.Documents.Session;
using Website.Infrastructure;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        public string ContactFormMessage { get; set; }
        private readonly IAsyncDocumentSession _session;
        private readonly PostmarkClient _postmarkClient;

        public IndexModel(IAsyncDocumentSession session, PostmarkClient postmarkClient)
        {
            _session = session;
            _postmarkClient = postmarkClient;
        }

        public void OnGet()
        {

        }

        public async Task OnPost(string name, string email)
        {
            ContactFormMessage =
                "Thank you for your interest in Simple Store. We will contact you as soon as possible. ";

            var toEmailAddress = Environment.GetEnvironmentVariable("TO_EMAIL_ADDRESS");

            var emailMessage = new PostmarkMessage()
            {
                To = toEmailAddress,
                From = "info@simplestore.io",
                Subject = "Simple Store email inquiry",
                TrackOpens = true,
                Tag = "Enquiry",
                TextBody = $"Email inquiry from {name} sent on {DateTime.UtcNow.AddHours(11):F}",
            };

            await _postmarkClient.SendMessageAsync(emailMessage);

            var entry = new EnquiryEntries
            {
                Name = name,
                Email = email,
                EmailSent = true,
                CreatedOnUtc = DateTime.UtcNow
            };

            await _session.StoreAsync(entry);
            await _session.SaveChangesAsync();
        }
    }
}
