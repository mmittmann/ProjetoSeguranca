using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Facensa.SegurancaApp.Core.Crypto;
using Facensa.SegurancaApp.Generate.Service;
using Facensa.SegurancaApp.Model;
using Facensa.SegurancaApp.Models;
using File = Facensa.SegurancaApp.Core.Infra.File;

namespace Facensa.SegurancaApp.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GerarateKey()
        {
            var passwordGenerateService = new PasswordGenerateService();
            var key = passwordGenerateService.Generate(24);

            return Json(key, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Download(string key)
        {
            var file = new File(System.Web.HttpContext.Current);

            var tripleDesEncryptor = new TripleDESEncrypt(key);

            var content = file.GetFileContent();

            var encryptedContent = tripleDesEncryptor.Encrypt(content);

            ViewBag.GeneratedPassword = key;

            return File(Encoding.UTF8.GetBytes(encryptedContent), "text/plain", "encryptedPassword.txt");

        }

        [HttpPost]
        public ActionResult Upload(FileModel model)
        {
            try
            {
                if (model.PostedFile.ContentLength > 0)
                {
                    var tripleDesEncryptor = new TripleDESEncrypt(model.Key);

                    var file = new File(System.Web.HttpContext.Current);

                    var encryptedFileContent = "";
                    using (var sr = new StreamReader(model.PostedFile.InputStream))
                    {
                        encryptedFileContent = sr.ReadToEnd();
                    }

                    var decryptedValue = tripleDesEncryptor.Decrypt(encryptedFileContent);

                    file.SetFileContent(decryptedValue);
                }

                return View("Index");
            }
            catch (Exception)
            {

                ViewBag.Erro = "Esta chave é inválida";
                return View("Index");
            }

        }
    }
}