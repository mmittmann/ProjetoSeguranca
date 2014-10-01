using System.IO;
using System.Web.Mvc;
using Facensa.SegurancaApp.Model;

namespace Facensa.SegurancaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginJsonRepository _loginJsonRepository;
        public HomeController()
        {
            _loginJsonRepository = new LoginJsonRepository(System.Web.HttpContext.Current);
        }

        public ActionResult Index()
        {
            if (IsFirstAccess())
                return RedirectToAction("RegisterUser", "Account");
            else if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else return View();
        }

        private bool IsFirstAccess()
        {
            var logins = _loginJsonRepository.GetAll();
            return logins == null || logins.Count == 0;
        }


    }
}
