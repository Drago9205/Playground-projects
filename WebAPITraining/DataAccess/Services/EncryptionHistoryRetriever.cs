using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models;

namespace DataAccess.Services
{
    public class EncryptionHistoryRetriever
    {

        public EncryptionHistoryModel GetEncryptionHistoroyById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EncryptionHistoryModel> GetEncryptionHistory()
        {
            using (var db = new WebApiTrainingEntities())
            {
                return db.RijndaelAESEncryptionHistories.Select(x => new EncryptionHistoryModel
                {
                    EncryptedPhrase = x.EncryptedPhrase,
                    Phrase = x.SourcePhrase,
                    Count = x.PhraseEncryptionRequestsCount,
                    KeyBytes = x.EncryptionKeyUsed,
                    VectorBytes = x.EncryptionVectorUsed
                });
            }
        }
    }
}
