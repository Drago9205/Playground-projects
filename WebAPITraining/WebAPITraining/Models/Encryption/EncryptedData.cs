using System;

namespace WebAPITraining.Models
{
    public class EncryptedData
    {
        public Guid RandomGuid { get; set; }
        public string EncryptedPhrase { get; set; }
    }
}
