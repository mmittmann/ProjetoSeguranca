using System.Web.Http;

namespace Facensa.SegurancaApp.Controllers
{
    public class ValidationController : ApiController
    {
        public IHttpActionResult Get(string word)
        {
            return Ok();
        }
    }
}