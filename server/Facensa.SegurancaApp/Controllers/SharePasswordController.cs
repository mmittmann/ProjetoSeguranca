using Facensa.SegurancaApp.Core.Crypto;
using Facensa.SegurancaApp.Core.Infra;
using Facensa.SegurancaApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Facensa.SegurancaApp.Controllers
{
    public class SharePasswordController : Controller
    {

        private readonly PasswordJsonRepository _repository;
        private RSACrypto _rsaCrypto;

        public SharePasswordController()
        {
            _repository = new PasswordJsonRepository(System.Web.HttpContext.Current);



            if (System.Web.HttpContext.Current.Session["rsa"] == null)
            {
                _rsaCrypto = new RSACrypto();
                System.Web.HttpContext.Current.Session["rsa"] = _rsaCrypto;
            }
            else
            {
                _rsaCrypto = (RSACrypto)System.Web.HttpContext.Current.Session["rsa"];

            }
        }


        public ActionResult Index()
        {
            var passwords = _repository.GetAll();

            var s = _rsaCrypto.GetPublicKey();
            ViewBag.PublicKey1 = s.Key;
            ViewBag.PublicKey2 = s.Value;


            return View(passwords);
        }

        [HttpPost]
        public ActionResult Download(string publikKeyVal, string publicKey)
        {
            var passwords = _repository.GetAll();

            CaesarChipherEncryptor ce = new CaesarChipherEncryptor();

            string pass = "";

            foreach (var p in passwords)
            {

                string line = p.System + "," + p.User + "," + ce.Decrypt(p.Password, 5);

                var crypt = _rsaCrypto.Encrypt(line, new KeyValuePair<uint, uint>(uint.Parse(publikKeyVal), uint.Parse(publicKey)));

                foreach (var c in crypt)
                {
                    pass += c + " ";
                }
                pass += "\r\n";
            }

            return File(Encoding.UTF8.GetBytes(pass), "text/plain", "rsaEncryptedPassword.csv");

        }

        public ActionResult Upload(HttpPostedFileBase arquivo)
        {
            try
            {
                var content = "";

                if (arquivo.ContentLength > 0)
                {

                    var file = new Facensa.SegurancaApp.Core.Infra.File(System.Web.HttpContext.Current);

                    var encryptedFileContent = "";
                    using (var sr = new StreamReader(arquivo.InputStream))
                    {
                        encryptedFileContent = sr.ReadToEnd();
                    }

                    var fileLines = encryptedFileContent.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

                    foreach(var l in fileLines)
                    {
                        var list = new List<uint>();
                        var a = l.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var c in a)
                        {
                            list.Add((uint)int.Parse(c));
                        }

                        content += _rsaCrypto.Decrypt(list) + "\r\n";
                    }
                }

                ViewBag.content = content;

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