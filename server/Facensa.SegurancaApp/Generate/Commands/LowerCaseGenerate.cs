using System;

namespace Facensa.SegurancaApp.Generate.Commands
{
    public class LowerCaseGenerate : IGenerateCommand
    {
        public char Generate()
        {
            const int upperCaseAsciiInitValue = 97;
            const int upperCaseAsciiFinalValue = 122;

            var random = new Random();

            return (char)random.Next(upperCaseAsciiInitValue, upperCaseAsciiFinalValue);
        }
    }
}