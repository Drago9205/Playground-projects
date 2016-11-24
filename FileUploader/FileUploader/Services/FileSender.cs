using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FileUploader.Services
{
    public class FileSender
    {
        public static bool UploadFiles(string[] files, out string outputMessage)
        {
            //var uploadServiceBaseAddress = Constants.Constants.ApiSettings.ApiFileUploadEndpoint;
            //This is for debugging purposes
            var uploadServiceBaseAddress = "http://localhost:21678/api/file/upload";

            try
            {
                using (var client = new HttpClient())
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        var fileStreamList = new List<FileStream>();
                        foreach (var file in files)
                        {
                            var filestream = new FileStream(file, FileMode.Open);
                            HttpContent fileStreamContent = new StreamContent(filestream);
                            formData.Add(fileStreamContent, filestream.Name, filestream.Name);
                            fileStreamList.Add(filestream);
                            //HttpContent stringContent = new StringContent(filestream.Name);
                            //HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
                            //formData.Add(stringContent, "param1", "param1");
                            //formData.Add(bytesContent, "file2", "file2");
                        }

                        var response = client.PostAsync(uploadServiceBaseAddress, formData).Result;
                        fileStreamList.ForEach(x => x.Dispose());
                        if (!response.IsSuccessStatusCode)
                        {
                            outputMessage = $"Response code: {response.StatusCode}\nResponse msessage: {response.Content.ReadAsStringAsync()}"; ;
                            return false;
                        }
                        outputMessage = response.Content.ReadAsStringAsync().Result;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                outputMessage = ex.Message;
                return false;
            }
        }
    }
}