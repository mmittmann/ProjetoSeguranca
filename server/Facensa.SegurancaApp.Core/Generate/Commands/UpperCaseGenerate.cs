using System;

namespace Facensa.SegurancaApp.Generate.Commands
{
    public class UpperCaseGenerate : IGenerateCommand
    {
        public char Generate()
        {
            const int upperCaseAsciiInitValue = 65;
            const int upperCaseAsciiFinalValue = 90;

            var random = new Random();

            return (char)random.Next(upperCaseAsciiInitValue, upperCaseAsciiFinalValue);
        }
    }
}