using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public interface IValidationCommand
    {
        ValidationType Validate(string word);  
    }
}