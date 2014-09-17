using System;
using System.Collections.Generic;
using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Generate.Commands;
using Facensa.SegurancaApp.Models;
using Facensa.SegurancaApp.Services;

namespace Facensa.SegurancaApp.Generate.Service
{
    public class PasswordGenerateService : IGenerateService
    {
        private List<IGenerateCommand> _generators; 

        public string Generate(int length, ValidationType validationType)
        {
            var passwordValidation = new PasswordValidationService();

            var word = GenerateChars(length, validationType);
            var measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word.ToString());

            if (validationType == ValidationType.Strong)
                while (measuredPasswordStrength != 100)
                {
                    word = GenerateChars(length, validationType);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word.ToString());
                }
            else if (validationType == ValidationType.Medium)
                 while (measuredPasswordStrength != 50)
                {
                    word = GenerateChars(length, validationType);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word.ToString());
                }
            else if (validationType == ValidationType.Weak)
                while (measuredPasswordStrength != 20)
                {
                    word = GenerateChars(length, validationType);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word.ToString());
                }

            return word.ToString();
        }

        private char[] GenerateChars(int length, ValidationType validationType)
        {
            var word = new char[length];
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                _generators = new List<IGenerateCommand>()
                {
                    new LowerCaseGenerate(),
                    new NumberGenerate(),
                    new NumberGenerate()
                };

                if(validationType == ValidationType.Strong)
                    _generators.Add(new SpecialCharGenerate());

                word[i] = _generators[random.Next(0, _generators.Count)].Generate();
            }

            return word;
        }
    }
}