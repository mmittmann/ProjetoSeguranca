using System.Linq;
using System.Text.RegularExpressions;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Services
{
    public class PasswordValidationService : IValidationService
    {
        public ValidationType Validate(string word)
        {
            var passwordForce = ValidationType.Weak;

            if (word.Any(char.IsUpper))
                passwordForce = ValidationType.Medium;

            var specialChars = "!@#$%^&*()".ToCharArray();

            if(word.IndexOfAny(specialChars)  >= 0)
                passwordForce = ValidationType.Strong;

            return passwordForce;
        }
    }
}