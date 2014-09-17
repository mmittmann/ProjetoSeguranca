using System;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public class RepeatCharValidation : IValidationCommand
    {
        public ValidationType Validate(string word)
        {
            var repeatCharNumber = 0;

            for (var i = 1; i < word.Length; i++)
                if (word[i] == word[i - 1])
                    repeatCharNumber++;

            if(repeatCharNumber == 2)
                return ValidationType.Weak;
            if(repeatCharNumber == 1)
                return ValidationType.Medium;

            return ValidationType.Strong;
        }
    }
}