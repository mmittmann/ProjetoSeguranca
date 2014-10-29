using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Core.Generate.Service
{
    public interface IGenerateService
    {
        string Generate(int length, ValidationType validationType);
        string Generate(int length);
    }
}
