﻿using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Facensa.SegurancaApp.Core.Crypto;
using Facensa.SegurancaApp.Model;
using Facensa.SegurancaApp.Services;

namespace Facensa.SegurancaApp.Controllers
{
    public class AccountController : Controller
    {
        private const int DeslocateNumber = 5;
        private readonly LoginJsonRepository _repository;
        public AccountController()
        {
            _repository = new LoginJsonRepository(System.Web.HttpContext.Current);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            var caesarCrypter = new CaesarChipherEncryptor();
            var users = _repository.GetAll();

            if (!users.Any(u => u.Username == login.Username && caesarCrypter.Decrypt(u.Password, DeslocateNumber) == login.Password))
            {
                this.ModelState.AddModelError("Username", "Usuário e senha não conferem!");
                return View(login);
            }
            FormsAuthentication.SetAuthCookie(login.Username, true);
            return Redirect("/Home");
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var caesarEncrypter = new CaesarChipherEncryptor();
            var validationService = new PasswordValidationService();

            if (loginModel.Password != loginModel.ConfirmPassword)
            {
                ModelState.AddModelError("Password", "As senhas não conferem");
                return View(loginModel);
            }

            if (validationService.MeasurePasswordStrength(loginModel.Password) < 100)
            {
                ModelState.AddModelError("Password", "Senha não considerada forte. Por favor, coloque uma nova senha");
                return View(loginModel);
            }

            loginModel.Password = caesarEncrypter.Encrypt(loginModel.Password, DeslocateNumber);
            loginModel.ConfirmPassword = caesarEncrypter.Encrypt(loginModel.ConfirmPassword, 5);

            _repository.Save(loginModel);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }
    }
}