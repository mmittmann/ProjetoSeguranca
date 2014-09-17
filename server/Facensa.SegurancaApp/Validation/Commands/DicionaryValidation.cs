using System;
using System.Collections.Generic;
using System.Linq;
using Facensa.SegurancaApp.Models;

namespace Facensa.SegurancaApp.Commands
{
    public class DicionaryValidation : IValidationCommand
    {
        private static IEnumerable<string> Words
        {
            get
            {
                return new[]
                {
                    "SENHAFORTE",
                    "TEIA",
                    "TETA",
                    "NATA",
                    "MATO",
                    "COIOTENEO",
                    "TINA",
                    "NENÊ",
                    "MINA",
                    "CANOMÃO",
                    "TIME",
                    "NOME",
                    "MOMO",
                    "CAMACÃO",
                    "TOCO",
                    "NUCA",
                    "MICO",
                    "COCÓLUA",
                    "TELA",
                    "NILO",
                    "MALA",
                    "CELAASA",
                    "TAÇA",
                    "NOZ",
                    "MESA",
                    "CASAFEIO",
                    "TUFÃO",
                    "NAVIO",
                    "MOFO",
                    "COIFAÁGUA",
                    "TOGA",
                    "NEGA",
                    "MAGO",
                    "CEGOPEÃO",
                    "TUBO",
                    "NABO",
                    "MAPA",
                    "COPOTOURO",
                    "NERO",
                    "MAR",
                    "COURO",
                    "LOUROLATA",
                    "SETA",
                    "FITA",
                    "GATO",
                    "PATOLONA",
                    "SINO",
                    "FONE",
                    "GINA",
                    "PIANOLAMA",
                    "SUMO",
                    "FUMO",
                    "GEMA",
                    "PUMALOUCO",
                    "SACO",
                    "FACA",
                    "GOKU",
                    "PACALULA",
                    "SALA",
                    "FILA",
                    "GALO",
                    "PELÉLIXA",
                    "XUXA",
                    "FOSSO",
                    "GESSO",
                    "PEIXELUVA",
                    "SOFÁ",
                    "FAFÁ",
                    "GIF",
                    "BIFELAGO",
                    "SAGUÃO",
                    "FOGO",
                    "GAGO",
                    "PAGÃOLOBO",
                    "SAPO",
                    "FUBÁ",
                    "GIBA",
                    "PAPASIRI",
                    "FEIRA",
                    "GAROA",
                    "PERA",
                    "TERRA"
                };
            }
        }

        public ValidationType Validate(string word)
        {
            return !Words.Contains(word.ToUpper()) ? ValidationType.Strong : ValidationType.Weak;
        }
    }
}