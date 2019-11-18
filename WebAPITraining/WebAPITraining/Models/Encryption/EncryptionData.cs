namespace WebAPITraining.Models.Encryption
{
    public class EncryptionData
    {
        public string Phrase { get; set; }
        public string EncryptionKey { get; set; }
        public string EncryptionVector { get; set; }
        public byte[] KeyBytes { get; set; }
        public byte[] VectorBytes { get; set; }
    }
}
