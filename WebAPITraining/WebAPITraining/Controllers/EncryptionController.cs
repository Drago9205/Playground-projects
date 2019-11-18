using System;
using System.Web.Http;
using WebAPITraining.Helpers;
using WebAPITraining.Models;
using WebAPITraining.Models.Encryption;

namespace WebAPITraining.Controllers
{
    [RoutePrefix("api/encryption")]
    public class EncryptionController : ApiController
    {
        //[Obsolete]
        public IHttpActionResult GetRandomEncryptedPhrase()
        {

            var result = new EncryptedData
            {
                RandomGuid = Guid.NewGuid()
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("encrypt")]
        [AcceptVerbs("POST")]
        public IHttpActionResult EncryptPhrase([FromBody]EncryptionData data)
        {
            var encryptionService = new EncryptionService();
            var result = new EncryptedData
            {
                EncryptedPhrase = encryptionService.EncryptTextToBase64(data.Phrase)
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("decrypt")]
        [AcceptVerbs("POST")]
        public IHttpActionResult DecryptPhrase([FromBody]EncryptionData data)
        {
            var encryptionService = new EncryptionService();
            var result = new EncryptedData
            {
                EncryptedPhrase = encryptionService.DecryptTextFromBase64(data.Phrase)
            };

            return Ok(result);
        }
    }
}
