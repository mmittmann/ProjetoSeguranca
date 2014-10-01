using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facensa.SegurancaApp.Core.Crypto;
using Facensa.SegurancaApp.Model;

namespace Facensa.SegurancaApp.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        private readonly PasswordJsonRepository _repository;
        private readonly CaesarChipherEncryptor _caesarChipherEncryptor;
        private const int WordShift = 5;

        public PasswordController()
        {
            _repository = new PasswordJsonRepository(System.Web.HttpContext.Current);
            _caesarChipherEncryptor = new CaesarChipherEncryptor();
        }


        public ActionResult Index()
        {
            var passwords = _repository.GetAll();

            return View(passwords);
        }


        public ActionResult Show(string guid)
        {
            var password = _repository.GetSpecific(p => p.Id == guid);
            password.Password = _caesarChipherEncryptor.Decrypt(password.Password, WordShift);

            return View(password);
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Password/Create
        [HttpPost]
        public ActionResult Create(PasswordModel model)
        {
            try
            {
                model.Id = Guid.NewGuid().ToString();
                model.Password = _caesarChipherEncryptor.Encrypt(model.Password, WordShift);
                _repository.Save(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        //
        // GET: /Password/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _repository.GetSpecific(p => p.Id == id);

            return View(model);
        }

        //
        // POST: /Password/Edit/5
        [HttpPost]
        public ActionResult Edit(PasswordModel model)
        {
            try
            {
                var oldPass = _repository.GetSpecific(p => p.Id == model.Id);
                model.Password = _caesarChipherEncryptor.Encrypt(model.Password, WordShift);
                _repository.Edit(oldPass, model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(string id)
        {
            var pass = _repository.GetSpecific(p => p.Id == id);
            return View(pass);
        }


        [HttpPost]
        public ActionResult Delete(PasswordModel pass)
        {
            try
            {
                _repository.Delete(pass);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View(pass);
            }
        

        }
    }
}
