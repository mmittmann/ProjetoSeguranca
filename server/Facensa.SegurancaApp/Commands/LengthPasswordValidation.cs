using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public class LengthPasswordValidation : IValidationCommand
    {
        public ValidationType Validate(string word)
        {
            if(word.Length < 4)
                return ValidationType.Weak;

            if (word.Length >= 4 && word.Length <= 8)
                return ValidationType.Medium;

            return ValidationType.Strong;
        }
    }
}