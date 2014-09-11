using System.Web.Http;
using Facensa.SegurancaApp.Services;

namespace Facensa.SegurancaApp.Controllers
{
    public class ValidationController : ApiController
    {
        public IHttpActionResult Get(string word)
        {
            var validation = new PasswordValidationService();
            var response  = validation.MeasurePasswordStrength(word);

            return Ok(response);
        }

    }
}