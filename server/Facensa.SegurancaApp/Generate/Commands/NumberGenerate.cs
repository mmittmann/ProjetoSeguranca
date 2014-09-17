using System;

namespace Facensa.SegurancaApp.Generate.Commands
{
    public class NumberGenerate : IGenerateCommand
    {
        public char Generate()
        {
            const int upperCaseAsciiInitValue = 48;
            const int upperCaseAsciiFinalValue = 57;

            var random = new Random();

            return (char)random.Next(upperCaseAsciiInitValue, upperCaseAsciiFinalValue);
        }
    }
}