using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Services
{
    public class PasswordValidationService : IValidationService
    {
        public double MeasurePasswordStrength(string word)
        {
            double passwordStrength = 0;

            var validators = new List<IValidationCommand>
            {
                new CharContainsValidation(),
                new DicionaryValidation(),
                new RepeatCharValidation(),
                new LengthPasswordValidation()
            };

            foreach (var validator in validators)
            {
                var validateResponse = validator.Validate(word);

                if (validateResponse == ValidationType.Strong)
                    passwordStrength += 25;

                if (validateResponse == ValidationType.Weak)
                    passwordStrength -= 25;
            }

            return passwordStrength;
        }
    }
}