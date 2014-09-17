using System;
using System.Collections.Generic;
using System.Threading;
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

            var wordChar = GenerateChars(length, validationType);
            var word = new String(wordChar);
            var measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word);

            if (validationType == ValidationType.Strong)
                while (measuredPasswordStrength != 100)
                {
                    wordChar = GenerateChars(length, validationType);
                    word = new String(wordChar);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word);
                }
            else if (validationType == ValidationType.Medium)
                while (measuredPasswordStrength != 50)
                {
                    wordChar = GenerateChars(length, validationType);
                    word = new String(wordChar);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word);
                }
            else if (validationType == ValidationType.Weak)
                while (measuredPasswordStrength != 20)
                {
                    wordChar = GenerateChars(length, validationType);
                    word = new String(wordChar);
                    measuredPasswordStrength = passwordValidation.MeasurePasswordStrength(word);
                }

            return word ;
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
                    new UpperCaseGenerate(),
                    new NumberGenerate()
                };

                if (validationType == ValidationType.Strong)
                    _generators.Add(new SpecialCharGenerate());

                Thread.Sleep(10);
                word[i] = _generators[random.Next(0, _generators.Count)].Generate();
            }

            return word;
        }
    }
}