using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Services
{
    public interface IValidationService
    {
        double MeasurePasswordStrength(string word);
    }
}