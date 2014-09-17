using System.Web.Http;
using Facensa.SegurancaApp.Generate.Service;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Controllers
{
    public class GenerateController : ApiController
    {
        public IHttpActionResult Get(int length, ValidationType validationType)
        {
            var generatePasswordService = new PasswordGenerateService();

            var password = generatePasswordService.Generate(length, validationType);

            return Ok(password);
        }
    }
}
