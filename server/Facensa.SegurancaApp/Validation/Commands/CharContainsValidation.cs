using System.Linq;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public class CharContainsValidation : IValidationCommand
    {
        public ValidationType Validate(string word)
        {
            var passwordForce = ValidationType.Weak;

            if (word.Any(char.IsUpper))
                passwordForce = ValidationType.Medium;

            var specialChars = "!@#$%^&*()".ToCharArray();

            if (word.IndexOfAny(specialChars) >= 0)
                passwordForce = ValidationType.Strong;

            return passwordForce;
        }
    }
}