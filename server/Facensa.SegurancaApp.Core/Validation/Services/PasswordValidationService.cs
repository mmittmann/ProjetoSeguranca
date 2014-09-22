using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Services
{
    public class PasswordValidationService : IValidationService
    {
        private const double valueWeakPassword = 20, valueMediumPassword = 50, valueStrongPassword = 100;

        public double MeasurePasswordStrength(string word)
        {
            double strongPassword = 0,
                weakPassword = 0,
                mediumPassword = 0;

            var validators = new List<IValidationCommand>
            {
                new CharContainsValidation(),
                new DicionaryValidation(),
                new RepeatCharValidation(),
                new LengthPasswordValidation(),
                new DateValidation()
            };

            foreach (var validator in validators)
            {
                var validateResponse = validator.Validate(word);

                if (validateResponse == ValidationType.Strong)
                    strongPassword += 20;
                else if (validateResponse == ValidationType.Medium)
                    mediumPassword += 20;
                else
                    weakPassword += 20;
            }

            if (weakPassword >= strongPassword && weakPassword >= mediumPassword)
                return valueWeakPassword;
            else if (mediumPassword >= strongPassword && mediumPassword > weakPassword)
                return valueMediumPassword;
            else
                return valueStrongPassword;
        }
    }
}