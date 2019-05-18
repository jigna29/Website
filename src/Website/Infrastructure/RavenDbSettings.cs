namespace Website.Infrastructure
{
    public class RavenDbSettings
    {
        /// <summary>
        /// The URL where the database is located.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The name of the database.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// The PFX certificate file name used to securely connect to the database. Optional.
        /// </summary>
        public string CertFileName { get; set; }

        /// <summary>
        /// The password for the PFX certificate. Optional.
        /// </summary>
        public string CertPassword { get; set; }
    }
}
