using System.Linq;
using Common.Models;

namespace DataAccess.Services
{
    public class SettingsRetriever
    {
        public StorageSettingsModel GetFileStorageSettings()
        {
            using (var db = new WebApiTrainingEntities())
            {
                return db.FileStorageSettings.Select(x =>
                    new StorageSettingsModel
                    {
                        StorageFolder = x.StorageLocalFolder
                    }).FirstOrDefault();
            }
        }
    }
}
