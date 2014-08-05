using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Services
{
    public interface IValidationService
    {
        ValidationType Validate(string word);
    }
}