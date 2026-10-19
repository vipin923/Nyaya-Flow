namespace Nyaya_Flow.Services
{
    public class BnsLegalDictionary
    {
        public static List<LegalCharge> GetCyberCrimeMappings()
        {
            return new List<LegalCharge>
            {
                new LegalCharge
                {
                    BnsSection = "Section 318",
                    OldIpcSection = "IPC 420",
                    CrimeType = "Cheating & Dishonest Inducement",
                    Description = "Using a deepfake to deceive someone into delivering property or funds.",
                    SuggestedAction = "Draft FIR for digital fraud under BNS 318(4)."
                },
                new LegalCharge
                {
                    BnsSection = "Section 336",
                    OldIpcSection = "IPC 463/465",
                    CrimeType = "Forgery of Electronic Record",
                    Description = "The act of creating the synthetic/deepfake image itself to be used as authentic.",
                    SuggestedAction = "Attach Cryptographic Seal as proof of forged electronic record."
                },
                new LegalCharge
                {
                    BnsSection = "Section 338",
                    OldIpcSection = "IPC 469",
                    CrimeType = "Forgery for Purpose of Harming Reputation",
                    Description = "Creating a deepfake to defame or blackmail a targeted individual.",
                    SuggestedAction = "File alongside Information Technology Act sections."
                },
                new LegalCharge
                {
                    BnsSection = "Section 111",
                    OldIpcSection = "IPC 469",
                    CrimeType = "Covers kidnapping, robbery, extortion, and cybercrime committed by a syndicate.",
                    Description = "Creating a deepfake to defame or blackmail a targeted individual.",
                    SuggestedAction = "File alongside Information Technology Act sections."
                }
            };
        }
    }

    public class LegalCharge
    {
        public string BnsSection { get; set; }
        public string OldIpcSection { get; set; }
        public string CrimeType { get; set; }
        public string Description { get; set; }
        public string SuggestedAction { get; set; }
    }
}

