namespace Common.Models
{
    public class EncryptionHistoryModel
    {
        public string Phrase { get; set; }

        public string EncryptedPhrase { get; set; }
        public int Count { get; set; }
        public byte[] KeyBytes { get; set; }
        public byte[] VectorBytes { get; set; }
    }
}
