using System;

namespace Website.Infrastructure
{
    public class EnquiryEntries
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public bool EmailSent { get; set; }

        public DateTime CreatedOnUtc { get; set; }
    }
}
