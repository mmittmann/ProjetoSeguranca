using System;
using Facensa.SegurancaApp.Generate.Commands;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Generate.Service
{
    public class PasswordGenerateService : IGenerateService
    {
        IGenerateCommand _generateCommand;

        public PasswordGenerateService()
        {
            _generateCommand = null;
            
        }
        public string Generate(int length, ValidationType validationType)
        {
            for (var i = 0; i <= length; i++)
            {
                
            }
        }
    }
}