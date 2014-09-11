using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public class DateValidation : IValidationCommand
    {
        public ValidationType Validate(string word)
        {
            var regex = new Regex("^[0-9]{6,8}$");

            if(!regex.Match(word).Success)
                return ValidationType.Strong;
            
            //int d, m, a;

            //var dia = word.Substring(0, 2);
            //var mes = word.Substring(2, 2);
            //var ano = word.Substring(4);

            //if (!int.TryParse(dia, out d) || !int.TryParse(mes, out m) || !int.TryParse(ano, out a))
            //    return ValidationType.Strong;

            //if (d <= 31 && m <= 12 && a >= 0)
            //    return ValidationType.Weak;

            return ValidationType.Weak;
        }
    }
}