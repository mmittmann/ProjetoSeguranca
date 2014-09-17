using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Generate.Service
{
    public interface IGenerateService
    {
        string Generate(int length, ValidationType validationType);
    }
}
