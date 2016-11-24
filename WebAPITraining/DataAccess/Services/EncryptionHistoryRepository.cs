using System;
using Common.Models;

namespace DataAccess.Services
{
    public class EncryptionHistoryRepository
    {
        public bool SaveEncryptionRecord(EncryptionHistoryModel encryption)
        {
            try
            {
                using (var db = new WebApiTrainingEntities())
                {
                    db.RijndaelAESEncryptionHistories.Add(new RijndaelAESEncryptionHistory
                    {
                        EncryptedPhrase = encryption.EncryptedPhrase,
                        PhraseEncryptionRequestsCount = encryption.Count,
                        EncryptionKeyUsed = encryption.KeyBytes,
                        SourcePhrase = encryption.Phrase,
                        EncryptionVectorUsed = encryption.VectorBytes
                    });

                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
