using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.ClassLib
{
    /// <summary>
    /// classe permettant de faire des opérations sur les notations romaines.
    /// On peut avoir 4 M d'affilé maximum
    ///               3 I / X / C       ex => 4 : IIII -> IV
    ///               1 V / L / D       ex => 10 : VV  -> X
    ///             
    /// Maximum affichable en respectant les règles : 4999 -> MMMM CM XC IX
    /// </summary>
    public class RomanCalculator : ICalculator
    {
        public string NombreA
        {
            get;
            private set;
        }

        public string NombreB
        {
            get;
            private set;
        }

        public void Entrer(string nombre)
        {
            if (NombreA == null)
                NombreA = nombre;
            else
                NombreB = nombre;
        }

        public string Add()
        {
            int a = RomanConverter.RomanNumberToInteger(NombreA);
            int b = RomanConverter.RomanNumberToInteger(NombreB);
            return RomanConverter.IntegerToRomanNumber(a + b);
        }
    }
}
