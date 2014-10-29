using System;
using System.IO;
using System.Web;

namespace Facensa.SegurancaApp.Core.Infra
{
    public class File
    {
        private readonly string _filePath;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        public File(HttpContext context)
        {
            _filePath = context.Server.MapPath("~/App_Data/passwords.json");
        }

        public string GetFileContent()
        {
            using (_streamReader = new StreamReader(_filePath))
            {
                return _streamReader.ReadToEnd();
            }
        }

        public Stream GetFileStream()
        {
            using (_streamReader = new StreamReader(_filePath))
            {
                return _streamReader.BaseStream;
            }
        }


        public void SetFileContent(string content)
        {
            var sw = System.IO.File.CreateText(_filePath);

            using (_streamWriter = sw)
            {
                _streamWriter.Write(content);
            }
        }
    }
}
