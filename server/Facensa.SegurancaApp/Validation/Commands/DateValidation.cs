using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Facensa.SegurancaApp.Models;
using Facensa.SegurancaApp.Services;
using Facensa.SegurancaApp.Utils;

namespace Facensa.SegurancaApp.Commands
{
    public class DateValidation : IValidationCommand
    {
        DateUtilService _dateUtilService;

        public DateValidation()
        {
            _dateUtilService = new DateUtilService();
        }

        public ValidationType Validate(string word)
        {
            var regex = new Regex("[0-9]{6,8}");

            if (!regex.Match(word).Success)
                return ValidationType.Strong;

            var startIndex = regex.Match(word).Index;
            String dateWord;

            try
            {
                dateWord = word.Substring(startIndex, 8);
            }
            catch (Exception)
            {
                dateWord = word.Substring(startIndex, 6);
            }

            if (_dateUtilService.CanConvertToDate(dateWord))
                return ValidationType.Weak;

            return ValidationType.Strong;
        }
    }
}