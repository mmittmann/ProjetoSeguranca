using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Facensa.SegurancaApp.Model
{
    public class FileModel
    {
        [Required]
        public HttpPostedFileBase PostedFile { get; set; }

        [Required]
        public string Key { get; set; }
    }
}