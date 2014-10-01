using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Facensa.SegurancaApp.Services;

namespace Facensa.SegurancaApp.CustomValidations
{
    public class StrongPassword : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            const double maxPasswordStrength = 100;

            var validationService = new PasswordValidationService();
            return validationService.MeasurePasswordStrength((string)value) == maxPasswordStrength;
        }
    }
}