namespace Nyaya_Flow.Models
{
    public class EvidenceStore
    {
        public Guid EvidenceId { get; set; } = new Guid();
        public string ClientName { get; set; } = string.Empty;
        public string ClientHash { get; set; } = string.Empty;
        public string DigitalSeal { get; set; } = string.Empty;
        public byte[] EvidenceFile { get; set; }
        public bool IsAdmissible { get; set; }
        public double SyntheticProbability { get; set; } = 0.0;
        public DateTime UploadTimestamp { get; set; }
    }
}
