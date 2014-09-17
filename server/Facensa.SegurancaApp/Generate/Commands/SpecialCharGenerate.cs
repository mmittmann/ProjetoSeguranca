using System;

namespace Facensa.SegurancaApp.Generate.Commands
{
    public class SpecialCharGenerate : IGenerateCommand
    {
        public char Generate()
        {
            const int upperCaseAsciiInitValue = 33;
            const int upperCaseAsciiFinalValue = 47;

            var random = new Random();

            return (char)random.Next(upperCaseAsciiInitValue, upperCaseAsciiFinalValue);
        }
    }
}