using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DataAccess.Services;

namespace WebAPITraining.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Upload()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest("Not a proper multipart MIME type");
            }

            var context = HttpContext.Current;
            var request = context.Request;

            var files = request.Files;

            if (files.Count > 0)
            {
                //TODO: Move to Service that does the logic for storing files and only be responsible for handling the request and providing a response
                var responseMessage = new List<string>();
                try
                {
                    for (int i = 0; i < files.Count; i++)
                    {
                        var file = files[i];
                        var generateFileFolder = GenerateFileFolder(file);
                        var fullFilePath = generateFileFolder + Path.GetFileName(file.FileName);
                        CreateDirectoryIfNotExistent(generateFileFolder);
                        file.SaveAs(fullFilePath);

                        responseMessage.Add(string.Format(CultureInfo.InvariantCulture, "File: \"{0}\" uploaded successfully!", file.FileName));
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return Ok(string.Join("\n", responseMessage));
            }

            return BadRequest("No files to Upload");

        }

        private string GenerateFileFolder(HttpPostedFile file)
        {
            var type = Path.GetExtension(file.FileName).Substring(1);
            var firstLetter = Path.GetFileName(file.FileName)[0];

            var settings = new SettingsRetriever().GetFileStorageSettings();
            var path = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/", settings.StorageFolder, type, firstLetter);

            return path;
        }

        private void CreateDirectoryIfNotExistent(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
